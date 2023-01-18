using System;
/* Topic: Fractals Julii Method
 * Desription: The program calculates a fractal using the Julia method 
 * in a given range and for a given complex number C. The results are then displayed on the screen.
 * 
 * Author: Patryk Wik³acz
 * Semester V 2022/2023
 * 11.01.2023
 */

namespace JuliaFractalsProject
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}