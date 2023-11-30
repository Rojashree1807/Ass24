using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConAppAss24
{
    internal class Program
    {
        class Source
        {
            public string CommonProperty1 { get; set; }
            public int CommonProperty2 { get; set; }
            public string SourceOnlyProperty { get; set; }
        }

        class Destination
        {
            public string CommonProperty1 { get; set; }
            public int CommonProperty2 { get; set; }
            public string DestinationOnlyProperty { get; set; }
        }
        static void Main()
        {
            Source sourceInstance = new Source();
            Destination destinationInstance = new Destination();

            sourceInstance.CommonProperty1 = "Value1";
            sourceInstance.CommonProperty2 = 42;
            sourceInstance.SourceOnlyProperty = "SourceOnlyValue";
                       
            MapProperties(sourceInstance, destinationInstance);

            Console.WriteLine($"Destination CommonProperty1: {destinationInstance.CommonProperty1}");
            Console.WriteLine($"Destination CommonProperty2: {destinationInstance.CommonProperty2}");
            Console.WriteLine($"Destination DestinationOnlyProperty: {destinationInstance.DestinationOnlyProperty}");
            Console.ReadKey();
        }

        static void MapProperties(Source source, Destination destination)
        {
            var sourceProperties = source.GetType().GetProperties();
            var destinationProperties = destination.GetType().GetProperties();

            foreach (var sourceProperty in sourceProperties)
            {                
                var matchingDestinationProperty = Array.Find(destinationProperties, p => p.Name == sourceProperty.Name);

                if (matchingDestinationProperty != null)
                {
                    var value = sourceProperty.GetValue(source);
                    matchingDestinationProperty.SetValue(destination, value);
                }
            }
        }
        
    }
}

