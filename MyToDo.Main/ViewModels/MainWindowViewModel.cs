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
        public MainWindowViewModel(IWindowOperations windowOperations)
        {
            _windowOperations = windowOperations;
            MinimizeWindowCommand = new DelegateCommand(MinimizeWindow);
            MaximizeWindowCommand = new DelegateCommand(MaximizeWindow);
            CloseWindowCommand = new DelegateCommand(CloseWindow);

            CreateMenuList();
        }

        private void CreateMenuList()
        {
            LeftMenuItems = new List<MenuItemModel>();
            // 获取应用全局资源（如果资源在页面局部，就用this.Resources）
            var resourceDict = Application.Current.Resources;
            LeftMenuItems.Add(new MenuItemModel { IconSource = resourceDict["HomePageIcon"] as ImageSource, MenuName = "首页" });
            LeftMenuItems.Add(new MenuItemModel { IconSource = resourceDict["ToDoIcon"] as ImageSource, MenuName = "代办事项" });
            LeftMenuItems.Add(new MenuItemModel { IconSource = resourceDict["MemoIcon"] as ImageSource, MenuName = "备忘录" });
            LeftMenuItems.Add(new MenuItemModel { IconSource = resourceDict["SettingIcon"] as ImageSource, MenuName = "设置" });
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
        #endregion
    }
}
