using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MyToDo.Main.Core.Extensions
{
    public class PasswordExtend
    {
        public static string GetPasswordEx(DependencyObject obj)
        {
            return (string)obj.GetValue(PasswordEx);
        }

        public static void SetPasswordEx(DependencyObject obj, string value)
        {
            obj.SetValue(PasswordEx, value);
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PasswordEx =
            DependencyProperty.RegisterAttached("PasswordEx", typeof(string), typeof(PasswordExtend), new PropertyMetadata(string.Empty,OnPasswordExChanged));

        /// <summary>
        /// 当viewmodel中的pwd属性改变时，执行这个方法
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void OnPasswordExChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PasswordBox password = d as PasswordBox;

            if (password==null)
            {
                return;
            }
            string odlValue = (string)e.OldValue;
            string newValue = (string)e.NewValue;
            if (password.Password!=newValue)
            {
                password.PasswordChanged -= HandlePasswordChanged;
                password.Password = newValue;
                password.PasswordChanged += HandlePasswordChanged;
            }
        }

        private static void HandlePasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox passwordBox = sender as PasswordBox;

            SetPasswordEx(passwordBox, passwordBox.Password);
        }
    }
}
