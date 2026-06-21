using SmartHomeCore.Models;
using SmartHomeCore.System;

namespace SmartHomeCore
{
    public class MenuHandler
    {
        private SmartHomeSystem _system;

        public MenuHandler(SmartHomeSystem system)
        {
            _system = system;
        }

        public void Run()
        {
            Console.Clear();
            PrintHeader();

            bool running = true;
            while (running)
            {
                PrintMenu();
                string? input = Console.ReadLine()?.Trim();

                Console.WriteLine();
                switch (input)
                {
                    case "1":
                        _system.ShowAllDevices();
                        break;
                    case "2":
                        HandleLights();
                        break;
                    case "3":
                        HandleThermostat();
                        break;
                    case "4":
                        HandleDoorLock();
                        break;
                    case "5":
                        Console.WriteLine("👋 Goodbye! Stay smart.");
                        running = false;
                        break;
                    default:
                        Console.WriteLine("❌ Invalid option. Please choose 1–5.");
                        break;
                }

                if (running)
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    PrintHeader();
                }
            }
        }

        private void PrintHeader()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔══════════════════════════════════════════╗");
            Console.WriteLine("║        SmartHome-Core v1.0               ║");
            Console.WriteLine("║        Console Smart Home System         ║");
            Console.WriteLine("╚══════════════════════════════════════════╝");
            Console.ResetColor();
        }

        private void PrintMenu()
        {
            Console.WriteLine("\n┌─────────────────────────────────┐");
            Console.WriteLine("│            MAIN MENU            │");
            Console.WriteLine("├─────────────────────────────────┤");
            Console.WriteLine("│  1. Show all devices            │");
            Console.WriteLine("│  2. Turn light on/off           │");
            Console.WriteLine("│  3. Change thermostat temp      │");
            Console.WriteLine("│  4. Lock / Unlock door          │");
            Console.WriteLine("│  5. Exit                        │");
            Console.WriteLine("└─────────────────────────────────┘");
            Console.Write("Enter your choice: ");
        }

        private void HandleLights()
        {
            var lights = _system.GetAllLights();
            if (lights.Count == 0)
            {
                Console.WriteLine("No lights found.");
                return;
            }

            Console.WriteLine("💡 Available Lights:");
            for (int i = 0; i < lights.Count; i++)
                Console.WriteLine($"  {i + 1}. {lights[i].GetStatus()}");

            Console.Write("Select light number: ");
            if (!int.TryParse(Console.ReadLine(), out int index) || index < 1 || index > lights.Count)
            {
                Console.WriteLine("Invalid selection.");
                return;
            }

            var light = lights[index - 1];
            Console.Write("Action — (1) Turn ON  (2) Turn OFF: ");
            string? action = Console.ReadLine();

            if (action == "1") light.TurnOn();
            else if (action == "2") light.TurnOff();
            else Console.WriteLine("Invalid action.");
        }

        private void HandleThermostat()
        {
            var thermostats = _system.GetAllThermostats();
            if (thermostats.Count == 0)
            {
                Console.WriteLine("No thermostats found.");
                return;
            }

            Console.WriteLine("🌡️  Available Thermostats:");
            for (int i = 0; i < thermostats.Count; i++)
                Console.WriteLine($"  {i + 1}. {thermostats[i].GetStatus()}");

            Console.Write("Select thermostat number: ");
            if (!int.TryParse(Console.ReadLine(), out int index) || index < 1 || index > thermostats.Count)
            {
                Console.WriteLine("Invalid selection.");
                return;
            }

            var thermostat = thermostats[index - 1];
            Console.Write($"Enter new temperature (°C): ");
            if (!double.TryParse(Console.ReadLine(), out double temp))
            {
                Console.WriteLine("Invalid temperature value.");
                return;
            }

            thermostat.TurnOn();
            thermostat.SetTemperature(temp);
        }

        private void HandleDoorLock()
        {
            var locks = _system.GetAllDoorLocks();
            if (locks.Count == 0)
            {
                Console.WriteLine("No door locks found.");
                return;
            }

            Console.WriteLine("🚪 Available Door Locks:");
            for (int i = 0; i < locks.Count; i++)
                Console.WriteLine($"  {i + 1}. {locks[i].GetStatus()}");

            Console.Write("Select door number: ");
            if (!int.TryParse(Console.ReadLine(), out int index) || index < 1 || index > locks.Count)
            {
                Console.WriteLine("Invalid selection.");
                return;
            }

            var door = locks[index - 1];
            Console.Write("Action — (1) Lock  (2) Unlock: ");
            string? action = Console.ReadLine();

            if (action == "1") door.Lock();
            else if (action == "2") door.Unlock();
            else Console.WriteLine("Invalid action.");
        }
    }
}
