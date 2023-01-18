/* Topic: Fractals Julii Method
 * Desription: The program calculates a fractal using the Julia method 
 * in a given range and for a given complex number C. The results are then displayed on the screen.
 * 
 * Author: Patryk Wikłacz
 * Semester V 2022/2023
 * 11.01.2023
 */

using JuliaCSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Threading.Tasks;


namespace JuliaFractalsProject
{
    /*
    The class responsible for the entire algorithm
    */
    internal class JuliaFractals
    {
        // Import a library with a function in asm
        [DllImport(@"C:\Users\wikla\source\repos\JuliaFractals\JuliaFractals\x64\Debug\JuliaASM.dll")]
        private static extern void JuliiFunctionASM(IntPtr ptr, double[] zIm, double cRe, double cIm, int maxIter, double[] zRe);

        /*
         * Variable storing the maximum number of iterations for the algorithm
         */
        public int MaxIterations { get; set; }
        /*
         * Variable storing a composite number specifying a point on the composite axis
         */
        public Complex Max { get; set; }
        /*
         * Variable storing a composite number specifying a point on the composite axis
         */
        public Complex Min { get; set; }

        /*
         * Variable storing a composite number specifying a point on the composite axis
         */
        public Complex C { get; set; }

        /*
         * Constructor for Julia class
         */
        public JuliaFractals(double maxRe, double maxIm, double minRe, double minIm, double cRe, double cIm, int maxIter)
        {
            Max = new Complex(maxRe, maxIm);
            Min = new Complex(minRe, minIm);
            C = new Complex(cRe, cIm);
            MaxIterations = maxIter;
        }

        /*
         * Method responsible for determining the number of available threads, 
         * running the algorithm depending on the selected library 
         * and displaying the result on the screen.
         * 
         * buffer - bitmap object
         * g - graphics object
         * numThreads - number of threads
         * cSharpLib - dll choice
         */
        public void RunJulia(Bitmap buffer, Graphics g, int numThreads, bool cSharpLib)
        {
            int chunkSize = buffer.Height / numThreads;
            List<Bitmap> bitmapChunks = new();
            for (int i = 0; i < numThreads; i++)
            {
                int startY = i * chunkSize;
                int endY = (i + 1) * chunkSize;
                Bitmap chunk = buffer.Clone(new Rectangle(0, startY, buffer.Width, endY - startY), buffer.PixelFormat);
                bitmapChunks.Add(chunk);
            }
            Task[] tasks = new Task[numThreads];
            for (int i = 0; i != numThreads; i++)
            {
                int index = i;
                Bitmap chunk = bitmapChunks[i];
                int height = buffer.Height;
                tasks[i] = Task.Run(() =>
                {
                    if (cSharpLib == true)
                    {
                        for (int x = 0; x != chunk.Width; x++)
                            for (int y = 0; y != chunk.Height; y++)
                            {
                                double zRe = (x * (Max.Real - Min.Real) / chunk.Width) + Min.Real;
                                double zIm = ((y + (index * chunk.Height)) * (Max.Imaginary - Min.Imaginary) / height) + Min.Imaginary;
                                chunk.SetPixel(x, y, SetColor(Julia.JuliiFunction(zRe, zIm, C.Real, C.Imaginary, MaxIterations)));
                            }
                    }
                    else
                    {
                        int c = 4;
                        for (int x = 0; x != chunk.Width; x++)
                            for (int y = 0; y != chunk.Height; y += c)
                            {
                                if (y + c > chunk.Height)
                                    c = chunk.Height - y;
                                else c = 4;
                                double[] zRe = new double[c];
                                double[] zIm = new double[c];
                                int[] result = new int[c];
                                for (int z = 0; z != c; z++)
                                {
                                    zRe[z] = (x * (Max.Real - Min.Real) / chunk.Width) + Min.Real;
                                    zIm[z] = ((y + z + (index * chunk.Height)) * (Max.Imaginary - Min.Imaginary) / height) + Min.Imaginary;
                                    result[z] = 0;
                                }

                                GCHandle handle = GCHandle.Alloc(result, GCHandleType.Pinned);
                                IntPtr ptr = handle.AddrOfPinnedObject();
                                JuliiFunctionASM(ptr, zIm, C.Real, C.Imaginary, MaxIterations, zRe);
                                handle.Free();

                                for (int z = 0; z != c; z++)
                                {
                                    int yy = y + z;
                                    chunk.SetPixel(x, yy, SetColor(result[z]));
                                }
                            }
                    }
                });
            }
            Task.WaitAll(tasks);
            for (int i = 0; i < numThreads; i++)
            {
                Bitmap chunk = bitmapChunks[i];
                g.DrawImage(chunk, 0, chunk.Height * i);
            }
        }

        /*
         * Method that returns the color for a pixel depending on the number of iterations for that pixel.
         * 
         * value - number of iteration
         */
        Color SetColor(int value)
        {
            Color color = Color.FromArgb(0, 0, 0);

            if (value != MaxIterations)
            {
                int colorNr = value % 16;

                switch (colorNr)
                {
                    case 0:
                        {
                            color = Color.FromArgb(60, 30, 15);
                            break;
                        }
                    case 1:
                        {
                            color = Color.FromArgb(25, 7, 26);
                            break;
                        }
                    case 2:
                        {
                            color = Color.FromArgb(9, 1, 47);
                            break;
                        }
                    case 3:
                        {
                            color = Color.FromArgb(4, 4, 73);
                            break;
                        }
                    case 4:
                        {
                            color = Color.FromArgb(0, 7, 100);
                            break;
                        }
                    case 5:
                        {
                            color = Color.FromArgb(12, 44, 138);
                            break;
                        }
                    case 6:
                        {
                            color = Color.FromArgb(24, 82, 177);
                            break;
                        }
                    case 7:
                        {
                            color = Color.FromArgb(57, 125, 209);
                            break;
                        }
                    case 8:
                        {
                            color = Color.FromArgb(134, 181, 229);
                            break;
                        }
                    case 9:
                        {
                            color = Color.FromArgb(211, 236, 248);
                            break;
                        }
                    case 10:
                        {
                            color = Color.FromArgb(241, 233, 191);
                            break;
                        }
                    case 11:
                        {
                            color = Color.FromArgb(248, 201, 95);
                            break;
                        }
                    case 12:
                        {
                            color = Color.FromArgb(255, 170, 0);
                            break;
                        }
                    case 13:
                        {
                            color = Color.FromArgb(204, 128, 0);
                            break;
                        }
                    case 14:
                        {
                            color = Color.FromArgb(153, 87, 0);
                            break;
                        }
                    case 15:
                        {
                            color = Color.FromArgb(106, 52, 0);
                            break;
                        }
                }
            }
            return color;
        }
    }
}

