using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Himiao.Assistant
{
  public class zCanConvert
  {
    /// <summary>Byte：0 到 255</summary>
    public static bool ToByte(object o)
    {
      if (o == null) { return false; }
      Byte x;
      return Byte.TryParse(o.ToString(), out x);
    }
    /// <summary>Int16：-32768 到 +32767</summary>
    public static bool ToInt16(object o)
    {
      if (o == null) { return false; }
      Int16 x;
      return Int16.TryParse(o.ToString(), out x);
    }
    /// <summary>Int32：-21亿 到 +21亿</summary>
    public static bool ToInt32(object o)
    {
      if (o == null) { return false; }
      Int32 x;
      return Int32.TryParse(o.ToString(), out x);
    }
    /// <summary>Int64：-9,223,372,036,854,775,808 到 +9,223,372,036,854,775,807</summary>
    public static bool ToInt64(object o)
    {
      if (o == null) { return false; }
      Int64 x;
      return Int64.TryParse(o.ToString(), out x);
    }
    /// <summary>Decimal</summary>
    public static bool ToDecimal(object o)
    {
      if (o == null) { return false; }
      Decimal x;
      return Decimal.TryParse(o.ToString(), out x);
    }
    /// <summary>是否能转换成数字（即仅由数字组成的字符串）</summary>
    public static bool ToNumeric(object o)
    {
      if (o == null) { return false; }
      foreach (char c in o.ToString())
      {
        if (!Char.IsNumber(c)) { return false; }
      }
      return true;
    }
    /// <summary>DateTime</summary>
    public static bool ToDateTime(object o)
    {
      if (o == null) { return false; }
      DateTime x;
      return DateTime.TryParse(o.ToString(), out x);
    }
    /// <summary>年月日是否能转换成 DateTime</summary>
    public static bool ToDateTime(object y, object M, object d)
    {
      if (y == null || M == null || d == null) { return false; }
      try { new DateTime(Convert.ToInt32(y.ToString()), Convert.ToInt32(M.ToString()), Convert.ToInt32(d.ToString())); return true; }
      catch { return false; }
    }
  }
}
