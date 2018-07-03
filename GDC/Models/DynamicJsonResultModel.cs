using System;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
namespace GDC.Models {

    /// <summary>
    /// Implements a JsonResult that uses NewtonSoft JSON.NET instead of the built-in MVC Json Serializer.
    /// </summary>
    /// <remarks>
    /// JSON.NET "just works" with dynamic objects, whereas the built-in serializer by default will serialize
    /// as a dictionary of "key": "mykey", "value" : "myvalue"  pairs.   You *can* get it to serialize dynamic
    /// properties but you have to jump through hoops.
    /// </remarks>
    public class DynamicJsonResult : ActionResult
    {
        public Encoding ContentEncoding { get; set; }
        public string ContentType { get; set; }
        public object Data { get; set; }
        public JsonSerializerSettings SerializerSettings { get; set; }
        public Formatting Formatting { get; set; }

        public DynamicJsonResult()
        {
            SerializerSettings = new JsonSerializerSettings();
        }

        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null) throw new ArgumentNullException("context");
            HttpResponseBase response = context.HttpContext.Response;
            response.ContentType = !string.IsNullOrEmpty(ContentType) ? ContentType : "application/json";

            if (ContentEncoding != null) response.ContentEncoding = ContentEncoding;

            if (Data != null)
            {
                // using Json.NET to serialize
                var writer = new JsonTextWriter(response.Output) { Formatting = Formatting };
                var serializer = JsonSerializer.Create(SerializerSettings);
                serializer.Serialize(writer, Data);
                writer.Flush();
            }
        }
    }

}
