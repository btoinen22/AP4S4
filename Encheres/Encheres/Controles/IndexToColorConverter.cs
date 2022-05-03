using System;
using System.Globalization;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Encheres.Controles.Converters
{
    public class IndexToColorConverter : IValueConverter
    {
        /// <summary>
        /// création d'une variable nouvelle couleur et creer son getter/setter
        /// </summary>
        public Color EvenColor { get; set; }

        /// <summary>
        /// création d'une variable nouvelle couleur et creer son getter/setter
        /// </summary>
        public Color OddColor { get; set; }

        /// <summary>
        /// convertie la couleur d'un objet 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var collectionView = parameter as CollectionView;

            return collectionView.ItemsSource.Cast<object>().IndexOf(value) % 2 == 0 ? EvenColor : OddColor;
        }

        /// <summary>
        /// retourne ecxeption , doit retourner la couleur de base
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

