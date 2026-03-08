using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo.Main.Core.Interface.ViewModel
{
    public interface IViewModleBase
    {
        string Title { get; set; }
        int ID { get; set; }
    }
}
