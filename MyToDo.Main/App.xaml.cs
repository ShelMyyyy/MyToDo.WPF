using MyToDo.Main.Common.Service;
using MyToDo.Main.Core.Interface;
using MyToDo.Main.Core.Tools;
using MyToDo.Main.ViewModels;
using MyToDo.Main.ViewModels.LeftMenuViewModels;
using MyToDo.Main.Views;
using MyToDo.Main.Views.LeftMenuViews;
using System.Configuration;
using System.Data;
using System.Windows;

namespace MyToDo.Main
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        /// <summary>
        /// 设置启动窗口
        /// </summary>
        /// <returns></returns>
        protected override Window CreateShell()
        {
          return Container.Resolve<MainWindowView>();
        }
        /// <summary>
        /// 用来注册需要的服务
        /// </summary>
        /// <param name="containerRegistry"></param>
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterDialog<LoginView,LoginViewModel>();
            // 关键：注册IWindowOperations到你单独定义的WindowOperations类（单例）
            containerRegistry.RegisterSingleton<IWindowOperations, WindowOperations>();

            containerRegistry.RegisterForNavigation<HomePageView, HomePageViewModel>();
            containerRegistry.RegisterForNavigation<MemoView, MemoViewModel>();
            containerRegistry.RegisterForNavigation<ToDoView, ToDoViewModel>();
            containerRegistry.RegisterForNavigation<SettingView, SettingViewfModel>();
        }

    /*    protected override void OnInitialized()
        {
            var dialog = Container.Resolve<IDialogService>();
            dialog.ShowDialog("LoginView", callback =>
            {
                if(callback.Result!=ButtonResult.OK)
                {
                    Environment.Exit(0);
                    return;
                }
            });
            base.OnInitialized();
        }*/
    }

}
