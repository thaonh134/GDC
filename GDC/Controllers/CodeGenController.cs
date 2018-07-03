using GDC.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
namespace GDC.Controllers
{
    //[RoutePrefix("api/codegen")]
    public class CodeGenController : ApiController
    {
        // thaonh
        /// <summary>
        /// test string: Execute .Return:codegen list
        /// <param name="token"></param>
        /// <returns></returns>
       [HttpPost]
        //    [ActionName("executedemo")]
        //[Route("executedemo") ]

        [Route("api/codegen/demo")]
        public IHttpActionResult Executedemo(JObject json)
        {
            try
            {
                #region Prepare
                //var serializer = new JsonSerializer();
                //serializer.RegisterConverters(new[] { new DynamicJsonConverter() });
                //dynamic Item = serializer.Deserialize(json, typeof(object));


                //dynamic d = JObject.Parse("{number:1000, str:'string', array: [1,2,3,4,5,6]}");
                //dynamic Item = JObject.Parse(json);
                //dynamic Item = JsonConvert.DeserializeObject<dynamic>(json);
                //dynamic d = JObject.Parse(json);
                dynamic Item = json;
                #endregion

                #region Validate
                #endregion

                #region SQL

                #endregion

                #region Log

                #endregion

                #region Process

                //return Json(item);

                #endregion

                var rs = new List<string>();

                if (Item.TypeGen == "DB") rs = CodeGenModel.AutoGenDB(Item);
                else if (Item.TypeGen == "Model") rs = CodeGenModel.AutoGenModel(Item);
                else if (Item.TypeGen == "All")
                {
                    
                    rs = ((List<string>)CodeGenModel.AutoGenDB(Item)).Concat(((List<string>)CodeGenModel.AutoGenModel(Item))).ToList();
                }
                return Json(rs);

            }
            catch (Exception objException)
            {
                return Json(objException);
            }

        }
        [HttpPost]
        [Route("api/codegen/create")]
        public HttpResponseMessage CreateModel([FromBody]CodeGenController app)
        {
            return null;
        }
        // thaonh
        /// <summary>
        /// test string: demo .Return:codegen list
        /// <param name="token"></param>
        /// <returns></returns>
        [Route("demo"), HttpGet]
        public IHttpActionResult Demo(string json)
        {
            return Json(json);
        }
    }
}
