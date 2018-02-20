using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

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

        private string _SignA_MIN;
        public string SignA_MIN
        {
            get { return _SignA_MIN; }
            set { OnPropertySignA_MINChanged(value); }
        }

        private string _SignA_MAX;
        public string SignA_MAX
        {
            get { return _SignA_MAX; }
            set { OnPropertySignA_MAXChanged(value); }
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

        private void OnPropertySignA_MINChanged(String _uiVal)
        {
            if (_uiVal != _SignA_MIN)
            {
                RdRType tmp = CNS.SignA_MIN;
                var valid = Helper.InRdRType1(ref tmp, _uiVal);
                

                if (valid)
                {
                    var valid2 = Helper.CheckMinMax(tmp, CNS.SignA_MAX);

                    if (valid2)
                    {
                        _SignA_MIN = _uiVal;
                        CNS.SignA_MIN = tmp;
                        Helper.SaveConst(CNS);
                    }
                    else
                    {
                        OnPropertyChanged(nameof(SignA_MIN));
                    }
                }
                else
                {
                    OnPropertyChanged(nameof(SignA_MIN));
                }
            }
        }

        private void OnPropertySignA_MAXChanged(String _uiVal)
        {
            if (_uiVal != _SignA_MAX)
            {
                RdRType tmp = CNS.SignA_MAX;
                var valid = Helper.InRdRType1(ref tmp, _uiVal);

                if (valid)
                {
                    var valid2 = Helper.CheckMinMax(CNS.SignA_MIN, tmp);

                    if (valid2)
                    {
                        _SignA_MAX = _uiVal;
                        CNS.SignA_MAX = tmp;
                        Helper.SaveConst(CNS);
                    }
                    else
                    {
                        OnPropertyChanged(nameof(SignA_MAX));
                    }
                }
                else
                {
                    OnPropertyChanged(nameof(SignA_MAX));
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

        private string _SignB_MIN;
        public string SignB_MIN
        {
            get { return _SignB_MIN; }
            set { OnPropertySignB_MINChanged(value); }
        }

        private string _SignB_MAX;
        public string SignB_MAX
        {
            get { return _SignB_MAX; }
            set { OnPropertySignB_MAXChanged(value); }
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

        private void OnPropertySignB_MINChanged(String _uiVal)
        {
            if (_uiVal != _SignB_MIN)
            {
                RdRType tmp = CNS.SignB_MIN;
                var valid = Helper.InRdRType1(ref tmp, _uiVal);

                if (valid)
                {
                    var valid2 = Helper.CheckMinMax(tmp, CNS.SignB_MAX);

                    if (valid2)
                    {
                        _SignB_MIN = _uiVal;
                        CNS.SignB_MIN = tmp;
                        Helper.SaveConst(CNS);
                    }
                    else
                    {
                        OnPropertyChanged(nameof(SignB_MIN));
                    }
                }
                else
                {
                    OnPropertyChanged(nameof(SignB_MIN));
                }
            }
        }

        private void OnPropertySignB_MAXChanged(String _uiVal)
        {
            if (_uiVal != _SignB_MAX)
            {
                RdRType tmp = CNS.SignB_MAX;
                var valid = Helper.InRdRType1(ref tmp, _uiVal);

                if (valid)
                {
                    var valid2 = Helper.CheckMinMax(CNS.SignB_MIN, tmp);

                    if (valid2)
                    {
                        _SignB_MAX = _uiVal;
                        CNS.SignB_MAX = tmp;
                        Helper.SaveConst(CNS);
                    }
                    else
                    {
                        OnPropertyChanged(nameof(SignB_MAX));
                    }
                }
                else
                {
                    OnPropertyChanged(nameof(SignB_MAX));
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

        private string _Main_Pr;
        public string Main_Pr
        {
            get { return _Main_Pr; }
            set
            {
                OnPropertyMain_PrChanged(value);
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


        private void OnPropertyMain_PrChanged(String _uiVal)
        {
            if (_uiVal != _Main_Pr)
            {
                RdCType tmp = CNS.Main_Pr;
                var valid = Helper.InRdCType1(ref tmp, _uiVal);

                if (valid)
                {
                    _Main_Pr = _uiVal;
                    CNS.Main_Pr = tmp;
                    Helper.SaveConst(CNS);
                }
                else
                {
                    OnPropertyChanged(nameof(Main_Pr));
                }
            }
        }

        #endregion

        private string _NameStartStop;
        public string NameStartStop
        {
            get { return _NameStartStop; }
            set
            {
                _NameStartStop = value;
                OnPropertyChanged(nameof(NameStartStop));
            }
        }

        private bool _IsProcess;
        public bool IsProcess
        {
            get { return _IsProcess; }
            set
            {
                _IsProcess = value;
                OnPropertyChanged(nameof(IsProcess));
            }
        }

        private CancellationTokenSource ts;
        private CancellationToken ct;

        private enum StateEnum
        {
            Idle,
            Process
        }

        private string[] StateName = new[]{ "Запуск имитации сигналов", "Стоп!"};

        private StateEnum _State;
        private StateEnum State
        {
            get { return _State; }
            set
            {
                _State = value;
                NameStartStop = StateName[(int)value];
                IsProcess = value == StateEnum.Process;
            }
        }

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
            _SignA_MIN = CNS.SignA_MIN.S;
            _SignA_MAX = CNS.SignA_MAX.S;
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
            _SignB_MIN = CNS.SignB_MIN.S;
            _SignB_MAX = CNS.SignB_MAX.S;
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
            _Main_Pr = CNS.Main_Pr.S;
            #endregion

            NameStartStop = StateName[(int)State];
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

        private DelegateCommand _commandStartStopCalc;
        public DelegateCommand CommandStartStopCalc => _commandStartStopCalc ?? (_commandStartStopCalc = new DelegateCommand(StartStopCalc));

        private void StartStopCalc(object arg)
        {
            switch (State)
            {
                case StateEnum.Idle:
                    State = StateEnum.Process;
                    ts = new CancellationTokenSource();
                    ct = ts.Token;
                    Task.Factory.StartNew(TaskCorrelation);
                    break;

                case StateEnum.Process:
                    State = StateEnum.Idle;
                    ts.Cancel();
                    break;
            }
        }

        private void TaskCorrelation()
        {
            bool ok = true;
            string okfilename = String.Empty;
            IGetData SignA;
            IGetData SignB;
            ClassCalcCorrelation Correlation = new ClassCalcCorrelation(CNS.Main_n.V, CNS.Main_m.V, CNS.Main_r.V, CNS.Main_Pr.V, CNS.SignA_MIN, CNS.SignA_MAX, CNS.SignB_MIN, CNS.SignB_MAX);

            switch (CNS.SignA_Type)
            {
                case EnumTypeSource.File:
                    SignA = new ClassGetDataFromFile(CNS.SignA_FileName);
                    break;

                case EnumTypeSource.Func:
                    SignA = new ClassGetDataFromFunc(CNS.SignA_M.V, CNS.SignA_D.V, CNS.SignA_n.V, CNS.SignA_b.V);
                    break;

                default:
                    SignA = new ClassGetDataFromFunc(CNS.SignA_M.V, CNS.SignA_D.V, CNS.SignA_n.V, CNS.SignA_b.V);
                    break;
            }

            switch (CNS.SignB_Type)
            {
                case EnumTypeSource.File:
                    SignB = new ClassGetDataFromFile(CNS.SignB_FileName);
                    break;

                case EnumTypeSource.Func:
                    SignB = new ClassGetDataFromFunc(CNS.SignB_M.V, CNS.SignB_D.V, CNS.SignB_n.V, CNS.SignB_b.V);
                    break;

                default:
                    SignB = new ClassGetDataFromFunc(CNS.SignB_M.V, CNS.SignB_D.V, CNS.SignB_n.V, CNS.SignB_b.V);
                    break;
            }

            for (int i = 0; i < CNS.Main_N.V; i++)
            {
                if (ct.IsCancellationRequested)
                {
                    ok = false;
                    break;
                }

                Correlation.Calc(SignA.GetValue(), SignB.GetValue());
                System.Threading.Thread.Sleep((int)CNS.Main_T.V);
            }

            if (ok)
                okfilename = Correlation.SaveResult();

            State = StateEnum.Idle;

            if (ok)
            {
                StringBuilder sbmsg = new StringBuilder();
                sbmsg.AppendLine("Вычисления завершены успешно!");
                sbmsg.Append(String.Format($"Файл с результатами расчетов: {okfilename}"));

                MessageBox.Show(sbmsg.ToString());
            }

            //Application.Current.Dispatcher.BeginInvoke(new Action(() =>
            //{
            //    State = StateEnum.Idle;
            //}));
        }
    }
}
