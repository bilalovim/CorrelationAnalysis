using System;

namespace СorrelationAnalysis
{
    [Serializable]
    public struct RdCType
    {
        public string S;
        public int V, Min, Max;

        public RdCType(string s, int v, int min, int max)
        {
            S = s;
            V = v;
            Min = min;
            Max = max;
        }

        public override bool Equals(object obj)
        {
            if (((RdCType)obj).S == this.S &&
                ((RdCType)obj).V == this.V &&
                ((RdCType)obj).Min == this.Min &&
                ((RdCType)obj).Max == this.Max)
                return true;
            else
                return false;
        }

        public override int GetHashCode()
        {
            return this.GetHashCode();
        }

        public static bool operator ==(RdCType a, RdCType b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(RdCType a, RdCType b)
        {
            return !a.Equals(b);
        }

        public override string ToString()
        {
            return S;
        }
    }
}
