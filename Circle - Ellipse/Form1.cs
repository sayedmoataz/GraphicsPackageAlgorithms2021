using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Refresh();
            var aBrush = Brushes.Black;
            var g = panel1.CreateGraphics();

            int x_centre = 0, y_centre = 0, r = 50;
            int x = r, y = 0;

            // Printing the initial point on the
            // axes after translation
            Console.Write("(" + (x + x_centre) + ", " + (y + y_centre) + ")");
            g.FillRectangle(aBrush, x + x_centre+ panel1.ClientSize.Width / 2, y + y_centre + panel1.ClientSize.Height / 2, 2, 2);

            // When radius is zero only a single
            // point will be printed
            if (r > 0)
            {

                Console.Write("(" + (x + x_centre) + ", " + (-y + y_centre) + ")");
                g.FillRectangle(aBrush, x + x_centre + panel1.ClientSize.Width / 2, -y + y_centre + panel1.ClientSize.Height / 2, 2, 2);
                Console.Write("(" + (y + x_centre) + ", " + (x + y_centre) + ")");
                g.FillRectangle(aBrush, y + x_centre + panel1.ClientSize.Width / 2, x + y_centre + panel1.ClientSize.Height / 2, 2, 2);
                Console.WriteLine("(" + (-y + x_centre) + ", " + (x + y_centre) + ")");
                g.FillRectangle(aBrush, -y + x_centre + panel1.ClientSize.Width / 2, x + y_centre + panel1.ClientSize.Height / 2, 2, 2);
            }

            // Initialising the value of P
            int P = 1 - r;
            while (x > y)
            {

                y++;

                // Mid-point is inside or on the perimeter
                if (P <= 0)
                    P = P + 2 * y + 1;

                // Mid-point is outside the perimeter
                else
                {
                    x--;
                    P = P + 2 * y - 2 * x + 1;
                }

                // All the perimeter points have already 
                // been printed
                if (x < y)
                    break;

                // Printing the generated point and its 
                // reflection in the other octants after
                // translation
                Console.Write("(" + (x + x_centre) + ", " + (y + y_centre) + ")");
                g.FillRectangle(aBrush, x + x_centre + panel1.ClientSize.Width / 2, y + y_centre + panel1.ClientSize.Height / 2, 2, 2);
                Console.Write("(" + (-x + x_centre) + ", " + (y + y_centre) + ")");
                g.FillRectangle(aBrush, -x + x_centre + panel1.ClientSize.Width / 2, y + y_centre + panel1.ClientSize.Height / 2, 2, 2);
                Console.Write("(" + (x + x_centre) + ", " + (-y + y_centre) + ")");
                g.FillRectangle(aBrush, x + x_centre + panel1.ClientSize.Width / 2, -y + y_centre + panel1.ClientSize.Height / 2, 2, 2);
                Console.WriteLine("(" + (-x + x_centre) + ", " + (-y + y_centre) + ")");
                g.FillRectangle(aBrush, -x + x_centre + panel1.ClientSize.Width / 2, -y + y_centre + panel1.ClientSize.Height / 2, 2, 2);

                // If the generated point is on the 
                // line x = y then the perimeter points
                // have already been printed
                if (x != y)
                {
                    Console.Write("(" + (y + x_centre) + ", " + (x + y_centre) + ")");
                    g.FillRectangle(aBrush, y + x_centre + panel1.ClientSize.Width / 2, x + y_centre + panel1.ClientSize.Height / 2, 2, 2);
                    Console.Write("(" + (-y + x_centre) + ", " + (x + y_centre) + ")");
                    g.FillRectangle(aBrush, -y + x_centre + panel1.ClientSize.Width / 2, x + y_centre + panel1.ClientSize.Height / 2, 2, 2);
                    Console.Write("(" + (y + x_centre) + ", " + (-x + y_centre) + ")");
                    g.FillRectangle(aBrush, y + x_centre + panel1.ClientSize.Width / 2, -x + y_centre + panel1.ClientSize.Height / 2, 2, 2);
                    Console.WriteLine("(" + (-y + x_centre) + ", " + (-x + y_centre) + ")");
                    g.FillRectangle(aBrush, -y + x_centre + panel1.ClientSize.Width / 2, -x + y_centre + panel1.ClientSize.Height / 2, 2, 2);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Refresh();
            var aBrush = Brushes.Black;
            var g = panel1.CreateGraphics();

            float rx = 100,ry = 60, xc = 0, yc = 0;
            float dx, dy, d1, d2, x, y;
            x = 0;
            y = ry;

            // Initial decision parameter of region 1
            d1 = (ry * ry) - (rx * rx * ry) +
                            (0.25f * rx * rx);
            dx = 2 * ry * ry * x;
            dy = 2 * rx * rx * y;

            while (dx < dy)
            {

                // Print points based on 4-way symmetry
                Console.WriteLine(String.Format("{0:0.000000}", (x + xc)) + ", " + String.Format("{0:0.000000}", (y + yc)));
                g.FillRectangle(aBrush, x + xc + panel1.ClientSize.Width / 2, y + yc + panel1.ClientSize.Height / 2, 2, 2);
                Console.WriteLine(String.Format("{0:0.000000}", (-x + xc)) + ", " + String.Format("{0:0.000000}", (y + yc)));
                g.FillRectangle(aBrush, -x + xc + panel1.ClientSize.Width / 2, y + yc + panel1.ClientSize.Height / 2, 2, 2);
                Console.WriteLine(String.Format("{0:0.000000}", (x + xc)) + ", " + String.Format("{0:0.000000}", (-y + yc)));
                g.FillRectangle(aBrush, x + xc + panel1.ClientSize.Width / 2, -y + yc + panel1.ClientSize.Height / 2, 2, 2);
                Console.WriteLine(String.Format("{0:0.000000}", (-x + xc)) + ", " + String.Format("{0:0.000000}", (-y + yc)));
                g.FillRectangle(aBrush, -x + xc + panel1.ClientSize.Width / 2, -y + yc + panel1.ClientSize.Height / 2, 2, 2);

                // Checking and updating value of
                // decision parameter based on algorithm
                if (d1 < 0)
                {
                    x++;
                    dx = dx + (2 * ry * ry);
                    d1 = d1 + dx + (ry * ry);
                }
                else
                {
                    x++;
                    y--;
                    dx = dx + (2 * ry * ry);
                    dy = dy - (2 * rx * rx);
                    d1 = d1 + dx - dy + (ry * ry);
                }
            }

            // Decision parameter of region 2
            d2 = ((ry * ry) * ((x + 0.5f) * (x + 0.5f)))
                + ((rx * rx) * ((y - 1) * (y - 1)))
                - (rx * rx * ry * ry);

            // Plotting points of region 2
            while (y >= 0)
            {

                // printing points based on 4-way symmetry
                Console.WriteLine(String.Format("{0:0.000000}", (x + xc)) + ", " + String.Format("{0:0.000000}", (y + yc)));
                g.FillRectangle(aBrush, x + xc + panel1.ClientSize.Width / 2, y + yc + panel1.ClientSize.Height / 2, 2, 2);
                Console.WriteLine(String.Format("{0:0.000000}", (-x + xc)) + ", " + String.Format("{0:0.000000}", (y + yc)));
                g.FillRectangle(aBrush, -x + xc + panel1.ClientSize.Width / 2, y + yc + panel1.ClientSize.Height / 2, 2, 2);
                Console.WriteLine(String.Format("{0:0.000000}", (x + xc)) + ", " + String.Format("{0:0.000000}", (-y + yc)));
                g.FillRectangle(aBrush, x + xc + panel1.ClientSize.Width / 2, -y + yc + panel1.ClientSize.Height / 2, 2, 2);
                Console.WriteLine(String.Format("{0:0.000000}", (-x + xc)) + ", " + String.Format("{0:0.000000}", (-y + yc)));
                g.FillRectangle(aBrush, -x + xc + panel1.ClientSize.Width / 2, -y + yc + panel1.ClientSize.Height / 2, 2, 2);

                // Checking and updating parameter
                // value based on algorithm
                if (d2 > 0)
                {
                    y--;
                    dy = dy - (2 * rx * rx);
                    d2 = d2 + (rx * rx) - dy;
                }
                else
                {
                    y--;
                    x++;
                    dx = dx + (2 * ry * ry);
                    dy = dy - (2 * rx * rx);
                    d2 = d2 + dx - dy + (rx * rx);
                }
            }
            
        }
    }
}

