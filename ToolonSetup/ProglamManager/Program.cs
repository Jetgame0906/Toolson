using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ProglamManager
{
    class Program
    {
        public static string[] argsnow;

        /// <summary>
        /// Usage
        /// help : Open Help screen
        /// install [package name/url] : Install selected package
        /// ofinstall [package path] ; Install from "application install file" without Internet
        /// remove [package name/purl] : Remove selected package (also remove CD2 config)
        /// getbin [package name/url] : Get Package Binary (Only Downloadable package)
        /// update : Update official package database
        /// upgrade : Upgrade all package
        /// fullupdate : Update all package within Tools on core package
        /// tmpremove : Remove temp file
        /// </summary>
        public static string mode = "help";
        public static string purl = "null";
        public static bool pefile = false;
        public static bool pvfile = false;
        public static bool pvwsi = false;
        public static bool cinst = false;
        public static string verinfo = "";

        public static string tmpfile = System.IO.Path.GetTempFileName();

        public static string todefpath = "null";

        static void Main(string[] args)
        {
            argsnow = args;
            try
            {
                try
                {
                    todefpath = Environment.GetEnvironmentVariable("toolsonpath", EnvironmentVariableTarget.Machine);
                }
                catch (ArgumentNullException)
                {
                    cinst = false;
                }
                if (System.IO.File.Exists(todefpath + "\\pkgll.lk")) { return; }
                if (System.IO.Directory.Exists(todefpath)) { cinst = true; } else { cinst = false; }
                if (todefpath != "null") { if (System.IO.File.Exists(todefpath + "\\pkgmgr\\packageEntry.petd")) { pefile = true; } }
                if (todefpath != "null") { if (System.IO.File.Exists(todefpath + "\\pkgmgr\\verinfo.pvrd")) { pvfile = true; } }
                if (todefpath != "null") { if (System.IO.File.Exists(todefpath + "\\pkgmgr\\verinfo.pvrd")) { pvwsi = true; } }
                mode = args[0];
                if (mode == "help")
                {
                    helpscreen();
                    return;
                }
                else if (mode == "install")
                {
                    purl = args[1];
                    installpkg(purl);
                }
            }
            catch (IndexOutOfRangeException)
            {
                helpscreen();
                Environment.Exit(1);
            }
        }

        static void updatepkgent()
        {

        }

        static string checkpackageid(string pkgname)
        {
            //\As?https?://[-_.!~*'()a-zA-Z0-9;/?:@&=+$,%#]+\z
            return "nf";
        }

        static void getpkgfile(string pkgname,string pkgpath)
        {

        }

        static void installpkg(string pkgname)
        {
            if (pefile == false)
            {
                WriteLine("Start Installation within Online package database");
            }
            if (System.Text.RegularExpressions.Regex.IsMatch(pkgname,@"\As?https?://[-_.!~*'()a-zA-Z0-9;/?:@&=+$,%#]+\z"))
            {
                getpkgfile(pkgname,tmpfile);
            }
            else
            {

            }
        }

        static void installpkgfile(string pkgfilepath)
        {

        }

        static void helpscreen()
        {
            WriteLine("Tools on Package Manager\n\nUsage:");
            WriteLine("");
        }
    }
}
