using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using BookStoreASPClient.Models;
using BookStoreASPClient.Modules.LoggingModule;
using BookStoreASPClient.Interfaces;

namespace BookStoreASPClient.Modules.ApiModule
{
    public class ResponseReader
    {
        private static string logTag = "ResponseReader";

        public static ApiResponse GetApiResponse(string jsonString)
        {
            ApiResponse apiResponse = new ApiResponse();
            try
            {
                apiResponse = JsonConvert.DeserializeObject<ApiResponse>(jsonString);

            }
            catch (Exception e)
            {
                LoggingService.Log(LoggingService.LogType.error, e.ToString(), logTag);
            }
            return apiResponse;

        }

        public static IBookDTO GetBookDetails(string jsonString)
        {
            ApiResponse apiResponse = GetApiResponse(jsonString);
            if (apiResponse.Error) return null;
            try
            {
                JObject jObJect = (JObject)apiResponse.Data;
                return jObJect.ToObject<BookDTO>();
            }
            catch
            {
                return null;
            }
        }

        public static IEnumerable<IBookDTO> GetBooks(string jsonString)
        {
            ApiResponse apiResponse = GetApiResponse(jsonString);
            try
            {
                if (apiResponse.Error) return null;
                JArray jArray = (JArray)apiResponse.Data;
                return jArray.ToObject<IEnumerable<BookDTO>>();
            }
            catch
            {
                return null;
            }
        }

        public static OrderDetailsDTO GetOrderDetails(string jsonString)
        {
            try
            {
                ApiResponse apiResponse = GetApiResponse(jsonString);
                if (apiResponse.Error)
                {
                    return null;
                }
                JObject jObject = (JObject)apiResponse.Data;
                return jObject.ToObject<OrderDetailsDTO>();
            }
            catch (Exception e)
            {
                LoggingService.Log(LoggingService.LogType.error, e.ToString(), logTag);
                return null;
            }
        }

        public static IEnumerable<string> GetStringList(string jsonString)
        {
            IEnumerable<string> result = null;
            ApiResponse apiResponse;
            try
            {
                apiResponse = JsonConvert.DeserializeObject<ApiResponse>(jsonString);
                if (apiResponse.Error)
                {
                    return result;
                }
                if (apiResponse.Message.Equals("ok"))
                {
                    return result;
                }
                return result = null; 
            }
            catch (Exception e)
            {
                LoggingService.Log(LoggingService.LogType.error, e.ToString(), logTag);
                return result;
            }
        }

        public static string RegistrationStatus(string jsonString)
        {
            try
            {
                ApiResponse apiResponse = GetApiResponse(jsonString);
                if (!apiResponse.Error && apiResponse.Data != null)
                {
                    return (string)apiResponse.Data;
                }
            }
            catch (Exception e)
            {
                LoggingService.Log(LoggingService.LogType.error, e.ToString(), logTag);
            }

            try
            {
                JObject mainObject = JsonConvert.DeserializeObject<JObject>(jsonString);
                string message = mainObject["Message"].ToString();
                JObject modelObject = mainObject["ModelState"].ToObject<JObject>();
                string modelErrors = "";
                foreach (JProperty element in modelObject.Properties())
                {
                    modelErrors += element;
                }
                return "ERROR: " + message + ", " + modelErrors.ToString();
            }
            catch (Exception e)
            {
                LoggingService.Log(LoggingService.LogType.error, e.ToString(), logTag);
                return null;
            }

        }

        public static string TokenString(string jsonString)
        {
            try
            {
                JObject mainObject = JsonConvert.DeserializeObject<JObject>(jsonString);
                string token = mainObject["access_token"].ToString();
                return token;
            }
            catch (Exception e)
            {
                LoggingService.Log(LoggingService.LogType.error, e.ToString(), logTag);
                return "ERROR: Something went wrong";
            }
        }
    }
}
