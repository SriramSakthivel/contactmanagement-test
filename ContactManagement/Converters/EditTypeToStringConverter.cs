using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;
using ContactManagement.ViewModels;

namespace ContactManagement.Converters
{
    public class EditTypeToStringConverter :  IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            EditType? editType = value as EditType?;
            if (!editType.HasValue)
            {
                return null;
            }
            switch (editType.Value)
            {
                case EditType.CreateNew:
                case EditType.Modify:
                    return string.Format("{0} Contact", editType.Value);
                default:
                    return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
