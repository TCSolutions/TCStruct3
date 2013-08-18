using System;
using System.Xml;
using System.Collections.Generic;
using System.Text;
using TCStruct3Wrapper.Events;

namespace TCStruct3_Debug_Application
{
    class TCStructDebugConsole
    {
        static void Main()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(@"E:\Development\Solutions\TCStruct3\TCStruct3 Debug Application\Main\Template.xml");
            XmlNodeList xnlGames = xmlDoc.SelectNodes("Game");
            foreach (XmlNode xnGame in xnlGames)
            {
                Console.WriteLine((xnGame.SelectSingleNode("DefaultEnabled").InnerText=="1").ToString());
                Console.WriteLine(xnGame.SelectSingleNode("Title").InnerText);
                Console.WriteLine(xnGame.SelectSingleNode("Comments").InnerText);
            }

            TCStruct3Wrapper.TCStruct3.TC3Client lol1 = new TCStruct3Wrapper.TCStruct3.TC3Client();
            lol1.DebugOutputEvent += PrintDebugOutput;

            Console.WriteLine(lol1.InitializeDebugOutput().ToString());
            lol1.LOLTEST();
            Console.ReadKey();
            lol1.Dispose();
        }

        static void PrintDebugOutput(Object sender, DebugEventArgs e)
        {
            Console.WriteLine(e.DebugOutput);
        }
    }
}
