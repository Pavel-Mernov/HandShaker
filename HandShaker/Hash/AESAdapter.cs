﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HandShaker.Hash
{
    public static class AESAdapter
    {
        private static readonly Aes _aes = Aes.Create();

        public static string EncodeAES(this string data, string key, Encoding encoding)
        {
            if (string.IsNullOrEmpty(data))
            {
                return string.Empty;
            }

            _aes.Key = encoding.GetBytes(key);
            _aes.IV = Array.Empty<byte>();

            var dataBytes = encoding.GetBytes(data);

            byte[] resultBytes;

            var encryptor = _aes.CreateEncryptor(_aes.Key, _aes.IV);

            using (var msEncrypt = new MemoryStream())
            {
                using (var csEncrypt =  new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (var swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(data);
                    }
                    resultBytes = msEncrypt.ToArray();
                }
            }

            return encoding.GetString(resultBytes);
        }

        // public static string EncodeAES(this object obj, string key, Encoding encoding) => EncodeAES(obj.ToString(), key, encoding);

        public static string EncodeAES(this string data, string key) => EncodeAES(data, key, Encoding.UTF8);

        // public static string EncodeAES(this object obj, string key) => EncodeAES(obj.ToString(), key, Encoding.UTF8);

        public static string DecodeAES(this string data, string key, Encoding encoding)
        {
            if (string.IsNullOrEmpty(data))
            {
                return string.Empty;
            }

            _aes.Key = Encoding.UTF8.GetBytes(key);

            var IVBytes = new byte[16];
            for (int i = 0; i < IVBytes.Length; i++)
            {
                IVBytes[i] = (byte)' ';
            }

            _aes.IV = IVBytes;

            var dataBytes = encoding.GetBytes(data);

            var decryptor = _aes.CreateDecryptor(_aes.Key, _aes.IV);

            var result = string.Empty;

            using (var msDecrypt = new MemoryStream(dataBytes))
            {
                var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
                var srDecrypt = new StreamReader(csDecrypt);
                result = srDecrypt.ReadToEnd();
            }

            return result;
        }

        public static string DecodeAES(this string data, string key) => DecodeAES(data, key, Encoding.UTF8);
    }
}
