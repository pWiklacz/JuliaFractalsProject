namespace JuliaCSharp
{
    public class Julia
    {
        /*
            * Algorithm that calculates the number of iterations for a single pixel.
            * 
            * zRe - The real number of the complex number Z
            * zIm - The imaginary number of the complex number Z
            * cRe - The real number of the complex number C
            * cIm - The imaginary number of the complex number C
            * maxIter - numer of max iteration
            */
        public static int JuliiFunction(double zRe, double zIm, double cRe, double cIm, int maxIter)
        {
            int iteration = 0;

            for (int i = 0; i != maxIter; i++)
            {
                double zRe2 = zRe;
                zRe = (zRe * zRe - zIm * zIm);
                zIm = (zIm * zRe2 + zRe2 * zIm);
                zRe += cRe;
                zIm += cIm;

                double ab = ((zRe * zRe) + (zIm * zIm));
                if (ab > 4.0)
                {
                    return i;
                }
                else
                {
                    iteration++;
                }
            }
            return iteration;
        }
    }
}