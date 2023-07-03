using RTU.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace RTU.Model
{
    internal class RealTimeUnit : RealTimeUnitI
    {
        private long _id;
        private double _lowLimit;
        private double _highLimit;
        private string _address;

        public RealTimeUnit(long id, double lowLimit, double highLimit, string address)
        {
            Id = id;
            LowLimit = lowLimit;
            HighLimit = highLimit;
            Address = address;
        }

        public long Id { get => _id; set => _id = value; }
        public double LowLimit { get => _lowLimit; set => _lowLimit = value; }
        public double HighLimit { get => _highLimit; set => _highLimit = value; }
        public string Address { get => _address; set => _address = value; }

        readonly HttpClient client = new();

        public void Work()
        {
            Random random = new();
            while (true) {
                _ = CallWebAPIAsync(random.Next((int)LowLimit, (int)HighLimit));
                Thread.Sleep(1000);
            }
        }

        private async Task CallWebAPIAsync(double value)
        {
            var requestData = new
            {
                Value = value,
            };
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync(this.Address, requestData);
                Console.WriteLine(response.ToString());
            } catch (Exception ex) 
            { 
                Console.WriteLine(ex.Message); 
            }
        }

    }
}
