using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace FirebaseCloudMessaging.Example
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var defaultApp = FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "key.json")),
            });
            Console.WriteLine(defaultApp.Name); // "[DEFAULT]"
            var messageSP = new Message()
            {
                Data = new Dictionary<string, string>()
                {
                   ["FirstName"] = "John",
                   ["LastName"] = "Doe"
                },
                Notification = new Notification
                {
                    Title = "Jim Morrison",
                    Body = "Is a killer on the road"
                },

                Token = "ce8eEjD8QRqI8gVhfvF_S-:APA91bHe-91rGH_UovR8KGh6UOHwXCOxGPMpqwUROSpw2g92lJkPDRAfd4kysVgUMcxYdyS56GjxBCo8Z_GpyqITVTyEPkj_ABnMZS5FI1tn_JYzYnS8kkVouxFZL04F6YJNR31QXA0M",
                //Topic = "news"
            };

            var messageHF = new Message()
            {
                Data = new Dictionary<string, string>()
                {
                    ["FirstName"] = "John",
                    ["LastName"] = "Doe",
                },

                Notification = new Notification
                {
                    Title = "Jim Morrison",
                    Body = "Is a killer on the road"
                },
                
               

                Token = "epVMhFA2QVqFh0rIKQ1nZK:APA91bF2pae4fqgALx-iyPVDPtw_Uqx-lD7yvKRYXyfYdA6ZyzK7iSruC2cOg75A1V0qyOcfp9Sx5P_g9M0G2y36xa9bWH4RhiGE0t_Eq2Zz7za6uKgt9lNR3-s7RagC3mt_ur0wL89D",
                
                //Topic = "news"
            };
            var messaging = FirebaseMessaging.DefaultInstance;



            //c4_wA5zIT0 - uu2N1Fht5AE:APA91bHUy1ZlttISGIlpgNZBFzfBcDR3zAP81p27hH0Sww - SwLQgSAaQ1AQpxm38_U_UCLuYxJTIvsZKnXxk1tTPGrZ3iiFH9vbqAX3m9OyHxrJp8kD0NceznLKpBW16nmkgSOzw5zpS

            var resultHF = await messaging.SendAsync(messageHF);
            //var resultSP = await messaging.SendAsync(messageSP);

            //await GoogleAPIHelper.SendNotification();

            //Console.WriteLine(result); //projects/myapp/messages/2492588335721724324
        }
    }
}
