using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationSampleApp
{
    public class Person : ValidatableBindableBase
    {
        private string name;

        [Required(ErrorMessage = "名前を入力してください")]
        public string Name
        {
            get { return this.name; }
            set { this.SetProperty(ref this.name, value); }
        }

    }
}
