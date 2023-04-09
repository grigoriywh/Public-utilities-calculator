using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.Drawing;

namespace MainClass
{

    [Serializable]
    public class ClassXML
    {
        private string m_exePath = string.Empty;


        [XmlAttribute]
        public float KvartPlataTarif;
        public float ElectricityTarif;
        public int someint;

        public string[] stringArray;
        public int[,] intArray;


        [XmlArray]
        [XmlArrayItem("v")]
        public string[] XMLStringArray
        {
            get { return stringArray; }
            set { stringArray = value; }
        }

        [XmlArray]
        [XmlArrayItem("n")]
        public int[,] XMLArrayint
        {
            get { return intArray; }
            set { intArray = value; }
        }


    }




    public class Class : DirectoryReading
    {
        private string m_exePath = string.Empty;
        private long size;
        private long SizeRequirements;
        private bool isFileReadOnly;

        public bool isFileReadOnlyFunc
        {
            get { return isFileReadOnly; }
        }

        public long FileSize
        {
            get { return size; }
        }

        public long setRequirementsSizeFile
        {
            set { SizeRequirements = value; }
        }

        public long getRequirementsSizeFile
        {
            get { return SizeRequirements; }
        }


        public void init(SortedList<string, object> parameters)
        {

        }


        public string[] DirectoryTree(string path)
        {

            string[] outTextBox = {};

            List<string> list = new List<string>();
            //list.Add(path);
            LogWrite(path);


            try
            {
                string[] files = Directory.GetFiles(
                      path, "*.*",
                      SearchOption.TopDirectoryOnly);

                string[] directories =
                        Directory.GetDirectories(
                            path, "*.*", SearchOption.
                                   TopDirectoryOnly);

                int countDirectories = directories.Length;
                int countFiles = files.Length;

                for (int i = 0; i < countFiles; i++)
                {

                    FileInfo file = new FileInfo(files[i]);
                    //size = file.Length / 1048576; // convert to MB
                    size = file.Length; // Длинна в байтах
                    isFileReadOnly = file.IsReadOnly;


                    if (size >= SizeRequirements)
                    {
                        list.Add(files[i]);
                        LogWrite(files[i] + " Size - " + size + " bytes " + " SizeRequirements - " + SizeRequirements + " bytes " + " TRUE");
                    }
                    else
                    {
                        LogWrite(files[i] + " Size - " + size + " bytes " + " SizeRequirements - " + SizeRequirements + " bytes " +  "FALSE");
                    }

                }


                for (int i = 0; i < countDirectories; i++)
                {

                    string[] somefiles = DirectoryTree(directories[i]);

                    for (int u = 0; u < somefiles.Length; u++)
                    {
                        list.Add(somefiles[u]);
                    }
                }

                outTextBox = list.ToArray();
                return outTextBox;

            }
            catch (Exception e) { 
            
            
            }

            outTextBox = list.ToArray();
            return outTextBox;
        }


        public void LogWrite(string logMessage)
        {
            m_exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            try
            {
                using (StreamWriter w = File.AppendText(m_exePath + "\\" + "log.txt"))
                {
                    Log(logMessage, w);
                }
            }
            catch (Exception ex)
            {
            }
        }

        public void Log(string logMessage, TextWriter txtWriter)
        {
            try
            {
                // \r\n
                txtWriter.Write("Log Записан: ");
                txtWriter.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                    DateTime.Now.ToLongDateString());
                txtWriter.WriteLine("  {0}", logMessage);
                txtWriter.WriteLine("-------------------------------");
            }
            catch (Exception ex)
            {
            }
        }

    }

   public class LogWriter
    {
        private string m_exePath = string.Empty;
        public LogWriter(string logMessage)
        {
            LogWrite(logMessage);
        }
        public void LogWrite(string logMessage)
        {
            m_exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            try
            {
                using (StreamWriter w = File.AppendText(m_exePath + "\\" + "log.txt"))
                {
                    Log(logMessage, w);
                }
            }
            catch (Exception ex)
            {
            }
        }

        public void Log(string logMessage, TextWriter txtWriter)
        {
            try
            {
                txtWriter.Write("\r\nLog Entry : ");
                txtWriter.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                    DateTime.Now.ToLongDateString());
                txtWriter.WriteLine("  :{0}", logMessage);
                txtWriter.WriteLine("-------------------------------");
            }
            catch (Exception ex)
            {
            }
        }
    }

}
