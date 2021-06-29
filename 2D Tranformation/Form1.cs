using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3__TwoDTransformation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // Functions

        // called inside Scaling
        private void findNewCoordinate(int[][] s, int[][] p)
        {
            int[][] temp =
            {
                new int[] {0},
                new int[] {0}
            };

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    for (int k = 0; k < 2; k++)
                    {
                        temp[i][j] += (s[i][k] * p[k][j]);
                    }
                }
            }

            p[0][0] = temp[0][0];
            p[1][0] = temp[1][0];
        }
        
        // Scaling
        private void scale(int[] x, int[] y, int sx, int sy ,int opt)
        {
            panel1.Refresh();
            Pen p1 = new Pen(Color.FromArgb(255, 0, 0, 0));
            var g = panel1.CreateGraphics();

            // before Scaling
            g.DrawLine(p1, x[0], y[0], x[1], y[1]);
            g.DrawLine(p1, x[1], y[1], x[2], y[2]);
            g.DrawLine(p1, x[2], y[2], x[0], y[0]);

            // Scaling
            int[][] s =
            {
                new int[] { sx, 0 } ,
                new int[] { 0, sy }
            };
            int[][] p =
            {
                new int[1],
                new int[1]
            };

            // Scaling the triangle
            for (int i = 0; i < 3; i++)
            {
                p[0][0] = x[i];
                p[1][0] = y[i];

                findNewCoordinate(s, p);

                x[i] = p[0][0];
                y[i] = p[1][0];
            }

            if (opt == 1)
            {
                // after Reflecttion
                g.DrawLine(p1, x[0] + panel1.ClientSize.Width, y[0] + panel1.ClientSize.Height, x[1] + panel1.ClientSize.Width, y[1] + panel1.ClientSize.Height);
                g.DrawLine(p1, x[1] + panel1.ClientSize.Width, y[1] + panel1.ClientSize.Height, x[2] + panel1.ClientSize.Width, y[2] + panel1.ClientSize.Height);
                g.DrawLine(p1, x[2] + panel1.ClientSize.Width, y[2] + panel1.ClientSize.Height, x[0] + panel1.ClientSize.Width, y[0] + panel1.ClientSize.Height);
            }
            else
            {
                // after Scaling
                g.DrawLine(p1, x[0], y[0], x[1], y[1]);
                g.DrawLine(p1, x[1], y[1], x[2], y[2]);
                g.DrawLine(p1, x[2], y[2], x[0], y[0]);
            }
            


        }

        //Rotation
        private void rotate(double[][] a, int n, int x_pivot, int y_pivot, double angle)
        {
            Pen p1 = new Pen(Color.FromArgb(255, 0, 0, 0));
            var g = panel1.CreateGraphics();

            double pi = 3.141592653589;
            int i = 0;
            while (i < n)
            {
                // Shifting and the given points accordingly
                int x_shifted = (int)a[i][0] - x_pivot;
                int y_shifted = (int)a[i][1] - y_pivot;

                // Calculating the rotated point co-ordinates
                // and shifting it back
                a[i][0] = x_pivot + (x_shifted * Math.Cos((angle * pi) / 180)) - y_shifted * Math.Sin((angle * pi) / 180);
                a[i][1] = y_pivot + (x_shifted * Math.Sin((angle * pi) / 180) + y_shifted * Math.Cos((angle * pi) / 180));

                g.DrawLine(p1, (float)a[i][0], (float)a[i][1], (float)a[i][0], (float)a[i][1]);
                i++;
            }
            g.DrawLine(p1, (float)a[0][0], (float)a[0][1], (float)a[1][0], (float)a[1][1]);
        }

                
        // Events

        // Transition  // Add "for loop" for multi points
        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Refresh();
            var aBrush = Brushes.Black;
            var bBrush = Brushes.Red;
            var g = panel1.CreateGraphics();

            int[] Point = new int[] { 50, 80 };
            int[] TranstionFactor = new int[] { 200, 100 };

            int[] NewPoint = new int[] { Point[0] + TranstionFactor[0], Point[1] + TranstionFactor[1] };


            g.FillRectangle(aBrush, Point[0], Point[1], 8, 8);

            g.FillRectangle(bBrush, NewPoint[0], NewPoint[1], 8, 8);

        }

        // scaling
        private void button2_Click(object sender, EventArgs e)
        {
            int[] x = { 50, 100, 150 };
            int[] y = { 100, 50, 100 };
            int sx = 2;
            int sy = 2;
            scale(x, y, sx, sy,0);
        }

        //rotation
        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Refresh();
            Pen p1 = new Pen(Color.FromArgb(255, 0, 0, 0));
            var g = panel1.CreateGraphics();

            int size1 = 4;
            double[][] points_list1 =
            {
                new double[] {50, 50},
                new double[] {75, 100},
                new double[] {100, 100},
                new double[] {100, 75}
            };
            g.DrawLine(p1, (float)points_list1[0][0], (float)points_list1[0][1], (float)points_list1[1][0], (float)points_list1[1][1]);

            rotate(points_list1, size1, 100, 100, 90);
        }

        //reflection
        private void button4_Click(object sender, EventArgs e)
        {
            int[] x = { 50, 100, 150 };
            int[] y = { 100, 50, 100 };
            int sx = -1;
            int sy = -1;
            scale(x, y, sx, sy ,1);

        }

        //Shearing
        private void button5_Click(object sender, EventArgs e)
        {
            panel1.Refresh();
            Pen p1 = new Pen(Color.FromArgb(255, 0, 0, 0));
            var g = panel1.CreateGraphics();

            // points
            int[] x = { 100, 100, 200, 200 };
            int[] y = { 100, 200, 100, 200 };

            // before Scaling
            g.DrawLine(p1, x[0], y[0], x[1], y[1]);
            g.DrawLine(p1, x[1], y[1], x[3], y[3]);
            g.DrawLine(p1, x[2], y[2], x[0], y[0]);
            g.DrawLine(p1, x[2], y[2], x[3], y[3]);

            // sharing factor
            int shx = 2, shy = 2;

            // new points
            int[] dx = new int[4];
            int[] dy = new int[4];
            
            if (true)
            {
                // Shearing along x - axis
                for (int i = 0; i < 4; i++)
                {
                    dx[i] = x[i] + y[i] * shy;
                    dy[i] = y[i];
                }
                g.DrawLine(p1, dx[0], dy[0], dx[1], dy[1]);
                g.DrawLine(p1, dx[1], dy[1], dx[3], dy[3]);
                g.DrawLine(p1, dx[2], dy[2], dx[0], dy[0]);
                g.DrawLine(p1, dx[2], dy[2], dx[3], dy[3]);
            }
            else
            {
                // Shearing along y-axis
                for (int i = 0; i < 4; i++)
                {
                    dx[i] = x[i];
                    dy[i] = shy * x[i] + y[i];
                }
                g.DrawLine(p1, dx[0], dy[0], dx[1], dy[1]);
                g.DrawLine(p1, dx[1], dy[1], dx[3], dy[3]);
                g.DrawLine(p1, dx[2], dy[2], dx[0], dy[0]);
                g.DrawLine(p1, dx[2], dy[2], dx[3], dy[3]);
            }
        }
    }
}