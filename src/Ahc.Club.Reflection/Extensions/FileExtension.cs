using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Ahc.Club.Reflection.Extensions
{
    public static class FileExtension
    {
        public static string GetBase64Data (this string path)
        {
            byte[] byteArray = File.ReadAllBytes(path);
            return Convert.ToBase64String(byteArray);
        }

        public static string GetFileName(this string path)
        {
            if (string.IsNullOrEmpty(path))
                return string.Empty;

            var array = path.Split('/');
            return array.LastOrDefault();
        }

        public static string GetFileType(this string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                return "";

            var array = fileName.Split('.');

            return array.LastOrDefault();

        }
    }
}
