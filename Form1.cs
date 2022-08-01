using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        Graphics graphics;
        Boolean cursorMoving = false;
        Pen cursorpen;
        int cursorX = -1;
        int cursorY = -1;

        public Form1()
        {
            InitializeComponent();
            graphics =canvas.CreateGraphics();
            cursorpen = new Pen(Color.Black, 7);
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            cursorpen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            cursorpen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            cursorMoving = true;
            cursorX = e.X;
            cursorY = e.Y;
        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            cursorMoving = false;
            cursorX = -1;
            cursorY = -1;
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if(cursorX != -1 && cursorY != -1 && cursorMoving==true)
            {
                graphics.DrawLine(cursorpen, new Point(cursorX, cursorY), e.Location);
                cursorX = e.X;
                cursorY = e.Y;
                listBox1.Items.Add( cursorX + ","+ cursorY);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            if(dlg.ShowDialog()== DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(dlg.FileName);
                for (int i = 0; i < listBox1.Items.Count;i++)
                {
                    writer.WriteLine((string)listBox1.Items[i]);
                }
                writer.Close();
            }
            dlg.Dispose();
            MessageBox.Show("Programs saved!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string zee1, zee2, zee3, zee4;

            double scordx, scordy, ecordx, ecordy;

            int m1, n1, m2, n2;

            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                using (StreamReader Reader = new StreamReader(openFileDialog1.FileName, true))
                {

                    foreach (string a in File.ReadAllLines(openFileDialog1.FileName))
                    {
                        zee1 = Reader.ReadLine();
                        scordx = Convert.ToDouble(zee1);
                        scordx = Math.Round(scordx);
                        m1 = Convert.ToInt32(scordx);

                        zee2 = Reader.ReadLine();
                        scordy = Convert.ToDouble(zee2);
                        scordy = Math.Round(scordy);
                        n1 = Convert.ToInt32(scordy);

                        zee3 = Reader.ReadLine();
                        ecordx = Convert.ToDouble(zee3);
                        ecordx = Math.Round(ecordx);
                        m2 = Convert.ToInt32(ecordx);

                        zee4 = Reader.ReadLine();
                        ecordy = Convert.ToDouble(zee4);
                        ecordy = Math.Round(ecordy);
                        n2 = Convert.ToInt32(ecordy);
                        Graphics formGraphics = this.CreateGraphics();
                        graphics.DrawLine(cursorpen, m1, n1, m2, n2);
                       
                    }
                    //cursorpen.Dispose();
                    //graphics.Dispose();





                }
                   
                }
            }

        private void button3_Click(object sender, EventArgs e)
        {
            graphics.Clear(Color.White);
        }
    }
    }

