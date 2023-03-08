using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Utility
{
    public static class ReadFile
    {
        public static T ResultFromReadFile<T>()
        {
            // khai báo folder chứa file ở đây
            string filePath = "";
            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), filePath);
            var resultJson = System.IO.File.ReadAllText(fullPath);
            if (!System.IO.File.Exists(fullPath))
            {
               // return T;
            }
            return JsonConvert.DeserializeObject<T>(resultJson);
        }
    }
}
