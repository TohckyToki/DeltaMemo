using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace DeltaMemo.Server.Utils
{
  public static class StringEncrypt
  {
    static string encryptKey = "Oyea";

    static string Encrypt(string str)
    {
      DESCryptoServiceProvider descsp = new DESCryptoServiceProvider();

      byte[] key = Encoding.Unicode.GetBytes(encryptKey);

      byte[] data = Encoding.Unicode.GetBytes(str);

      MemoryStream MStream = new MemoryStream();

      CryptoStream CStream = new CryptoStream(MStream, descsp.CreateEncryptor(key, key), CryptoStreamMode.Write);

      CStream.Write(data, 0, data.Length);

      CStream.FlushFinalBlock();

      return Convert.ToBase64String(MStream.ToArray());
    }

    static string Decrypt(string str)
    {
      DESCryptoServiceProvider descsp = new DESCryptoServiceProvider();

      byte[] key = Encoding.Unicode.GetBytes(encryptKey);

      byte[] data = Convert.FromBase64String(str);

      MemoryStream MStream = new MemoryStream();

      CryptoStream CStream = new CryptoStream(MStream, descsp.CreateDecryptor(key, key), CryptoStreamMode.Write);

      CStream.Write(data, 0, data.Length);

      CStream.FlushFinalBlock();

      return Encoding.Unicode.GetString(MStream.ToArray());
    }
  }
}
