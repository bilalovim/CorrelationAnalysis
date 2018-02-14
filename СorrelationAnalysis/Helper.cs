using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace СorrelationAnalysis
{
    public static class Helper
    {
        private static readonly string FileNameCNS = System.AppDomain.CurrentDomain.BaseDirectory + "CNS.DAT";

        private static bool SaveF(string filename, object obj)
        {
            bool okSaveF = false;
            string FileName = filename;

            FileStream fs = new FileStream(FileName, FileMode.Create);

            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, obj);

                okSaveF = true;
            }
            catch (Exception ex)
            {
                okSaveF = false;
            }
            finally
            {
                fs.Close();
            }

            return okSaveF;
        }

        private static bool RestoreF(string filename, out object obj)
        {
            bool okRestoreF = false;
            obj = null;

            string FileName = filename;

            if (File.Exists(FileName))
            {
                FileStream fs = new FileStream(FileName, FileMode.Open);
                try
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    obj = formatter.Deserialize(fs);

                    okRestoreF = true;
                }
                catch (Exception ex)
                {
                    okRestoreF = false;
                }
                finally
                {
                    fs.Close();
                }
            }

            return okRestoreF;
        }

        public static void SaveConst(ClassConsts cnsobj)
        {
            SaveF(FileNameCNS, cnsobj);
        }

        public static void RestoreConst(ref ClassConsts cnsobj)
        {
            object objPC;
            if (!RestoreF(FileNameCNS, out objPC))
            {
                SaveConst(cnsobj);
            }
            else
            {
                try
                {
                    cnsobj = (ClassConsts)objPC;
                }
                catch
                {
                    SaveConst(cnsobj);
                }
            }
        }

        public static bool InRdRType1(ref RdRType V, string S)
        {
            bool ok = false;

            if (V.S == S)
                return true;

            if (string.IsNullOrEmpty(S))
            {
                V.V = 0.0;
                V.S = "";
                V.Ok = false;
                return true;
            }

            S = S.Replace('e', 'E');

            double _V = 0;
            V.Ok = false;
            try
            {
                _V = Convert.ToDouble(S);

                if (_V < V.Min)
                {
                    MessageBox.Show("Ошибка ввода : меньше допустимого значения");
                }
                else if (_V > V.Max)
                {
                    MessageBox.Show("Ошибка ввода : больше допустимого значения");
                }
                else
                {
                    V.V = _V;
                    V.S = S;
                    V.Ok = true;

                    ok = true;
                }
            }
            catch
            {
                if (S == "")
                {
                    V.V = 0.0;
                    V.S = "";
                    V.Ok = false;

                    ok = true;
                }
                else
                    MessageBox.Show("Ошибка ввода : недопустимые символы");
            }

            return ok;
        }

        public static bool InRdCType1(ref RdCType V, string S)
        {
            int v = 0;
            bool Ok = false;

            if (V.S == S)
                return true;

            if (S.Length != 0)
            {
                try
                {
                    v = Convert.ToInt32(S);
                    if (v < V.Min)
                    {
                        MessageBox.Show("Ошибка ввода : меньше допустимого значения");
                        Ok = false;
                    }
                    else if (v > V.Max)
                    {
                        MessageBox.Show("Ошибка ввода : больше допустимого значения");
                        Ok = false;
                    }
                    else
                    {
                        V.V = v;
                        V.S = S;
                        Ok = true;
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка ввода : недопустимые символы");
                    Ok = false;
                }
            }
            else
            {
                MessageBox.Show("Ошибка ввода : нет значения");
                Ok = false;
            }

            return Ok;
        }
    }
}
