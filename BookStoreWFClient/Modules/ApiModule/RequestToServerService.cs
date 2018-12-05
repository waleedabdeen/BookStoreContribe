using System;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using BookStoreWFClient.Model;
using System.Collections.Generic;
using BookStoreWFClient.Modules.LoggingModule;

namespace BookStoreWFClient.Modules.ApiModule
{
    public class RequestToServer
    {
        private static readonly string logTag = "RequestToServer";
        
        // this variable will be sent with each request as UserAgent
        private static readonly string agentDescription = ".NET Framework WinForms - Contribe";

        private static string Get(string link)
        {
            string responseData = "";
            WebRequest webRequest = WebRequest.Create(link);
            ((HttpWebRequest)webRequest).UserAgent = agentDescription;
            WebResponse webResponse;

            try
            {
                webResponse = webRequest.GetResponse();
                if (((HttpWebResponse)webResponse).StatusCode == HttpStatusCode.OK)
                {
                    Stream dataStream = webResponse.GetResponseStream();
                    // using: will help close the reader after we finish from reading or get out of the scope
                    using (StreamReader reader = new StreamReader(dataStream))
                    {
                        responseData = reader.ReadToEnd();
                    }
                    dataStream.Close();
                }
                webResponse.Close();
                return responseData;
            }
            catch (Exception e)
            {
                LoggingService.Log(LoggingService.LogType.error, e.ToString(), logTag);
                return "Error: " + e.ToString(); ;
            }
        }

        private static string Post(string link, byte[] payload, string contentType = null, string accessToken = null)
        {
            string responseString = "";
            WebRequest webRequest = WebRequest.Create(link);
            ((HttpWebRequest)webRequest).UserAgent = agentDescription;
            webRequest.Method = "POST";
            webRequest.ContentLength = payload.Length;
            if (contentType == null || contentType == "json")
            {
                webRequest.ContentType = "application/json";
            }
            else
            {
                webRequest.ContentType = "application/x-www-form-urlencoded";
            }
            if (!string.IsNullOrEmpty(accessToken))
            {
                webRequest.Headers["Authorization"] = "Bearer " + accessToken;
            }


            using (Stream stream = webRequest.GetRequestStream())
            {
                stream.Write(payload, 0, payload.Length);
            }
            WebResponse webResponse;

            try
            {
                webResponse = webRequest.GetResponse();
                if (((HttpWebResponse)webResponse).StatusCode == HttpStatusCode.OK ||
                    ((HttpWebResponse)webResponse).StatusCode == HttpStatusCode.Created)
                {
                    Stream dataStream = webResponse.GetResponseStream();
                    // using: will help close the reader after we finish from reading or get out of the scope
                    using (StreamReader reader = new StreamReader(dataStream))
                    {
                        responseString = reader.ReadToEnd();
                    }
                    dataStream.Close();
                }
                webResponse.Close();
                return responseString;
            }
            catch (WebException e)
            {
                try
                {
                    // another attempt to read the Bad request result body
                    webResponse = e.Response;
                    if (((HttpWebResponse)webResponse).StatusCode == HttpStatusCode.Unauthorized)
                    {
                        return "Error: Unauthorized";
                    }
                    Stream dataStream = webResponse.GetResponseStream();
                    // using: will help close the reader after we finish from reading or get out of the scope
                    using (StreamReader reader = new StreamReader(dataStream))
                    {
                        responseString = reader.ReadToEnd();
                    }
                    dataStream.Close();
                    webResponse.Close();
                    return responseString;
                }
                catch (Exception ex)
                {
                    LoggingService.Log(LoggingService.LogType.error, ex.ToString(), logTag);
                    return "Error: " + e.ToString(); ;
                }
            }
        }

        public static string RequestBookDetails(string id)
        {
            string link = ServerConfig.SERVER_ADDRESS + "/api/Books";
            //build link by impeding the id of the book
            if (!String.IsNullOrEmpty(id)) link += "/" + id;

            string jsonResponse = Get(link);
            return jsonResponse;
        }

        public static string CheckBooksAvailability(Cart cart, string accessToken)
        {
            string link = ServerConfig.SERVER_ADDRESS + "/api/Books/availability";
            if (string.IsNullOrEmpty(link))
            {
                throw new NullReferenceException("Link can not be empty");
            }

            string postString = JsonConvert.SerializeObject(cart, Formatting.Indented);
            byte[] postData = Encoding.ASCII.GetBytes(postString);
            return Post(link, postData, "json", accessToken);
        }

        public static string CreateNewOrder(Cart cart, string accessToken)
        {
            //TODO replace the link with the new order 
            string link = ServerConfig.SERVER_ADDRESS + "/api/Orders";
            if (string.IsNullOrEmpty(link))
            {
                throw new NullReferenceException("Link can not be empty");
            }
            string postString = JsonConvert.SerializeObject(cart, Formatting.Indented);
            byte[] postData = Encoding.ASCII.GetBytes(postString);
            return Post(link, postData, "json", accessToken);
        }

        public static string RequestBooks(string searchString = null)
        {
            string link = ServerConfig.SERVER_ADDRESS + "/api/Books";
            //build link by impeding the search string
            if (!String.IsNullOrEmpty(searchString)) link += "?keyword=" + searchString;

            string jsonResponse = Get(link);
            return jsonResponse;
        }

        public static string RequestNewId()
        {
            string link = ServerConfig.SERVER_ADDRESS +  "/api/util/getId";
            return Get(link);
        }

        public static string RegisterNewAccount(string email, string password)
        {
            Dictionary<string, string> credentials = new Dictionary<string, string>();
            credentials.Add("email", email);
            credentials.Add("password", password);
            credentials.Add("confirmPassword", password);
            string link = ServerConfig.SERVER_ADDRESS + "/api/Account/Register";
            string postString = JsonConvert.SerializeObject(credentials, Formatting.Indented);
            byte[] postData = Encoding.ASCII.GetBytes(postString);
            return Post(link, postData);
        }

        public static string GetToken(string email, string password)
        {
            string postString = "grant_type=password" +
                                "&username=" + email +
                                "&password=" + password;
            string link = ServerConfig.SERVER_ADDRESS + "/token";
            byte[] postData = Encoding.ASCII.GetBytes(postString);
            return Post(link, postData, "form");
        }
    }
}
