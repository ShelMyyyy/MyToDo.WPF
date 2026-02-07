using MyToDo.Main.Core.Model;
using Newtonsoft.Json;
using RestSharp;
using System.Diagnostics;

namespace MyToDo.Main.Core.Tools
{
    /// <summary>
    /// 发送api请求的工具类
    /// </summary>
    public class HttpClientTool
    {
        private readonly string baseUri;
        public HttpClientTool()
        {
            baseUri = "http://localhost:37694/api/";
        }
        /// <summary>
        /// 发送 REST API 请求并处理响应，将成功响应内容反序列化为 ApiReponseModel 对象。
        /// 若请求失败或状态码非 OK，则返回包含错误信息的默认 ApiReponseModel 实例。
        /// </summary>
        /// <param name="apiRequestModel">封装了请求方法、内容类型及请求参数的模型对象。</param>
        /// <param name="restClient">用于执行 REST 请求的客户端实例。</param>
        /// <returns>
        /// 成功时（HTTP 状态码为 OK）返回反序列化后的 ApiReponseModel 对象；
        /// 失败时返回 ResultCode 为 -99、Msg 为 "位置错误" 的 ApiReponseModel 实例。
        /// </returns>
        public ApiReponseModel SendRequest(ApiRequestModel apiRequestModel)
        {
            var restClient = new RestClient();

            var restRequest = new RestRequest(baseUri+apiRequestModel.RequestRoute);
           
            restRequest.Method = apiRequestModel.Method;
            restRequest.AddHeader("Content-Type", apiRequestModel.ContentType);

            // 如果请求参数不为空，则将其序列化为 JSON 并作为请求体添加到请求中
          
            if (apiRequestModel.RequestParam != null)
            {
                string jsonParam = JsonConvert.SerializeObject(apiRequestModel.RequestParam);
                // 直接添加JSON请求体，无需指定参数名，完美匹配后端[FromBody]接收
                restRequest.AddStringBody(jsonParam, DataFormat.Json);
            }
            var response = restClient.Execute(restRequest);

          
            // 检查响应状态码是否为 HTTP 200 OK，若是则反序列化响应内容
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<ApiReponseModel>(response.Content);
            }

            return new ApiReponseModel { ResultCode = -99, Msg = "未知错误" };
        }
    }
}
