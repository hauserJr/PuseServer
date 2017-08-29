using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebPush;
namespace PuseServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("請輸入Public Key：");
            var PublicKey = Console.ReadLine();
            Console.WriteLine("\n請輸入Private Key：");
            var PrivateKey = Console.ReadLine();
            Console.WriteLine("\n請輸入EndPoint(URL)：");
            var pushEndpoint = Console.ReadLine();
            Console.WriteLine("\n請輸入p256dh：");
            var p256dh = Console.ReadLine();
            Console.WriteLine("\n請輸入auth：");
            var auth = Console.ReadLine();
            Console.WriteLine("\n請輸入通知內容：");
            var PushData = Console.ReadLine();


            var subject = @"mailto:example@example.com";
            var publicKey = PublicKey;
            var privateKey = PrivateKey;

            var subscription = new PushSubscription(pushEndpoint, p256dh, auth);
            var vapidDetails = new VapidDetails(subject, publicKey, privateKey);
            var webPushClient = new WebPushClient();

            try
            {
                webPushClient.SendNotification(subscription, PushData, vapidDetails);
                Console.WriteLine("\n通知推送完成");
                //webPushClient.SendNotification(subscription, "payload", gcmAPIKey);
            }
            catch (WebPushException exception)
            {
                Console.WriteLine("Http STATUS code" + exception.StatusCode);
            }
            Console.ReadLine();
        }
    }
}
