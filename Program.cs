using System;
using System.Net.Http;
using System.Threading.Tasks;
using Grpc.Net.Client;

namespace GrpcGreeterClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // The port number(5001) must match the port of the gRPC server.
           using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            //using var channel = GrpcChannel.ForAddress("https://localhost:5000");


            var client = new  Inventor.InventorClient(channel);

            var NewClient = new CartService.CartServiceClient(channel);
           try
            {
                var reply = await client.SayHelloAsync(
                             new InventorRequest { Name = "InventorRequest" });
                Console.WriteLine("Greeting: " + reply.Message);
            }
            catch
            {

                Console.WriteLine("Error Inventory Client ");

            }
            try
            {
                var reply =  NewClient.EmptyCart(
                            new  EmptyCartRequest { UserId = "InventorRequest" });
                Console.WriteLine("Greeting: " + reply.ToString());

            }
            catch
            {

                Console.WriteLine("Cart  Client Error ");
            }
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}