using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomListBoxApp
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Person> People { get; }

        public MainWindowViewModel()
        {
            this.People = new ObservableCollection<Person>(Enumerable.Range(1, 100)
                .Select(x => new Person { Name = $"sample taro {x}" }));
        }
    }
}
