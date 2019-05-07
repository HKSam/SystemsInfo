using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Test
{
    public partial class LineChart : UserControl
    {
        private int m_GridStartPos = 0;
        private ArrayList aList = new ArrayList();

        public LineChart()
        {
            InitializeComponent();
            //SetStyle(ControlStyles.UserPaint, true);
            //SetStyle(ControlStyles.AllPaintingInWmPaint, true); // ��ֹ��������.
            SetStyle(ControlStyles.DoubleBuffer, true); // ˫����

            PaintMe();
        }

        private void LineChart_Paint(object sender, PaintEventArgs e)
        {
            PaintMe();
        }

        private void PaintMe()
        {
            int tWidth=this.Width;
            int tHeight=this.Height;

            Graphics g = this.CreateGraphics();
            //g.Clear(this.BackColor);
            g.FillRectangle(new SolidBrush(this.BackColor), 0, 0, tWidth, tHeight);

            //�滭�������
            int x = tWidth / m_GridSize.Width;
            int y = tHeight / m_GridSize.Height;

            Pen pGrid = new Pen(m_GridColor);
            int pos;

            for (int i = 0; i <= x; i++)
            {
                pos = tWidth - (i * m_GridSize.Width + m_GridStartPos - 1);
                g.DrawLine(pGrid, pos, 0, pos, tHeight);
            }

            for (int i = 0; i <= y; i++)
            {
                pos = i * m_GridSize.Height - 1;
                g.DrawLine(pGrid, 0, pos, tWidth, pos);
            }

            //�滭����
            int px = tWidth - m_GridMoveStep;
            int start = aList.Count - 2;
            Pen lGrid = new Pen(m_LineColor);
            while (start >= 0)
            {
                float f = (float)aList[start];
                float fPre = (float)aList[start + 1];
                int h = (int)(tHeight - (tHeight * f));
                int hPre = (int)(tHeight - (tHeight * fPre));
                g.DrawLine(lGrid, px, h, px + m_GridMoveStep, hPre);
                if (px < 0)
                {
                    break;
                }
                px -= m_GridMoveStep;
                start--;
            }

            g.Dispose();
        }

        /// <summary>
        /// ���»�������
        /// </summary>
        public void ReSet()
        {
            m_GridStartPos = 0;
            aList.Clear();
            PaintMe();
        }

        /// <summary>
        /// ����һ���ٷֱ�
        /// </summary>
        /// <param name="f">�ٷֱ�</param>
        public void Add(float f)
        {
            aList.Add(f);
            if (m_MoveGrid)
            {
                m_GridStartPos += m_GridMoveStep;
                if (m_GridStartPos >= m_GridSize.Width)
                {
                    m_GridStartPos -= m_GridSize.Width;
                }
            }
            PaintMe();
        }

        private Color m_LineColor = Color.FromArgb(0, 255, 0);
        public Color LineColor
        {
            get { return m_LineColor; }
            set { m_LineColor = value; }
        }

        private Color m_GridColor = Color.Black;
        public Color GridColor
        {
            get { return m_GridColor; }
            set { m_GridColor = value; }
        }

        private Size m_GridSize = new Size(12, 12);
        public Size GridSize
        {
            get { return m_GridSize; }
            set { m_GridSize = value; }
        }

        private int m_GridMoveStep = 3;
        public int GridMoveStep
        {
            get { return m_GridMoveStep; }
            set { m_GridMoveStep = value; }
        }

        private bool m_MoveGrid = true;
        public bool MoveGrid
        {
            get { return m_MoveGrid; }
            set { m_MoveGrid = value; }
        }

        private void LineChart_Resize(object sender, EventArgs e)
        {
            PaintMe();
        }

    }
}
