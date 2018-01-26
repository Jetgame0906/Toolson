using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsonScript
{
    class Program
    {
        public static string todefpath;
        public static string rubypath;
        public static string phppath;

        public static string arg1;

        /// <summary>
        /// Usage:
        /// check : Check Library
        /// <Filename> : Open and exec the "Toolson supported Script (Ruby or PHP Based)"
        /// update : Update native script support file
        /// sif <method name> : Help of method
        /// help : How to use this application
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            try
            {
                todefpath = Environment.GetEnvironmentVariable("toolsonpath", EnvironmentVariableTarget.Machine);
            }
            catch (ArgumentNullException)
            {
                Console.Write("Error : Toolson Framework not Installed");
                return;
            }
            rubypath = todefpath + "\\script\\ruby\\bin\\ruby.exe";
            phppath = todefpath + "\\script\\php\\php.exe";

            try{
                arg1 = args[0];
            }catch (IndexOutOfRangeException)
            {
                apphelpscr();
                Environment.Exit(1);
            }
            switch (arg1)
            {
                case "check":
                    break;
                case "update":
                    break;
                case "sif":
                    break;
                case "help":
                    apphelpscr();
                    return;
                default:
                    if (System.IO.File.Exists(arg1)) { checkscr(arg1); }
                    break;
            }
        }

        static void checkscr(string fname)
        {
            string filemeat = System.IO.File.ReadAllText(fname, Encoding.GetEncoding("utf-8"));
            switch (System.IO.Path.GetExtension(fname))
            {
                case ".rb":
                    if (System.Text.RegularExpressions.Regex.IsMatch(filemeat, @"require\s" + '"' + @".*toolson\.rb" + '"'))
                    { OpenRuby(fname); }
                    else {
                        Console.WriteLine("This file is not supported.\nBe Load toolson tool kit");
                        Environment.Exit(3);
                    }
                    break;
                case ".php":
                    if (System.Text.RegularExpressions.Regex.IsMatch(filemeat, @"require\s" + '"' + @".*toolson\.php" + '"'))
                    { OpenPHP(fname); }
                    else
                    {
                        Console.WriteLine("This file is not supported.\nBe Load toolson tool kit");
                        Environment.Exit(3);
                    }
                    break;
                default:
                    Console.WriteLine("This file is not supported");
                    Environment.Exit(2);
                    break;
            }
        }

        static void apphelpscr()
        {
            Console.WriteLine("Script Usage:\n"+
                "PHP : Set require " + '"' + todefpath + "\\script\\php\\toolson.php" + '"' + "\n" +
                "Ruby : Set require " + '"' + todefpath + "\\script\\ruby\\toolson.rb" + '"' +
                "\n\nApplication Usage :\n"+
        "check : Check Library\n"+
        "<Filename> : Open and exec the 'Toolson supported Script (Ruby or PHP Based)'\n"+
        "update : Update native script support file\n"+
        "sif <method name> : Help of method\n"+
        "help : How to use this application\n");
        }

        static void OpenPHP(string filename)
        {
            if (!System.IO.File.Exists(phppath))
            {
                Console.WriteLine("PHP Script Loader cound not be detect!");
                Environment.Exit(4);
            }
            System.Diagnostics.Process.Start(@"D:\VSP\Projects\Toolson\Toolson\Thirdparty\php-7.2.1-Win32-VC15-x64\php.exe",filename);
        }

        static void OpenRuby(string filename)
        {
            if (!System.IO.File.Exists(rubypath))
            {
                Console.WriteLine("Ruby Script Loader cound not be detect!");
                Environment.Exit(4);
            }
            System.Diagnostics.Process.Start(@"D:\VSP\Projects\Toolson\Toolson\Thirdparty\rubyinstaller-2.5.0-1-x64\bin\ruby.exe", filename);
        }
    }
}
