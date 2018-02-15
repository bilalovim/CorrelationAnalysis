using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace СorrelationAnalysis
{
    public struct WrRType
    {
        private double _V;
        public double V
        {
            get { return _V; }
            set
            {
                _V = value;
                S = V.ToString("N" + Pr);
            }
        }
        private int Pr;
        public string S;

        public WrRType(int _Pr)
        {
            _V = 0;
            Pr = _Pr;
            S = string.Empty;
        }
    }
}
