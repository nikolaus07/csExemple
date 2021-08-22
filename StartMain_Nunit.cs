using NUnit.Framework;
using System;
using System.Data;
using System.IO;
using System.Xml;

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
        public static void xml_read()
        {
            //    <?xml version="1.0" encoding="utf-8"?>
            //    <BeispielWerte Fingerprint="3456775">
            //      <Werte Name="Banane"    xx="0"  wert="33"  Default="20"    Min="1"  Max="41"     Show="True"  />
            //      <Werte Name="Apfel"     xx ="0" wert="100" Default="10"    Min="-1" Max="100"    Show="True"  />
            //      <Werte Name="Pflaume"   xx="0"  wert="550" Default="30"    Min="0"  Max="10"     Show="True"  />
            //      <Werte Name="Kirsche"   xx="0"  wert="667" Default="10"    Min="0"  Max="100"    Show="True"  />
            //    </BeispielWerte>

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


    

        [Test]
        public static void xml_update()
        {
            int index = 3; // die Kirsche

            var rootDir = AppDomain.CurrentDomain.BaseDirectory;
            rootDir = rootDir.Replace("bin\\", "");
            rootDir = rootDir.Replace("Debug\\", "");
            rootDir = rootDir.Replace("net48\\", "");
            string fileName = Path.Combine(rootDir, "resources");
            fileName = Path.Combine(fileName, "Beispielxml.xml");

            // updaten 
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(fileName);

            DataSet ds = new DataSet();
            ds.ReadXml(fileName);
            ds.Tables[0].Rows[0]["Fingerprint"] = "654456klaus";  // OK -> ParameterValues Fingerprint="654456klaus">
            ds.Tables[1].Rows[3]["Name"] = "Kirsche_update_name";
            ds.Tables[1].Rows[3]["Max"] = "987";

            ds.AcceptChanges();
            ds.WriteXml(fileName);

            /*  Ergebnis.  In 3. Zeile wird aus 'Kirsche' 'Kirsch_update' und Max wird zu 987 gesetzt
               <?xml version="1.0" standalone="yes"?>
               <BeispielWerte Fingerprint="654456klaus">
                 <Werte Name="Banane" xx="0" wert="33" Default="20" Min="1" Max="41" Show="True" />
                 <Werte Name="Apfel" xx="0" wert="100" Default="10" Min="-1" Max="100" Show="True" />
                 <Werte Name="Pflaume" xx="0" wert="550" Default="30" Min="0" Max="10" Show="True" />
                 <Werte Name="Kirsche_update_name" xx="0" wert="667" Default="10" Min="0" Max="987" Show="True" />
               </BeispielWerte>
             */
        }

    }

}

