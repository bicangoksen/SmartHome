namespace SmartHomeCore.Models
{
    public abstract class Device
    {
        public string Name { get; protected set; }
        public string DeviceId { get; protected set; }
        public bool IsOn { get; protected set; }

        protected Device(string name, string deviceId)
        {
            Name = name;
            DeviceId = deviceId;
            IsOn = false;
        }

        public virtual void TurnOn()
        {
            IsOn = true;
            Console.WriteLine($"[{Name}] turned ON.");
        }

        public virtual void TurnOff()
        {
            IsOn = false;
            Console.WriteLine($"[{Name}] turned OFF.");
        }

        public abstract string GetStatus();
    }
}
