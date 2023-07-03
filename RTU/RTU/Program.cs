using RTU.Model;

RealTimeUnit rtu = new RealTimeUnit(1, 1, 5, "http://localhost:5000/api/controller");
Console.WriteLine("RTU initialized");
rtu.Work();