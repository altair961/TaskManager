using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TaskManager.View
{
    /// <summary>
    /// Interaction logic for ProgressBarCpu.xaml
    /// </summary>
    public partial class ProgressBarCpu : UserControl
    {
        public ProgressBarCpu()
        {
            InitializeComponent();
        }

        private void pbCpu_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var binding = ((ProgressBar)sender).GetBindingExpression(ProgressBar.ValueProperty);
            binding.UpdateSource();
        }
    }
}
