using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SQLIndexManager {

  internal class AES {
    private static readonly byte[] Key1 = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF, 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
    private static readonly byte[] Key2 = Encoding.UTF8.GetBytes("_SQLIndexManager");

    internal static string Encrypt(string content) {
      using (Rijndael des = Rijndael.Create()) {
        var input = Encoding.UTF8.GetBytes(content);
        des.Key = Key2;
        des.IV = Key1;
        using (MemoryStream ms = new MemoryStream()) {
          using (CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write)) {
            cs.Write(input, 0, input.Length);
            cs.FlushFinalBlock();
            var result = ms.ToArray();
            cs.Close();
            ms.Close();
            return Convert.ToBase64String(result);
          }
        }
      }
    }

    internal static string Decrypt(string content) {
      using (Rijndael des = Rijndael.Create()) {
        des.Key = Key2;
        des.IV = Key1;
        var input = Convert.FromBase64String(content);
        var result = new byte[input.Length];
        using (MemoryStream ms = new MemoryStream(input)) {
          using (CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Read)) {
            cs.Read(result, 0, result.Length);
            cs.Close();
            ms.Close();
            return Encoding.UTF8.GetString(result).TrimEnd('\0');
          }
        }
      }
    }
  }

}