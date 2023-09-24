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
            string start = "";
            double delkades = 0;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openFileDialog1.FileName);

                while(!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    listBox1.Items.Add(line);
                    string[] rozdel = line.Split(';');

                    for(int i = 0; i < rozdel.Length; i++)
                    {
                        if (rozdel[i].Length > start.Length)
                        {
                            start = rozdel[i];

                            // 4 10 7
                        }
                    }
                    delkades = start.Length / 10;
                    MessageBox.Show(delkades.ToString());
                    FileStream a = new FileStream("cisla.dat", FileMode.Create, FileAccess.ReadWrite);
                    BinaryWriter bw = new BinaryWriter(a);
                    a.Position = 0;
                    bw.BaseStream.Position = 0;
                    for (int i = 0; i < listBox1.Items.Count; i++)
                    {
                        bw.Write(delkades);
                        listBox2.Items.Add(delkades);
                    }

                    a.Position = 0;
                    BinaryReader br = new BinaryReader(a);
                    br.BaseStream.Position = 0;
                    for (int i = 0; i < listBox1.Items.Count; i++)
                    {

                        listBox3.Items.Add(br.ReadDouble());

                    }
                    br.Close();
                    bw.Close();
                    a.Close();
                    start="";
                }
            }

        }
    }
}
