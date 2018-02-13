using System;

namespace СorrelationAnalysis
{
    class ClassGetDataFromFunc:IGetData
    {
        private double M { get; set; }
        private double D { get; set; }

        private double MIN;
        private double MAX;

        public ClassGetDataFromFunc(double _M, double _D)
        {
            M = _M;
            D = _D;

            MIN = M - D;
            MAX = M + D;
        }

        public double GetValue()
        {
            Random random = new Random();
            return random.NextDouble() * (MIN - MAX) + MIN;
        }
    }
}