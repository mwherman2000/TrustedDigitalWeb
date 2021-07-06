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
namespace TDW.VDAServer
{
    #region Server
    
    public abstract partial class TDWVerifiableDataRegistryAgentBase : TrinityServer
    {
        #region Handler lookup table
        private static Dictionary<string, uint> s_HttpHandlerLookupTable = new Dictionary<string, uint>
        {
            
            { "PostVDAIdentityRegistryEntry", 0  }
            ,
            { "PostVDAServiceEndpointEntry", 1  }
            ,
            { "PostVDARevocationListEntry", 2  }
            ,
            { "GetVDAPostResult", 3  }
            ,
            { "IsCredentialValid", 4  }
            ,
            { "IsCredentialRevoked", 5  }
            ,
            { "IsCredentialVerified", 6  }
            ,
            { "SaveAccountRegistryEntry", 7  }
            ,
            { "GetAccountRegistryEntry", 8  }
            ,
            { "SaveSmartContractRegistryEntry", 9  }
            ,
            { "GetSmartContractRegistryEntry", 10  }
            ,
        };
        #endregion
        
        public abstract void PostVDAIdentityRegistryEntryHandler(TDWPostVDAIdentityRegistryEntryRequest request, out TDWPostResponse response);
        
        public abstract void PostVDAServiceEndpointEntryHandler(TDWPostVDAIdentityRegistryEntryRequest request, out TDWPostResponse response);
        
        public abstract void PostVDARevocationListEntryHandler(TDWPostVDARevocationListEntryRequest request, out TDWPostResponse response);
        
        public abstract void GetVDAPostResultHandler(TDWGetVDAPostResultRequest request, out TDWGetVDAPostResultResponse response);
        
        public abstract void IsCredentialValidHandler(TDWIsCredentialValidRequest request, out TDWIsCredentialValidResponse response);
        
        public abstract void IsCredentialRevokedHandler(TDWIsCredentialRevokedRequest request, out TDWIsCredentialRevokedResponse response);
        
        public abstract void IsCredentialVerifiedHandler(TDWIsCredentialVerifiedRequest request, out TDWIsCredentialVerifiedResponse response);
        
        public abstract void SaveAccountRegistryEntryHandler(TDWSaveAccountRegistryEntryRequest request, out TDWSaveAccountRegistryEntryResponse response);
        
        public abstract void GetAccountRegistryEntryHandler(TDWGetAccountRegistryEntryRequest request, out TDWGetAccountRegistryEntryResponse response);
        
        public abstract void SaveSmartContractRegistryEntryHandler(TDWSaveSmartContractRegistryEntryRequest request, out TDWSaveSmartContractRegistryEntryResponse response);
        
        public abstract void GetSmartContractRegistryEntryHandler(TDWGetSmartContractRegistryEntryRequest request, out TDWGetSmartContractRegistryEntryResponse response);
        
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
                
                case  0 :
                    {
                        
                        string          json_string;
                        TDWPostVDAIdentityRegistryEntryRequest   request_struct;
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
                        if (!TDWPostVDAIdentityRegistryEntryRequest.TryParse(json_string, out request_struct))
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                            return;
                        }
                        TDWPostResponse   response_struct ;
                        PostVDAIdentityRegistryEntryHandler(request_struct, out response_struct);
                        
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
                
                case  1 :
                    {
                        
                        string          json_string;
                        TDWPostVDAIdentityRegistryEntryRequest   request_struct;
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
                        if (!TDWPostVDAIdentityRegistryEntryRequest.TryParse(json_string, out request_struct))
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                            return;
                        }
                        TDWPostResponse   response_struct ;
                        PostVDAServiceEndpointEntryHandler(request_struct, out response_struct);
                        
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
                        TDWPostVDARevocationListEntryRequest   request_struct;
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
                        if (!TDWPostVDARevocationListEntryRequest.TryParse(json_string, out request_struct))
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                            return;
                        }
                        TDWPostResponse   response_struct ;
                        PostVDARevocationListEntryHandler(request_struct, out response_struct);
                        
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
                        TDWGetVDAPostResultRequest   request_struct;
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
                        if (!TDWGetVDAPostResultRequest.TryParse(json_string, out request_struct))
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                            return;
                        }
                        TDWGetVDAPostResultResponse   response_struct ;
                        GetVDAPostResultHandler(request_struct, out response_struct);
                        
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
                        TDWIsCredentialValidRequest   request_struct;
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
                        if (!TDWIsCredentialValidRequest.TryParse(json_string, out request_struct))
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                            return;
                        }
                        TDWIsCredentialValidResponse   response_struct ;
                        IsCredentialValidHandler(request_struct, out response_struct);
                        
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
                        TDWIsCredentialRevokedRequest   request_struct;
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
                        if (!TDWIsCredentialRevokedRequest.TryParse(json_string, out request_struct))
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                            return;
                        }
                        TDWIsCredentialRevokedResponse   response_struct ;
                        IsCredentialRevokedHandler(request_struct, out response_struct);
                        
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
                
                case  6 :
                    {
                        
                        string          json_string;
                        TDWIsCredentialVerifiedRequest   request_struct;
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
                        if (!TDWIsCredentialVerifiedRequest.TryParse(json_string, out request_struct))
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                            return;
                        }
                        TDWIsCredentialVerifiedResponse   response_struct ;
                        IsCredentialVerifiedHandler(request_struct, out response_struct);
                        
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
                
                case  7 :
                    {
                        
                        string          json_string;
                        TDWSaveAccountRegistryEntryRequest   request_struct;
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
                        if (!TDWSaveAccountRegistryEntryRequest.TryParse(json_string, out request_struct))
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                            return;
                        }
                        TDWSaveAccountRegistryEntryResponse   response_struct ;
                        SaveAccountRegistryEntryHandler(request_struct, out response_struct);
                        
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
                
                case  8 :
                    {
                        
                        string          json_string;
                        TDWGetAccountRegistryEntryRequest   request_struct;
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
                        if (!TDWGetAccountRegistryEntryRequest.TryParse(json_string, out request_struct))
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                            return;
                        }
                        TDWGetAccountRegistryEntryResponse   response_struct ;
                        GetAccountRegistryEntryHandler(request_struct, out response_struct);
                        
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
                
                case  9 :
                    {
                        
                        string          json_string;
                        TDWSaveSmartContractRegistryEntryRequest   request_struct;
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
                        if (!TDWSaveSmartContractRegistryEntryRequest.TryParse(json_string, out request_struct))
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                            return;
                        }
                        TDWSaveSmartContractRegistryEntryResponse   response_struct ;
                        SaveSmartContractRegistryEntryHandler(request_struct, out response_struct);
                        
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
                
                case  10 :
                    {
                        
                        string          json_string;
                        TDWGetSmartContractRegistryEntryRequest   request_struct;
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
                        if (!TDWGetSmartContractRegistryEntryRequest.TryParse(json_string, out request_struct))
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                            return;
                        }
                        TDWGetSmartContractRegistryEntryResponse   response_struct ;
                        GetSmartContractRegistryEntryHandler(request_struct, out response_struct);
                        
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
