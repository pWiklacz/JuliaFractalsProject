/* Topic: Fractals Julii Method
 * Desription: The program calculates a fractal using the Julia method 
 * in a given range and for a given complex number C. The results are then displayed on the screen.
 * 
 * Author: Patryk Wik³acz
 * Semester V 2022/2023
 * 11.01.2023
 */


using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection.Emit;
using System.Threading;
using System.Windows.Forms;

namespace JuliaFractalsProject
{
    /*
     * The class responsible for the GUI
     */
    public partial class Form1 : Form
    {
        /*
         * Constructor for class Form1
         */
        public Form1()
        {
            InitializeComponent();
            myInitCompontents();
        }

        /*
         * Method that reads the value of the slider
         */
        private void TrackBar1_ValueChanged(object sender, EventArgs e)
        {
            numOfTreadsLabel.Text = threadSilder.Value.ToString();
        }

        /*
         * Method called when the Generate button is pressed
         */
        private void Button1_Click(object sender, EventArgs e)
        {
            if (CheckTextBoxes())
            {
                int maxIter = ReadMaxIterValue();
                int threadNumber = threadSilder.Value;
                JuliaFractals julia = new JuliaFractals(Double.Parse(textMaxRe.Text), Double.Parse(textMaxIm.Text), Double.Parse(textMinRe.Text),
                    Double.Parse(textMinIm.Text), Double.Parse(textCRe.Text), Double.Parse(textCIm.Text), maxIter);
                Bitmap bufor = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                using (Graphics g = pictureBox1.CreateGraphics())
                {
                    julia.RunJulia(bufor, g, threadNumber, radioButtonCSharp.Checked);
                }
                stopwatch.Stop();
                TimeSpan ts = stopwatch.Elapsed;

                label12.Text = ts.TotalMilliseconds.ToString();
            }
            else
            {
                MessageBox.Show("Incorrect data was given! Floating point numbers are required!");
            }
        }

        /*
         * Method that checks the radioButtons responsible for the maximum number of iterations
         */
        private int ReadMaxIterValue()
        {
            if (maxIter100.Checked == true)
                return 100;
            if (maxIter255.Checked == true)
                return 255;
            if (maxIter1000.Checked == true)
                return 1000;
            if (maxIter5000.Checked == true)
                return 5000;
            if (maxIter10000.Checked == true)
                return 10000;
            else return 1000;
        }

        /*
         * Method called when the Reset button is pressed
         */
        private void ResetButton_Click(object sender, EventArgs e)
        {
            this.textMinIm.Text = "-1.25";
            this.textMaxIm.Text = "1.25";
            this.textMaxRe.Text = "1.5";
            this.textMinRe.Text = "-1.5";
            this.textCIm.Text = "0.65";
            this.textCRe.Text = "-0.10";
            this.maxIter1000.Checked = true;
            ThreadPool.GetMinThreads(out int workerThreads, out _);
            this.numOfTreadsLabel.Text = workerThreads.ToString();
            this.threadSilder.Value = workerThreads;
        }

        /*
         * A method that checks the correctness of the data entered.
         */
        private bool CheckTextBoxes()
        {
            if (double.TryParse(textMinRe.Text, out _)
                && double.TryParse(textMinIm.Text, out _)
                && double.TryParse(textMaxRe.Text, out _)
                && double.TryParse(textMaxIm.Text, out _)
                && double.TryParse(textCRe.Text, out _)
                && double.TryParse(textCRe.Text, out _))
            {
                return true;
            }
            else return false;
        }

        /*
        * Method called when the Test button is pressed
        */
        private void testButton_Click(object sender, EventArgs e)
        {
            if (CheckTextBoxes())
            {
                string[] cSharpTests = new string[8];
                string[] asmTests = new string[8];
                bool ddl;
                int maxIter = ReadMaxIterValue();
                JuliaFractals julia = new JuliaFractals(Double.Parse(textMaxRe.Text), Double.Parse(textMaxIm.Text), Double.Parse(textMinRe.Text),
                    Double.Parse(textMinIm.Text), Double.Parse(textCRe.Text), Double.Parse(textCIm.Text), maxIter);
                Bitmap bufor = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                for (int j = 0; j < 2; j++)
                {
                    if (j == 0)
                        ddl = true;
                    else ddl = false;
                    int index = 0;
                    for (int i = 1; i <= 64; i++)
                    {
                        if ((i > 0) && (((i & (i - 1)) == 0) || i == 12))
                        {
                            Stopwatch stopwatch = new Stopwatch();
                            stopwatch.Start();
                            using (Graphics g = pictureBox1.CreateGraphics())
                            {
                                julia.RunJulia(bufor, g, i, ddl);
                            }
                            stopwatch.Stop();
                            TimeSpan ts = stopwatch.Elapsed;
                            if (j == 0)
                                cSharpTests[index] = ts.TotalMilliseconds.ToString();
                            else asmTests[index] = ts.TotalMilliseconds.ToString();
                            index++;
                        }
                    }
                }
                SaveTest(cSharpTests, asmTests);
                DisplayTest(cSharpTests, asmTests);
            }
            else
            {
                MessageBox.Show("Incorrect data was given! Floating point numbers are required!");
            }
        }

        /*
         * A method that saves the test result to a text file and displays it on the screen.
         */
        private void SaveTest(string[] tests, string[] tests2)
        {
            string filename;
            filename = "cSharpTest.txt";
            using (StreamWriter sw = new StreamWriter(filename))
            {
                for (int i = 0; i < tests.Length; i++)
                {
                    sw.WriteLine(tests[i]);
                }
                sw.WriteLine("MaxIter : " + ReadMaxIterValue().ToString());
            }
            filename = "asmTest.txt";
            using (StreamWriter sw = new StreamWriter(filename))
            {
                for (int i = 0; i < tests2.Length; i++)
                {
                    sw.WriteLine(tests2[i]);
                }
                sw.WriteLine("MaxIter : " + ReadMaxIterValue().ToString());
            }
        }

        private void DisplayTest(string[] tests, string[] tests2)
        {
            int index = 0;
            label10.Text = "Threads\n";
            label12.Text = "C#\n";
            label13.Text = "ASM\n";
            for (int i = 1; i <= 64; i++)
            {
                if ((i > 0) && (((i & (i - 1)) == 0) || i == 12))
                {
                    label10.Text += $"{i}\n";
                    label12.Text += $"{tests[index]}\n";
                    label13.Text += $"{tests2[index]}\n";
                    index++;
                }
            }
        }
    }
}
