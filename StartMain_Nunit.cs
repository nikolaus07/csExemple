using NUnit.Framework;
using System;
using System.IO;

namespace csExemple
{
    class StartMain_Nunit
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void test_N_log()
        {
            Test_N_Log.testLogger();
            Assert.Pass();

            // output yyyy / mm / dd 10:37:21.518 | Info | das ist INFO-logger
            // output yyyy / mm / dd 10:37:21.587 | Warn | das ist WARN-logger
            // output yyyy / mm / dd 10:37:21.587 | Error | das ist ERROR-logger
            // output yyyy / mm / dd 10:37:21.587 | Fatal | das ist FATAL-logger
            // output yyyy / mm / dd 16:00:07.972 | Info | das ist INFO-logger
            // output yyyy / mm / dd 16:00:08.047 | Warn | das ist WARN-logger
            // output yyyy / mm / dd 16:00:08.169 | Error | das ist ERROR-logger
            // output yyyy / mm / dd 16:00:08.169 | Fatal | das ist FATAL-logger
        }


        [Test]
        public static void read_XML_file()
        {
            // merken create-dir  --> Directory.CreateDirectory(TestRun.sss);
            string xxx = Path.Combine("abc", "543", "DFG");   // ergibt abc\\543\\DFG
            xxx = Path.Combine("abc\\", "543", "DFG");  // ergibt abc\\543\\DFG

            var rootDir = AppDomain.CurrentDomain.BaseDirectory;
            rootDir = rootDir.Replace("bin\\", "");
            rootDir = rootDir.Replace("Debug\\", "");
            rootDir = rootDir.Replace("net48\\", "");
            string fileName = Path.Combine(rootDir, "resources");
            fileName = Path.Combine(fileName, "Beispielxml.xml");

            System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(xml_Read_Write.xmlWerte));

            StreamReader file = new StreamReader(fileName);
            var xx = (xml_Read_Write.xmlWerte)reader.Deserialize(file);
            var yy = xx.Parameter;

            int index = -9999;

            int anz = yy.Count;
            for (int i = 0; i < anz; i++)
            {
                string name = yy[i].Name;
                if (name.Contains("Kirsche"))
                {
                    index = i;

                    //  3. Element Kirsche wirde gefunden und im debug kann man yy[3].xx = 0 und yy[3].Name = Kirsche und yy[3].Max = 100 sehen
                    break;
                }
            }




        }  // end test



    }

}

