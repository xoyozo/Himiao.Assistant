using Himiao.Assistant.JsonClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;

namespace Himiao.Assistant
{
  public class zTimes
  {
    public static List<coming_times_get_list> Times = new List<coming_times_get_list>();

    /// <summary>
    /// 从接口获取未来的秒杀时刻表
    /// </summary>
    public static void SetTimes()
    {
      string json = zHttp.Get("http://www.himiao.com/api/coming_times.get/");

      JavaScriptSerializer jss = new JavaScriptSerializer();
      coming_times_get ct = jss.Deserialize<coming_times_get>(json);

      if (ct != null && ct.result.success)
      {
        // 用于测试
        //ct.list.Add(new coming_times_get_list
        //{
        //  t = zTime.Now.AddMinutes(2),
        //  firstTip = zTime.Now.AddMinutes(0),
        //  lastTip = zTime.Now.AddMinutes(1),
        //});

        foreach (coming_times_get_list item in ct.list)
        {
          coming_times_get_list old = Times.SingleOrDefault(c => c.t == item.t);

          if (old != null)
          {
            item.firstTipShown = old.firstTipShown;
            item.lastTipShown = old.lastTipShown;
          }
        }

        Times = ct.list;
      }
    }

    /// <summary>
    /// 获取本分钟内需提醒的项，并标记已提醒
    /// Key：秒杀时间；Value：剩余分钟数
    /// </summary>
    public static KeyValuePair<DateTime, int>? GetTipTimeInMinute()
    {
      DateTime m = zTime.Now;
      m = m.Date.AddHours(m.Hour).AddMinutes(m.Minute);

      // 先找需要最后一次提醒的秒杀
      coming_times_get_list item = zTimes.Times.FirstOrDefault(c => c.lastTipShown != true && c.lastTip >= m && c.lastTip < m.AddMinutes(1));
      if (item != null)
      {
        item.lastTipShown = true;
        return new KeyValuePair<DateTime, int>(item.t, (item.t - item.lastTip).Minutes);
      }

      // 再找首次提醒的秒杀
      item = zTimes.Times.FirstOrDefault(c => c.firstTipShown != true && c.firstTip >= m && c.firstTip < m.AddMinutes(1));
      if (item != null)
      {
        item.firstTipShown = true;
        return new KeyValuePair<DateTime, int>(item.t, (item.t - item.firstTip).Minutes);
      }

      return null;
    }
    /// <summary>
    /// 本分钟是否有秒杀
    /// </summary>
    public static bool HaveOnInMinute
    {
      get
      {
        DateTime m = zTime.Now;
        m = m.Date.AddHours(m.Hour).AddMinutes(m.Minute);
        return zTimes.Times.Any(c => c.t >= m && c.t < m.AddMinutes(1));
      }
    }
    /// <summary>
    /// 最近的秒杀时间
    /// </summary>
    public static DateTime? ComingTime
    {
      get
      {
        return zTimes.Times.Where(c => c.t >= zTime.Now).Select(c => (DateTime?)c.t).Min();
      }
    }
  }
}
