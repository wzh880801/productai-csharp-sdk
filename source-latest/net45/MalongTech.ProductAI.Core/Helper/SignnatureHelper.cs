using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace MalongTech.ProductAI.Core
{
    public class SignnatureHelper
    {
        public static string Signnature(string secretKey, Dictionary<string, string> paras)
        {
            var excludeKeys = new string[] { "x-ca-signature", "x-ca-file-md5" };
            var res = new List<string>();

            var fields = paras.Where(p => !excludeKeys.Contains(p.Key)).OrderBy(p => p.Key).ToDictionary(p => p.Key, p => p.Value);
            foreach (var f in fields)
                res.Add(string.Format("{0}={1}", f.Key, f.Value));

            var urlPairs = string.Join("&", res);
            var hmac = new HMACSHA1()
            {
                Key = Encoding.UTF8.GetBytes(secretKey)
            };
            var hashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(urlPairs));
            return Convert.ToBase64String(hashBytes);
        }
    }
}