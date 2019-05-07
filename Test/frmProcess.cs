using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Diagnostics;
using Sam.SystemInfo;
using System.Runtime.InteropServices;


namespace Test
{
    public partial class frmProcess : Form
    {
        SystemInfo sInfo; //系统信息类
        DateTime lastSysTime; //最后刷新时间, 用于计算进程 CPU 利用率

        public frmProcess()
        {
            InitializeComponent();
        }

        private void mnuFile_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmProcess_Load(object sender, EventArgs e)
        {
            TabMain.SelectedIndex = 2;

            sInfo = new SystemInfo();
            tmrProcess_Tick(tmrProcess, new EventArgs());
            tmrSysInfo_Tick(tmrSysInfo, new EventArgs());
            btReApp_Click(btReApp, new EventArgs());

            List<DiskInfo> dInfo = sInfo.GetLogicalDrives();
            for (int i = 0; i < dInfo.Count; i++)
            {
                ListViewItem item = new ListViewItem(dInfo[i].DiskName);
                item.SubItems.Add(dInfo[i].Size.ToString());
                item.SubItems.Add(dInfo[i].FreeSpace.ToString());
                lvDisk.Items.Add(item);
            }
        }        

        #region tmrProcess_Tick
        private void tmrProcess_Tick(object sender, EventArgs e)
        {
            int oldWorkingSet = 0;  //记录进程旧的内存大小
            int oldTimePercent = 0;  //记录进程旧的CPU百分比
            int newTimePercent = 0;
            int lvProcessCount = lvProcess.Items.Count;
            TimeSpan ts = (TimeSpan)(DateTime.Now - lastSysTime);
            double sysTimeSpan = ts.TotalMilliseconds;
            Hashtable htProcess = new Hashtable();  //进程哈希表

            List<ProcessInfo> pInfo = sInfo.GetProcessInfo();
            for (int i = 0; i < pInfo.Count; i++)
            {
                htProcess.Add(pInfo[i].ProcessID.ToString(), pInfo[i].ProcessID);
                ListViewItem item = lvProcessCount > 0 ? lvProcess.FindItemWithText(pInfo[i].ProcessID.ToString(), false, 0, false) : null;
                if (item != null)   //找到节点则更新
                {
                    #region 计算cpu占用率
                    double processorTimeSpan = (double)Math.Abs(pInfo[i].ProcessorTime - (double)item.Tag);
                    if (sysTimeSpan != 0)
                    {
                        processorTimeSpan = processorTimeSpan / sysTimeSpan;
                        newTimePercent = (int)(processorTimeSpan * 100 / sInfo.ProcessorCount);
                        //if (newTimePercent > 100 || newTimePercent < 0)
                        //{
                        //    newTimePercent = 0;
                        //}
                        if (newTimePercent == 100)
                        {
                            newTimePercent = 99;
                        }
                    }
                    else
                    {
                        newTimePercent = 0;
                    }
                    #endregion
                    //缓冲，没有改变的数值不更新，避免界面闪烁
                    oldTimePercent = int.Parse(item.SubItems[2].Text);
                    if (newTimePercent != oldTimePercent)
                    {
                        item.SubItems[2].Text = string.Format("{0:00}", newTimePercent);
                    }
                    oldWorkingSet = int.Parse(item.SubItems[3].Text);
                    if (pInfo[i].WorkingSet != oldWorkingSet)
                    {
                        item.SubItems[3].Text = pInfo[i].WorkingSet.ToString();
                    }
                    item.Tag = pInfo[i].ProcessorTime;
                }
                else //否则添加节点
                {
                    item = new ListViewItem(pInfo[i].ProcessID.ToString());
                    item.SubItems.Add(pInfo[i].ProcessName);
                    item.SubItems.Add(string.Format("{0:00}", 0));
                    item.SubItems.Add(pInfo[i].WorkingSet.ToString());
                    item.SubItems.Add(pInfo[i].ProcessPath);
                    item.Tag = pInfo[i].ProcessorTime;
                    lvProcess.Items.Add(item); //add
                }
            }

            #region 删除过时的进程
            //删除过时的进程
            if (lvProcess.Items.Count != htProcess.Count)
            {
                foreach (ListViewItem item in lvProcess.Items)
                {
                    if (!htProcess.ContainsKey(item.Text))
                    {
                        lvProcess.Items.Remove(item);
                    }
                }
            }
            #endregion

            #region 刷新网络信息
            //获取本机 ip 
            string IPAddress = "";
            System.Net.IPHostEntry oIPHost = System.Net.Dns.GetHostByName(Environment.MachineName);
            if (oIPHost.AddressList.Length > 0)
            {
                IPAddress = oIPHost.AddressList[0].ToString();
            }

            //刷新网络信息
            NetInfo nInfo = SystemInfo.GetNetInfoByIp(IPAddress);
            lstNet.Items.Clear();
            lstNet.Items.Add("名称 - " + nInfo.Name);
            lstNet.Items.Add("类型 - " + nInfo.Type.ToString());
            lstNet.Items.Add("状态 - " + nInfo.Status.ToString());
            lstNet.Items.Add("速度 - " + nInfo.Speed.ToString());
            lstNet.Items.Add("总接收 - " + nInfo.InOctets.ToString());
            lstNet.Items.Add("总发送 - " + nInfo.OutOctets.ToString());
            lstNet.Items.Add("物理地址 - " + nInfo.PhysAddr); 
            #endregion

            //更新最后刷新时间
            lastSysTime = DateTime.Now;
            //刷新状态栏
            Status1_Process.Text = string.Format("进程数: {0}", htProcess.Count);
        } 
        #endregion

        #region btEndProcess_Click
        private void btEndProcess_Click(object sender, EventArgs e)
        {
            if (lvProcess.SelectedItems.Count > 0)
            {
                ListViewItem item = lvProcess.SelectedItems[0];
                int pid = int.Parse(item.Text);
                string pName = item.SubItems[1].Text;
                //MessageBox.Show (String, String, MessageBoxButtons, MessageBoxIcon) 
                DialogResult dr = MessageBox.Show(string.Format("确定要结束进程 {0} 吗？", pName),
                    "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dr == DialogResult.OK)
                {
                    SystemInfo.EndProcess(pid);
                }
            }
        } 
        #endregion

        private void tmrSysInfo_Tick(object sender, EventArgs e)
        {
            //刷新cpu, 内存信息
            float cpuLoad = sInfo.CpuLoad;
            Status1_Cpu.Text = string.Format("CPU 使用: {0:f}%", cpuLoad);
            long pMemory = sInfo.PhysicalMemory;
            long aMemory = sInfo.MemoryAvailable;
            long lMemory = pMemory - aMemory;
            Status1_Memory.Text = string.Format("内存使用: {0}/{1} Bytes", lMemory, pMemory);

            lcCpu.Add(cpuLoad / 100F);
        }

        private void mnuFile_New_Click(object sender, EventArgs e)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = "rundll32.exe";
            proc.StartInfo.Arguments = "shell32.dll #61";
            proc.Start();  

        }

   
        private void btReApp_Click(object sender, EventArgs e)
        {
            LvApp.Items.Clear();
            List<string> Apps = SystemInfo.FindAllApps(this.Handle.ToInt32());
            foreach (string app in Apps)
            {
                ListViewItem item = new ListViewItem(app);
                LvApp.Items.Add(item);
            }
        }

       
    }
}