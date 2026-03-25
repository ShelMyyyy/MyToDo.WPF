using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace MyToDo.Main.Core.Convert
{
    public class ResourceKeyToDrawingImageConverter : IValueConverter
    {
        /// <summary>
        /// 正向转换
        /// </summary>
        /// <param name="value">源值</param>
        /// <param name="targetType">转换后的目标类型</param>
        /// <param name="parameter">需要的参数</param>
        /// <param name="culture">区域文化信息（本例未使用，多语言场景会用到）</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null|| !(value is string strSource))
            {
                return null;
            }
            //拿到全局的资源
            var imagesource = Application.Current.TryFindResource(strSource) as ImageSource;

            return imagesource ?? null;
           
        }
        /// <summary>
        /// 反向转换，双向绑定时才会用到，用户在界面更改了值同步更改到绑定的ViewModel
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
           return DependencyProperty.UnsetValue;
        }
    }
}
