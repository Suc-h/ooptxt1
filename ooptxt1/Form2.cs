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
using System.Windows.Forms.VisualStyles;

namespace ooptxt1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double start = 0;


            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                StreamReader sr = new StreamReader(openFileDialog1.FileName);
                FileStream cisla = new FileStream("cisla.dat", FileMode.Create, FileAccess.Write);
                BinaryWriter bw = new BinaryWriter(cisla);
                bw.BaseStream.Position = 0;
                while(!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] rozdel = line.Split(';');
                    for(int i = 0; i < rozdel.Count(); i++)
                    {
                        if(start < rozdel[i].Length)
                        {
                            start = rozdel[i].Length;
                        }
                    }
                    start = start / 10;
                    bw.Write(start);
                    start = 0;
                }
                sr.Close();
                bw.Close();
                cisla.Close();

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            FileStream cisla = new FileStream("cisla.dat", FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(cisla);
            br.BaseStream.Position = 0;
            while(br.BaseStream.Position < br.BaseStream.Length)
            {
                listBox1.Items.Add(br.ReadDouble());
            }
            br.Close();
            cisla.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FileStream cisla = new FileStream("cisla.dat", FileMode.OpenOrCreate, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(cisla);
            foreach(double a in listBox1.Items)
            {
                if(a<1)
                {

                    bw.Write((a*10));
                    listBox2.Items.Add(a*10);

                }
                else
                {
                    bw.Write(a);
                    listBox2.Items.Add(a);

                }

            }
            bw.Close ();
            cisla.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double prumer = 0;
            double pocet = 0;
            double soucet = 0;
            FileStream cisla = new FileStream("cisla.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryReader br = new BinaryReader(cisla);
            BinaryWriter bw = new BinaryWriter(cisla);

            br.BaseStream.Position = 0;
            while(br.BaseStream.Position<br.BaseStream.Length)
            {
                double cislo= br.ReadDouble();
                if(cislo>2)
                {
                    soucet = soucet + cislo;
                    pocet++;
                }
            }
            prumer = soucet / pocet;

            bw.BaseStream.Position=bw.BaseStream.Length;
            bw.Write (prumer);
            bw.Close ();
            br.Close ();
            cisla.Close();
        }
    }
}
