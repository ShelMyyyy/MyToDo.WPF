using MyToDo.Main.Core.Interface.ViewModel.LeftMenuViewModels;
using MyToDo.Main.Core.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo.Main.ViewModels.LeftMenuViewModels
{
   public class ToDoViewModel:ViewModelBase,IToDoViewModel
    {

        private ObservableCollection<MemoItemModel> todoItems;

        public ObservableCollection<MemoItemModel> TodoItems
        {
            get => todoItems;
            set => SetProperty(ref todoItems, value);
        }

        private bool isChecked;

        public bool IsChecked
        {
            get => isChecked;
            set => SetProperty(ref isChecked, value);
        }


        public ToDoViewModel()
        {
            InitialCommand();
            TodoItems = new ObservableCollection<MemoItemModel>();
            TodoItems.Add(new MemoItemModel() { Title = "Title1", Description = "Description1" });
            TodoItems.Add(new MemoItemModel() { Title = "Title2", Description = "Description2" });
            TodoItems.Add(new MemoItemModel() { Title = "Title3", Description = "Description3" });
            TodoItems.Add(new MemoItemModel() { Title = "Title3", Description = "Description3" });
            TodoItems.Add(new MemoItemModel() { Title = "Title3", Description = "Description3" });
            TodoItems.Add(new MemoItemModel() { Title = "Title3", Description = "Description3" });
            TodoItems.Add(new MemoItemModel() { Title = "Title3", Description = "Description3" });
            TodoItems.Add(new MemoItemModel() { Title = "Title3", Description = "Description3" });
            TodoItems.Add(new MemoItemModel() { Title = "Title3", Description = "Description3" });
            TodoItems.Add(new MemoItemModel() { Title = "Title3", Description = "Description3" });
            TodoItems.Add(new MemoItemModel() { Title = "Title3", Description = "Description3" });
            TodoItems.Add(new MemoItemModel() { Title = "Title3", Description = "Description3" });
            TodoItems.Add(new MemoItemModel() { Title = "Title3", Description = "Description3" });
        }

        public void InitialCommand()
        {
            AddTodoItemCommand=new DelegateCommand(AddTodeItem);
        }

        private void AddTodeItem()
        {
            IsChecked = !IsChecked;
        }

        public DelegateCommand AddTodoItemCommand { get; set;}
    }
}
