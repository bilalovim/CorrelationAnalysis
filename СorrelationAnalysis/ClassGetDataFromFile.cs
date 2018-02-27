using System.Collections.Generic;
using System.IO;
using System.Text;

namespace СorrelationAnalysis
{
    class ClassGetDataFromFile:IGetData
    {
        private List<double> listDouble;
        private int index;
        private int n;
        private double b;
        private double delta;

        public ClassGetDataFromFile(string FileName, int _n, double _b)
        {
            listDouble = new List<double>();
            var fileStream = new FileStream(FileName, FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                string svalue;
                double dvalue;
                while ((svalue = streamReader.ReadLine()) != null)
                {
                    if (double.TryParse(svalue, out dvalue))
                    {
                        listDouble.Add(dvalue);
                    }
                    else
                    {
                        listDouble.Add(0.0);
                    }
                }
            }

            n = _n;
            b = _b;
            delta = 0;

            index = 0;
        }

        public double GetValue()
        {
            double value = 0.0;

            if (n != 0 && index >= n)
                delta = delta + b;

            if (listDouble.Count > 0)
            {
                if (index < listDouble.Count)
                {
                    value = listDouble[index];
                    index++;
                }
                else
                {
                    index = 0;
                    value = listDouble[index];
                    index++;
                }
            }

            return value + delta;
        }
    }
}
