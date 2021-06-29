using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicsPackage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            // 1st Step : Panel Tools For Drawing 
            panel1.Refresh();
            var aBrush = Brushes.Black;
            var g = panel1.CreateGraphics();
            
            // 2nd Step : Inputs " anyother input is valid "
            int  x0 = 5, xEnd = -120, 
                y0 = -100, yEnd = 10;

            // 3rd Step : Calculate ΔX, ΔY
            int dx = xEnd - x0, 
                dy = yEnd - y0;

            float x = x0, y = y0;

            // 4th Step : Calculate Steps 
            int Steps = Math.Abs(dx) > Math.Abs(dy) ? Math.Abs(dx) : Math.Abs(dy);
            
            float xIncrement = (float)dx / (float)Steps;
            float yIncrement = (float)dy / (float)Steps;
            
            // Plot Output/Result Points
            /***************************************************************************************
             *************************************Note**********************************************
             (0 , 0) Point At panel plotted at left-top Corner by defautl 
             so we add ClientSize.Height or ClientSize.Width  to Result to shift (0 , 0) to the center of Panel 
             But one problem remains that the quadrants are reversed. The first quadrant is in the lower right corner, not the upper right corner
             * ***************************************************************************************/
            
            // Plot Points at the Panel 
            for (int i = 0; i < Steps; i++)
            {
                x += xIncrement;
                y += yIncrement;

                g.FillRectangle(aBrush, (int)Math.Round(x) + panel1.ClientSize.Width / 2, (int)Math.Round(y)+ panel1.ClientSize.Height / 2, 1, 1);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 1st Step : Panel Tools For Drawing
            panel1.Refresh();
            var aBrush = Brushes.Black;
            var g = panel1.CreateGraphics();

            int xEnd = 90, x0 = 20, yEnd = 80, y0 = 48;
            int dx = xEnd - x0, dy = yEnd - y0;
            int x, y, p = 2 * dy - dx;

            int twoDy = 2 * dy, twoDyMinusDx = 2 * (dy - dx);

            if (x0 > xEnd)
            {
                x = xEnd;
                y = yEnd;
                xEnd = x0;
            }
            else
            {
                x = x0;
                y = y0;
            }
            g.FillRectangle(aBrush, x+ panel1.ClientSize.Height / 2, y+ panel1.ClientSize.Height / 2, 2, 2);

            while (x < xEnd)
            {
                x++;
                if (p < 0)
                    p += twoDy;
                else
                {
                    y++;
                    p += twoDyMinusDx;
                }
                g.FillRectangle(aBrush, x+ panel1.ClientSize.Height / 2, y+ panel1.ClientSize.Height / 2, 2, 2);
            }
        } 
    }
}

