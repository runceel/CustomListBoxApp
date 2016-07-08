using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationSampleApp
{
    public class MainWindowViewModel : BindableBase
    {
        public ObservableCollection<Person> People { get; }

        public MainWindowViewModel()
        {
            this.People = new ObservableCollection<Person>(Enumerable
                .Range(1, 10)
                .Select(x => new Person { Name = $"sample {x}" }));
        }
    }
}
