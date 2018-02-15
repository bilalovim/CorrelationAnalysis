using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace СorrelationAnalysis
{
    class ClassCalcCorrelation
    {
        private int i;
        private int n;
        private int m;
        private int r;
        private int pr;

        private List<double> ListA = new List<double>();
        private List<double> ListAr = new List<double>();
        private List<double> ListA2 = new List<double>();
        private List<double> ListAr2 = new List<double>();
        private List<double> ListAAr = new List<double>();

        private List<double> ListB = new List<double>();
        private List<double> ListBr = new List<double>();
        private List<double> ListB2 = new List<double>();
        private List<double> ListBr2 = new List<double>();
        private List<double> ListBBr = new List<double>();

        private List<double> ListAB = new List<double>();

        private StringBuilder sbResult = new StringBuilder();

        private string Dir => "Result";

        private string FileName => DateTime.Now.ToString("yyyyMMdd") + "_" + DateTime.Now.ToString("HHmmss") + ".csv";



        public ClassCalcCorrelation(int _n, int _m, int _r, int _pr)
        {
            n = _n;
            m = _m;
            r = _r;
            pr = _pr;
        }


        public void Calc(double A, double B)
        {
            i++;

            WrRType a = new WrRType(pr);
            WrRType b = new WrRType(pr);
            WrRType Rab = new WrRType(pr);
            WrRType Ra = new WrRType(pr);
            WrRType Rb = new WrRType(pr);

            a.V = A;
            ListA.Add(A);
            ListA2.Add(Math.Pow(A, 2));

            b.V = B;
            ListB.Add(B);
            ListB2.Add(Math.Pow(B, 2));

            ListAB.Add(A * B);

            if (i >= r)
            {
                double Ar = ListA[i - r];

                ListAr.Add(Ar);
                ListAr2.Add(Math.Pow(Ar, 2));
                ListAAr.Add(A * Ar);

                double Br = ListB[i - r];

                ListBr.Add(Ar);
                ListBr2.Add(Math.Pow(Br, 2));
                ListBBr.Add(B * Br);
            }

            if (i >= n)
            {
                if ((i - n) % m == 0)
                {
                    double Av_AB = GetAv(ListAB, n);
                    double Av_A = GetAv(ListA, n);
                    double Av_B = GetAv(ListB, n);
                    double G_A = Math.Sqrt(GetAv(ListA2, n) - Math.Pow(GetAv(ListA, n), 2));
                    double G_B = Math.Sqrt(GetAv(ListB2, n) - Math.Pow(GetAv(ListB, n), 2));

                    try
                    {
                        double rab = (Av_AB - Av_A * Av_B) / (G_A * G_B);
                        Rab.V = rab;
                    }
                    catch (Exception e)
                    {
                        // ignored
                    }

                    if (i >= n + r)
                    {
                        #region Вычисляем автокорреляцию Ra
                        double Av_AAr = GetAv(ListAAr, n);
                        double Av_Ar = GetAv(ListAr, n);
                        double G_Ar = Math.Sqrt(GetAv(ListAr2, n) - Math.Pow(GetAv(ListAr, n), 2));

                        try
                        {
                            double ra = (Av_AAr - Av_A * Av_Ar) / (G_A * G_Ar);
                            Ra.V = ra;
                        }
                        catch (Exception e)
                        {
                            // ignored
                        }
                        #endregion  

                        #region Вычисляем автокорреляцию Rb
                        double Av_BBr = GetAv(ListBBr, n);
                        double Av_Br = GetAv(ListBr, n);
                        double G_Br = Math.Sqrt(GetAv(ListBr2, n) - Math.Pow(GetAv(ListBr, n), 2));

                        try
                        {
                            double rb = (Av_BBr - Av_B * Av_Br) / (G_B * G_Br);
                            Rb.V = rb;
                        }
                        catch (Exception e)
                        {
                            // ignored
                        }
                        #endregion

                    }
                }
            }

            sbResult.AppendLine($"{i,-10};{a.S,-10};{b.S,-10};{Rab.S,-10};{Ra.S,-10};{Rb.S,-10}");
        }

        private double GetAv(List<double> list, int k, int d = 0)
        {
            double Av = 0;
            int iAv = 0;

            if (list.Count >= k+d)
            {
                for (int j = list.Count - 1 - d; j >= 0; j--)
                {
                    iAv++;
                    Av = Av + list[j];

                    if (iAv == k)
                    {
                        Av = Av / iAv;
                        break;
                    }
                }
            }

            return Av;
        }

        

        public string SaveResult()
        {
            if (!Directory.Exists(Dir))
            {
                Directory.CreateDirectory(Dir);
            }

            string fullfilename = Dir + "\\" + FileName;

            using (StreamWriter writer = new StreamWriter(fullfilename))
            {
                writer.WriteLine(sbResult.ToString());
            }

            return fullfilename;
        }
    }
}
