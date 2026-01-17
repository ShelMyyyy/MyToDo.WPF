


using System.Diagnostics;

namespace MyToDo.Main.ViewModels
{
    public class LoginViewModel : ViewModelBase, IDialogAware
    {
        #region ProPerty
        private int _selectedIndex;

        public int SelectedIndex
        {
            get => _selectedIndex;
            set => SetProperty(ref _selectedIndex, value);
        }


        private string _pwd;

        public string Pwd
        {
            get => _pwd;
            set => SetProperty(ref _pwd, value,OnPwdChanged);
        }

        private void OnPwdChanged()
        {
            Debug.WriteLine("========" + Pwd);
        }
        #endregion

        #region Command
        public DelegateCommand LoginCommand { get; set; }
        public DelegateCommand SwitchPageCommand { get; set; }
        #endregion

        public LoginViewModel()
        {
            SelectedIndex = 0;
            LoginCommand = new DelegateCommand(Login);
            SwitchPageCommand = new DelegateCommand(SwitchPage);
        }
        /// <summary>
        /// 切换登录和注册界面
        /// </summary>
        private void SwitchPage()
        {
            SelectedIndex = SelectedIndex == 1 ? 0 : 1;
        }

        private void Login()
        {
            // RequestClose.Invoke(new DialogResult(ButtonResult.OK));
            Pwd += "PWD";
        }

        public DialogCloseListener RequestClose { get; set; }
        /// <summary>
        /// 是否可以关闭这个对话框视图
        /// </summary>
        /// <returns></returns>
        public bool CanCloseDialog()
        {
            return true;
        }
        /// <summary>
        /// 对话框关闭后执行的操作
        /// </summary>
        public void OnDialogClosed()
        {

        }
        /// <summary>
        /// 打开对话框时执行的操作
        /// </summary>
        /// <param name="parameters"></param>
        public void OnDialogOpened(IDialogParameters parameters)
        {

        }
    }
}
