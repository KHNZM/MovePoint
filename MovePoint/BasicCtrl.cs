using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovePoint
{
    public partial class MainForm : Form
    {
        private int nPos1 = 0;

        private int nPos2 = 0;

        private bool bRight = true;

        private bool bUp = true;

        MovePoint1 mp1 = new MovePoint1();

        MovePoint2 mp2 = new MovePoint2();

        private static Brush brush1 = Brushes.Blue;

        public Brush PropBrush1
        {
            set { brush1 = value; }
            get { return brush1; }
        }

        private static Brush brush2 = Brushes.Red;

        public Brush PropBrush2
        {
            set { brush2 = value; }
            get { return brush2; }
        }

        private bool bColorChanged = false;

        public MainForm()
        {
            InitializeComponent();
        }
        

        private void timer_Tick(object sender, EventArgs e)
        {
            if      (nPos1 == 0)
                bRight = true;
            else if (nPos1 == 464)
                bRight = false;

            if (bRight)
                nPos1 += 2;
            else
                nPos1 -= 2;

            if      (nPos2 == 0)
                bUp = true;
            else if (nPos2 == 300)
                bUp = false;

            if (bUp)
                nPos2 += 2;
            else
                nPos2 -= 2;

            mp1.Location = new Point(nPos1, 100);
            mp1.Size = new Size(20, 10);
            Controls.Add(mp1);

            mp2.Location = new Point(nPos1, nPos2);
            mp2.Size = new Size(20, 20);
            Controls.Add(mp2);

            if (nPos2 == 100 && !bColorChanged)
            {
                bColorChanged = true;
                brush1 = Brushes.Yellow;
                brush2 = Brushes.Yellow;
            }
            else if (nPos2 == 100 && bColorChanged)
            {
                bColorChanged = false;
                brush1 = Brushes.Blue;
                brush2 = Brushes.Red;
            }
        }
    }
    class MovePoint1 : UserControl
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            MainForm mf = new MainForm();
            Graphics graphics = e.Graphics;
            // Draw the button in the form of a circle
            graphics.FillEllipse(mf.PropBrush1, 5, 0, 10, 10);
        }
    }
    class MovePoint2 : UserControl
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            MainForm mf = new MainForm();
            Graphics graphics = e.Graphics;
            // Draw the button in the form of a circle
            graphics.FillEllipse(mf.PropBrush2, 5, 5, 10, 10);
        }
    }
}
