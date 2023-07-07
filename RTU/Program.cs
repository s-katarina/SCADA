using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RTU.AnalogInputServiceRef;
using System.Threading;

namespace RTU
{
    class Program
    {
        static AnalogInputServiceClient aisClient = new AnalogInputServiceClient();

        static void Main(string[] args)
        {
            Console.WriteLine("pocelo");

            IEnumerable<AnalogInput> analogInputs = aisClient.GetAll();

            foreach (AnalogInput analogInput in analogInputs)
            {
                if (analogInput.Driver != DriverType.REAL)
                    continue;

                Thread t = new Thread(() =>
                {
                    SendAnalog(analogInput);
                });
                t.Start();
            }

            Console.ReadKey();
        }

        static void SendAnalog(AnalogInput analogInput)
        {
            while (true)
            {
                double value = GenerateDouble();
                aisClient.SendFromRTU(analogInput.IOAddress, value);
                Console.WriteLine($"Tag {analogInput.TagName}, Adress {analogInput.IOAddress}, Value {value}");

                Thread.Sleep(analogInput.ScanTime);
            }
        }

        private static double GenerateDouble()
        {
            Random random = new Random();
            return random.NextDouble() * random.Next(-100, 100);
        }

        private static bool GenerateBool()
        {
            Random random = new Random();
            return Convert.ToBoolean(random.Next(2));
        }
    }
}
