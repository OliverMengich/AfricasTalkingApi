using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AfricasTalkingCS;

namespace AfricastalkingApi
{
    class Program
    {
        static void Main(string[] args)
        {
            /*const string username = "sandbox"; // substitute with your username if mot using sandbox
            const string apikey = "000f9760d2b71bc720bd77346545afdf72f9c71abdd41e4e8b0910df480c241b";
            var gateway = new AfricasTalkingGateway(username, apikey);
            Console.WriteLine("Enter recipient must start with +254..");
            string recepients = Console.ReadLine();
            Console.WriteLine("Enter text Message to send");
            string msg = Console.ReadLine();
            */
            /*try
            {
                var sms = gateway.SendMessage(recepients, msg);
                
                foreach (var res in sms["SMSMessageData"]["Recipients"])
                {
                    Console.WriteLine((string)res["number"] + ": ");
                    Console.WriteLine((string)res["status"] + ": ");
                    Console.WriteLine((string)res["messageId"] + ": ");
                    Console.WriteLine((string)res["cost"] + ": ");
                }
            }
            catch (AfricasTalkingGatewayException exception)
            {
                Console.WriteLine(exception);
            }*/
            var username = "sandbox";
            var apiKey = "000f9760d2b71bc720bd77346545afdf72f9c71abdd41e4e8b0910df480c241b";
            var productName = "coolproduct";
            var phoneNumber = "+254741954425";
            var currency = "KES";
            int amount = 5;
            var channel = "mychannel";
            var metadata = new Dictionary<string, string>
           {
               { "reason", "stuff" }
           };

            var gateway = new AfricasTalkingGateway(username, apiKey);

            try
            {
                // You will get an object of type C2BDataResults :
                // From which you can extract the following properties
                // 1. C2BDataResults.ProviderChannel
                // 2. C2BDataResults.Status
                // 3. C2BDataResults.Description
                // 4. C2BDataResults.TransactionId
                // You also get a ToString() method
                C2BDataResults checkout = gateway.Checkout(productName, phoneNumber, currency, amount, channel, metadata);
                Console.WriteLine(checkout.Status);
            }
            catch (AfricasTalkingGatewayException e)
            {
                Console.WriteLine("We ran into problems: " + e.Message);
            }
            Console.ReadKey();
        }
    }
}
