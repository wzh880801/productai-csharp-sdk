using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace ProductAI.API {
    public static class Functions {
        public static byte[] getFileBytes(string filePath) {
            byte[] bytes = null;
            if (!File.Exists(filePath)) {
                throw new Exception("File：" + filePath + "Not Exist!");
            }
            using (FileStream fsSource = new FileStream(filePath,
            FileMode.Open, FileAccess.Read)) {
                bytes = new byte[fsSource.Length];
                int bytesToRead = (int)fsSource.Length;
                int bytesReaded = 0;
                while (bytesToRead > 0) {
                    int n = fsSource.Read(bytes, bytesReaded, bytesToRead);
                    if (0 == n)
                        break;
                    bytesReaded += n;
                    bytesToRead -= n;
                }
            }
            return bytes;
        }

        public static string getFileMd5(byte[] file) {
            byte[] md5Bytes;
            using (MemoryStream stream = new MemoryStream(file)) {
                MD5 md5 = new MD5CryptoServiceProvider();
                md5Bytes = md5.ComputeHash(stream);
            }
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < md5Bytes.Length; i++) {
                sb.Append(md5Bytes[i].ToString("x2"));
            }
            return sb.ToString();
        }

        public static string getTimeStamp() {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }

        public static string shortUuid() {
            return Guid.NewGuid().ToString("N");
        }
    }
}
