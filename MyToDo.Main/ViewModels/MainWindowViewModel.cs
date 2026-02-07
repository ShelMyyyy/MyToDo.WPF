using MyToDo.Main.Core.Interface;
using MyToDo.Main.Core.Model;
using System.Windows;
using System.Windows.Media;

namespace MyToDo.Main.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {


        #region Property

        private List<MenuItemModel> _leftMenuItems;

        public List<MenuItemModel> LeftMenuItems
        {
            get => _leftMenuItems;
            set => SetProperty(ref _leftMenuItems, value);
        }

        #endregion
        private IWindowOperations _windowOperations;
        private IRegionManager _regionManager;
        private IRegionNavigationJournal _journal;
        public MainWindowViewModel(IWindowOperations windowOperations,IRegionManager regionManager)
        {
            _windowOperations = windowOperations;
            _regionManager = regionManager;
            MinimizeWindowCommand = new DelegateCommand(MinimizeWindow);
            MaximizeWindowCommand = new DelegateCommand(MaximizeWindow);
            CloseWindowCommand = new DelegateCommand(CloseWindow);
            NavigationMenuCommond = new DelegateCommand<MenuItemModel>(NavigationMenu);
            GoBackCommand = new DelegateCommand(GoBack);
            GoForWardCommand = new DelegateCommand(GoForWard);

            CreateMenuList();
        }

        private void GoBack()
        {
            if (_journal == null||!_journal.CanGoBack)
            {
                return;
            }
            _journal.GoBack();
        }

        private void GoForWard()
        {

            if (_journal == null || !_journal.CanGoForward)
            {
                return;
            }
            _journal.GoForward();
        }

        private void NavigationMenu(MenuItemModel model)
        {
            if (model == null)
            { 
                return; 
            }
            _regionManager.RequestNavigate("MainViewRegion", model.ViewName, callback =>
            {
                _journal = callback.Context.NavigationService.Journal;
            });
           
        }

        private void CreateMenuList()
        {
            LeftMenuItems = new List<MenuItemModel>();
            // 获取应用全局资源（如果资源在页面局部，就用this.Resources）
            var resourceDict = Application.Current.Resources;
            LeftMenuItems.Add(new MenuItemModel { IconSource = resourceDict["HomePageIcon"] as ImageSource, MenuName = "首页", ViewName="HomePageView" });
            LeftMenuItems.Add(new MenuItemModel { IconSource = resourceDict["ToDoIcon"] as ImageSource, MenuName = "代办事项", ViewName = "ToDoView" });
            LeftMenuItems.Add(new MenuItemModel { IconSource = resourceDict["MemoIcon"] as ImageSource, MenuName = "备忘录", ViewName = "MemoView" });
            LeftMenuItems.Add(new MenuItemModel { IconSource = resourceDict["SettingIcon"] as ImageSource, MenuName = "设置", ViewName = "SettingView" });
        }

        private void CloseWindow()
        {
            _windowOperations.Close();
        }

        private void MaximizeWindow()
        {
            _windowOperations.MaximizeOrRestore();
        }

        private void MinimizeWindow()
        {
            _windowOperations.Minimize();
        }

        #region Command
        public DelegateCommand MinimizeWindowCommand { get; set; }
        public DelegateCommand MaximizeWindowCommand { get; set; }
        public DelegateCommand CloseWindowCommand { get; set; }
        public DelegateCommand<MenuItemModel> NavigationMenuCommond { get; set; }
        public DelegateCommand GoBackCommand { get; set; }
        public DelegateCommand GoForWardCommand { get; set; }

        #endregion
    }
}
