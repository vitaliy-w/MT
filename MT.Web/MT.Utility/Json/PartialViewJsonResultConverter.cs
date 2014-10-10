using System;
using System.Globalization;
using System.IO;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace MT.Utility.Json
{
    /// <summary>
    /// Represents the functionality to return the asp.net mvc partial views for asynchronous requests.
    /// </summary>
    public class PartialViewJsonResultConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var result = (PartialViewJsonResult)value;
            writer.WriteValue(RenderRazorViewToString(result));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotSupportedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(PartialViewJsonResult);
        }

        public string RenderRazorViewToString(PartialViewJsonResult result)
        {
            result.ViewData.Model = result.Model;

            using (StringWriter stringWriter = new StringWriter(CultureInfo.InvariantCulture))
            {
                ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(result.ControllerContext, result.ViewName);
                ViewContext viewContext = new ViewContext(result.ControllerContext, viewResult.View, result.ViewData, result.TempData, stringWriter);

                viewResult.View.Render(viewContext, stringWriter);
                viewResult.ViewEngine.ReleaseView(result.ControllerContext, result.View);

                return stringWriter.GetStringBuilder().ToString();
            }
        }

    }

}
