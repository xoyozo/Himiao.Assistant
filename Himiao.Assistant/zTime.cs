using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Himiao.Assistant
{
  public class zTime
  {
    /// <summary>淘宝等站服务器时间与本机时间的差的最小值</summary>
    public static TimeSpan? ts = null;

    /// <summary>嗨秒服务器时间与本机时间的差</summary>
    public static TimeSpan? ts_himiao = null;

    /// <summary>
    /// 获取当前时间
    /// </summary>
    public static DateTime Now
    {
      get
      {
        return ts.HasValue ? DateTime.Now.Add(ts.Value) : DateTime.Now;
      }
    }

    /// <summary>
    /// 设置当前时间（从淘宝、天猫、聚划算等站获得服务器时间的最小值）
    /// </summary>
    public static void SetTime()
    {
      // 先获取嗨秒服务器时间，用于判断以下各站获取到的时间是否误差过大
      TimeSpan? ts_himiao = GetHeaderDate("http://www.himiao.com/api/assistant/time_ticks.get/");
      // 若获取失败直接返回
      if (!ts_himiao.HasValue) { return; }

      // 获取各站时间
      TimeSpan? ts_taobao = GetHeaderDate("https://www.taobao.com/");
      TimeSpan? ts_tmall = GetHeaderDate("https://www.tmall.com/");
      TimeSpan? ts_juhuasuan = GetHeaderDate("https://ju.taobao.com/");

      // 与嗨秒时间相差 1 分钟以上的弃用，原因可能是静态页，其 Header["Date"] 是早前的时间
      if (ts_taobao.HasValue && (ts_taobao.Value - ts_himiao.Value).Duration() > new TimeSpan(0, 1, 0)) { ts_taobao = null; }
      if (ts_tmall.HasValue && (ts_tmall.Value - ts_himiao.Value).Duration() > new TimeSpan(0, 1, 0)) { ts_tmall = null; }
      if (ts_juhuasuan.HasValue && (ts_juhuasuan.Value - ts_himiao.Value).Duration() > new TimeSpan(0, 1, 0)) { ts_juhuasuan = null; }

      // 取各站的最小时间
      ts = new List<TimeSpan?> { ts_taobao, ts_tmall, ts_juhuasuan }.Where(c => c.HasValue).Min();
    }

    /// <summary>
    /// 获取网页的 Header["Date"] 并转化为与本地时间的差
    /// </summary>
    /// <param name="url">要保证传入网址的 Header["Date"] 是即时更新的</param>
    /// <returns></returns>
    private static TimeSpan? GetHeaderDate(string url)
    {
      DateTime dt1 = DateTime.Now;
      DateTime? headerDate = zConvertNullable.ToDateTime(zHttp.Get(url, null, null, null, null, null, false, "Date", null));
      DateTime dt2 = DateTime.Now;

      // 若无法获取 Header["Date"]
      if (!headerDate.HasValue) { return null; }

      // 若执行超过 3 秒则废弃
      if (dt2 > dt1.AddSeconds(3)) { return null; }

      // 减掉半个执行时间
      headerDate = headerDate.Value.Add(dt1 - dt2);

      return headerDate.Value - DateTime.Now;
    }
  }
}
