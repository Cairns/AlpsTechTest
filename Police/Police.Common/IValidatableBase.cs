using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Police.Common
{
    public interface IValidatableBase
    {
        Dictionary<string, List<string>> Errors { get; }

        System.Collections.IEnumerable GetErrors(string propertyName = null);
        System.Collections.Generic.IEnumerable<string> GetErrors();

        string ErrorMessage { get; }

        bool IsValid { get; }

        void Validate();
    }
}
