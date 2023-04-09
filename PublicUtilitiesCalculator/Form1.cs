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


            ///////////////////////////////////////////////////////////////////////////////////////////////
            // Квартплата 
            writer.WriteStartElement("KvartPlataTarif");
            writer.WriteElementString("KvartPlataprice", obj.KvartPlataTarif.ToString());
            writer.WriteEndElement();

            ///////////////////////////////////////////////////////////////////////////////////////////////
            //	Электроэнергия

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

            ///////////////////////////////////////////////////////////////////////////////////////////////
            //	Газ

            writer.WriteStartElement("GasTarif");

            writer.WriteStartElement("GasTarif2500");
            writer.WriteElementString("GasTarif2500Price", obj.GasTarif2500.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("GasTarif2500_6000");
            writer.WriteElementString("GasTarif2500_6000Price", obj.GasTarif2500_6000.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("GasTarif6000");
            writer.WriteElementString("GasTarif6000Price", obj.GasTarif6000.ToString());
            writer.WriteEndElement();

            writer.WriteEndElement();


            ///////////////////////////////////////////////////////////////////////////////////////////////
            //	Вода

            writer.WriteStartElement("WaterTarif");
            writer.WriteElementString("WaterTarifPrice", obj.WaterTarif.ToString());
            writer.WriteEndElement();

            ///////////////////////////////////////////////////////////////////////////////////////////////
            //	Отопление

            writer.WriteStartElement("HeatingTarif");
            writer.WriteElementString("HeatingTarifPrice", obj.HeatingTarif.ToString());
            writer.WriteEndElement();

            ///////////////////////////////////////////////////////////////////////////////////////////////
            //	ТБО

            writer.WriteStartElement("TrashTarif");
            writer.WriteElementString("TrashTarifPrice", obj.TrashTarif.ToString());
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
                        // Квартплата
                        case "KvartPlataprice":
                            obj.KvartPlataTarif = float.Parse(reader.ReadElementContentAsString());
                            break;
                        // Электроэнергия
                        case "ElectricityTarif150Price":
                            obj.ElectricityTarif150 = float.Parse(reader.ReadElementContentAsString());
                            break;
                        case "ElectricityTarif150_800Price":
                            obj.ElectricityTarif150_800 = float.Parse(reader.ReadElementContentAsString());
                            break;
                        case "ElectricityTarif800Price":
                            obj.ElectricityTarif800 = float.Parse(reader.ReadElementContentAsString());
                            break;
                        // Природный газ
                        case "GasTarif2500Price":
                            obj.GasTarif2500 = float.Parse(reader.ReadElementContentAsString());
                            break;
                        case "GasTarif2500_6000Price":
                            obj.GasTarif2500_6000 = float.Parse(reader.ReadElementContentAsString());
                            break;
                        case "GasTarif6000Price":
                            obj.GasTarif6000 = float.Parse(reader.ReadElementContentAsString());
                            break;
                        // Вода
                        case "WaterTarifPrice":
                            obj.WaterTarif = float.Parse(reader.ReadElementContentAsString());
                            break;
                        // Отопление
                        case "HeatingTarifPrice":
                            obj.HeatingTarif = float.Parse(reader.ReadElementContentAsString());
                            break;
                        // ТБО
                        case "TrashTarifPrice":
                            obj.TrashTarif = float.Parse(reader.ReadElementContentAsString());
                            break;




                        default:
                            reader.Read();
                            break;
                    }
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


        public string StrManipulationsWithSpace(string LocalStringTempValue)
        {

            Char[] ch = LocalStringTempValue.ToCharArray();
            for (int i = 0; i < ch.Length; i++)
            {
                if (ch[i] == ' ')
                    ch[i] = '\0';
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

            GasTarif2500.Text = StrManipulations(GasTarif2500.Text);
            GasTarif2500_6000.Text = StrManipulations(GasTarif2500_6000.Text);
            GasTarif6000.Text = StrManipulations(GasTarif6000.Text);

            WaterTarif.Text = StrManipulations(WaterTarif.Text);
            HeatingTarif.Text = StrManipulations(HeatingTarif.Text);
            TrashTarif.Text = StrManipulations(TrashTarif.Text);

            //	Убираем пробелы

            KvartPlataTarif.Text = StrManipulationsWithSpace(KvartPlataTarif.Text);
            ElectricityTarif150.Text = StrManipulationsWithSpace(ElectricityTarif150.Text);
            ElectricityTarif150_800.Text = StrManipulationsWithSpace(ElectricityTarif150_800.Text);
            ElectricityTarif800.Text = StrManipulationsWithSpace(ElectricityTarif800.Text);

            GasTarif2500.Text = StrManipulationsWithSpace(GasTarif2500.Text);
            GasTarif2500_6000.Text = StrManipulationsWithSpace(GasTarif2500_6000.Text);
            GasTarif6000.Text = StrManipulationsWithSpace(GasTarif6000.Text);

            WaterTarif.Text = StrManipulationsWithSpace(WaterTarif.Text);
            HeatingTarif.Text = StrManipulationsWithSpace(HeatingTarif.Text);
            TrashTarif.Text = StrManipulationsWithSpace(TrashTarif.Text);

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

            float ElectricityPrice150 = 0;
            float ElectricityPrice150_800 = 0;
            float ElectricityPrice800 = 0;



            float ElectricityResult = 0;

            float floatElectricityTarif150 = 0;
            float floatElectricityTarif150_800 = 0;
            float floatElectricityTarif800 = 0;

            // Тарифы
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

            // Показания счетчика
            if (ElectricitytextBox1.Text != "")
            {
                ElectricityOnToTheStartMonth = float.Parse(ElectricitytextBox1.Text);
            }

            if (ElectricitytextBox2.Text != "")
            {
                ElectricityOnToTheEndMonth = float.Parse(ElectricitytextBox2.Text);
            }


            // Счетчик
            if (ElectricitycheckBox1.Checked != true)
            {
                ElectricityResult = 777;
                ElectricitytextBox5.Text = Convert.ToString(ElectricityResult);
                ElectricitytextBox5.Text = "Счетчика не может не быть";
            }

            // Элекетроэнергия - разница в показаниях на начало и конец меясяца 
            ElectricityDifference = ElectricityOnToTheEndMonth - ElectricityOnToTheStartMonth;
            ElectricitytextBox3.Text = Convert.ToString(ElectricityDifference);

            if (ElectricityDifference < 150)
            {
                ElectricityPrice150 = ElectricityDifference;
                ElectricityPrice150_800 = 0;
                ElectricityPrice800 = 0;
            }

            if (150 < ElectricityDifference  && ElectricityDifference < 800)
            {
                ElectricityPrice150 = 150;
                ElectricityPrice150_800 = ElectricityDifference - 150;
                ElectricityPrice800 = 0;
            }

            if (800 < ElectricityDifference)
            {
                ElectricityPrice150 = 150;
                ElectricityPrice150_800 = 800;
                ElectricityPrice800 = ElectricityDifference - 800;
            }



            // Льгота
            if (checkBoxBenefitChildrenOfWar.Checked == true)
            {
                ElectricityPrice150 = ElectricityPrice150 - 75;
                ElectricityResult = ElectricityResult + (75 * (floatElectricityTarif150 / 100) * 75) + (ElectricityPrice150 * floatElectricityTarif150) + (ElectricityPrice150_800 * floatElectricityTarif150_800) + (ElectricityPrice800 * floatElectricityTarif800);
            }
            else
            {
                ElectricityResult = ElectricityResult + (ElectricityPrice150 * floatElectricityTarif150) + (ElectricityPrice150_800 * floatElectricityTarif150_800) + (ElectricityPrice800 * floatElectricityTarif800);
            }

            ElectricitytextBox5.Text = Convert.ToString(ElectricityResult);


            ///////////////////////////////////////////////////////////////////////////////////////////////
            // Природный газ


            float GasOnToTheStartMonth = 0;
            float GasOnToTheEndMonth = 0;
            float GasDifference = 0;

            float GasPrice150 = 0;
            float GasPrice150_800 = 0;
            float GasPrice800 = 0;



            float GasResult = 0;

            float floatGasTarif150 = 0;
            float floatGasTarif150_800 = 0;
            float floatGasTarif800 = 0;



            ///////////////////////////////////////////////////////////////////////////////////////////////
            // Вода

            float WaterOnToTheStartMonth = 0;
            float WaterOnToTheEndMonth = 0;
            float WaterDifference = 0;

            float WaterResult = 0;

            float floatWaterTarif = 0;


            ///////////////////////////////////////////////////////////////////////////////////////////////
            // Отопление

        }


        private void TarifiSave_Click(object sender, EventArgs e)
        {

            ///////////////////////////////////////////////////////////////////////////////////////////////
            //	Заменяем точки на запятые

            KvartPlataTarif.Text = StrManipulations(KvartPlataTarif.Text);

            ElectricityTarif150.Text = StrManipulations(ElectricityTarif150.Text);
            ElectricityTarif150_800.Text = StrManipulations(ElectricityTarif150_800.Text);
            ElectricityTarif800.Text = StrManipulations(ElectricityTarif800.Text);

            GasTarif2500.Text = StrManipulations(GasTarif2500.Text);
            GasTarif2500_6000.Text = StrManipulations(GasTarif2500_6000.Text);
            GasTarif6000.Text = StrManipulations(GasTarif6000.Text);

            WaterTarif.Text = StrManipulations(WaterTarif.Text);
            HeatingTarif.Text = StrManipulations(HeatingTarif.Text);
            TrashTarif.Text = StrManipulations(TrashTarif.Text);


            float floatKvartPlataTarif = 0;

            float floatElectricityTarif150 = 0;
            float floatElectricityTarif150_800 = 0;
            float floatElectricityTarif800 = 0;

            float floatGasTarif2500 = 0;
            float floatGasTarif2500_6000 = 0;
            float floatGasTarif6000 = 0;

            float floatWaterTarif = 0;

            float floatHeatingTarif = 0;

            float floatTrashTarif = 0;



            // Квартплата 
            if (KvartPlataTarif.Text != "")
            {
                floatKvartPlataTarif = float.Parse(KvartPlataTarif.Text);
            }

            // Электроэнергия
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


            // Природный газ
            if (GasTarif2500.Text != "")
            {
                floatGasTarif2500 = float.Parse(GasTarif2500.Text);
            }

            if (GasTarif2500_6000.Text != "")
            {
                floatGasTarif2500_6000 = float.Parse(GasTarif2500_6000.Text);
            }

            if (GasTarif6000.Text != "")
            {
                floatGasTarif6000 = float.Parse(GasTarif6000.Text);
            }


            // Вода 
            if (WaterTarif.Text != "")
            {
                floatWaterTarif = float.Parse(WaterTarif.Text);
            }

            // Отопление 
            if (HeatingTarif.Text != "")
            {
                floatHeatingTarif = float.Parse(HeatingTarif.Text);
            }


            // Мусор 
            if (TrashTarif.Text != "")
            {
                floatTrashTarif = float.Parse(TrashTarif.Text);
            }









            ClassXML src = new ClassXML();
            src.KvartPlataTarif = floatKvartPlataTarif;

            src.ElectricityTarif150 = floatElectricityTarif150;
            src.ElectricityTarif150_800 = floatElectricityTarif150_800;
            src.ElectricityTarif800 = floatElectricityTarif800;

            src.GasTarif2500 = floatGasTarif2500;
            src.GasTarif2500_6000 = floatGasTarif2500_6000;
            src.GasTarif6000 = floatGasTarif6000;

            src.WaterTarif = floatWaterTarif;

            src.HeatingTarif = floatHeatingTarif;

            src.TrashTarif = floatTrashTarif;


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

                // Квартплата
                KvartPlataTarif.Text = Convert.ToString(dst.KvartPlataTarif);

                // Электроэнергия
                ElectricityTarif150.Text = Convert.ToString(dst.ElectricityTarif150);
                ElectricityTarif150_800.Text = Convert.ToString(dst.ElectricityTarif150_800);
                ElectricityTarif800.Text = Convert.ToString(dst.ElectricityTarif800);

                // Природный газ
                GasTarif2500.Text = Convert.ToString(dst.GasTarif2500);
                GasTarif2500_6000.Text = Convert.ToString(dst.GasTarif2500_6000);
                GasTarif6000.Text = Convert.ToString(dst.GasTarif6000);

                // Вода
                WaterTarif.Text = Convert.ToString(dst.WaterTarif);

                // Отопление
                HeatingTarif.Text = Convert.ToString(dst.HeatingTarif);

                // Мусор
                TrashTarif.Text = Convert.ToString(dst.TrashTarif);

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

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
