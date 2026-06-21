using SmartHomeCore.Models;

namespace SmartHomeCore.System
{
    public class Room
    {
        public string RoomName { get; private set; }
        private List<Device> _devices;

        public Room(string roomName)
        {
            RoomName = roomName;
            _devices = new List<Device>();
        }

        public void AddDevice(Device device)
        {
            _devices.Add(device);
        }

        public List<Device> GetDevices()
        {
            return _devices;
        }

        public void ShowDevices()
        {
            Console.WriteLine($"\n  📍 {RoomName}");
            Console.WriteLine("  " + new string('-', 45));
            if (_devices.Count == 0)
            {
                Console.WriteLine("    No devices in this room.");
            }
            else
            {
                foreach (var device in _devices)
                {
                    Console.WriteLine($"    {device.GetStatus()}");
                }
            }
        }
    }
}
