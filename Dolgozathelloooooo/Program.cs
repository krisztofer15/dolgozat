using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Dolgozathelloooooo
{

    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());


            UtazasRepository repo = new UtazasRepository();

            string[] lines = File.ReadAllLines("./utazasok.csv");

            Console.WriteLine("Utazasok:");
            for (int i = 1; i < lines.Length; i++)
            {
                Utazas utazas = Utazas.CreateFromCSVLine(lines[i]);
                repo.Save(utazas);

                Console.WriteLine(lines[i]);
            }

            Console.ReadLine();
        }
    }
}
