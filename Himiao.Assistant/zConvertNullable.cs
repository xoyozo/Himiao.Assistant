using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Himiao.Assistant
{
  public class zConvertNullable
  {
    /// <summary>转换为布尔型（失败返回 null）</summary>
    public static Boolean? ToBoolean(object o)
    {
      if (o == null) { return null; }
      Boolean x;
      if (Boolean.TryParse(o.ToString(), out x)) { return x; }
      else { return null; }
    }

    /// <summary>转换为布尔型（true 或 1 视为 True；false 或 0 视为 False；其它视为 null。忽略大小写）</summary>
    /// <returns></returns>
    public static Boolean? ToBoolean_API(object o)
    {
      if (o == null) { return null; }
      switch (o.ToString().Trim().ToLower())
      {
        case "true": return true;
        case "false": return false;
        case "1": return true;
        case "0": return false;
        default: return null;
      }
    }

    /// <summary>转换为 Byte 型（失败返回 null）</summary>
    public static Byte? ToByte(object o)
    {
      if (o == null) { return null; }
      Byte x;
      if (Byte.TryParse(o.ToString(), out x)) { return x; }
      else { return null; }
    }

    /// <summary>转换为 Int16 型（失败返回 null）</summary>
    public static Int16? ToInt16(object o)
    {
      if (o == null) { return null; }
      Int16 x;
      if (Int16.TryParse(o.ToString(), out x)) { return x; }
      else { return null; }
    }

    /// <summary>转换为 Int32 型（失败返回 null）</summary>
    public static Int32? ToInt32(object o)
    {
      if (o == null) { return null; }
      Int32 x;
      if (Int32.TryParse(o.ToString(), out x)) { return x; }
      else { return null; }
    }

    /// <summary>转换为 Int64 型（失败返回 null）</summary>
    public static Int64? ToInt64(object o)
    {
      if (o == null) { return null; }
      Int64 x;
      if (Int64.TryParse(o.ToString(), out x)) { return x; }
      else { return null; }
    }

    /// <summary>转换为 Decimal 型（失败返回 null）</summary>
    public static Decimal? ToDecimal(object o)
    {
      if (o == null) { return null; }
      Decimal x;
      if (Decimal.TryParse(o.ToString(), out x)) { return x; }
      else { return null; }
    }

    /// <summary>转换为 DataTime，失败则返回 null</summary>
    public static DateTime? ToDateTime(object o)
    {
      if (o == null) { return null; }
      DateTime x;
      if (DateTime.TryParse(o.ToString(), out x)) { return x; }
      else { return null; }
    }

    /// <summary>将年月日转换为 DataTime，失败则返回 null</summary>
    public static DateTime? ToDateTime(int y, int M, int d)
    {
      try { return new DateTime(y, M, d); }
      catch { return null; }
    }

  }
}
