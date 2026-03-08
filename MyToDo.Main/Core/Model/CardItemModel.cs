using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo.Main.Core.Model
{
    public class CardItemModel
    {
        public int Id { get; set; }
        public string CardName { get; set; }
        public string Color { get; set; }
        public string Value { get; set; }
        public string IconKey { get; set; }
    }
}
