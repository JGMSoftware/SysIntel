using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SysIntelServer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            Console.WriteLine("There are: " + SystemInfo.getNumCores() + " cores.");
            Console.WriteLine("The machine is called: " + SystemInfo.getMachineName());
            Console.WriteLine("The machine has: " + SystemInfo.getTotalRam() + "MB of RAM.");
            Console.WriteLine("The machine has: " + SystemInfo.getAvailableRam() + "MB of RAM available.");
            Console.WriteLine("The machine has: " + SystemInfo.getUsedRam() + "MB currently in use.");
            Console.WriteLine("The current overall CPU usage is: " + SystemInfo.getOverallCpuUsage() + "%");

            int cores = SystemInfo.getNumCores();

            for (int i = 0; i < cores; i++)
            {
                Console.WriteLine("The current CPU usage for Core " + (i+1) + " is: " + SystemInfo.getCoreUsage(i.ToString()) + "%");
            }

        }
    }
}
