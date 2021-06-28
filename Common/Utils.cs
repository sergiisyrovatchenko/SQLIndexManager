using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace SQLIndexManager {

  public static class Utils {

    public static void ShowErrorFrom(Exception e, string message = "Error") {
      Output.Current.Add($"{message}: {e.Source}", e.Message);
      using (ErrorBox errorBox = new ErrorBox(e)) {
        errorBox.ShowDialog();
      }
    }

    public static string Description(this Enum value) {
      var da = (DescriptionAttribute[])(value.GetType().GetField(value.ToString())).GetCustomAttributes(typeof(DescriptionAttribute), false);
      return da.Length > 0 ? da[0].Description : value.ToString();
    }

    public static T ToEnum<T>(this object value) {
      return (T)Enum.Parse(typeof(T), value.ToString(), true);
    }

    public static T GetValueFromDescription<T>(string description) {
      var type = typeof(T);
      if (!type.IsEnum) throw new InvalidOperationException();
      foreach (var field in type.GetFields()) {
        if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute) {
          if (attribute.Description == description)
            return (T)field.GetValue(null);
        }
        else {
          if (field.Name == description)
            return (T)field.GetValue(null);
        }
      }
      return default(T);
    }

    public static string OnOff(this bool value) {
      return value ? "ON" : "OFF";
    }

    public static bool IsBetween(this int value, int minimum, int maximum) {
      return value >= minimum && value <= maximum;
    }

    public static string Sort(this string value) {
      if (string.IsNullOrEmpty(value))
        return string.Empty;

      return value.Replace("], ", "],").Split(',').ToList().OrderBy(_ => _).Aggregate((_, __) => _ + __);
    }

    public static string Left(this string value, int maxLength) {
      if (string.IsNullOrEmpty(value))
        return value;

      maxLength = Math.Abs(maxLength);
      return value.Length <= maxLength ? value : value.Substring(0, maxLength);
    }

    public static List<string> RemoveInvalidTokens(this List<string> value) {
      List<string> items = new List<string>();
      foreach (string item in value) {
        string t = item.Replace("'", "").Trim();
        if (!string.IsNullOrEmpty(t))
          items.Add(t);
      }
      return items;
    }

    public static string ToQuota(this string value) {
      return $"[{value?.Replace("[", "[[").Replace("]", "]]")}]";
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