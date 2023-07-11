using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RTU.AnalogInputServiceRef;
using RTU.DigitalInputServiceRef;
using System.Threading;
using System.ServiceModel;

namespace RTU
{
    class Program
    {
        static AnalogInputServiceClient aisClient = new AnalogInputServiceClient();
        static DigitalInputServiceClient disClient = new DigitalInputServiceClient();
        static PubSubService.PubClient pubClient = new PubSubService.PubClient();
        static AlarmServiceRef.PubAlarmClient pubAlarmClient = new AlarmServiceRef.PubAlarmClient();

        static Dictionary<string, Thread> inputs = new Dictionary<string, Thread>();
        static Dictionary<string, ManualResetEvent> waits = new Dictionary<string, ManualResetEvent>();

        static void Main(string[] args)
        {
            //while (true)
            //{
            //    pubClient.DoWork("aaaaaaaaaa", 2);
            //    Thread.Sleep(2000);
            //}

            Console.WriteLine("RTU is sending data...");

            //IEnumerable<AnalogInput> analogInputs = aisClient.GetAll();
            //IEnumerable<DigitalInput> digitalInputs = disClient.GetAll();
            //FillDicts(analogInputs, digitalInputs);

            while (true)
            {
                IEnumerable<AnalogInput> aInputs = aisClient.GetAll();
                IEnumerable<DigitalInput> dInputs = disClient.GetAll();

                foreach (AnalogInput analogInput in aInputs)
                {
                    if (!inputs.ContainsKey(analogInput.TagName))
                    {
                        if (analogInput.Driver == AnalogInputServiceRef.DriverType.REAL)
                            inputs.Add(analogInput.TagName, new Thread(() => SendAnalog(analogInput)));
                        else
                            inputs.Add(analogInput.TagName, new Thread(() => SendSimAnalog(analogInput)));

                        waits.Add(analogInput.TagName, new ManualResetEvent(false));
                        inputs[analogInput.TagName].Start();
                    }

                    if (analogInput.IsScanning)
                        waits[analogInput.TagName].Set();
                    else
                        waits[analogInput.TagName].Reset();
                }

                foreach (DigitalInput digitalInput in dInputs)
                {
                    if (!inputs.ContainsKey(digitalInput.TagName))
                    {
                        if (digitalInput.Driver == DigitalInputServiceRef.DriverType.REAL)
                            inputs.Add(digitalInput.TagName, new Thread(() => SendDigital(digitalInput)));
                        else
                            inputs.Add(digitalInput.TagName, new Thread(() => SendSimDigital(digitalInput)));

                        waits.Add(digitalInput.TagName, new ManualResetEvent(false));
                        inputs[digitalInput.TagName].Start();
                    }

                    if (digitalInput.IsScanning)
                        waits[digitalInput.TagName].Set();
                    else
                        waits[digitalInput.TagName].Reset();
                }
            }
        }

        static void FillDicts(IEnumerable<AnalogInput> analogInputs, IEnumerable<DigitalInput> digitalInputs)
        {
            foreach (AnalogInput analogInput in analogInputs)
            {
                if (analogInput.Driver != AnalogInputServiceRef.DriverType.REAL)
                    continue;
                inputs.Add(analogInput.TagName, new Thread(() => SendAnalog(analogInput)));
                waits.Add(analogInput.TagName, new ManualResetEvent(false));
                inputs[analogInput.TagName].Start();
            }

            foreach (DigitalInput digitalInput in digitalInputs)
            {
                if (digitalInput.Driver != DigitalInputServiceRef.DriverType.REAL)
                    continue;
                inputs.Add(digitalInput.TagName, new Thread(() => SendDigital(digitalInput)));
                waits.Add(digitalInput.TagName, new ManualResetEvent(false));
                inputs[digitalInput.TagName].Start();
            }
        }

        static void SendAnalog(AnalogInput analogInput)
        {
            while (true)
            {
                waits[analogInput.TagName].WaitOne();

                double value = GenerateDouble();
                pubClient.DoWork(analogInput.IOAddress, value);
                pubAlarmClient.DoWork(analogInput.IOAddress, value);
                Console.WriteLine($"Tag {analogInput.TagName}, Adress {analogInput.IOAddress}, Value {value}");

                Thread.Sleep(analogInput.ScanTime);
            }
        }

        static void SendSimAnalog(AnalogInput analogInput)
        {
            int value = 0;
            while (true)
            {
                waits[analogInput.TagName].WaitOne();

                pubClient.DoWork(analogInput.IOAddress, value);
                Console.WriteLine($"Tag {analogInput.TagName}, Adress {analogInput.IOAddress}, Value {value}");
                pubAlarmClient.DoWork(analogInput.IOAddress, value);
                value++;

                Thread.Sleep(analogInput.ScanTime);
            }
        }

        static void SendDigital(DigitalInput digitalInput)
        {
            while (true)
            {
                waits[digitalInput.TagName].WaitOne();

                bool value = GenerateBool();
                //disClient.SendFromRTU(digitalInput.IOAddress, value);
                pubClient.SendDigitalInput(digitalInput.IOAddress, value);
                Console.WriteLine($"Tag {digitalInput.TagName}, Adress {digitalInput.IOAddress}, Value {value}");

                Thread.Sleep(digitalInput.ScanTime);
            }
        }

        static void SendSimDigital(DigitalInput digitalInput)
        {
            bool value = false;
            while (true)
            {
                waits[digitalInput.TagName].WaitOne();

                pubClient.SendDigitalInput(digitalInput.IOAddress, value);
                Console.WriteLine($"Tag {digitalInput.TagName}, Adress {digitalInput.IOAddress}, Value {value}");

                value = !value;

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
