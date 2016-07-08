using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ValidationSampleApp
{
    public class ValidatableBindableBase : BindableBase, INotifyDataErrorInfo
    {
        private Dictionary<string, IEnumerable> Errors { get; } = new Dictionary<string, IEnumerable>();

        public bool HasErrors => this.Errors.Any();

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                return this.Errors.Any() ?
                    this.Errors.Values.SelectMany(x => x.Cast<string>()) :
                    null;
            }

            return this.Errors.ContainsKey(propertyName) ? 
                this.Errors[propertyName] : 
                null;
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            var ctx = new ValidationContext(this) { MemberName = propertyName };
            var results = new List<ValidationResult>();
            if (Validator.TryValidateProperty(this.GetType().GetProperty(propertyName).GetValue(this), ctx, results))
            {
                this.Errors.Remove(propertyName);
            }
            else
            {
                this.Errors[propertyName] = results.Select(x => x.ErrorMessage).ToArray();
            }
            this.ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }
    }
}
