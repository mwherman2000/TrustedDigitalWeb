#pragma warning disable 162,168,649,660,661,1522

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Trinity;
using Trinity.Network;
using Trinity.Network.Http;
using Trinity.TSL;
using Trinity.TSL.Lib;
namespace TDW.KMAServer
{
    #region Server
    
    public abstract partial class TDWKMAServiceBase : TrinityServer
    {
        #region Handler lookup table
        private static Dictionary<string, uint> s_HttpHandlerLookupTable = new Dictionary<string, uint>
        {
            
            { "CreateKeyPair", 1  }
            ,
            { "GetBestKeyPair", 2  }
            ,
            { "ComputePayloadHash", 3  }
            ,
            { "ComputeHashKeyPairSignature", 4  }
            ,
            { "ValidateHashKeyPairSignature", 5  }
            ,
        };
        #endregion
        
        public abstract void CreateKeyPairHandler(KMACreateKeyPairRequest request, out KMAKeyPairResponse response);
        
        public abstract void GetBestKeyPairHandler(KMAGetBestKeyPairRequest request, out KMAKeyPairResponse response);
        
        public abstract void ComputePayloadHashHandler(KMAComputePayloadHashRequest request, out KMAPayloadHashResponse response);
        
        public abstract void ComputeHashKeyPairSignatureHandler(KMAComputeHashKeyPairSignatureRequest request, out KMAHashKeyPairSignatureResponse response);
        
        public abstract void ValidateHashKeyPairSignatureHandler(KMAValidateHashKeyPairSignatureRequest request, out KMAValidateHashKeyPairSignatureResponse response);
        
        /// <summary>
        /// Processes requests on the root endpoint. By default it
        /// will list available API endpoints in html.
        /// Override this method to get custom behaviors.
        /// </summary>
        /// <param name="ctx">A <see cref="HttpListenerContext"/> object.</param>
        protected override void RootHttpHandler(HttpListenerContext ctx)
        {
            CommonHttpHandlers.ListAvailableEndpoints(ctx, s_HttpHandlerLookupTable.Keys, this.GetType());
        }
        protected override void DispatchHttpRequest(HttpListenerContext context, string endpoint_name, string url)
        {
            var method          = context.Request.HttpMethod;
            uint handler_id     = 0;
            if (!s_HttpHandlerLookupTable.TryGetValue(endpoint_name, out handler_id))
            {
                CommonHttpHandlers.PageNotFound(context);
                RootHttpHandler(context);
                return;
            }
            var querystring_idx = url.IndexOf('?');
            switch (handler_id)
            {
                
                case  1 :
                    {
                        
                        string          json_string;
                        KMACreateKeyPairRequest   request_struct;
                        if (method == "GET")
                        {
                            if (querystring_idx == -1)
                                json_string = url;
                            else
                                json_string = url.Substring(0, querystring_idx);
                        }
                        else if (method == "POST")
                        {
                            using (var sr = new System.IO.StreamReader(context.Request.InputStream))
                                json_string = sr.ReadToEnd();
                        }
                        else
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                            return;
                        }
                        if (!KMACreateKeyPairRequest.TryParse(json_string, out request_struct))
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                            return;
                        }
                        KMAKeyPairResponse   response_struct ;
                        CreateKeyPairHandler(request_struct, out response_struct);
                        
                        context.Response.ContentType = "application/json";
                        string jsonp_callback  = context.Request.QueryString["jsonp_callback"] ?? context.Request.QueryString["callback"];
                        string iframe_callback = context.Request.QueryString["iframe_callback"];
                        using (var sw = new System.IO.StreamWriter(context.Response.OutputStream))
                        {
                            if (jsonp_callback != null)
                            {
                                sw.Write("{0}(", jsonp_callback);
                                sw.Write(Serializer.ToString(response_struct));
                                sw.Write(");", jsonp_callback);
                            }
                            else if (iframe_callback != null)
                            {
                                context.Response.ContentType = "text/html";
                                sw.Write("<script language=\"javascript\" type=\"text/javascript\">window.top.window.{0}(", iframe_callback);
                                sw.Write(Serializer.ToString(response_struct));
                                sw.Write(");</script>");
                            }
                            else
                            {
                                sw.Write(Serializer.ToString(response_struct));
                            }
                        }
                        
                    }
                    break;
                
