using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace SysIntelServer
{
    class SystemInfo
    {
        //Save the number of cores as a useful variable to have in this class
        private int cores = getNumCores();
        //Declare the counters so this doesn't happen every time we poll for info
        private static PerformanceCounter availableRam = new PerformanceCounter("Memory", "Available MBytes");
        private static PerformanceCounter cpuUsage = new PerformanceCounter("Processor", "% Processor Time", "_Total");

        //Return the number of cores the machine has
        public static int getNumCores()
        {
            return Environment.ProcessorCount;
        }

        //Return the name of the machine
        public static String getMachineName()
        {
            return Environment.MachineName;
        }

        //Get the total amount of installed physical RAM in the machine
        public static int getTotalRam()
        {
            //Use a VB library to get the total in bytes
            ulong rambytes = new Microsoft.VisualBasic.Devices.ComputerInfo().TotalPhysicalMemory;
            //Convert bytes to MB, cast to int for use.
            int rammeg = (int)(rambytes / 1024) / 1024;
            return rammeg;
        }

        //Use the performance counter declared at the top to get the currently available RAM
        public static int getAvailableRam()
        {
            return (int)availableRam.NextValue();
        }

        //Calculate the used RAM from the total and the avalable RAM.
        public static int getUsedRam()
        {
            return getTotalRam() - getAvailableRam();
        }

        //Get the overall CPU usage
        public static int getOverallCpuUsage()
        {
            //The initial value will always return 0
            cpuUsage.NextValue();
            //Wait so the counter has something to compare against
            System.Threading.Thread.Sleep(750);
            //Save and return the second percentage
            int percentage = (int)cpuUsage.NextValue();
            return percentage;
        }

        //Get the CPU usage for the core passed in
        public static int getCoreUsage(String core)
        {
            //Generate a new counter for core x
            PerformanceCounter coreUsage = new PerformanceCounter("Processor", "% Processor Time", core);
            coreUsage.NextValue();
            System.Threading.Thread.Sleep(750);
            int corePercentage = (int)coreUsage.NextValue();
            return corePercentage;
        }
    }
}
