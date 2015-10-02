using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace TaskManager.ViewModel
{
    class CpuUsageToSliderValueConverter : IMultiValueConverter
    {
        // Fields
        double CurrentCpuUsage { set; get; }
        double SliderVal { set; get; }

        // Methods
        object IMultiValueConverter.Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            CurrentCpuUsage = (double)(float)values[0];
            SliderVal = (double)values[1];

            if (CurrentCpuUsage > SliderVal)
            {
                return Brushes.Red;
            }
            else
            {
                return Brushes.Teal;
            }

        }

        object[] IMultiValueConverter.ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
