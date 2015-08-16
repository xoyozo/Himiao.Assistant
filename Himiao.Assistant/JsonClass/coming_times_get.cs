using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Himiao.Assistant.JsonClass
{
  public class coming_times_get
  {
    public List<coming_times_get_list> list { get; set; }
    public result result { get; set; }
  }
  public class coming_times_get_list
  {
    /// <summary>开秒时间</summary>
    public DateTime t { get; set; }

    public DateTime firstTip { get; set; }

    public DateTime lastTip { get; set; }

    /// <summary>是否已第一次提醒（视秒杀商品数多少在秒杀开始前 2 或 3 分钟提醒）</summary>
    public bool? firstTipShown { get; set; }

    /// <summary>是否已第二次提醒（秒杀开始前 1 分钟提醒）</summary>
    public bool? lastTipShown { get; set; }
  }
}
