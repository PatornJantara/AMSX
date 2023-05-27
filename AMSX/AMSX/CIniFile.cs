using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace AMSX
{
    class CIniFile
    {
        string Path;
        string EXE = Assembly.GetExecutingAssembly().GetName().Name;

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern long WritePrivateProfileString(string Section, string Key, string Value, string FilePath);

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);

        public CIniFile(string IniPath  , Dictionary<string,string[]> KeyValPair )
        {
            Path = new FileInfo(IniPath ?? EXE + ".ini").FullName;

            if (!File.Exists(Path))
            {
                if (!Directory.Exists(Path))
                {
                    Directory.CreateDirectory(System.IO.Path.GetDirectoryName(Path));
                }

                this.Create(KeyValPair);
            }

        }

        public string Read(string Key, string Section = null)
        {
            var RetVal = new StringBuilder(255);
            GetPrivateProfileString(Section ?? EXE, Key, "", RetVal, 255, Path);
            return RetVal.ToString();
        }

        public void Write(string Key, string Value, string Section = null)
        {
            WritePrivateProfileString(Section ?? EXE, Key, Value, Path);
        }

        public void DeleteKey(string Key, string Section = null)
        {
            Write(Key, null, Section ?? EXE);
        }

        public void DeleteSection(string Section = null)
        {
            Write(null, null, Section ?? EXE);
        }

        public bool KeyExists(string Key, string Section = null)
        {
            return Read(Key, Section).Length > 0;
        }

        public void Create(Dictionary<string, string[]> KeyValPair)
        {
            using (StreamWriter writer = new StreamWriter(Path))
            {

                foreach (string key in KeyValPair.Keys)
                {
                    writer.WriteLine($"[{key}]");

                    foreach (string Val in KeyValPair[key])
                    {
                        if(string.IsNullOrEmpty(Val))
                        {
                            continue;
                        }
                        writer.WriteLine($"{Val}=0");
                    }
                }
            }

        }
    }
}
