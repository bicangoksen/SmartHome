using SmartHomeCore.Models;
using SmartHomeCore.System;

namespace SmartHomeCore
{
    class Program
    {
        static void Main(string[] args)
        {
            // --- Setup Smart Home ---
            var home = new SmartHomeSystem("My Smart Home");

            // Living Room
            var livingRoom = new Room("Living Room");
            livingRoom.AddDevice(new Light("Ceiling Light", "LR-L01"));
            livingRoom.AddDevice(new Light("Floor Lamp", "LR-L02", brightness: 60));
            livingRoom.AddDevice(new Thermostat("Main Thermostat", "LR-T01", initialTemp: 21.0));

            // Bedroom
            var bedroom = new Room("Bedroom");
            bedroom.AddDevice(new Light("Bedside Lamp", "BR-L01", brightness: 40));
            bedroom.AddDevice(new Thermostat("Bedroom Thermostat", "BR-T01", initialTemp: 19.0));
            bedroom.AddDevice(new DoorLock("Bedroom Door", "BR-D01", startLocked: false));

            // Garage
            var garage = new Room("Garage");
            garage.AddDevice(new Light("Garage Light", "GR-L01"));
            garage.AddDevice(new DoorLock("Garage Door", "GR-D01", startLocked: true));

            home.AddRoom(livingRoom);
            home.AddRoom(bedroom);
            home.AddRoom(garage);

            // --- Run Menu ---
            var menu = new MenuHandler(home);
            menu.Run();
        }
    }
}
