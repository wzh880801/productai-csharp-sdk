using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MalongTech.ProductAI.Core
{
    public class FileHelper
    {
        public static string GetBoundary()
        {
            return "---------------------------" + DateTime.Now.Ticks.ToString("x");
        }

        public static string GetContentType(string boundary)
        {
            return "multipart/form-data; boundary=" + boundary;
        }

        public static byte[] GetMultipartBytes(FileInfo file, string boundary, Dictionary<string, string> options, string paraName = "search")
        {
            if (file == null || !file.Exists)
                throw new FileNotFoundException("The image file you specified does not exists.");

            byte[] fileBytes = null;
            try
            {
                fileBytes = File.ReadAllBytes(file.FullName);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Can not read file {0}, make sure you have the permission.", file.FullName), ex);
            }

            var bytes = new List<byte>();
            bytes.AddRange(BoundaryBytes(boundary));
            if (options != null && options.Count > 0)
            {
                foreach (var opt in options)
                    bytes.AddRange(FieldBytes(opt.Key, opt.Value, boundary));
            }
            bytes.AddRange(FileHeaders(file, paraName));
            bytes.AddRange(fileBytes);
            bytes.AddRange(TailBytes(boundary));
            return bytes.ToArray();
        }

        public static byte[] GetMultipartBytes(Stream imageStream, string boundary, Dictionary<string, string> options, string paraName = "search")
        {
            
            if (imageStream == null || imageStream.Length == 0)
                throw new Exception("The image stream couldn't be null.");

            byte[] fileBytes = new byte[imageStream.Length];
            try
            {
                imageStream.Read(fileBytes, 0, fileBytes.Length);
                imageStream.Seek(0, SeekOrigin.Begin);
            }
            catch (Exception ex)
            {
                throw new Exception("Can not read byte from the input stream, make sure you have the permission.", ex);
            }

            var bytes = new List<byte>();
            bytes.AddRange(BoundaryBytes(boundary));
            if (options != null && options.Count > 0)
            {
                foreach (var opt in options)
                    bytes.AddRange(FieldBytes(opt.Key, opt.Value, boundary));
            }
            bytes.AddRange(FileHeaders(GetFileType(fileBytes), paraName));
            bytes.AddRange(fileBytes);
            bytes.AddRange(TailBytes(boundary));
            return bytes.ToArray();
        }

        private static byte[] BoundaryBytes(string boundary)
        {
            return Encoding.UTF8.GetBytes("\r\n--" + boundary + "\r\n");
        }

        private static byte[] FileHeaders(FileInfo file, string paraName = "search")
        {
            string header = "Content-Disposition: form-data;";
            header += string.Format(" name=\"{0}\";", paraName);
            header += string.Format(" filename=\"{0}\"\r\n", file.Name);
            header += string.Format("Content-Type: {0}\r\n\r\n", GetFileType(file));
            return Encoding.UTF8.GetBytes(header);
        }

        private static byte[] FileHeaders(string fileType = "image/jpeg", string paraName = "search")
        {
            var extension = ".jpg";
            if (fileType == "image/jpeg")
                extension = ".jpg";
            else if (fileType == "image/png")
                extension = ".png";
            else if (fileType == "image/gif")
                extension = ".gif";
            else if (fileType == "image/bmp")
                extension = ".bmp";

            string header = "Content-Disposition: form-data;";
            header += string.Format(" name=\"{0}\";", paraName);
            header += string.Format(" filename=\"{0}\"\r\n", Guid.NewGuid().ToString() + extension);
            header += string.Format("Content-Type: {0}\r\n\r\n", fileType);
            return Encoding.UTF8.GetBytes(header);
        }

        private static byte[] FieldBytes(string key, string value, string boundary)
        {
            string field = "Content-Disposition: form-data;";
            field += string.Format(" name=\"{0}\"\r\n\r\n{1}", key, value);
            byte[] fdBytes = Encoding.UTF8.GetBytes(field);
            byte[] bdBytes = BoundaryBytes(boundary);
            var bytes = new List<byte>();
            bytes.AddRange(fdBytes);
            bytes.AddRange(bdBytes);
            return bytes.ToArray();
        }

        private static byte[] TailBytes(string boundary)
        {
            string tail = string.Format("\r\n--{0}--\r\n", boundary);
            return Encoding.UTF8.GetBytes(tail);
        }

        private static string GetFileType(FileInfo _file)
        {
            switch (_file.Extension.ToLower())
            {
                case ".png":
                    return "image/png";
                case ".jpg":
                    return "image/jpeg";
                case ".gif":
                    return "image/gif";
                case ".bmp":
                    return "image/bmp";
                case ".csv":
                    return "application/vnd.ms-excel";
                case ".txt":
                    return "text/plain";
                case ".xlsx":
                    return "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            }

            return "text/plain";
        }

        public static string GetFileType(byte[] fileBytes)
        {
            if (fileBytes != null && fileBytes.Length > 2)
            {
                var fileClass = "";
                for (int i = 0; i < 2; i++)
                {
                    fileClass += fileBytes[i].ToString();
                }

                if (fileClass == "255216")
                    return "image/jpeg";
                else if (fileClass == "7173")//gif
                    return "image/gif";
                else if (fileClass == "13780")//png
                    return "image/png";
                else if (fileClass == "6677")//bmp
                    return "image/bmp";
            }

            return "image/jpeg";
        }
    }
}