# SmartHome-Core

SmartHome-Core is a console-based smart home simulation project.
It demonstrates object-oriented programming, inheritance, encapsulation,
device control logic, and modular software design.

---

## Features

- 🏠 Multiple rooms: Living Room, Bedroom, Garage
- 💡 Light control — turn on/off, adjust brightness
- 🌡️ Thermostat — set temperature per room
- 🔒 Door Lock — lock/unlock individual doors
- 📋 Console menu interface — clean and navigable

---

## Project Structure

```
SmartHome-Core/
├── src/
│   ├── Models/
│   │   ├── Device.cs          # Abstract base class
│   │   ├── Light.cs           # Inherits Device
│   │   ├── Thermostat.cs      # Inherits Device
│   │   └── DoorLock.cs        # Inherits Device
│   ├── System/
│   │   ├── Room.cs            # Holds devices per room
│   │   └── SmartHomeSystem.cs # Manages all rooms
│   ├── MenuHandler.cs         # Console menu logic
│   └── Program.cs             # Entry point
└── SmartHomeCore.csproj
```

---

## OOP Concepts Demonstrated

| Concept | Where Used |
|---|---|
| Abstraction | `Device` abstract class |
| Inheritance | `Light`, `Thermostat`, `DoorLock` extend `Device` |
| Encapsulation | Private fields + public properties/methods |
| Polymorphism | `GetStatus()` overridden per device |

---

## How to Run

**Requirements:** .NET 8 SDK

```bash
git clone https://github.com/YOUR_USERNAME/SmartHome-Core.git
cd SmartHome-Core
dotnet run
```

---

## Roadmap

- [x] v1.0 — Console menu + OOP device control
- [ ] v1.1 — Sensor simulator (motion, temperature)
- [ ] v1.2 — Automation rules engine
- [ ] v1.3 — Unit tests (xUnit)
- [ ] v2.0 — REST API (ASP.NET Core)

---

## Tech Stack

- Language: C# (.NET 8)
- Paradigm: Object-Oriented Programming
- Interface: Console / Terminal

---

*Built as a portfolio project for George Brown College — Computer Programming.*
