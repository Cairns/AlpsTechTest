using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Police.Common
{
    public class ValidatableBase : BindableBase, IValidatableBase, INotifyDataErrorInfo, IChangeTracking
    {
        #region BindableBase Members
        protected override bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            var wasSet = base.SetProperty<T>(ref storage, value, propertyName);
            ValidateProperty<T>(value, propertyName);
            return wasSet;
        }
        #endregion

        #region INotifyDataErrorInfo Members
        public event EventHandler<System.ComponentModel.DataErrorsChangedEventArgs> ErrorsChanged;

        protected virtual void OnPropertyErrorsChanges(DataErrorsChangedEventArgs args)
        {
            this.ErrorsChanged?.Invoke(this, args);
        }
        protected virtual void OnPropertyErrorsChanged(string propertyName)
        {
            this.ErrorsChanged?.Invoke(this, new System.ComponentModel.DataErrorsChangedEventArgs(propertyName));
        }

        public System.Collections.Generic.IEnumerable<string> GetErrors()
        {
            return this.GetErrors(null) as IEnumerable<string>;
        }

        public System.Collections.IEnumerable GetErrors(string propertyName = null)
        {
            List<string> errorsList = new List<string>();
            if (propertyName != null)
            {
                Errors.TryGetValue(propertyName, out errorsList);
                return errorsList;
            }
            else
            {
                foreach (KeyValuePair<string, List<string>> keyValuePair in this.Errors)
                {
                    errorsList.AddRange(keyValuePair.Value);
                }
                return errorsList;
            }
        }

        public bool HasErrors => this.Errors?.Values?.Any() ?? false;
        #endregion

        #region IValidatableBase Members
        public Dictionary<string, List<string>> Errors { get; } = new Dictionary<string, List<string>>();

        public string ErrorMessage => string.Join<string>(Environment.NewLine, this.GetErrors());

        public bool IsValid => !this.HasErrors;

        public virtual void Validate()
        {
            foreach (PropertyInfo property in this.GetType().GetProperties())
            {
                ValidateProperty(property.GetValue(this), property.Name);
            }
        }

        protected virtual void ValidateProperty<T>(T value, [CallerMemberName] string propertyName = null)
        {
            var results = new List<ValidationResult>();

            ValidationContext context = new ValidationContext(this);
            context.MemberName = propertyName;
            Validator.TryValidateProperty(value, context, results);

            if (results.Any())
            {
                Errors[propertyName] = results.Select(v => v.ErrorMessage).ToList();
            }
            else
            {
                Errors.Remove(propertyName);
            }

            this.OnPropertyErrorsChanged(propertyName);
        }
        #endregion
    }
}
