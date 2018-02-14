using System;

namespace СorrelationAnalysis
{
    [Serializable]
    public class ClassConsts
    {
        //Сигнал А
        public EnumTypeSource SignA_Type;
        public RdRType SignA_M;
        public RdRType SignA_D;
        public RdRType SignA_b;
        public RdCType SignA_n;
        public string SignA_FileName;

        //Сигнал B
        public EnumTypeSource SignB_Type;
        public RdRType SignB_M;
        public RdRType SignB_D;
        public RdRType SignB_b;
        public RdCType SignB_n;
        public string SignB_FileName;

        //Общие параметры
        public RdCType Main_N;
        public RdCType Main_n;
        public RdCType Main_m;
        public RdCType Main_r;
        public RdRType Main_T;

        public ClassConsts()
        {
            SignA_Type = EnumTypeSource.Func;
            SignA_M = new RdRType("25,00", 25.00, Double.MinValue, Double.MaxValue, true);
            SignA_D = new RdRType("0,05", 0.05, Double.MinValue, Double.MaxValue, true);
            SignA_b = new RdRType("0,05", 0.05, Double.MinValue, Double.MaxValue, true);
            SignA_n = new RdCType("0", 0, 0, int.MaxValue);
            SignA_FileName = String.Empty;

            SignB_Type = EnumTypeSource.Func;
            SignB_M = new RdRType("27,00", 27.00, Double.MinValue, Double.MaxValue, true);
            SignB_D = new RdRType("0,05", 0.05, Double.MinValue, Double.MaxValue, true);
            SignB_b = new RdRType("0,05", 0.05, Double.MinValue, Double.MaxValue, true);
            SignB_n = new RdCType("0", 0, 0, int.MaxValue);
            SignB_FileName = String.Empty;

            Main_N = new RdCType("300", 300, 0, int.MaxValue);
            Main_n = new RdCType("30", 30, 0, int.MaxValue);
            Main_m = new RdCType("3", 3, 0, int.MaxValue);
            Main_r = new RdCType("2", 2, 0, int.MaxValue);
            Main_T = new RdRType("0,05", 0.05, Double.MinValue, Double.MaxValue, true);
        }
    }
}
