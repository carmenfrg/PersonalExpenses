using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace PersonalExpenses.ViewModel.ValueConverters
{
    class DateToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime fecha = (DateTime)value;

            var diferencia = DateTime.Now - fecha;

            if (diferencia.TotalMinutes < 60)
                return $"Hace {diferencia.TotalMinutes:0} minuto(s)";
            if(diferencia.TotalHours < 24)
                return $"Hace {diferencia.TotalHours:0} hora(s)";
            if (diferencia.TotalHours < 48)
                return $"Ayer";
            if (diferencia.TotalDays < 7)
                return $"Hace {diferencia.TotalDays:0} dias";

            return $"{fecha:d}";

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DateTime.Now;
        }
    }
}
