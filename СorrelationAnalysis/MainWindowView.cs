using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace СorrelationAnalysis
{
    class MainWindowView:INotifyPropertyChanged
    {
        public ObservableCollection<SourceData> SourceDatas { get; private set; }
        public EnumTypeSource SelectedTypeSource { get; set; }

        public MainWindowView()
        {
            SourceDatas  = new ObservableCollection<SourceData>();
            SourceDatas.Add(new SourceData() { NameSource = "Функция", TypeSource = EnumTypeSource.Func});
            SourceDatas.Add(new SourceData() { NameSource = "Файл", TypeSource = EnumTypeSource.File });

            SelectedTypeSource = SourceDatas[0].TypeSource;
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
            Debug.WriteLine(SelectedTypeSource);
        }
    }

    public enum EnumTypeSource
    {
        Func,
        File
    }

    public class SourceData
    {
        public string NameSource { get; set; }
        public EnumTypeSource TypeSource { get; set; }
    }
}
