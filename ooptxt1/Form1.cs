using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace ooptxt1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string Vek(string rodcis,string jmeno)
        {
            //05 07 25 6508
            //David;2;0507256508

            bool prvni = false;

            int rok=Convert.ToInt32(rodcis.Substring(0,2));
            int mesic = Convert.ToInt32(rodcis.Substring(2, 2));
            int den = Convert.ToInt32(rodcis.Substring(4, 2));
            if (rok>=0)
            {
                rok += 2000;


            }
            else { rok +=  1900;
                mesic -= 50;
            }
            string mesicslovem;
            switch (mesic)
            {
                default:
                    {
                        mesicslovem = "neznámý";
                        break;
                    }
                case 1:
                    {
                        mesicslovem = "Leden";
                        break;
                    }
                case 2:
                    {
                        mesicslovem = "Únor";
                        break;
                    }
                case 3:
                    {
                        mesicslovem = "Březen";
                        break;
                    }
                case 4:
                    {
                        mesicslovem = "Duben";
                        break;
                    }
                case 5:
                    {
                        mesicslovem = "Květen";
                        break;
                    }
                case 6:
                    {
                        mesicslovem = "Červen";
                        break;
                    }
                case 7:
                    {
                        mesicslovem = "Červenec";
                        break;
                    }
                case 8:
                    {
                        mesicslovem = "Srpen";
                        break;
                    }
                case 9:
                    {
                        mesicslovem = "Září";
                        break;
                    }
                case 10:
                    {
                        mesicslovem = "Říjen";
                        break;
                    }
                case 11:
                    {
                        mesicslovem = "Listopad";
                        break;
                    }
                case 12:
                    {
                        if (!prvni)
                        {
                            MessageBox.Show(jmeno + "Je první člověk narozený v prosinci");
                            prvni = true;
                        }
                        mesicslovem = "Prosinec";
                        break;
                    }
            }
            DateTime narozky = new DateTime(rok, mesic, den);
            TimeSpan vek = new TimeSpan();
            vek = DateTime.Now - narozky;
            return "věk: "+(vek.Days / 365).ToString() + " " + mesicslovem;


        }



        private void button1_Click(object sender, EventArgs e)
        {

            listBox1.Items.Clear();
            listBox2.Items.Clear();
            double prumer = 0;
            double pocet = 0;
            int znamky = 0;
            string[] rozdel;
            StreamReader sr = new StreamReader("rodna_cis.txt");
            while (!sr.EndOfStream)
            {

                string line = sr.ReadLine();

                rozdel = line.Split(';');
                znamky = znamky + Convert.ToInt32(rozdel[1]);
                pocet++;
                listBox1.Items.Add(Vek(rozdel[2], rozdel[0]));
                listBox2.Items.Add(line);

            }

            sr.Close();
            prumer = znamky / pocet;


            StreamWriter zapis = new StreamWriter("rodna_cis.txt", true, Encoding.UTF8);

            zapis.WriteLine(";" + prumer.ToString());
            zapis.Close();
            MessageBox.Show(prumer.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form f2 = new Form2();
            f2.Show();
        }
    }
}
