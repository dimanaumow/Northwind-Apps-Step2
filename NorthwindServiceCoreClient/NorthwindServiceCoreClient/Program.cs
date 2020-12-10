using System;
using System.Threading;

namespace NorthwindServiceCoreClient
{
    class Program
    {
        static void Main(string[] args)
        {
            const string serviceUri = "https://services.odata.org/V3/Northwind/Northwind.svc/";
            var entities = new NorthwindModel.NorthwindEntities(new Uri(serviceUri));

            IAsyncResult asyncResult = entities.Employees.BeginExecute((ar) =>
            {
                Console.WriteLine("People in TripPin service:");
                var people = entities.Employees.EndExecute(ar);

                foreach (var person in people)
                {
                    Console.WriteLine("\t{0} {1}", person.FirstName, person.LastName);
                }

            }, null);

            WaitHandle.WaitAny(new[] { asyncResult.AsyncWaitHandle });

            Console.WriteLine("Press any key to continue.");
            Console.ReadLine();
        }
    }
}
