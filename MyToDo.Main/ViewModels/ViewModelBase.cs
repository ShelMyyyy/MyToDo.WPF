using MyToDo.Main.Core.Interface.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo.Main.ViewModels
{
  public  class ViewModelBase:BindableBase, IViewModleBase
    {
		private int id;

		public int ID
		{
			get => id;
			set => SetProperty(ref id, value);
		}


        private string title;

        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }

    }
}
