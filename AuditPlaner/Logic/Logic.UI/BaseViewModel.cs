using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.ComponentModel;
using System.Reflection;
using GalaSoft.MvvmLight.Command;

namespace bregau.AuditPlaner.Logic.UI.ViewModel
{
    public class BaseViewModel : ViewModelBase, IDataErrorInfo
    {
        private Dictionary<string, PropertyInfo> _properties = new Dictionary<string, PropertyInfo>();
        private Dictionary<string, string> _errors = new Dictionary<string, string>();

        public BaseViewModel()
        {
            var _props  = this.GetType().GetProperties().ToList();
            _props.ForEach(prop =>
            {
                _properties.Add(prop.Name, prop);
            });
        }

        public string this[string propertyName]
        {
            get
            {
                return OnValidate(propertyName);
            }
        }

        public string Error
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool HasErrors => _errors.Any();
        public bool IsOK => !HasErrors;


        /// <summary>
        /// Validates Property Values based on DataAnnotations
        /// Based on : https://social.technet.microsoft.com/wiki/contents/articles/22660.data-validation-in-mvvm.aspx
        /// </summary>
        /// <param name="propertyName">The name of the property to be validated</param>
        /// <returns>Empty String or Error-Message</returns>
        protected virtual string OnValidate(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName) || !_properties.ContainsKey(propertyName) )
            {
                throw new ArgumentException("Invalid property name", propertyName);
            }

            if (_errors.ContainsKey(propertyName))
                _errors.Remove(propertyName);

            string error = string.Empty;
            var value = _properties[propertyName].GetValue(this);
            var results = new List<System.ComponentModel.DataAnnotations.ValidationResult>(1);
            var result = Validator.TryValidateProperty(
                value,
                new ValidationContext(this, null, null)
                {
                    MemberName = propertyName
                },
                results);

            if (!result)
            {
                var validationResult = results.First();
                error = validationResult.ErrorMessage;
                _errors.Add(propertyName, error);
            }

            // Manually update RelayCommands ...
            var relayCommands = _properties.Where(prop => prop.Value.PropertyType == typeof(RelayCommand)).ToList();
            relayCommands.ForEach(prop => ((RelayCommand)prop.Value.GetValue(this)).RaiseCanExecuteChanged());

            return error;
        }
    }
}
