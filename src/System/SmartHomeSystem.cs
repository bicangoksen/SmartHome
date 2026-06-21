using SmartHomeCore.Models;

namespace SmartHomeCore.System
{
    public class SmartHomeSystem
    {
        private List<Room> _rooms;
        private string _homeName;

        public SmartHomeSystem(string homeName)
        {
            _homeName = homeName;
            _rooms = new List<Room>();
        }

        public void AddRoom(Room room)
        {
            _rooms.Add(room);
        }

        public void ShowAllDevices()
        {
            Console.WriteLine($"\n🏠 {_homeName} — All Devices");
            Console.WriteLine(new string('=', 50));
            foreach (var room in _rooms)
            {
                room.ShowDevices();
            }
            Console.WriteLine();
        }

        public List<Light> GetAllLights()
        {
            var lights = new List<Light>();
            foreach (var room in _rooms)
                foreach (var device in room.GetDevices())
                    if (device is Light light)
                        lights.Add(light);
            return lights;
        }

        public List<Thermostat> GetAllThermostats()
        {
            var thermostats = new List<Thermostat>();
            foreach (var room in _rooms)
                foreach (var device in room.GetDevices())
                    if (device is Thermostat thermostat)
                        thermostats.Add(thermostat);
            return thermostats;
        }

        public List<DoorLock> GetAllDoorLocks()
        {
            var locks = new List<DoorLock>();
            foreach (var room in _rooms)
                foreach (var device in room.GetDevices())
                    if (device is DoorLock doorLock)
                        locks.Add(doorLock);
            return locks;
        }
    }
}