                case  2 :
                    {
                        
                        string          json_string;
                        KMAGetBestKeyPairRequest   request_struct;
                        if (method == "GET")
                        {
                            if (querystring_idx == -1)
                                json_string = url;
                            else
                                json_string = url.Substring(0, querystring_idx);
                        }
                        else if (method == "POST")
                        {
                            using (var sr = new System.IO.StreamReader(context.Request.InputStream))
                                json_string = sr.ReadToEnd();
                        }
                        else
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                            return;
                        }
                        if (!KMAGetBestKeyPairRequest.TryParse(json_string, out request_struct))
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                            return;
                        }
                        KMAKeyPairResponse   response_struct ;
                        GetBestKeyPairHandler(request_struct, out response_struct);
                        
                        context.Response.ContentType = "application/json";
                        string jsonp_callback  = context.Request.QueryString["jsonp_callback"] ?? context.Request.QueryString["callback"];
                        string iframe_callback = context.Request.QueryString["iframe_callback"];
                        using (var sw = new System.IO.StreamWriter(context.Response.OutputStream))
                        {
                            if (jsonp_callback != null)
                            {
                                sw.Write("{0}(", jsonp_callback);
                                sw.Write(Serializer.ToString(response_struct));
                                sw.Write(");", jsonp_callback);
                            }
                            else if (iframe_callback != null)
                            {
                                context.Response.ContentType = "text/html";
                                sw.Write("<script language=\"javascript\" type=\"text/javascript\">window.top.window.{0}(", iframe_callback);
                                sw.Write(Serializer.ToString(response_struct));
                                sw.Write(");</script>");
                            }
                            else
                            {
                                sw.Write(Serializer.ToString(response_struct));
                            }
                        }
                        
                    }
                    break;
                
                case  3 :
                    {
                        
                        string          json_string;
                        KMAComputePayloadHashRequest   request_struct;
                        if (method == "GET")
                        {
                            if (querystring_idx == -1)
                                json_string = url;
                            else
                                json_string = url.Substring(0, querystring_idx);
                        }
                        else if (method == "POST")
                        {
                            using (var sr = new System.IO.StreamReader(context.Request.InputStream))
                                json_string = sr.ReadToEnd();
                        }
                        else
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                            return;
                        }
                        if (!KMAComputePayloadHashRequest.TryParse(json_string, out request_struct))
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                            return;
                        }
                        KMAPayloadHashResponse   response_struct ;
                        ComputePayloadHashHandler(request_struct, out response_struct);
                        
                        context.Response.ContentType = "application/json";
                        string jsonp_callback  = context.Request.QueryString["jsonp_callback"] ?? context.Request.QueryString["callback"];
                        string iframe_callback = context.Request.QueryString["iframe_callback"];
                        using (var sw = new System.IO.StreamWriter(context.Response.OutputStream))
                        {
                            if (jsonp_callback != null)
                            {
                                sw.Write("{0}(", jsonp_callback);
                                sw.Write(Serializer.ToString(response_struct));
                                sw.Write(");", jsonp_callback);
                            }
                            else if (iframe_callback != null)
                            {
                                context.Response.ContentType = "text/html";
                                sw.Write("<script language=\"javascript\" type=\"text/javascript\">window.top.window.{0}(", iframe_callback);
                                sw.Write(Serializer.ToString(response_struct));
                                sw.Write(");</script>");
                            }
                            else
                            {
                                sw.Write(Serializer.ToString(response_struct));
                            }
                        }
                        
                    }
                    break;
                
                case  4 :
                    {
                        
                        string          json_string;
                        KMAComputeHashKeyPairSignatureRequest   request_struct;
                        if (method == "GET")
                        {
                            if (querystring_idx == -1)
                                json_string = url;
                            else
                                json_string = url.Substring(0, querystring_idx);
                        }
                        else if (method == "POST")
                        {
                            using (var sr = new System.IO.StreamReader(context.Request.InputStream))
                                json_string = sr.ReadToEnd();
                        }
                        else
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                            return;
                        }
                        if (!KMAComputeHashKeyPairSignatureRequest.TryParse(json_string, out request_struct))
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                            return;
                        }
                        KMAHashKeyPairSignatureResponse   response_struct ;
                        ComputeHashKeyPairSignatureHandler(request_struct, out response_struct);
                        
                        context.Response.ContentType = "application/json";
                        string jsonp_callback  = context.Request.QueryString["jsonp_callback"] ?? context.Request.QueryString["callback"];
                        string iframe_callback = context.Request.QueryString["iframe_callback"];
                        using (var sw = new System.IO.StreamWriter(context.Response.OutputStream))
                        {
                            if (jsonp_callback != null)
                            {
                                sw.Write("{0}(", jsonp_callback);
                                sw.Write(Serializer.ToString(response_struct));
                                sw.Write(");", jsonp_callback);
                            }
                            else if (iframe_callback != null)
                            {
                                context.Response.ContentType = "text/html";
                                sw.Write("<script language=\"javascript\" type=\"text/javascript\">window.top.window.{0}(", iframe_callback);
                                sw.Write(Serializer.ToString(response_struct));
                                sw.Write(");</script>");
                            }
                            else
                            {
                                sw.Write(Serializer.ToString(response_struct));
                            }
                        }
                        
                    }
                    break;
                
                case  5 :
                    {
                        
                        string          json_string;
                        KMAValidateHashKeyPairSignatureRequest   request_struct;
                        if (method == "GET")
                        {
                            if (querystring_idx == -1)
                                json_string = url;
                            else
                                json_string = url.Substring(0, querystring_idx);
                        }
                        else if (method == "POST")
                        {
                            using (var sr = new System.IO.StreamReader(context.Request.InputStream))
                                json_string = sr.ReadToEnd();
                        }
                        else
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                            return;
                        }
                        if (!KMAValidateHashKeyPairSignatureRequest.TryParse(json_string, out request_struct))
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                            return;
                        }
                        KMAValidateHashKeyPairSignatureResponse   response_struct ;
                        ValidateHashKeyPairSignatureHandler(request_struct, out response_struct);
                        
                        context.Response.ContentType = "application/json";
                        string jsonp_callback  = context.Request.QueryString["jsonp_callback"] ?? context.Request.QueryString["callback"];
                        string iframe_callback = context.Request.QueryString["iframe_callback"];
                        using (var sw = new System.IO.StreamWriter(context.Response.OutputStream))
                        {
                            if (jsonp_callback != null)
                            {
                                sw.Write("{0}(", jsonp_callback);
                                sw.Write(Serializer.ToString(response_struct));
                                sw.Write(");", jsonp_callback);
                            }
                            else if (iframe_callback != null)
                            {
                                context.Response.ContentType = "text/html";
                                sw.Write("<script language=\"javascript\" type=\"text/javascript\">window.top.window.{0}(", iframe_callback);
                                sw.Write(Serializer.ToString(response_struct));
                                sw.Write(");</script>");
                            }
                            else
                            {
                                sw.Write(Serializer.ToString(response_struct));
                            }
                        }
                        
                    }
                    break;
                
            }
        }
    }
    
    #endregion
    #region Proxy
    
    #endregion
    #region Module
    
    #endregion
    
}

#pragma warning restore 162,168,649,660,661,1522
