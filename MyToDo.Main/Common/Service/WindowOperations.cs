using MyToDo.Main.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyToDo.Main.Common.Service
{
    public class WindowOperations : IWindowOperations
    {
        // 用弱引用避免内存泄漏（窗口关闭后自动释放）
        private WeakReference<Window> _windowRef;

        /// <summary>
        /// 关联要操作的窗口
        /// </summary>
        /// <param name="window">要操作的窗口实例</param>
        public void AttachWindow(Window window)
        {
            if (window == null)
                throw new ArgumentNullException(nameof(window));
            _windowRef = new WeakReference<Window>(window);
        }
        public void Minimize()
        {
            if (_windowRef?.TryGetTarget(out Window window) == true)
            {
                window.WindowState = WindowState.Minimized;
            }
            else
            {
                throw new InvalidOperationException("未关联窗口实例，无法执行最小化操作");
            }
        }

        public void MaximizeOrRestore()
        {
            if (_windowRef?.TryGetTarget(out Window window) == true)
            {
                window.WindowState = window.WindowState == WindowState.Maximized
                    ? WindowState.Normal
                    : WindowState.Maximized;
            }
            else
            {
                throw new InvalidOperationException("未关联窗口实例，无法执行最大化/还原操作");
            }
        }

        public void Close()
        {
            if (_windowRef?.TryGetTarget(out Window window) == true)
            {
                window.Close();
            }
            else
            {
                throw new InvalidOperationException("未关联窗口实例，无法执行关闭操作");
            }
        }
    }
}
