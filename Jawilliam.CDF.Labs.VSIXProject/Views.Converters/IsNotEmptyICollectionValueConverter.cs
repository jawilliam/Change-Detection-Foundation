using System;
using System.Collections;
using System.Globalization;
using System.Windows.Data;

namespace Jawilliam.CDF.Labs.VSIXProject.Views.Converters
{
    /// <summary>
    /// Rather to convert, it informs if the given collection is empty. 
    /// </summary>
    [ValueConversion(typeof(ICollection), typeof(bool))]
    public class IsNotEmptyICollectionValueConverter : IValueConverter
    {
        /// <summary>
        /// Converts a value.
        /// </summary>
        /// <param name="value">The value produced by the binding source.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>A converted value. If the method returns null, the valid null value is used.</returns>
        public virtual object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is ICollection))
                throw new ArgumentException("The given value must be ICollection.");
            return value != null ? ((ICollection)value).Count > 0 : false;
        }

        /// <summary>
        /// Converts a value.
        /// </summary>
        /// <param name="value">The value that is produced by the binding target.</param>
        /// <param name="targetType">The type to convert to.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>A converted value. If the method returns null, the valid null value is used.</returns>
        public virtual object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new InvalidOperationException();
        }
    }
}
