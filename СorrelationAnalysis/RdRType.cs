using System;

namespace СorrelationAnalysis
{
    [Serializable]
    public struct RdRType
    {
        public string S;
        public double V, Min, Max;
        public bool Ok;

        public RdRType(string s, double v, double min, double max, bool ok)
        {
            S = s;
            V = v;
            Min = min;
            Max = max;
            Ok = ok;
        }

        public RdRType(double v, double min, double max, bool ok)
        {
            S = v.ToString();
            V = v;
            Min = min;
            Max = max;
            Ok = ok;
        }

        public RdRType(double v, double min, double max)
        {
            S = v.ToString();
            V = v;
            Min = min;
            Max = max;
            Ok = true;
        }

        public override bool Equals(object obj)
        {
            if (((RdRType)obj).Max == this.Max &&
                ((RdRType)obj).Min == this.Min &&
                ((RdRType)obj).Ok == this.Ok &&
                ((RdRType)obj).S == this.S &&
                ((RdRType)obj).V == this.V)
                return true;
            else
                return false;
        }
        public override int GetHashCode()
        {
            return this.GetHashCode();
        }
        public static bool operator ==(RdRType a, RdRType b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(RdRType a, RdRType b)
        {
            return !a.Equals(b);
        }

        public override string ToString()
        {
            return S;
        }
    }
}
