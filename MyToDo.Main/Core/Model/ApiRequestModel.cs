using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo.Main.Core.Model
{
    /// <summary>
    /// 发送api请求的内容
    /// </summary>
    public class ApiRequestModel
    {
        /// <summary>
        /// 路由地址 api/Login
        /// </summary>
        public string RequestRoute { get; set; }
        /// <summary>
        /// 请求的方式 get post...
        /// </summary>
        public Method Method { get; set; }
        /// <summary>
        /// 请求的格式 joson image...
        /// </summary>
        public string ContentType { get; set; } = "application/json";
        /// <summary>
        /// 请求的参数
        /// </summary>
        public object RequestParam { get; set; }
    }
}
