using MyToDo.Main.Core.DTOS;
using MyToDo.Main.Core.Events;
using MyToDo.Main.Core.Model;
using MyToDo.Main.Core.Tools;
using Newtonsoft.Json;
using RestSharp;
using System.Diagnostics;
using System.Windows;

namespace MyToDo.Main.ViewModels
{
    public class LoginViewModel : ViewModelBase, IDialogAware
    {
        private HttpClientTool httpClientTool;
        private readonly IEventAggregator _eventAggregator;
        #region ProPerty
        private int _selectedIndex;

        public int SelectedIndex
        {
            get => _selectedIndex;
            set => SetProperty(ref _selectedIndex, value);
        }

        private RegisterInfoDto _registerInfoDto;

        public RegisterInfoDto RegisterInfoDto
        {
            get => _registerInfoDto;
            set => SetProperty(ref _registerInfoDto, value);
        }

        private string _secondPwd;

        public string SecondPwd
        {
            get => _secondPwd;
            set => SetProperty(ref _secondPwd, value);
        }
        private string _pwd;

        public string Pwd
        {
            get => _pwd;
            set => SetProperty(ref _pwd, value, OnPwdChanged);
        }

        private string _accountName;

        public string AccountName
        {
            get => _accountName;
            set => SetProperty(ref _accountName, value);
        }

        private void OnPwdChanged()
        {
        }
        #endregion

        #region Command
        public DelegateCommand LoginCommand { get; set; }
        public DelegateCommand SwitchPageCommand { get; set; }
        public DelegateCommand RegistAccountCommand { get; set; }
        #endregion

        public LoginViewModel(IEventAggregator eventAggregator)
        {
            SelectedIndex = 0;
            LoginCommand = new DelegateCommand(Login);
            SwitchPageCommand = new DelegateCommand(SwitchPage);
            RegistAccountCommand = new DelegateCommand(RegistAccount);
            RegisterInfoDto= new RegisterInfoDto(); 
            httpClientTool = new HttpClientTool();
           _eventAggregator= eventAggregator;
        }

        private void RegistAccount()
        {
            //检查空
            if (RegisterInfoDto.UserName == null || RegisterInfoDto.AccountName == null || RegisterInfoDto.Password == null)
            {
                return;
            }
            if (RegisterInfoDto.Password != SecondPwd)
            {
                //发布消息
                _eventAggregator.GetEvent<MsgEvent>().Publish("两次输入的密码不一致");
               // MessageBox.Show("两次输入的密码不一致");
                return;
            }
            var apiRequestModel = new ApiRequestModel();
            apiRequestModel.Method = Method.Post;
            apiRequestModel.RequestRoute = "Account/Regist";
            apiRequestModel.RequestParam = RegisterInfoDto;

            ApiReponseModel apiResponse = httpClientTool.SendRequest(apiRequestModel);

            if (apiResponse.ResultCode == 1)
            {
                _eventAggregator.GetEvent<MsgEvent>().Publish("注册成功");
                SelectedIndex = 0;
                return;
            }
            else
            {
                _eventAggregator.GetEvent<MsgEvent>().Publish("apiResponse.Msg");
            }
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

            var apiRequestModel = new ApiRequestModel();
            apiRequestModel.Method = Method.Get;

            //api端对应的方法是get请求，需要的参数必须放在路由中
            apiRequestModel.RequestRoute = $"Account/Login?accountName={AccountName}&password={Pwd}";
            //  apiRequestModel.RequestParam = RegisterInfoDto;

            var apiResponse = httpClientTool.SendRequest(apiRequestModel);
            if (apiResponse.ResultCode==1)
            {
                _eventAggregator.GetEvent<MsgEvent>().Publish("登录成功");
                RequestClose.Invoke(new DialogResult(ButtonResult.OK));
            }
            else
            {
                _eventAggregator.GetEvent<MsgEvent>().Publish(apiResponse.Msg);
            }
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
