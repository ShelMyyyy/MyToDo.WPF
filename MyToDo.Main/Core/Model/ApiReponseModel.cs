using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo.Main.Core.Model
{
    /// <summary>
    /// 请求api后返回的内容
    /// </summary>
    public class ApiReponseModel
    {
        /// <summary>
        /// 结果编码
        /// </summary>
        public int ResultCode { get; set; }
        /// <summary>
        /// 响应信息
        /// </summary>
        public string Msg { get; set; }

        public object ResultData { get; set; }
    }
}
