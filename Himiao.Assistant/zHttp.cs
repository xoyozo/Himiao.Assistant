using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Himiao.Assistant
{
  public class zHttp
  {
    public static string Get(
      string url,
      object parameters = null,
      Encoding encode = null,
      string cookie = null,
      string referer = null,
      string userAgent = null,
      bool? allowAutoRedirect = null,
      string returnHeadersValue = null,
      bool? returnExceptionMessageIfError = null)
    {
      return Request(WebRequestMethods.Http.Get, url, parameters, encode, cookie, referer, userAgent, allowAutoRedirect, returnHeadersValue, returnExceptionMessageIfError);
    }

    public static string Post(
      string url,
      object parameters = null,
      Encoding encode = null,
      string cookie = null,
      string referer = null,
      string userAgent = null,
      bool? allowAutoRedirect = null,
      string returnHeadersValue = null,
      bool? returnExceptionMessageIfError = null)
    {
      return Request(WebRequestMethods.Http.Post, url, parameters, encode, cookie, referer, userAgent, allowAutoRedirect, returnHeadersValue, returnExceptionMessageIfError);
    }

    /// <summary>
    /// 执行 HttpWebRequest 请求
    /// </summary>
    /// <param name="method">协议方法的类型 WebRequestMethods.Http.XXX</param>
    private static string Request(
      string method,
      string url,
      object parameters = null,
      Encoding encode = null,
      string cookie = null,
      string referer = null,
      string userAgent = null,
      bool? allowAutoRedirect = null,
      string returnHeadersValue = null,
      bool? returnExceptionMessageIfError = null)
    {
      // 验证 URL
      if (string.IsNullOrEmpty(url) || !Regex.IsMatch(url, @"^https?\:\/\/[^/].+", RegexOptions.IgnoreCase))
      {
        return returnExceptionMessageIfError == true ? "无法识别该 URI 前缀。" : string.Empty;
      }

      try
      {
        url = new Uri(url).ToString(); // 此步会将“http://www.baidu.com”变成“http://www.baidu.com/”

        //// 配置请求

        // 拼接参数
        string ps = joinParameters(parameters);

        if (method == WebRequestMethods.Http.Get && ps.Length > 0)
        {
          url += (url.Contains("?") ? "&" : "?") + ps;
        }

        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
        req.Method = method;
        req.Headers.Set("Cache-Control", "no-cache");
        req.Headers.Set("Pragma", "no-cache");

        if (!string.IsNullOrWhiteSpace(cookie)) { req.Headers["Cookie"] = cookie; }
        if (!string.IsNullOrWhiteSpace(referer)) { req.Referer = referer; }
        if (!string.IsNullOrWhiteSpace(userAgent)) { req.UserAgent = userAgent; }
        if (allowAutoRedirect == false) { req.AllowAutoRedirect = false; }

        if (method == WebRequestMethods.Http.Post)
        {
          // ！！！写入 Post 内容必须放在所有设置之后，不然会导致设置 Referer 无效
          req.ContentLength = ps.Length;
          req.ContentType = "application/x-www-form-urlencoded";
          StreamWriter writer = new StreamWriter(req.GetRequestStream());
          writer.Write(ps);
          writer.Close();
        }

        //// 执行请求

        HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

        if (!string.IsNullOrWhiteSpace(returnHeadersValue))
        {
          return resp.Headers[returnHeadersValue];
        }

        Encoding pageEncoding = encode != null ? encode : (string.IsNullOrWhiteSpace(resp.CharacterSet) ? Encoding.UTF8 : Encoding.GetEncoding(resp.CharacterSet));
        Stream receiveStream = resp.GetResponseStream();
        StreamReader readStream = new StreamReader(receiveStream, pageEncoding);
        return readStream.ReadToEnd();
      }
      catch (Exception ex)
      {
        return returnExceptionMessageIfError == true ? ex.Message : string.Empty;
      }
    }

    /// <summary>
    /// 拼接 GET/POST 参数，返回示例：a=1&b=2&c=3
    /// <param name="parameters">GET / POST 参数（允许 Dictionary&lt;string, object&gt; 字典、已拼接的字符串、类 或 null）</param>
    /// </summary>
    public static string joinParameters(object parameters)
    {
      if (parameters == null) { return string.Empty; }

      string q = string.Empty;

      Type type = parameters.GetType();

      // 字典
      if (type == typeof(Dictionary<string, object>) || type == typeof(Dictionary<string, string>))
      {
        foreach (KeyValuePair<string, object> kv in parameters as Dictionary<string, object>)
        {
          if (kv.Value != null)
          {
            q += "&" + HttpUtility.UrlEncode(kv.Key) + "=" + HttpUtility.UrlEncode(kv.Value.ToString());
          }
        }
        if (q.Length > 0) { q = q.Substring(1); }
      }
      // 字符串
      else if (type == typeof(string))
      {
        q = parameters as string;
      }
      // 类
      else if (type.IsClass)
      {
        foreach (System.Reflection.PropertyInfo p in type.GetProperties())
        {
          if (p.GetValue(parameters, null) != null)
          {
            q += "&" + HttpUtility.UrlEncode(p.Name) + "=" + HttpUtility.UrlEncode(p.GetValue(parameters, null).ToString());
          }
        }
        if (q.Length > 0) { q = q.Substring(1); }
      }

      return q;
    }
  }
}
