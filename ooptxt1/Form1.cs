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

namespace ooptxt1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string Vek(string text)
        {
            //05 07 25 6508
            //David;2;0507256508
            string[] rozdel=text.Split(';');
            
            string rodcis = rozdel[2];


            int rok=Convert.ToInt32(rodcis.Substring(0,2));
            if(rok>=0)
            {
                rok += 2000;
            }
            else { rok += 1900; }
            int mesic= Convert.ToInt32(rodcis.Substring(2,2));
            int den= Convert.ToInt32(rodcis.Substring(4,2));
         

            DateTime narozky = new DateTime(rok, mesic, den);
            TimeSpan vek = new TimeSpan();
            vek = DateTime.Now - narozky;
            return "věk: "+(vek.Days / 365).ToString();


        }



        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("rodna_cis.txt");
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                listBox1.Items.Add(Vek(line));
                listBox2.Items.Add(line);
            }
            sr.Close();
        }
    }
}
