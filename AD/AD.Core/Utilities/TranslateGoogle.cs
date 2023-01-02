using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Script.Serialization;

namespace AD.Core
{
    public static class TranslateGoogle
    {
        public static string TranslateText(string input, string langOrigin = "us", string langTranslate = "vi")
        {
            string url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl={langOrigin}&tl={langTranslate}&dt=t&q={Uri.EscapeUriString(input)}";
            HttpClient httpClient = new HttpClient();
            string result = httpClient.GetStringAsync(url).Result;
            var jsonData = new JavaScriptSerializer().Deserialize<List<dynamic>>(result);
            var translationItems = jsonData[0];
            string translation = "";
            foreach (object item in translationItems)
            {
                IEnumerable translationLineObject = item as IEnumerable;
                IEnumerator translationLineString = translationLineObject.GetEnumerator();
                translationLineString.MoveNext();
                translation+= $" {Convert.ToString(translationLineString.Current)}";
            }
            if (translation.Length > 1) { translation = translation.Substring(1); };
            return translation;
        }
    }
}
