// Minimal shim for LibreHardwareMonitor types used by the project so the project builds
// when the external LibreHardwareMonitorLib.dll is not present.
using System.Collections.Generic;

namespace LibreHardwareMonitor.Hardware
{
    public enum HardwareType
    {
        Cpu,
        // other types can be added if needed
    }

    public enum SensorType
    {
        Temperature,
        // other sensor types
    }

    public class Sensor
    {
        public SensorType SensorType { get; set; }
        public float? Value { get; set; }
    }

    public class Hardware
    {
        public HardwareType HardwareType { get; set; }
        public List<Sensor> Sensors { get; } = new List<Sensor>();
        public void Update() { }
    }

    public class Computer
    {
        public bool IsCpuEnabled { get; set; }
        public List<Hardware> Hardware { get; } = new List<Hardware>();
        public void Open() { }
    }
}
