using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RTU.AnalogInputServiceRef;
using RTU.DigitalInputServiceRef;
using System.Threading;

namespace RTU
{
    class Program
    {
        static AnalogInputServiceClient aisClient = new AnalogInputServiceClient();
        static DigitalInputServiceClient disClient = new DigitalInputServiceClient();

        static void Main(string[] args)
        {
            Console.WriteLine("RTU is sending data...");

            IEnumerable<AnalogInput> analogInputs = aisClient.GetAll();
            IEnumerable<DigitalInput> digitalInputs = disClient.GetAll();

            foreach (AnalogInput analogInput in analogInputs)
            {
                if (analogInput.Driver != AnalogInputServiceRef.DriverType.REAL)
                    continue;

                Thread t = new Thread(() =>
                {
                    SendAnalog(analogInput);
                });
                t.Start();
            }

            foreach (DigitalInput digitalInput in digitalInputs)
            {
                if (digitalInput.Driver != DigitalInputServiceRef.DriverType.REAL)
                    continue;

                Thread t = new Thread(() =>
                {
                    SendDigital(digitalInput);
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

        static void SendDigital(DigitalInput digitalInput)
        {
            while (true)
            {
                bool value = GenerateBool();
                disClient.SendFromRTU(digitalInput.IOAddress, value);
                Console.WriteLine($"Tag {digitalInput.TagName}, Adress {digitalInput.IOAddress}, Value {value}");

                Thread.Sleep(digitalInput.ScanTime);
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
