using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace toolson_pathservice
{
    class Program
    {

        [DllImport("KERNEL32.DLL")]
        public static extern uint GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);

        [DllImport("KERNEL32.DLL")]
        public static extern uint WritePrivateProfileString(string lpAppName, string lpKeyName, string lpString, string lpFileName);

        public static string todefpath;
        public static string confpath;


        static void Main(string[] args)
        {
            try {
                todefpath = Environment.GetEnvironmentVariable("toolsonpath", EnvironmentVariableTarget.Machine);
                confpath = todefpath + "\\config.ini";
            } catch (ArgumentNullException) {
                Console.Write("enull");
                return;
            }
            if (args[0] == "read")
            {
                Console.Write(Read_ini(args[1],args[2]));
            }
            else if (args[0] == "write")
            {
                Write_ini(args[1],args[2],args[3]);
            }
        }

        static string Read_ini(string appssel,string key)
        {
            var readedini = new StringBuilder(4096);
            GetPrivateProfileString(appssel,key,"null",readedini,readedini.Capacity,confpath);
            return readedini.ToString();
        }

        static void Write_ini(string appssel, string key, string value)
        {
            WritePrivateProfileString(appssel, key, value, confpath);
        }
    }
}
