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


        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Сериализация 

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

        static void SerializeTarifi_XmlWriter(ClassXML obj, string fileName)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            XmlWriter writer = XmlWriter.Create(fileName, settings);

            writer.WriteStartDocument();
            writer.WriteStartElement("Tarifi");

            writer.WriteAttributeString("Time", DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString());


            writer.WriteStartElement("KvartPlataTarif");
            writer.WriteElementString("KvartPlataprice", obj.KvartPlataTarif.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("ElectricityTarif");
                writer.WriteStartElement("ElectricityTarif150");
                    writer.WriteElementString("ElectricityTarif150Price", obj.ElectricityTarif150.ToString());
                writer.WriteEndElement();
                writer.WriteStartElement("ElectricityTarif150_800");
                    writer.WriteElementString("ElectricityTarif150_800Price", obj.ElectricityTarif150_800.ToString());
                writer.WriteEndElement();
                writer.WriteStartElement("ElectricityTarif800");
                    writer.WriteElementString("ElectricityTarif800Price", obj.ElectricityTarif800.ToString());
                writer.WriteEndElement();
            writer.WriteEndElement();

            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////
        // Десериализация 


        static ClassXML Deserialize_XmlReader(string fileName)
        {
            ClassXML obj = new ClassXML();
            XmlReader reader = XmlReader.Create(fileName);
            List<string> stringList = new List<string>();
            List<int> intList = new List<int>();
            int rows = 1, columns = 1;
            reader.Read();
            for (; ; )
            {
                XmlNodeType type = reader.NodeType;
                if (type == XmlNodeType.Element)
                {
                    switch (reader.Name)
                    {
                        case "Tarifi":
                            reader.MoveToAttribute("someint");
                            obj.someint = reader.ReadContentAsInt();
                            break;
                        case "XMLArrayint":
                            reader.MoveToAttribute("rows");
                            rows = reader.ReadContentAsInt();
                            reader.MoveToAttribute("columns");
                            columns = reader.ReadContentAsInt();
                            break;
                        case "v":
                            stringList.Add(reader.ReadElementContentAsString());
                            break;
                        case "n":
                            intList.Add(reader.ReadElementContentAsInt());
                            break;
                        case "XMLImage":
                            {

                            }
                            break;
                        default:
                            reader.Read();
                            break;
                    }
                }
                else if (reader.NodeType == XmlNodeType.EndElement)
                {
                    switch (reader.Name)
                    {
                        case "XMLStringArray":
                            obj.XMLStringArray = stringList.ToArray();
                            break;

                        case "XMLArrayint":

                            int[] tempArray = intList.ToArray();
                            int[,] MyArray = new int[rows, columns];

                            int CounterNumbers = 0;
                            for (int i = 0; i < rows; i++)
                            {

                                for (int j = 0; j < columns - 1; j++)
                                {

                                    MyArray[i, j] = tempArray[CounterNumbers];
                                    CounterNumbers += 1;
                                }
                            }

                            obj.XMLArrayint = MyArray;
                            break;
                    }
                    if (!reader.Read())
                        break;
                }
                else
                {
                    if (!reader.Read())
                        break;
                }
            }

            reader.Close();

            return obj;
        }

        static ClassXML DeserializeTarifi_XmlReader(string fileName)
        {
            ClassXML obj = new ClassXML();
            XmlReader reader = XmlReader.Create(fileName);
            List<string> stringList = new List<string>();
            List<int> intList = new List<int>();
            int rows = 1, columns = 1;
            reader.Read();
            for (; ; )
            {
                XmlNodeType type = reader.NodeType;
                if (type == XmlNodeType.Element)
                {
                    switch (reader.Name)
                    {
                        case "KvartPlataprice":
                            obj.KvartPlataTarif = float.Parse(reader.ReadElementContentAsString());
                            break;
                        case "ElectricityTarif150Price":
                            obj.ElectricityTarif150 = float.Parse(reader.ReadElementContentAsString());
                            break;
                        case "ElectricityTarif150_800Price":
                            obj.ElectricityTarif150_800 = float.Parse(reader.ReadElementContentAsString());
                            break;
                        case "ElectricityTarif800Price":
                            obj.ElectricityTarif800 = float.Parse(reader.ReadElementContentAsString());
                            break;
                        case "XMLImage":
                            {

                            }
                            break;
                        default:
                            reader.Read();
                            break;
                    }
                }
                else if (reader.NodeType == XmlNodeType.EndElement)
                {
                    switch (reader.Name)
                    {
                        case "XMLStringArray":
                            obj.XMLStringArray = stringList.ToArray();
                            break;

                        case "XMLArrayint":

                            int[] tempArray = intList.ToArray();
                            int[,] MyArray = new int[rows, columns];

                            int CounterNumbers = 0;
                            for (int i = 0; i < rows; i++)
                            {

                                for (int j = 0; j < columns - 1; j++)
                                {

                                    MyArray[i, j] = tempArray[CounterNumbers];
                                    CounterNumbers += 1;
                                }
                            }

                            obj.XMLArrayint = MyArray;
                            break;
                    }
                    if (!reader.Read())
                        break;
                }
                else
                {
                    if (!reader.Read())
                        break;
                }
            }

            reader.Close();

            return obj;
        }


        public string StrManipulations(string LocalStringTempValue)
        {

            Char[] ch = LocalStringTempValue.ToCharArray();
            for (int i = 0; i < ch.Length; i++)
            {
                if (ch[i] == '.')
                    ch[i] = ',';
            }
            LocalStringTempValue = new string(ch);
            return LocalStringTempValue;
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

            textBox1.Text += Environment.NewLine;

            int curmonth = DateTime.Now.Month;

            textBox1.Text = textBox1.Text + "\n Дата :" + DateTime.Now.ToLongDateString() + "  " + DateTime.Now.ToLongTimeString();
            textBox1.Text += Environment.NewLine;





            DateTime d = monthCalendar1.SelectionRange.Start;
            textBox1.Text = textBox1.Text + "\n Дата :" + d.Date.ToString();
            textBox1.Text += Environment.NewLine;
            textBox1.Text = textBox1.Text + "\n Месяц :" + d.Month.ToString();
            textBox1.Text += Environment.NewLine;
            textBox1.Text = textBox1.Text + "\n Год :" + d.Year.ToString();
            //DateTime b = monthCalendar1.SelectionRange.Start;
            //textBox1.Text = Convert.ToString(monthCalendar1.TodayDate);


            ///////////////////////////////////////////////////////////////////////////////////////////////
            //	Блок расчета 
            ///////////////////////////////////////////////////////////////////////////////////////////////

            //	Заменяем точки на запятые
            KvartPlataTarif.Text = StrManipulations(KvartPlataTarif.Text);
            ElectricityTarif150.Text = StrManipulations(ElectricityTarif150.Text);
            ElectricityTarif150_800.Text = StrManipulations(ElectricityTarif150_800.Text);
            ElectricityTarif800.Text = StrManipulations(ElectricityTarif800.Text);

            ///////////////////////////////////////////////////////////////////////////////////////////////
            //	Квартплата 
            float KvartPlataResult = 0;
            float floatKvartPlataTarif = 0;

            if (KvartPlataTarif.Text != "")
            {
                floatKvartPlataTarif = float.Parse(KvartPlataTarif.Text);
            }

            KvartPlataResult = floatKvartPlataTarif;

            KvartPlatatextBox5.Text = Convert.ToString(KvartPlataResult);

            ///////////////////////////////////////////////////////////////////////////////////////////////
            // Элекетроэнергия

            float ElectricityOnToTheStartMonth = 0;
            float ElectricityOnToTheEndMonth = 0;
            float ElectricityDifference = 0;


            float ElectricityResult = 0;
            float floatElectricityTarif = 0;

            if (ElectricityTarif150.Text != "")
            {
                floatElectricityTarif = float.Parse(ElectricityTarif150.Text);
            }

            if (ElectricitytextBox1.Text != "")
            {
                ElectricityOnToTheStartMonth = float.Parse(ElectricitytextBox1.Text);
            }

            if (ElectricitytextBox2.Text != "")
            {
                ElectricityOnToTheEndMonth = float.Parse(ElectricitytextBox2.Text);
            }


            if (ElectricitycheckBox1.Checked != true)
            {
                ElectricityResult = 777;
                ElectricitytextBox5.Text = Convert.ToString(ElectricityResult);
                ElectricitytextBox5.Text = "Счетчика не может не быть";
            }

            // Элекетроэнергия - разница в показаниях на начало и конец меясяца 
            ElectricityDifference = ElectricityOnToTheEndMonth - ElectricityOnToTheStartMonth;





            if (checkBoxBenefitChildrenOfWar.Checked == true)
            {




            }
            else
            {


            }


            ///////////////////////////////////////////////////////////////////////////////////////////////
            // Природный газ

        }

        private void button2_Click(object sender, EventArgs e)  // Считать files
        {

            DirectoryReading handler = new Class();

            List<string> list = new List<string>();
            string dirName = textBox1.Text;


        }

        private void TarifiSave_Click(object sender, EventArgs e)
        {

            ///////////////////////////////////////////////////////////////////////////////////////////////
            //	Заменяем точки на запятые

            KvartPlataTarif.Text = StrManipulations(KvartPlataTarif.Text);

            ElectricityTarif150.Text = StrManipulations(ElectricityTarif150.Text);
            ElectricityTarif150_800.Text = StrManipulations(ElectricityTarif150_800.Text);
            ElectricityTarif800.Text = StrManipulations(ElectricityTarif800.Text);



            float floatKvartPlataTarif = 0;

            float floatElectricityTarif150 = 0;
            float floatElectricityTarif150_800 = 0;
            float floatElectricityTarif800 = 0;

            // float
            if (KvartPlataTarif.Text != "")
            {
                floatKvartPlataTarif = float.Parse(KvartPlataTarif.Text);
            }

            if (ElectricityTarif150.Text != "")
            {
                floatElectricityTarif150 = float.Parse(ElectricityTarif150.Text);
            }

            if (ElectricityTarif150_800.Text != "")
            {
                floatElectricityTarif150_800 = float.Parse(ElectricityTarif150_800.Text);
            }

            if (ElectricityTarif800.Text != "")
            {
                floatElectricityTarif800 = float.Parse(ElectricityTarif800.Text);
            }



            ClassXML src = new ClassXML();
            src.KvartPlataTarif = floatKvartPlataTarif;

            src.ElectricityTarif150 = floatElectricityTarif150;
            src.ElectricityTarif150_800 = floatElectricityTarif150_800;
            src.ElectricityTarif800 = floatElectricityTarif800;



            /////////////////////////////////////////////////////////////////////////////////////////////
            // Создаем папку с тарифами если её нет

            // Get the current directory.
            string path = Directory.GetCurrentDirectory() + "/Tarifi";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            /////////////////////////////////////////////////////////////////////////////////////////////
            // Находим выбранный месяц

            DateTime d = monthCalendar1.SelectionRange.Start;
            int curmonth = d.Month;
            int curyear = d.Year;
            int n = Convert.ToInt32(Console.ReadLine());
            for (int i = n; i >= 0; i--)
            {
                if (curmonth.Equals(0))
                    curmonth = 12;
                curmonth--;
            }
            string[] months = { "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };

            /////////////////////////////////////////////////////////////////////////////////////////////
            // Записываем тарифы в XML

            SerializeTarifi_XmlWriter(src, "Tarifi/" + "Тарифы_" + months[(curmonth)]  + "_" + curyear + ".xml");

            textBox1.Text += File.ReadAllText("Tarifi/" + "Тарифы_" + months[(curmonth)] + "_" + curyear + ".xml");
            textBox1.Text += Environment.NewLine;

        }


        private void TarifiLoad_Click(object sender, EventArgs e)
        {

            OpenFileDialog OPF = new OpenFileDialog();
            if (OPF.ShowDialog() == DialogResult.OK)
            {
                //MessageBox.Show(OPF.FileName);
                textBox1.Text = OPF.FileName;
            }

            if (OPF.FileName != "")
            {
                ClassXML dst = DeserializeTarifi_XmlReader(OPF.FileName);

                KvartPlataTarif.Text = Convert.ToString(dst.KvartPlataTarif);
                ElectricityTarif150.Text = Convert.ToString(dst.ElectricityTarif150);
                ElectricityTarif150_800.Text = Convert.ToString(dst.ElectricityTarif150_800);
                ElectricityTarif800.Text = Convert.ToString(dst.ElectricityTarif800);
            }

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
