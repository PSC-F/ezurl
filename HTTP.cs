
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;

namespace CollectWork.Plugin.PluginName
{
    /************************************************************************************* 
     * 描    述: HTTP扩展类
     * 
     * 版    本：  V1.0
     * 创 建 者： 张鹏飞
     * 创建时间：  2023.9.26
     * ======================================
     * 历史更新记录
     * 版本：V          修改时间：         修改人：
     * 修改内容：
     * ======================================
    *************************************************************************************/
    static class HTPP
    {
        /// <summary>
        /// normal http get request
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>

        public static string GET(this string url)
        {
            using var client = new WebClient();
            return client.DownloadString(url);
        }
        public static string GETByHeaders(this string url, List<Header> headers)
        {
            using var client = new WebClient();
            if (headers != null && headers.Count > 0)
            {
                headers.ForEach(header =>
                {
                    client.Headers.Add(header.K, header.V);
                });
            }

            return client.DownloadString(url);
        }

        public static string POST(this string url, string data)
        {
            using var client = new WebClient();

            return client.UploadString(url, data);
        }
        /// <summary>
        /// use http post by headers 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        public static string POST(this string url, string data, List<Header> headers)
        {
            using var client = new WebClient();
            if (headers != null && headers.Count > 0)
            {
                headers.ForEach(header =>
                {
                    client.Headers.Add(header.K, header.V);
                });
            }
            return client.UploadString(url, data);
        }
        /// <summary>
        /// post by formdata
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <param name="formData"></param>
        /// <returns></returns>
        public static string PostUseFormData(this string url, string data, NameValueCollection formData)
        {
            using var client = new WebClient();
            byte[] responseBytes = client.UploadValues(url, "POST", formData);

            // 将响应转换为字符串
            string responseContent = System.Text.Encoding.UTF8.GetString(responseBytes);
            return responseContent;
        }
        /// <summary>
        /// json strings to JObject
        /// </summary>
        /// <param name="jsonStrs"></param>
        /// <returns></returns>
        public static JObject ToObject(this string jsonStrs)
        {
            return JObject.Parse(jsonStrs);
        }
    }

    /// <summary>
    /// 请求头
    /// </summary>
    class Header
    {
        public string K
        {
            get; set;
        }
        public string V
        {
            get; set;
        }
    }
    class DebugInfo
    {

        public string Url
        {
            get; set;
        }
        public string Response
        {
            get; set;
        }
        public List<Header> HeadersCollection
        {
            get; set;
        }
        public string Param
        {
            get; set;
        }

    }

}
