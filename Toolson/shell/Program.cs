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
        static void Main(string[] args)
        {
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
                    rettext = "Hello " + userfullname + " :)";
                }
                else if (commandstr.SubstringByTextElements(0, 6) == "config")
                {
                    try
                    {
                        if (commandstr.SubstringByTextElements(7, 4) == "edit")
                        {
                            if (commandstr.SubstringByTextElements(12, 16) == "conf.assist.mode")
                            {
                                if (commandstr.SubstringByTextElements(28, 2) == " 0")
                                {
                                    EasyPCAssistant.Properties.Settings.Default.assistmode = 0;
                                    EasyPCAssistant.Properties.Settings.Default.Save();
                                    rettext = "Set config conf.assist.mode 0";
                                    return rettext;
                                }
                                else if (commandstr.SubstringByTextElements(28, 2) == " 1")
                                {
                                    EasyPCAssistant.Properties.Settings.Default.assistmode = 1;
                                    EasyPCAssistant.Properties.Settings.Default.Save();
                                    rettext = "Set config conf.assist.mode 1";
                                    return rettext;
                                }
                            }
                        }
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        optscr showopt = new optscr();
                        rettext = "Open config screen";
                        showopt.Show();
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
