using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MyToDo.Main.Core.Model
{
    /// <summary>
    /// 左侧菜单
    /// </summary>
    public class MenuItemModel
    {
        public string MenuName { get; set; }

        public string ViewName{get; set; }
        public ImageSource IconSource { get; set; }
       
    }
}
