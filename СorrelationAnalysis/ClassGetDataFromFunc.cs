using System;
using System.Security.Permissions;

namespace СorrelationAnalysis
{
    class ClassGetDataFromFunc:IGetData
    {
        private double M { get; set; }
        private double D { get; set; }
        private int n;
        private double b;

        private int i;

        private double MIN;
        private double MAX;

        public ClassGetDataFromFunc(double _M, double _D, int _n, double _b)
        {
            M = _M;
            D = _D;
            n = _n;
            b = _b;

            i = 0;
        }

        public double GetValue()
        {
            i++;

            if (n != 0 && i >= n)
                M = M + b;

            MIN = M - D;
            MAX = M + D;

            Random random = new Random((int)DateTime.Now.Ticks);
            return random.NextDouble() * (MIN - MAX) + MIN;
        }
    }
}