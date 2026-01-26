using MyToDo.Main.Core.Interface;
using MyToDo.Main.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MyToDo.Main.Views
{
    /// <summary>
    /// MainWindowView.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindowView : Window
    {
        private readonly IWindowOperations _windowOperations;

        // 构造函数注入IWindowOperations实例
        public MainWindowView(IWindowOperations windowOperations)
        {
            InitializeComponent();
            _windowOperations = windowOperations;

            // 关键：将当前窗口实例关联到WindowOperations类
            _windowOperations.AttachWindow(this);
        }

        private void BtnMinimize_Click(object sender, RoutedEventArgs e)
        {
           //this.WindowState = WindowState.Minimized;
        }
    }
}
