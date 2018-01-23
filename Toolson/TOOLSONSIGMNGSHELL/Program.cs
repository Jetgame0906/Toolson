using Mono.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace TOOLSONSIGMNGSHELL
{
    class Program
    {
        public static string todefpath;
        public static string loggingFW;

        public static bool help;

        public static string reason = "Unknown";
        public static int runlevelcode = -1;
        public static bool exit;
        public static bool restart;
        public static bool list;
        public static int kill;
        public static string purge;
        public static string service;

        public static List<string> anotherarg = new List<string>();

        static void Main(string[] args)
        {
            try
            {
                todefpath = Environment.GetEnvironmentVariable("toolsonpath", EnvironmentVariableTarget.Machine);
                loggingFW = todefpath + "\\LOGGING.exe";
            }
            catch (ArgumentNullException)
            {
                Console.Write("CANT LOAD TOOLSON SYSTEM FRAME");
                return;
            }

            OptionSet options = new OptionSet()
            {
                { "h|help", "Show command list", v => help = v != null },

                { "w=|why=", "Reason (This value is logged)", v => reason = v },
                { "c=|code=", "Exec code", (int v) => runlevelcode = v },
                { "e|exit", "Exit Toolson Service Frame", v => exit = v != null },
                { "r|restart", "Restart Toolson Service Frame (Restart with ExecFrameSv)", v => restart = v != null },
                { "l|list", "Show tasklist (This command is using Parent OS Frame)", v => list = v != null },
                { "k=|kill=", "Kill Service or Process with PID (It is also works for Parent OS Frame)", (int v) => kill = v },
                { "p=|purge=", "Kill Service or Process with IM (It is also works for Parent OS Frame)", v => purge = v },
                { "s=|service=", "Start Toolson Native or Ext. Service", v => service = v },
            };
            anotherarg = options.Parse(args);
            if (help) { helpscr(options); }
        }

        static void helpscr(OptionSet options)
        {
            Console.WriteLine("Toolson CODE1 SIGNAL MANAGER SHELL\n\nUsage :");
            options.WriteOptionDescriptions(Console.Out);
        }
    }
}
