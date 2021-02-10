using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FirebaseCloudMessaging.Example
{
    public class GoogleAPIHelper
    {
        public static async Task<bool> SendNotification()
        {
            try
            {
                string message1Json = GetJson("Message1.json");
                string keyJson = GetJson("key.json");
                
                GoogleKey googleKey = JsonConvert.DeserializeObject<GoogleKey>(keyJson);



                //var httpContent = JsonConvert.SerializeObject(fcmBody);
                var client = new HttpClient();
                
                var authorization = string.Format("key={0}", googleKey.private_key);

                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", authorization);
                
                var stringContent = new StringContent(message1Json);
                stringContent.Headers.Add(@"Content-Length", "0");

                stringContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                

                string uri = "https://fcm.googleapis.com/v1/projects/myproject-b5ae1/messages:send";
                
                var response = await client.PostAsync(uri, stringContent).ConfigureAwait(false);
                
                var result = response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (TaskCanceledException ex)
            {
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static string GetJson(string file)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string filePath = System.IO.Path.Combine(currentDirectory, file);

            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();

                return json;
            }

        }

        public class GoogleKey
        {
            public string type { get; set; }
            public string project_id { get; set; }
            public string private_key_id { get; set; }
            public string private_key { get; set; }
            public string client_email { get; set; }
            public string client_id { get; set; }
            public string auth_uri { get; set; }
            public string token_uri { get; set; }
            public string auth_provider_x509_cert_url { get; set; }
            public string client_x509_cert_url { get; set; }
        }

    }
}
