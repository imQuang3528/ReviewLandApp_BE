using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Utility
{
    public static class ConvertUtility
    {
        public static readonly DateFormatHandling dateFormatHandling = DateFormatHandling.IsoDateFormat;
        public static readonly DateTimeZoneHandling dateTimeZoneHandling = DateTimeZoneHandling.Local;
        public static readonly NullValueHandling nullValueHandling = NullValueHandling.Include;
        public static readonly ReferenceLoopHandling referenceLoopHandling = ReferenceLoopHandling.Ignore;
        public static readonly string JsonDateFormatString = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffK";

        public static JsonSerializerSettings GetJsonSerializerSettings()
        {
            return new JsonSerializerSettings
            {
                DateFormatHandling = dateFormatHandling,
                DateTimeZoneHandling = dateTimeZoneHandling,
                DateFormatString = JsonDateFormatString,
                NullValueHandling = nullValueHandling,
                ReferenceLoopHandling = referenceLoopHandling
            };
        }

        public static string Serializer(object obj)
        {
            var jsonSerializerSettings = GetJsonSerializerSettings();
            return JsonConvert.SerializeObject(obj, jsonSerializerSettings);
        }

        public static object Deserializer(string json, Type type)
        {
            try
            {
                var jsonSerializerSetting = GetJsonSerializerSettings();
                return JsonConvert.DeserializeObject(json, type, jsonSerializerSetting);
            }
            catch (Exception)
            {
                if (type == typeof(string))
                {
                    return json;
                }
                throw;
            }
        }

        public static string FormFileToBase64(IFormFile formFile)
        {
            string base64Str = "";
            if(formFile != null)
            {
                base64Str = "data:" + formFile.ContentType + ";base64,";
                using(MemoryStream ms=new MemoryStream())
                {
                    formFile.CopyTo(ms);
                    var fileBytes=ms.ToArray();
                    base64Str += Convert.ToBase64String(fileBytes);
                }
            }
            return base64Str;
        }
    }
}
