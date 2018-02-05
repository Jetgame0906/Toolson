using System;
using static System.Console;
using System.Diagnostics;

namespace FileManager
{
	class FileManagerConsole
	{
		public static string userdir;

		public static void Main (string[] args)
		{
			userdir=System.Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
			if (args.Length > 0){
				gohand(args);
			}
			msh();
		}

		public static void gohand(string[] rargs)
		{
			Environment.Exit(0);
		}

		public static void showcsl(string cur){
			Write(cur + " >");
		}

		public static void msh()
		{
			while (true){
				showcsl(System.IO.Directory.GetCurrentDirectory());
				WriteLine(cexec(ReadLine()));
			}
		}

		public static string cexec(string cmds){
			if (cmds == "exit" || cmds == "quit" || cmds == "close"){
				Environment.Exit(0);
			}
			if (cmds=="list"||cmds=="showd"||cmds=="ls"||cmds=="dir"){
				showup_onlyname(System.IO.Directory.GetCurrentDirectory(),"*");
				return "";
			}
			if (cmds=="cd"){
				System.IO.Directory.SetCurrentDirectory(userdir);
				return "";
			}
			try{
				if (cmds.Substring(0,3) == "cd ")
				{
					cmds=cmds.Replace("~",userdir);
					string nowdir = System.IO.Directory.GetCurrentDirectory();
					string sd = cmds.Substring(3);
					if(System.IO.Directory.Exists(sd)){
						System.IO.Directory.SetCurrentDirectory(sd);
						return"";
					}else if(System.IO.Directory.Exists(nowdir + sd)){
						System.IO.Directory.SetCurrentDirectory(nowdir + sd);
						return"";
					}else if (System.IO.File.Exists(sd)){
						return"Directory Found not";
					}else if(System.IO.Directory.Exists(nowdir + sd)){
						return"Directory Found not";
					}else{
						return"Entry Found not";
					}	
				}
			}catch(Exception){
				
			}
			return "Command not found!";
		}

		public static void showup_onlyname(string dirpath,string filter){
			foreach (string fl in System.IO.Directory.GetFileSystemEntries(dirpath, filter)){
				WriteLine(System.IO.Path.GetFileName(fl));
			}
		}

		public static void showup_definf(string dirpath,string filter){
			foreach (string fl in System.IO.Directory.GetFileSystemEntries(dirpath, filter)){
				string fn = System.IO.Path.GetFileName(fl);
				System.IO.FileInfo finf = new System.IO.FileInfo(fl);
				long fs = finf.Length;
				WriteLine(fn + "  " + fs + "Bytes");
			}
		}
	}
}
