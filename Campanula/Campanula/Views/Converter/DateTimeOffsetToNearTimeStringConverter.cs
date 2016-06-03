using System;
using System.Globalization;
using Xamarin.Forms;

namespace Campanula.Views.Converter
{
    public class DateTimeOffsetToNearTimeStringConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var dto = value as DateTimeOffset?;

            if (dto == null) return null;

            var date = dto.Value;

            var defferentialTime = DateTimeOffset.Now-date;

            if (defferentialTime.TotalSeconds < 60)
            {
                return (int)defferentialTime.TotalSeconds + "秒";
            }

            if (defferentialTime.TotalMinutes < 60)
            {
                return (int)defferentialTime.TotalMinutes + "分";
            }

            if (defferentialTime.TotalHours < 24)
            {
                return (int)defferentialTime.TotalHours + "時間";
            }

            if (defferentialTime.TotalDays < 7)
            {
                return (int)defferentialTime.TotalDays+"日";
            }

            return date.ToString("yyyy/MM/dd");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new System.NotImplementedException();
        }
    }
}