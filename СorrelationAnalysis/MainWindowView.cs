using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace СorrelationAnalysis
{
    class MainWindowView:INotifyPropertyChanged
    {
        private ClassConsts CNS;

        #region SignA
        public ObservableCollection<SourceData> SignA_SourceDatas { get; private set; }

        private EnumTypeSource _SignA_SelectedTypeSource;
        public EnumTypeSource SignA_SelectedTypeSource
        {
            get { return _SignA_SelectedTypeSource; }
            set
            {
                _SignA_SelectedTypeSource = value;
                CNS.SignA_Type = value;
                Helper.SaveConst(CNS);

                SignA_IsFunc = CNS.SignA_Type == EnumTypeSource.Func;
                OnPropertyChanged(nameof(SignA_IsFunc));

                SignA_IsFile = CNS.SignA_Type == EnumTypeSource.File;
                OnPropertyChanged(nameof(SignA_IsFile));
            }
        }

        public bool SignA_IsFunc { get; set; }
        public bool SignA_IsFile { get; set; }

        private string _SignA_M;
        public string SignA_M
        {
            get { return _SignA_M; }
            set
            {
                OnPropertySignA_MChanged(value);
            }
        }

        private string _SignA_D;
        public string SignA_D
        {
            get { return _SignA_D; }
            set { OnPropertySignA_DChanged(value); }
        }

        private string _SignA_b;
        public string SignA_b
        {
            get { return _SignA_b; }
            set { OnPropertySignA_bChanged(value); }
        }

        private string _SignA_n;
        public string SignA_n
        {
            get { return _SignA_n; }
            set { OnPropertySignA_nChanged(value); }
        }

        private string _SignA_FileName;
        public string SignA_FileName
        {
            get { return _SignA_FileName; }
            set
            {
                _SignA_FileName = value;
                OnPropertyChanged(nameof(SignA_FileName));

                CNS.SignA_FileName = value;
                Helper.SaveConst(CNS);
            }
        }

        private void OnPropertySignA_MChanged(String _uiVal)
        {
            if (_uiVal != _SignA_M)
            {
                RdRType tmp = CNS.SignA_M;
                var valid = Helper.InRdRType1(ref tmp, _uiVal);

                if (valid)
                {
                    _SignA_M = _uiVal;
                    CNS.SignA_M = tmp;
                    Helper.SaveConst(CNS);
                }
                else
                {
                    OnPropertyChanged(nameof(SignA_M));
                }
            }
        }

        private void OnPropertySignA_DChanged(String _uiVal)
        {
            if (_uiVal != _SignA_D)
            {
                RdRType tmp = CNS.SignA_D;
                var valid = Helper.InRdRType1(ref tmp, _uiVal);

                if (valid)
                {
                    _SignA_D = _uiVal;
                    CNS.SignA_D = tmp;
                    Helper.SaveConst(CNS);
                }
                else
                {
                    OnPropertyChanged(nameof(SignA_D));
                }
            }
        }

        private void OnPropertySignA_bChanged(String _uiVal)
        {
            if (_uiVal != _SignA_b)
            {
                RdRType tmp = CNS.SignA_b;
                var valid = Helper.InRdRType1(ref tmp, _uiVal);

                if (valid)
                {
                    _SignA_b = _uiVal;
                    CNS.SignA_b = tmp;
                    Helper.SaveConst(CNS);
                }
                else
                {
                    OnPropertyChanged(nameof(SignA_b));
                }
            }
        }

        private void OnPropertySignA_nChanged(String _uiVal)
        {
            if (_uiVal != _SignA_n)
            {
                RdCType tmp = CNS.SignA_n;
                var valid = Helper.InRdCType1(ref tmp, _uiVal);

                if (valid)
                {
                    _SignA_n = _uiVal;
                    CNS.SignA_n = tmp;
                    Helper.SaveConst(CNS);
                }
                else
                {
                    OnPropertyChanged(nameof(SignA_n));
                }
            }
        }

        private DelegateCommand _commandSelectSignA_FileName;
        public DelegateCommand CommandSelectSignA_FileName => _commandSelectSignA_FileName ?? (_commandSelectSignA_FileName = new DelegateCommand(SelectSignA_FileName));

        private void SelectSignA_FileName(object arg)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            dlg.InitialDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Text documents (.txt)|*.txt";

            bool? result = dlg.ShowDialog();
            if (result == true)
            {
                SignA_FileName = dlg.FileName;
            }
        }
        #endregion

        #region SignB
        public ObservableCollection<SourceData> SignB_SourceDatas { get; private set; }

        private EnumTypeSource _SignB_SelectedTypeSource;
        public EnumTypeSource SignB_SelectedTypeSource
        {
            get { return _SignB_SelectedTypeSource; }
            set
            {
                _SignB_SelectedTypeSource = value;
                CNS.SignB_Type = value;
                Helper.SaveConst(CNS);

                SignB_IsFunc = CNS.SignB_Type == EnumTypeSource.Func;
                OnPropertyChanged(nameof(SignB_IsFunc));

                SignB_IsFile = CNS.SignB_Type == EnumTypeSource.File;
                OnPropertyChanged(nameof(SignB_IsFile));
            }
        }

        public bool SignB_IsFunc { get; set; }
        public bool SignB_IsFile { get; set; }

        private string _SignB_M;
        public string SignB_M
        {
            get { return _SignB_M; }
            set
            {
                OnPropertySignB_MChanged(value);
            }
        }

        private string _SignB_D;
        public string SignB_D
        {
            get { return _SignB_D; }
            set { OnPropertySignB_DChanged(value); }
        }

        private string _SignB_b;
        public string SignB_b
        {
            get { return _SignB_b; }
            set { OnPropertySignB_bChanged(value); }
        }

        private string _SignB_n;
        public string SignB_n
        {
            get { return _SignB_n; }
            set { OnPropertySignB_nChanged(value); }
        }

        private string _SignB_FileName;
        public string SignB_FileName
        {
            get { return _SignB_FileName; }
            set
            {
                _SignB_FileName = value;
                OnPropertyChanged(nameof(SignB_FileName));

                CNS.SignB_FileName = value;
                Helper.SaveConst(CNS);
            }
        }

        private void OnPropertySignB_MChanged(String _uiVal)
        {
            if (_uiVal != _SignB_M)
            {
                RdRType tmp = CNS.SignB_M;
                var valid = Helper.InRdRType1(ref tmp, _uiVal);

                if (valid)
                {
                    _SignB_M = _uiVal;
                    CNS.SignB_M = tmp;
                    Helper.SaveConst(CNS);
                }
                else
                {
                    OnPropertyChanged(nameof(SignB_M));
                }
            }
        }

        private void OnPropertySignB_DChanged(String _uiVal)
        {
            if (_uiVal != _SignB_D)
            {
                RdRType tmp = CNS.SignB_D;
                var valid = Helper.InRdRType1(ref tmp, _uiVal);

                if (valid)
                {
                    _SignB_D = _uiVal;
                    CNS.SignB_D = tmp;
                    Helper.SaveConst(CNS);
                }
                else
                {
                    OnPropertyChanged(nameof(SignB_D));
                }
            }
        }

        private void OnPropertySignB_bChanged(String _uiVal)
        {
            if (_uiVal != _SignB_b)
            {
                RdRType tmp = CNS.SignB_b;
                var valid = Helper.InRdRType1(ref tmp, _uiVal);

                if (valid)
                {
                    _SignB_b = _uiVal;
                    CNS.SignB_b = tmp;
                    Helper.SaveConst(CNS);
                }
                else
                {
                    OnPropertyChanged(nameof(SignB_b));
                }
            }
        }

        private void OnPropertySignB_nChanged(String _uiVal)
        {
            if (_uiVal != _SignB_n)
            {
                RdCType tmp = CNS.SignB_n;
                var valid = Helper.InRdCType1(ref tmp, _uiVal);

                if (valid)
                {
                    _SignB_n = _uiVal;
                    CNS.SignB_n = tmp;
                    Helper.SaveConst(CNS);
                }
                else
                {
                    OnPropertyChanged(nameof(SignB_n));
                }
            }
        }

        private DelegateCommand _commandSelectSignB_FileName;
        public DelegateCommand CommandSelectSignB_FileName => _commandSelectSignB_FileName ?? (_commandSelectSignB_FileName = new DelegateCommand(SelectSignB_FileName));

        private void SelectSignB_FileName(object arg)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            dlg.InitialDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Text documents (.txt)|*.txt";

            bool? result = dlg.ShowDialog();
            if (result == true)
            {
                SignB_FileName = dlg.FileName;
            }
        }
        #endregion

        #region Main
        private string _Main_N;
        public string Main_N
        {
            get { return _Main_N; }
            set
            {
                OnPropertyMain_NChanged(value);
            }
        }

        private string _Main_n;
        public string Main_n
        {
            get { return _Main_n; }
            set
            {
                OnPropertyMain_nChanged(value);
            }
        }

        private string _Main_m;
        public string Main_m
        {
            get { return _Main_m; }
            set
            {
                OnPropertyMain_mChanged(value);
            }
        }

        private string _Main_r;
        public string Main_r
        {
            get { return _Main_r; }
            set
            {
                OnPropertyMain_rChanged(value);
            }
        }

        private string _Main_T;
        public string Main_T
        {
            get { return _Main_T; }
            set
            {
                OnPropertyMain_TChanged(value);
            }
        }

        private void OnPropertyMain_NChanged(String _uiVal)
        {
            if (_uiVal != _Main_N)
            {
                RdCType tmp = CNS.Main_N;
                var valid = Helper.InRdCType1(ref tmp, _uiVal);

                if (valid)
                {
                    _Main_N = _uiVal;
                    CNS.Main_N = tmp;
                    Helper.SaveConst(CNS);
                }
                else
                {
                    OnPropertyChanged(nameof(Main_N));
                }
            }
        }

        private void OnPropertyMain_nChanged(String _uiVal)
        {
            if (_uiVal != _Main_n)
            {
                RdCType tmp = CNS.Main_n;
                var valid = Helper.InRdCType1(ref tmp, _uiVal);

                if (valid)
                {
                    _Main_n = _uiVal;
                    CNS.Main_n = tmp;
                    Helper.SaveConst(CNS);
                }
                else
                {
                    OnPropertyChanged(nameof(Main_n));
                }
            }
        }

        private void OnPropertyMain_mChanged(String _uiVal)
        {
            if (_uiVal != _Main_m)
            {
                RdCType tmp = CNS.Main_m;
                var valid = Helper.InRdCType1(ref tmp, _uiVal);

                if (valid)
                {
                    _Main_m = _uiVal;
                    CNS.Main_m = tmp;
                    Helper.SaveConst(CNS);
                }
                else
                {
                    OnPropertyChanged(nameof(Main_m));
                }
            }
        }

        private void OnPropertyMain_rChanged(String _uiVal)
        {
            if (_uiVal != _Main_r)
            {
                RdCType tmp = CNS.Main_r;
                var valid = Helper.InRdCType1(ref tmp, _uiVal);

                if (valid)
                {
                    _Main_r = _uiVal;
                    CNS.Main_r = tmp;
                    Helper.SaveConst(CNS);
                }
                else
                {
                    OnPropertyChanged(nameof(Main_r));
                }
            }
        }

        private void OnPropertyMain_TChanged(String _uiVal)
        {
            if (_uiVal != _Main_T)
            {
                RdRType tmp = CNS.Main_T;
                var valid = Helper.InRdRType1(ref tmp, _uiVal);

                if (valid)
                {
                    _Main_T = _uiVal;
                    CNS.Main_T = tmp;
                    Helper.SaveConst(CNS);
                }
                else
                {
                    OnPropertyChanged(nameof(Main_T));
                }
            }
        }

        #endregion

        public MainWindowView()
        {
            Init();

            #region SignA
            SignA_SourceDatas = new ObservableCollection<SourceData>();
            SignA_SourceDatas.Add(new SourceData() { NameSource = "Функция", TypeSource = EnumTypeSource.Func});
            SignA_SourceDatas.Add(new SourceData() { NameSource = "Файл", TypeSource = EnumTypeSource.File });

            _SignA_SelectedTypeSource = CNS.SignA_Type;
            _SignA_M = CNS.SignA_M.S;
            _SignA_D = CNS.SignA_D.S;
            _SignA_b = CNS.SignA_b.S;
            _SignA_n = CNS.SignA_n.S;
            _SignA_FileName = CNS.SignA_FileName;

            SignA_IsFunc = CNS.SignA_Type == EnumTypeSource.Func;
            SignA_IsFile = CNS.SignA_Type == EnumTypeSource.File;
            #endregion

            #region SignB
            SignB_SourceDatas = new ObservableCollection<SourceData>();
            SignB_SourceDatas.Add(new SourceData() { NameSource = "Функция", TypeSource = EnumTypeSource.Func });
            SignB_SourceDatas.Add(new SourceData() { NameSource = "Файл", TypeSource = EnumTypeSource.File });

            _SignB_SelectedTypeSource = CNS.SignB_Type;
            _SignB_M = CNS.SignB_M.S;
            _SignB_D = CNS.SignB_D.S;
            _SignB_b = CNS.SignB_b.S;
            _SignB_n = CNS.SignB_n.S;
            _SignB_FileName = CNS.SignB_FileName;

            SignB_IsFunc = CNS.SignB_Type == EnumTypeSource.Func;
            SignB_IsFile = CNS.SignB_Type == EnumTypeSource.File;
            #endregion

            #region Main
            _Main_N = CNS.Main_N.S;
            _Main_n = CNS.Main_n.S;
            _Main_m = CNS.Main_m.S;
            _Main_r = CNS.Main_r.S;
            _Main_T = CNS.Main_T.S;
            #endregion
        }

        private void Init()
        {
            CNS = new ClassConsts();
            Helper.RestoreConst(ref CNS);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private DelegateCommand _commandStartCalc;
        public DelegateCommand CommandStartCalc => _commandStartCalc ?? (_commandStartCalc = new DelegateCommand(StartCalc));

        private void StartCalc(object arg)
        {
            Debug.WriteLine(SignA_SelectedTypeSource);
        }


    }




}
