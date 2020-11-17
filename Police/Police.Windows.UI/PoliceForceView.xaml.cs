using Police.Windows.UI.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Police.Windows.UI
{
    /// <summary>
    /// Interaction logic for PoliceForceView.xaml
    /// </summary>
    public partial class PoliceForceView : UserControl
    {
        public PoliceForceView()
        {
            InitializeComponent();
        }

        public PoliceForceView(IPoliceForceViewModel viewModel)
        {
            InitializeComponent();

            base.DataContext = viewModel;
        }
    }
}
