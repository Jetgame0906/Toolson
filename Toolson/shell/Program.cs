//Assign at mkaraki

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shell
{
    class Program
    {

        public static System.Diagnostics.ProcessStartInfo readarg = new System.Diagnostics.ProcessStartInfo();
        public static string todefpath;
        public static string UPath;
        public static string UAPath;
        public static string UName;
        public static string UFName;

        static void Main(string[] args)
        {
            try
            {
                todefpath = Environment.GetEnvironmentVariable("toolsonpath", EnvironmentVariableTarget.Machine);
            }
            catch (ArgumentNullException)
            {
                Console.Write("enull");
                return;
            }
            readarg.FileName = todefpath + "\\readconf.exe";
            readarg.UseShellExecute = false;
            readarg.RedirectStandardOutput = true;
            readarg.CreateNoWindow = true;

            System.Diagnostics.Process readinf = new System.Diagnostics.Process();readinf.StartInfo = readarg;

            readinf.StartInfo.Arguments = "read grobal exappsdir";readinf.Start();UAPath = readinf.StandardOutput.ReadToEnd();readinf.WaitForExit();readinf.Close();

            readinf.StartInfo.Arguments = "read grobal userdir";
            readinf.Start();
            UPath = readinf.StandardOutput.ReadToEnd();
            readinf.WaitForExit();
            readinf.Close();

            readinf.StartInfo.Arguments = "read grobal username";
            readinf.Start();
            UName = readinf.StandardOutput.ReadToEnd();
            readinf.WaitForExit();
            readinf.Close();

            readinf.StartInfo.Arguments = "read grobal userfullname";
            readinf.Start();
            UFName = readinf.StandardOutput.ReadToEnd();
            readinf.WaitForExit();
            readinf.Close();

            if (args.Length == 0)
            {
                WaitUser();
            }
            else
            {
                string cmdarg = "";
                foreach (string arg in args)
                    cmdarg = cmdarg+arg;
            }
        }

        static string Readcommand(string command)
        {
            System.Globalization.StringInfo commandstr = new System.Globalization.StringInfo(command);
            string rettext = "unknown problem";
            try
            {
                if (command == "")
                {
                    rettext = "";
                    return rettext;
                }
                else if (commandstr.SubstringByTextElements(0, 3) == "cmd")
                {
                    try
                    {
                        rettext = "Run command " + '"' + commandstr.SubstringByTextElements(4) + '"';
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        rettext = "Open cmd";
                        System.Diagnostics.Process.Start("cmd.exe", @"/k cd %userprofile%");
                        return rettext;
                    }
                    System.Diagnostics.Process.Start("cmd.exe", @"/k @cd %userprofile% && " + commandstr.SubstringByTextElements(4));
                    return rettext;
                }
                else if (commandstr.SubstringByTextElements(0, 4) == "open")
                {

                    try
                    {
                        rettext = "Trying to open " + '"' + commandstr.SubstringByTextElements(5) + '"';

                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        rettext = "File name is not selected";
                        return rettext;
                    }
                    try
                    {
                        System.Diagnostics.Process.Start(commandstr.SubstringByTextElements(5));
                    }
                    catch (System.ComponentModel.Win32Exception)
                    {
                        rettext = "File not found";
                        return rettext;
                    }
                    rettext = "Sucsess to run " + '"' + commandstr.SubstringByTextElements(5) + '"';
                }
                else if (commandstr.SubstringByTextElements(0, 4) == "help")
                {
                    System.Diagnostics.Process.Start("cmd.exe", @"/c prompt $_ && cls &" +
                        "& echo Command List &" +
                        "& echo cmd : Open cmd or exec command(Argments) &" +
                        "& echo open (Proglam path) : Open Proglam &"
                        + "& echo hello : hello! &"
                        + "& echo  &"
                        + "&& echo. && pause");
                    return "";
                }
                else if (command == "hello")
                {
                    rettext = "Hello " + UFName + " :)";
                }
                else if (commandstr.SubstringByTextElements(0, 7) == "config ")
                {
                    try
                    {
                        
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        rettext = "Wrong Option";
                        return rettext;
                    }
                }
                else if (commandstr.SubstringByTextElements(0, 9) == "sshutdown")
                {
                    try
                    {
                        rettext = "Doing shutdown by " + commandstr.SubstringByTextElements(10);
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        rettext = "No option selected";
                        return rettext;
                    }
                    System.Diagnostics.Process.Start("shutdown.exe", commandstr.SubstringByTextElements(10));
                    rettext = "Sucsess";
                }
                else
                {
                    rettext = "No command found " + '"' + command + '"';
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                rettext = "No command found " + '"' + command + '"';
            }
            return rettext;

        }

        static void WaitUser()
        {
            
        }
    }
}
