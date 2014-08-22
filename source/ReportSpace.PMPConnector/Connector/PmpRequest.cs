using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ReportSpace.PMPConnector.Connector
{
    public class PmpRequest
    {
        private string _url;

        public PmpRequest(String url)
        {
            _url = url;
        }


        private WebRequest GetRequest()
        {
            var request = WebRequest.Create(_url);
            request.Method = "GET";
            request.ContentType = "application/json";
            //var authInfo = _apiKey + ":";
            //var encodedAuthInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
            //request.Headers.Add("Authorization", "Basic " + encodedAuthInfo);

            return request;
        }

        public List<T> GetResponse<T>()
        {
            
            var request = GetRequest();

            var response = request.GetResponse();
            var dataStream = response.GetResponseStream();
            var reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            var wrapper = JsonConvert.DeserializeObject<PmpWrapper<T>>(responseFromServer);
            reader.Close();
            dataStream.Close();
            response.Close();

            return wrapper.Resources;
        }
    }
}
