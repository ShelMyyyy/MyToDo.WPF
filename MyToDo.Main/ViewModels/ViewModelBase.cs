using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo.Main.ViewModels
{
  public  class ViewModelBase:BindableBase
    {
		private int id;

		public int ID
		{
			get => id;
			set => SetProperty(ref id, value);
		}

	}
}
