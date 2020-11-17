using System;
using System.Collections.Generic;
using System.Text;

namespace Police.Windows.UI.Common
{
    public interface IViewModelBase
    {
        void DisplayError(string message);

        void DisplayError(System.Exception ex);
    }
}
