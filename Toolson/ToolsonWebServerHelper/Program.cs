using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ToolsonWebServerHelper
{
    class Program
    {
        public static string todefpath;

        public static string wsverinf="Unknown";

        public static string[] tsoninfod;

        static void Main(string[] args)
        {
            try
            {
                todefpath = Environment.GetEnvironmentVariable("toolsonpath", EnvironmentVariableTarget.Machine);
            }
            catch (ArgumentNullException)
            {
                Console.Write("Error");
                return;
            }

            wsverinf = System.Diagnostics.FileVersionInfo.GetVersionInfo(todefpath+"\\webserver\\httpd.exe").FileVersion.Replace('"',' ');
            //wsverinf = System.Diagnostics.FileVersionInfo.GetVersionInfo(todefpath+"\\webserver\\httpd.exe").FileVersion.Replace(' ','"');
            tsoninfod =System.IO.File.ReadAllText(todefpath + "\\toolsoninf.toi", Encoding.GetEncoding("shift_jis")).Split('|');

            writeVItoXML();
        }

        static void repaireconf()
        {

        }

        static void repairehtml()
        {

        }

        static void writeVItoXML()
        {
            var xml = new XDocument(
                new XDeclaration("1.0", "utf-8", "true"),
                new XComment("Tools on Information for web server"),
                new XElement("VINF",
            new XElement("WebServerInfo",
               new XElement("Server_Neme", "Apache"),
               new XElement("Version", wsverinf)
            ),
            new XElement("ToolsonInfo",
               new XElement("Name", "Tools_on"),
               new XElement("Version", tsoninfod[0]),
               new XElement("Branch", tsoninfod[1]),
                     new XElement("Installer_Branch", tsoninfod[2]),
                     new XElement("Installer_Mode", tsoninfod[3])
                 )
            )
        );

            xml.Save(todefpath+"\\webserver\\wr\\toolsoninf.xml");
        }
    }
}
