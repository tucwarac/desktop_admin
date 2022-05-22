#region Using library
using System;
using System.Configuration;
using System.Net;
using Newtonsoft.Json;
using RestSharp;
using desktop_admin.Models;
using Newtonsoft.Json.Linq;
#endregion

namespace desktop_admin.Helpers
{
    class HttpRestApiHelper
    {
        #region GetPostPutDelete
        public ResponseModel GetPostPutDelete(string action, string apiPath, string enpoint, string token, object data)
        {
            ResponseModel responseModel = new ResponseModel();

            try
            {
                Method method = Method.GET;
                switch (action)
                {
                    case "get":
                        method = Method.GET;
                        break;

                    case "post":
                        method = Method.POST;
                        break;

                    case "put":
                        method = Method.PUT;
                        break;

                    case "delete":
                        method = Method.DELETE;
                        break;
                }

                RestRequest request = new RestRequest(enpoint, method);

                var client = new RestClient(apiPath);

                request.AddJsonBody(data);

                if (token != "")
                {
                    request.AddHeader("Authorization", "Bearer " + token);
                }

                request.Timeout = SystemSettingModel.httpRestApi_timeout;

                IRestResponse response = client.Execute(request);

                if ((response.ErrorException != null) || (response.StatusCode != HttpStatusCode.OK
                    && response.StatusCode != HttpStatusCode.Created))
                {
                    responseModel.status = SystemSettingModel.responseStatus[1];

                    if (response.ErrorException != null)
                    {
                        responseModel.description = string.Format("{0}  {1}", apiPath, response.ErrorException.Message.ToString());
                    }
                    else
                    {
                        responseModel.description = string.Format("{0}  {1}", apiPath, response.StatusCode.ToString());
                    }

                    return responseModel;
                }

                var content = response.Content; // raw content as string
                dynamic result = JsonConvert.DeserializeObject(content);

                responseModel = (ResponseModel)result.ToObject(typeof(ResponseModel));

                return responseModel;
            }
            catch (Exception ex)
            {
                responseModel.status = SystemSettingModel.responseStatus[1];
                responseModel.description = ex.Message;
                return responseModel;
            }
        }
        #endregion
    }
}
