using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Himiao.Assistant
{
  public class zConvert
  {
    /// <summary>转换为布尔型（失败返回 false）</summary>
    public static Boolean ToBoolean(object o)
    {
      if (o == null) { return false; }
      Boolean x;
      if (Boolean.TryParse(o.ToString(), out x)) { return x; }
      else { return false; }
    }

    /// <summary>转换为布尔型（true 或 1 视为 True；否则视为 False。忽略大小写）</summary>
    /// <returns></returns>
    public static Boolean ToBoolean_API(object o)
    {
      if (o == null) { return false; }
      switch (o.ToString().Trim().ToLower())
      {
        case "true": return true;
        case "1": return true;
        default: return false;
      }
    }

    /// <summary>转换为 Byte 型（失败返回 0）</summary>
    public static Byte ToByte(object o)
    {
      if (o == null) { return 0; }
      Byte x;
      if (Byte.TryParse(o.ToString(), out x)) { return x; }
      else { return 0; }
    }

    /// <summary>转换为 Int16 型（失败返回 0）</summary>
    public static Int16 ToInt16(object o)
    {
      if (o == null) { return 0; }
      Int16 x;
      if (Int16.TryParse(o.ToString(), out x)) { return x; }
      else { return 0; }
    }

    /// <summary>转换为 Int32 型（失败返回 0）</summary>
    public static Int32 ToInt32(object o)
    {
      if (o == null) { return 0; }
      Int32 x;
      if (Int32.TryParse(o.ToString(), out x)) { return x; }
      else { return 0; }
    }

    /// <summary>转换为 Int64 型（失败返回 0）</summary>
    public static Int64 ToInt64(object o)
    {
      if (o == null) { return 0L; }
      Int64 x;
      if (Int64.TryParse(o.ToString(), out x)) { return x; }
      else { return 0L; }
    }

    /// <summary>转换为 Decimal 型（失败返回 0）</summary>
    public static Decimal ToDecimal(object o)
    {
      if (o == null) { return Decimal.Zero; }
      Decimal x;
      if (Decimal.TryParse(o.ToString(), out x)) { return x; }
      else { return Decimal.Zero; }
    }

    /// <summary>转换为 String 型（失败返回 string.Empty）</summary>
    public static String ToString(object o)
    {
      return o == null ? string.Empty : o.ToString();
    }

    /// <summary>转换为 String 型并 Trim（失败返回 string.Empty）</summary>
    public static String ToStringTrim(object o)
    {
      return o == null ? string.Empty : o.ToString().Trim();
    }

    /// <summary>转换为 DataTime，失败则返回 DateTime.Now</summary>
    public static DateTime ToDateTime(object o)
    {
      if (o == null) { return DateTime.Now; }
      DateTime x;
      if (DateTime.TryParse(o.ToString(), out x)) { return x; }
      else { return DateTime.Now; }
    }

    /// <summary>将年月日转换为 DataTime，失败则抛出异常</summary>
    public static DateTime ToDateTime(int y, int M, int d)
    {
      return new DateTime(y, M, d);
    }

  }
}
