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
    class CTextFile
    {
        string Path;
        string EXE = Assembly.GetExecutingAssembly().GetName().Name;

        public CTextFile(string IniPath = null)
        {
            Path = new FileInfo(IniPath ?? EXE + ".txt").FullName;

            if (!File.Exists(Path)) 
            {
                this.Write("");
            }
        }

        public string Read()
        {
            string strData = "";

            string strLine = "";

            try
            {
                StreamReader sr = new StreamReader(Path);
                
                strLine = sr.ReadLine();

                strData += strLine + "\n";

                while (strLine != null)
                {
                    strLine = sr.ReadLine();

                    strData += strLine + "\n";
                }

                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }

            strData.Trim();

            return strData;
        }

        public void Write(string strData)
        {
            try
            {
                StreamWriter sw = new StreamWriter(Path);

                sw.Write(strData);

                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }


    }
}
