using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyToDo.Main.Core.Interface
{
    public interface IWindowOperations
    {
        void AttachWindow(Window window);
        void Minimize();
        void MaximizeOrRestore();
        void Close();
    }
}
