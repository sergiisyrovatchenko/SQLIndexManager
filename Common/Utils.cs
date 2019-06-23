using System;
using System.ComponentModel;

namespace SQLIndexManager {

  public static class Utils {

    public static string ToDescription(this Enum value) {
      var da = (DescriptionAttribute[])(value.GetType().GetField(value.ToString())).GetCustomAttributes(typeof(DescriptionAttribute), false);
      return da.Length > 0 ? da[0].Description : value.ToString();
    }

    public static bool IsBetween(this int value, int minimum, int maximum) {
      return value >= minimum && value <= maximum;
    }

    public static string Truncate(this string value, int maxLength) {
      if (string.IsNullOrEmpty(value)) return value;
      return value.Length <= maxLength ? value : value.Substring(0, maxLength);
    }

    public static int PageSize(this int val) {
      return val * 1024 / 8;
    }

    public static string FormatSize(this decimal val) {
      decimal aval = Math.Abs(val);
      string dimension = "KB";

      if (aval > 1024 * 1024 * 1024) {
        val = val / 1024 / 1024 / 1024;
        dimension = "TB";
      }
      else if (aval > 1024 * 1024) {
        val = val / 1024 / 1024;
        dimension = "GB";
      }
      else if (aval > 1024) {
        val = val / 1024;
        dimension = "MB";
      }

      return $"{ (val.ToString(val - Math.Truncate(val) == 0 ? "N0" : "N2")) } {dimension}";
    }

    public static string FormatMbSize(this int val) {
      decimal value = val;
      string dimension = "MB";

      if (value > 1000) {
        value = value / 1024;
        dimension = "GB";
      }

      return $"{ (value.ToString(value - Math.Truncate(value) == 0 ? "N0" : "N2")) } {dimension}";
    }
  }

}