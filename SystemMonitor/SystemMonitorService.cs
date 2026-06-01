using System.Diagnostics;
using System.IO;
using System.Net.NetworkInformation;

namespace SystemMonitor
{
    public class SystemMonitorService
    {
        private PerformanceCounter cpuCounter;
        private PerformanceCounter ramCounter;
        private long lastBytes = 0;

        public SystemMonitorService()
        {
            cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            ramCounter = new PerformanceCounter("Memory", "% Committed Bytes In Use");
        }

        public float GetCpu()
        {
            return cpuCounter.NextValue();
        }

        public float GetRam()
        {
            return ramCounter.NextValue();
        }

        public string GetDisk()
        {
            DriveInfo drive = new DriveInfo("C");

            if (drive.IsReady)
            {
                long free = drive.AvailableFreeSpace / (1024 * 1024 * 1024);
                long total = drive.TotalSize / (1024 * 1024 * 1024);
                return $"Disk C: {free} GB free of {total} GB";
            }

            return "Disk not ready";
        }

        public long GetNetwork()
        {
            long current = 0;

            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (ni.OperationalStatus == OperationalStatus.Up)
                {
                    current += ni.GetIPv4Statistics().BytesReceived;
                }
            }

            long speed = current - lastBytes;
            lastBytes = current;

            return speed / 1024;
        }
    }
}