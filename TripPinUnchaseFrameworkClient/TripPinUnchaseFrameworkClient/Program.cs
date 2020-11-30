﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripPinUnchaseFrameworkClient
{
    class Program
    {
        static void Main(string[] args)
        {
            const string serviceUri = "https://services.odata.org/TripPinRESTierService";
            var container = new Microsoft.OData.Service.Sample.TrippinInMemory.Models.Container(new Uri(serviceUri));

            Console.WriteLine("People in TripPin service:");
            var people = container.People;

            foreach (var person in people)
            {
                Console.WriteLine("\t{0} {1}", person.FirstName, person.LastName);
            }

            Console.WriteLine("Press any key to continue.");
            Console.ReadLine();
        }
    }
}
