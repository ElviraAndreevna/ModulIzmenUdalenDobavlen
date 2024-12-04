using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace ModulUdalIzmenDobav.converters
{
    class RelativeToFullPathConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string path = value as string;
            if (String.IsNullOrEmpty(path)) return "pack://application:,,,/Resources/Images/nnpolzovatel.jpg";
            try
            {
                if (!File.Exists(path))
                    return "pack://application:,,,/Resources/Images/nnpolzovatel.jpg";
                else
                    using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                        return BitmapFrame.Create(fs, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
            }
            catch
            {
                return "pack://application:,,,/Resources/Images/nnpolzovatel.jpg";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
