using MyToDo.Main.Core.Interface.ViewModel.LeftMenuViewModels;
using MyToDo.Main.Core.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyToDo.Main.ViewModels.LeftMenuViewModels
{
    public class HomePageViewModel : ViewModelBase, IHomePageViewModel
    {
        #region Property
        private ObservableCollection<CardItemModel> cardItems;

        public ObservableCollection<CardItemModel> CardItems
        {
            get => cardItems;
            set => SetProperty(ref cardItems, value);
        }

        private ObservableCollection<TodoItemModel> todoItems;

        public ObservableCollection<TodoItemModel> TodoItems
        {
            get => todoItems;
            set => SetProperty(ref todoItems, value);
        }
        #endregion


        public HomePageViewModel()
        {
            Initialize();
        }

        private void Initialize()
        {
            CreateCardItems();
            CreateTodoItems();
        }
        /// <summary>
        /// 卡片项
        /// </summary>
        private void CreateCardItems()
        {
            CardItems = new ObservableCollection<CardItemModel>();
            CardItems.Add(new CardItemModel() { CardName = "汇总", Value = "9", Color = "#0ba0fd", IconKey = "HuiZongIcon" });
            CardItems.Add(new CardItemModel() { CardName = "已完成", Value = "9", Color = "#1dca38", IconKey = "CompletedIcon" });
            CardItems.Add(new CardItemModel() { CardName = "完成比例", Value = "9", Color = "#01c7dc", IconKey = "CompletionPercentageIcon" });
            CardItems.Add(new CardItemModel() { CardName = "备忘录", Value = "9", Color = "#fda100", IconKey = "ToDoIcon" });
        }

        public void CreateTodoItems()
        {
            TodoItems = new ObservableCollection<TodoItemModel>();
            TodoItems.Add(new TodoItemModel() { Title = "项目1", Description = "今天要完成一个项目", IsCompleted = false, CreateTime = DateTime.Now });
            TodoItems.Add(new TodoItemModel() { Title = "项目2", Description = "今天要完成一个项目", IsCompleted = false, CreateTime = DateTime.Now });
            TodoItems.Add(new TodoItemModel() { Title = "项目3", Description = "今天要完成一个项目", IsCompleted = false, CreateTime = DateTime.Now });           
        }

        #region Command
        /// <summary>
        /// 新增代办事项
        /// </summary>
        DelegateCommand AddTodoCommand {  get; set; }
        /// <summary>
        /// 新增备忘录事项
        /// </summary>
        DelegateCommand AddMemoCommand {  get; set; }
        #endregion
    }
}
