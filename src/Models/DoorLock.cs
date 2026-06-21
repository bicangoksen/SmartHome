namespace SmartHomeCore.Models
{
    public class DoorLock : Device
    {
        public bool IsLocked { get; private set; }

        public DoorLock(string name, string deviceId, bool startLocked = true)
            : base(name, deviceId)
        {
            IsLocked = startLocked;
            IsOn = true; // Door lock is always "on" (active)
        }

        public void Lock()
        {
            IsLocked = true;
            Console.WriteLine($"[{Name}] is now LOCKED. 🔒");
        }

        public void Unlock()
        {
            IsLocked = false;
            Console.WriteLine($"[{Name}] is now UNLOCKED. 🔓");
        }

        public override string GetStatus()
        {
            string lockState = IsLocked ? "LOCKED 🔒" : "UNLOCKED 🔓";
            return $"🚪 {Name} (Door Lock) — {lockState}";
        }
    }
}
