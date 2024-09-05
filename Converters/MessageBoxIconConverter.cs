using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using System.Windows;

namespace Timesheet.Converters {

    /// Based on https://stackoverflow.com/a/2436975
    [ValueConversion(typeof(MessageBoxImage), typeof(BitmapSource))]
    public class MessageBoxIconConverter : IValueConverter {
        public object Convert (object value, Type type, object parameter, CultureInfo culture) {
            Icon icon = null;
            switch (parameter as MessageBoxImage?) {
                case MessageBoxImage.None:
                case null:
                    return null;
                case MessageBoxImage.Error:
                    icon = SystemIcons.Error;
                    break;
                case MessageBoxImage.Question:
                    icon = SystemIcons.Question;
                    break;
                case MessageBoxImage.Exclamation:
                    icon = SystemIcons.Exclamation;
                    break;
                case MessageBoxImage.Asterisk:
                    icon = SystemIcons.Asterisk;
                    break;
            }
            BitmapSource bs = Imaging.CreateBitmapSourceFromHIcon(icon.Handle, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            return bs;
        }

        public object ConvertBack (object value, Type type, object parameter, CultureInfo culture) {
            throw new NotSupportedException();
        }
    }
}
