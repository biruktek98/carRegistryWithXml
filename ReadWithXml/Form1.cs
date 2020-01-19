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
using System.Xml.Serialization;

namespace ReadWithXml
{
    public partial class Form1 : Form
    {

            XmlSerializer xs;
            List<CarClass> ls;
            public Form1()
            {
                InitializeComponent();
                ls = new List<CarClass>();
                xs = new XmlSerializer(typeof(List<CarClass>));
            }
        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("C:\\Users\\Biruk\\Documents\\Cars.xml", FileMode.Create, FileAccess.Write);
            CarClass cc = new CarClass();
            cc.Manufacturer = manufacturerText.Text;
            cc.Model = modelText.Text;
            cc.Year = int.Parse(yearText.Text);
            cc.Type = typeText.Text;

            ls.Add(cc);
            xs.Serialize(fs, ls);
            fs.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("C:\\Users\\Biruk\\Documents\\Cars.xml", FileMode.Open, FileAccess.Read);
            ls = (List<CarClass>)xs.Deserialize(fs);

            dataGridView1.DataSource = ls;
            fs.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
