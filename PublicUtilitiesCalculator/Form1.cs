using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Diagnostics;
using MainClass;
using System.Xml;
using System.Xml.Serialization;

namespace PublicUtilitiesCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        // Main class

        static void Serialize_XmlSerializer(ClassXML obj, string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create);
            XmlSerializer x = new XmlSerializer(obj.GetType());
            x.Serialize(fs, obj);
            fs.Close();
        }

        static void Serialize_XmlWriter(ClassXML obj, string fileName)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            XmlWriter writer = XmlWriter.Create(fileName, settings);

            writer.WriteStartDocument();
            writer.WriteStartElement("ClassXML");

            writer.WriteAttributeString("someint", obj.someint.ToString());

            // Записываем массив строк

                if (obj.XMLStringArray != null)
                {
                    writer.WriteStartElement("XMLStringArray");
                    writer.WriteAttributeString("rows", obj.XMLStringArray.Length.ToString());
                    for (int i = 0; i < obj.XMLStringArray.Length; i++)
                    {
                        writer.WriteElementString("v", obj.XMLStringArray[i]);
                    }
                    writer.WriteEndElement();
                }


            // Записываем двухмерный массив


            if (obj.XMLArrayint != null)
            {
                int rows = obj.XMLArrayint.GetUpperBound(0);    // количество строк
                int columns = obj.XMLArrayint.Length / rows;        // количество столбцов

                writer.WriteStartElement("XMLArrayint");
                writer.WriteAttributeString("rows", rows.ToString());
                writer.WriteAttributeString("columns", (columns - 5).ToString());

                for (int i = 1; i < rows + 1; i++)
                {
                    for (int j = 1; j < columns - 4; j++)
                    {

                        writer.WriteElementString("n", obj.XMLArrayint[i, j].ToString());
                    }
                }
                writer.WriteEndElement();
            }



            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
        }



        ///////////////////////////////////////////////////////////////////////////////////////////////
        //		Кнопки 

        private void Clear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void Clear2_Click(object sender, EventArgs e)
        {
            KvartPlatatextBox.Text = "";
        }


        ///////////////////////////////////////////////////////////////////////////////////////////////
        //	Форма - Выбор директории

        private void button1_Click(object sender, EventArgs e)  // Выбор директории
        {

            /* FolderBrowserDialog ChoiceFolder = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
            }
            */

            DateTime d = monthCalendar1.SelectionRange.Start;
            textBox1.Text = textBox1.Text + "\n Дата :" + d.Date.ToString();
            textBox1.Text = textBox1.Text + "\n Месяц :" + d.Month.ToString();
            textBox1.Text = textBox1.Text + "\n Год :" + d.Year.ToString();
            //DateTime b = monthCalendar1.SelectionRange.Start;
            //textBox1.Text = Convert.ToString(monthCalendar1.TodayDate);

        }

        private void button2_Click(object sender, EventArgs e)  // Считать files
        {

            DirectoryReading handler = new Class();

            List<string> list = new List<string>();
            string dirName = textBox1.Text;


        }

        private void TarifiSave_Click(object sender, EventArgs e)
        {
            float floatKvartPlataTarif = 0;
            float floatElectricityTarif = 0;
            //int
            if (KvartPlataTarif.Text != "")
            {
                floatKvartPlataTarif = float.Parse(KvartPlataTarif.Text);
            }

            if (KvartPlataTarif.Text != "")
            {
                floatElectricityTarif = float.Parse(ElectricityTarif.Text);
            }

            

            ClassXML src = new ClassXML();
            src.KvartPlataTarif = floatKvartPlataTarif;
            src.ElectricityTarif = floatElectricityTarif;

            // Get the current directory.
            string path = Directory.GetCurrentDirectory() + "/Tarifi";


            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            int curmonth = DateTime.Now.Month;
            int curyear = DateTime.Now.Year;
            int n = Convert.ToInt32(Console.ReadLine());
            for (int i = n; i >= 0; i--)
            {
                if (curmonth.Equals(0))
                    curmonth = 12;
                curmonth--;
            }
            string[] months = { "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };

           
            Serialize_XmlWriter(src, "Tarifi/" + "Тарифы_" + months[(curmonth)]  + "_" + curyear + ".xml");

            textBox1.Text += File.ReadAllText("Tarifi/" + "Тарифы_" + months[(curmonth)] + "_" + curyear + ".xml");
            textBox1.Text += Environment.NewLine;

        }


        private void folderBrowserDialog1_HelpRequest_1(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        //	Пустые функции 


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void KvartPlatacheckBoxChetchik_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
