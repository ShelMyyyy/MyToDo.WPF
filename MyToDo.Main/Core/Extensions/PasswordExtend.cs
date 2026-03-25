using System.Windows;
using System.Windows.Controls;

namespace MyToDo.Main.Core.Extensions
{
    public class PasswordExtend
    {
        /// <summary>
        /// 获取附加属性 PasswordEx 的当前值。
        /// </summary>
        /// <param name="obj">要从中读取 PasswordEx 附加属性值的 DependencyObject。</param>
        /// <returns>当前设置的 PasswordEx 字符串值。</returns>
        public static string GetPasswordEx(DependencyObject obj)
        {
            return (string)obj.GetValue(PasswordEx);
        }

        /// <summary>
        /// 设置附加属性 PasswordEx 的值。
        /// </summary>
        /// <param name="obj">要设置 PasswordEx 附加属性值的 DependencyObject。</param>
        /// <param name="value">要设置的字符串值。</param>
        public static void SetPasswordEx(DependencyObject obj, string value)
        {
            obj.SetValue(PasswordEx, value);
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PasswordEx =
            DependencyProperty.RegisterAttached("PasswordEx", typeof(string), typeof(PasswordExtend), new PropertyMetadata(string.Empty, OnPasswordExChanged));

        /// <summary>
        /// 当viewmodel中的pwd属性改变时，执行这个方法
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void OnPasswordExChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            /// <summary>
            /// 处理密码框绑定值更新的逻辑，确保 PasswordBox 的 Password 属性与绑定的新值同步，
            /// 同时避免在设置过程中触发重复的 PasswordChanged 事件。
            /// </summary>
            /// <param name="d">依赖对象，预期为 PasswordBox 类型。</param>
            /// <param name="e">包含旧值和新值的 PropertyChangedEventArgs 或类似事件参数。</param>
            /// <remarks>
            /// 此方法通常用作绑定目标更新的回调函数。通过临时移除事件处理器、更新密码值、再重新附加事件处理器，
            /// 防止因程序性赋值而引发不必要的事件循环。
            /// </remarks>
            PasswordBox password = d as PasswordBox;

            if (password == null)
            {
                return;
            }
            string odlValue = (string)e.OldValue;
            string newValue = (string)e.NewValue;
            // 如果当前 PasswordBox 的密码值与绑定的新值不一致，则同步更新，
            // 并在更新过程中临时禁用 PasswordChanged 事件以避免递归触发。
            if (password.Password != newValue)
            {
                password.PasswordChanged -= HandlePasswordChanged;
                password.Password = newValue;
                password.PasswordChanged += HandlePasswordChanged;
            }
        }

        /// <summary>
        /// 处理 PasswordBox 的 PasswordChanged 事件，将 PasswordBox 的当前密码同步回附加属性 PasswordEx。
        /// </summary>
        /// <param name="sender">触发事件的 PasswordBox 对象。</param>
        /// <param name="e">事件参数。</param>
        private static void HandlePasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox passwordBox = sender as PasswordBox;

            SetPasswordEx(passwordBox, passwordBox.Password);
        }
    }
}
