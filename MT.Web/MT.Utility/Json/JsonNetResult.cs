using System;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace MT.Utility.Json
{
    /// <summary>
    /// Represents a object to return as action result json structure.
    /// </summary>
    public class JsonNetResult : ActionResult
    {
        public static JsonSerializerSettings DefaultSerializerSettings { get; set; }

        public object Data { get; set; }
        public int StatusCode { get; set; }

        public JsonSerializerSettings SerializerSettings { get; set; }

        public JsonRequestBehavior JsonRequestBehavior { get; set; }

        public Encoding ContentEncoding { get; set; }
        public string ContentType { get; set; }

        static JsonNetResult()
        {
            DefaultSerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Converters =
                    new JsonConverter[]
                    {
                        new StringEnumConverter {CamelCaseText = true}, new PartialViewJsonResultConverter(),
                        new IsoDateTimeConverter {DateTimeFormat = "yyyy-MM-dd"}
                    },
            };
        }

        public JsonNetResult()
        {
            StatusCode = (int) HttpStatusCode.OK;
        }

        public JsonNetResult(object data)
            : this(data, HttpStatusCode.OK)
        {
        }

        public JsonNetResult(object data, bool isLegacySerializaion)
            : this(data, HttpStatusCode.OK)
        {
            if (isLegacySerializaion)
            {
                SerializerSettings = JsonExtensions.LegacyJsonSettings;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed")]
        public JsonNetResult(object data, HttpStatusCode statusCode)
            : this()
        {
            Data = data;
            StatusCode = (int) statusCode;
        }

        public JsonNetResult(object data, HttpStatusCode statusCode, JsonRequestBehavior jsonRequestBehavior)
            : this()
        {
            Data = data;
            StatusCode = (int) statusCode;
            JsonRequestBehavior = jsonRequestBehavior;
        }

        public JsonNetResult(object data, JsonRequestBehavior jsonRequestBehavior)
            : this(data)
        {
            JsonRequestBehavior = jsonRequestBehavior;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            if (JsonRequestBehavior == JsonRequestBehavior.DenyGet &&
                string.Equals(context.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("JsonRequest_GetNotAllowed");
            }

            HttpResponseBase response = context.HttpContext.Response;

            response.ContentType = !string.IsNullOrEmpty(ContentType) ? ContentType : "application/json";
            response.StatusCode = StatusCode;
            if (ContentEncoding != null)
            {
                response.ContentEncoding = ContentEncoding;
            }

            if (Data != null)
            {
                response.Write(Json);
            }
        }

        public string Json
        {
            get { return Data.ToJson(SerializerSettings ?? DefaultSerializerSettings); }
        }
    }
}
