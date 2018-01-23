using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mono.Options;

namespace LOGGING
{
    class Program
    {
        public static string todefpath;
        public static string loggingBIN;

        public static bool help;

        public static string fname = "null";

        public static int loglevel = -10;
        public static string writeby = "null";
        public static string log = "null";

        public static List<string> anotherarg = new List<string>();

        static void Main(string[] args)
        {
            try
            {
                todefpath = Environment.GetEnvironmentVariable("toolsonpath", EnvironmentVariableTarget.Machine);
                loggingBIN = todefpath + "\\LOGSERVICE.tologservexec";
            }
            catch (ArgumentNullException)
            {
                Console.Write("CANT LOAD TOOLSON SYSTEM FRAME");
                return;
            }

            OptionSet options = new OptionSet()
            {
                { "h|help=", "Show command list", v => help = v != null },
                { "r=|read=", "Read Logfile", v => fname = v },
                { "l=|level=", "Log Level (more of -9 less of 9)", (int v) => loglevel = v },
                { "a=|apps=", "Writed apps(or Session) name", v => writeby = v },
                { "s=|string=", "Log", v => log = v },
            };
            anotherarg = options.Parse(args);
            if (help) { helpscr(options); }
            if (fname != "null") { readlog(fname); }
            if (loglevel != -10) { writelog(loglevel,writeby,log); ; }
        }
        
        static void writelog(int llev,string uan,string lstr)
        {
            //Write by (<TIME>)|[<Writer>][<FRAME>]|{<Agent>}|*<LogLevel>*|:<Log>
            string logsrc = "\n("+ DateTime.Now+ ")|[LOGSRV1][TOOLSON]|{" + uan + "}|*" + llev.ToString() + "*|:" + lstr;
            System.IO.File.AppendAllText(loggingBIN, logsrc, Encoding.GetEncoding("utf-8"));
        }

        static void readlog(string fname)
        {
            string[] srclog = System.IO.File.ReadAllLines(fname, Encoding.GetEncoding("utf-8"));
            foreach (string logtxt in srclog)
            {
                if (logtxt == "") { continue; }
                try{
                    string[] cutbyent = logtxt.Split('|');
                    if(writeby!="null"){if(cutbyent[2]!='{'+writeby+'}'){continue;}}
                    if(loglevel!=-10){if(cutbyent[3]!='*'+loglevel.ToString()+'*'){continue;}}
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(cutbyent[0]);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(cutbyent[1]);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write(cutbyent[2]);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(cutbyent[3]);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(cutbyent[4]);
                }catch(Exception){Console.ForegroundColor=ConsoleColor.Red;Console.WriteLine("File Error");Console.ResetColor();Environment.Exit(1);}
                Console.ResetColor();
            }
        }

        static void helpscr(OptionSet options)
        {
            Console.WriteLine("Toolson LOGGING FRAME :");
            options.WriteOptionDescriptions(Console.Out);
        }
    }
}
