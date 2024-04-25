using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dolgozathelloooooo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void kilépésToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void megnyitásToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                UtazasRepository.Path = openFileDialog1.FileName;
                using (StreamReader sr = new StreamReader(UtazasRepository.Path))
                {
                    
                    if (sr.Peek() >= 0)
                    {
                        
                        DataTable dataTable = new DataTable();
                        string[] headers = sr.ReadLine().Split(',');
                        foreach (string header in headers)
                        {
                            dataTable.Columns.Add(header);
                        }
                        while (!sr.EndOfStream)
                        {
                            string[] rows = sr.ReadLine().Split(',');
                            dataTable.Rows.Add(rows);
                        }
                        dataGridView1.DataSource = dataTable;
                    }
                    else
                    {
                        MessageBox.Show("A fájl üres.");
                    }
                }
            }
        }


        private void névjegyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Reporting 1.0\nCopyright (C) 2024 by Krisztofer Kóczé");
            new Form2().ShowDialog();
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void utazásToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Form2().ShowDialog();

        }
    }

    public class UtazasRepository
    {
        private List<Utazas> utazasok;
        public static string Path { get; set; }
        public static bool SkipHeader { get; set; } = true;
        public static char Separator { get; set; } = ',';

        public UtazasRepository()
        {
            utazasok = new List<Utazas>();
        }

        

        public List<Utazas> FindAll()
        {
            return utazasok;
        }

        

        public Utazas FindById(int id)
        {
            return utazasok.Find(u => u.Id == id);
        }

        public void Save(Utazas utazas)
        {
            if (utazas.Id == 0)
            {
                int maxId = utazasok.Count > 0 ? utazasok.Max(u => u.Id) : 0;
                utazas.Id = maxId + 1;
                utazasok.Add(utazas);
            }
            else
            {
                int index = utazasok.FindIndex(u => u.Id == utazas.Id);
                if (index != -1)
                {
                    utazasok[index] = utazas;
                }
            }
        }
    }

    public class Utazas
    {
        public int Id { get; set; }
        public string Orszag { get; set; }
        public int Honap { get; set; }
        public int Nap { get; set; }
        public int Hossz { get; set; }
        public int Ar { get; set; }
        public string Ellatas { get; set; }

        public Utazas(int id, string orszag, int honap, int nap, int hossz, int ar, string ellatas)
        {
            Id = id;
            Orszag = orszag;
            Honap = honap;
            Nap = nap;
            Hossz = hossz;
            Ar = ar;
            Ellatas = ellatas;
        }

        public override string ToString()
        {
            return $"Utazás {Id}: {Orszag}, {Honap}/{Nap}, Hossz: {Hossz} nap, Ár: {Ar}, Ellátás: {Ellatas}";
        }


        

        public static Utazas CreateFromCSVLine(string csvLine)
        {
            string[] parts = csvLine.Split(',');
            int id = int.Parse(parts[0]);
            string orszag = parts[1];
            int honap = int.Parse(parts[2]);
            int nap = int.Parse(parts[3]);
            int hossz = int.Parse(parts[4]);
            int ar = int.Parse(parts[5]);
            string ellatas = parts[6];

            return new Utazas(id, orszag, honap, nap, hossz, ar, ellatas);
        }

        public string ToCSVLine()
        {
            return $"{Id},{Orszag},{Honap},{Nap},{Hossz},{Ar},{Ellatas}";
        }
    }

}
