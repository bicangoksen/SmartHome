namespace SmartHomeCore.Models
{
    public class Light : Device
    {
        public int Brightness { get; private set; } // 1-100

        public Light(string name, string deviceId, int brightness = 100)
            : base(name, deviceId)
        {
            Brightness = brightness;
        }

        public void SetBrightness(int level)
        {
            if (level < 1 || level > 100)
            {
                Console.WriteLine("Brightness must be between 1 and 100.");
                return;
            }
            Brightness = level;
            Console.WriteLine($"[{Name}] brightness set to {Brightness}%.");
        }

        public override string GetStatus()
        {
            string state = IsOn ? "ON" : "OFF";
            return $"💡 {Name} (Light) — {state} | Brightness: {Brightness}%";
        }
    }
}
