using MyToDo.Main.Core.Events;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyToDo.Main.Views
{
    /// <summary>
    /// LoginView.xaml 的交互逻辑
    /// </summary>
    public partial class LoginView : UserControl
    {
        private readonly IEventAggregator _eventAggregator;
        public LoginView(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            InitializeComponent();
            _eventAggregator.GetEvent<MsgEvent>().Subscribe(ShowMsg);
        }

        private void ShowMsg(string obj)
        {
            TipBox.MessageQueue.Enqueue(obj);
        }
    }
}
