using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace СorrelationAnalysis
{
    class ClassCalcCorrelation
    {
        private int i;
        private int n;
        private int m;
        private int r;
        private int pr;

        private RdRType Amin;
        private RdRType Amax;

        private RdRType Bmin;
        private RdRType Bmax;

        private List<double> ListA = new List<double>();
        private List<double> ListAr = new List<double>();
        private List<double> ListAAr = new List<double>();

        private List<double> ListB = new List<double>();
        private List<double> ListBr = new List<double>();
        private List<double> ListBBr = new List<double>();

        private List<double> ListAB = new List<double>();

        private StringBuilder sbResult = new StringBuilder();

        private string Dir => "Result";

        private string FileName => DateTime.Now.ToString("yyyyMMdd") + "_" + DateTime.Now.ToString("HHmmss") + ".csv";

        private enum LevelEnum
        {
            Low,
            High,
            Ok
        }

        private string[] sLevels = new[] {"L", "H", ""};

        public ClassCalcCorrelation(int _n, int _m, int _r, int _pr, RdRType _Amin, RdRType _Amax, RdRType _Bmin, RdRType _Bmax)
        {
            n = _n;
            m = _m;
            r = _r;
            pr = _pr;

            Amin = _Amin;
            Amax = _Amax;
            Bmin = _Bmin;
            Bmax = _Bmax;
        }

        public void Calc(double A, double B)
        {
            i++;

            WrRType a = new WrRType(pr);
            string a_level;
            
            WrRType b = new WrRType(pr);
            string b_level = String.Empty;

            WrRType Rab = new WrRType(pr);
            WrRType Ra = new WrRType(pr);
            WrRType Rb = new WrRType(pr);

            #region SingA
            a.V = A;
            
            if (Amin.Ok && a.V < Amin.V)
                a_level = sLevels[(int) LevelEnum.Low];
            else if (Amax.Ok && a.V > Amax.V)
                a_level = sLevels[(int)LevelEnum.High];
            else
                a_level = sLevels[(int)LevelEnum.Ok];

            ListA.Add(A);
            #endregion      

            #region SingB
            b.V = B;

            if (Bmin.Ok && b.V < Bmin.V)
                b_level = sLevels[(int)LevelEnum.Low];
            else if (Bmax.Ok && b.V > Bmax.V)
                b_level = sLevels[(int)LevelEnum.High];
            else
                b_level = sLevels[(int)LevelEnum.Ok];

            ListB.Add(B);
            #endregion      

            ListAB.Add(A * B);

            if (i >= r + 1)
            {
                double Ar = ListA[i - r - 1];

                ListAr.Add(Ar);
                ListAAr.Add(A * Ar);

                double Br = ListB[i - r - 1];

                ListBr.Add(Br);
                ListBBr.Add(B * Br);
            }

            if (i >= n)
            {
                if ((i - n) % m == 0)
                {
                    double Av_AB = GetAv(ListAB, n);
                    double Av_A = GetAv(ListA, n);
                    double Av_B = GetAv(ListB, n);

                    double G_A = GetSigma(ListA, n);
                    double G_B = GetSigma(ListB, n);

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
                        double G_Ar = GetSigma(ListAr, n);
                        
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
                        double G_Br = GetSigma(ListBr, n);

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

            sbResult.AppendLine($"{i,-10};{a.S,-10};{a_level,-10};{b.S,-10};{b_level,-10};{Rab.S,-10};{Ra.S,-10};{Rb.S,-10}");
        }

        private double GetAv(List<double> list, int k)
        {
            double Av = 0;
            int ik = 0;

            if (list.Count >= k)
            {
                for (int j = list.Count - 1; j >= 0; j--)
                {
                    ik++;
                    Av = Av + list[j];

                    if (ik == k)
                    {
                        Av = Av / ik;
                        break;
                    }
                }
            }

            return Av;
        }

        private double GetSigma(List<double> list, int k)
        {
            double sigma = 0.0;

            if (list.Count >= k)
            {
                double av = GetAv(list, k);
                int ik = 0;

                for (int j = list.Count - 1; j >= 0; j--)
                {
                    ik++;
                    sigma = sigma + Math.Pow((list[j] - av), 2);

                    if (ik == k)
                    {
                        sigma = Math.Sqrt(sigma / ik);
                        break;
                    }
                }
            }

            return sigma;
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
