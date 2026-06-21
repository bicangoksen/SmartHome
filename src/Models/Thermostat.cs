namespace SmartHomeCore.Models
{
    public class Thermostat : Device
    {
        public double Temperature { get; private set; }
        public string Unit { get; private set; } // "C" or "F"

        public Thermostat(string name, string deviceId, double initialTemp = 20.0, string unit = "C")
            : base(name, deviceId)
        {
            Temperature = initialTemp;
            Unit = unit;
        }

        public void SetTemperature(double temp)
        {
            double min = Unit == "C" ? 10 : 50;
            double max = Unit == "C" ? 35 : 95;

            if (temp < min || temp > max)
            {
                Console.WriteLine($"Temperature must be between {min}°{Unit} and {max}°{Unit}.");
                return;
            }

            Temperature = temp;
            Console.WriteLine($"[{Name}] temperature set to {Temperature}°{Unit}.");
        }

        public override string GetStatus()
        {
            string state = IsOn ? "ON" : "OFF";
            return $"🌡️  {Name} (Thermostat) — {state} | Temp: {Temperature}°{Unit}";
        }
    }
}
