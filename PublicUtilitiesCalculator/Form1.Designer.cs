
namespace PublicUtilitiesCalculator
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button5 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TarifiSave = new System.Windows.Forms.Button();
            this.button1Result = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.KvartPlatatextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.KvartPlatacheckBoxChetchik = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.KvartPlatagroupBox = new System.Windows.Forms.GroupBox();
            this.KvartPlatatextBox5 = new System.Windows.Forms.TextBox();
            this.KvartPlataTarif = new System.Windows.Forms.TextBox();
            this.KvartPlatatextBox3 = new System.Windows.Forms.TextBox();
            this.KvartPlatatextBox2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.label8 = new System.Windows.Forms.Label();
            this.ElectricitygroupBox = new System.Windows.Forms.GroupBox();
            this.ElectricitytextBox5 = new System.Windows.Forms.TextBox();
            this.ElectricitytextBox3 = new System.Windows.Forms.TextBox();
            this.ElectricitytextBox2 = new System.Windows.Forms.TextBox();
            this.ElectricitycheckBox1 = new System.Windows.Forms.CheckBox();
            this.ElectricitytextBox1 = new System.Windows.Forms.TextBox();
            this.TarifiLoad = new System.Windows.Forms.Button();
            this.checkBoxBenefitChildrenOfWar = new System.Windows.Forms.CheckBox();
            this.ElectricityTarif150_800 = new System.Windows.Forms.TextBox();
            this.ElectricityTarif150 = new System.Windows.Forms.TextBox();
            this.ElectricityTarif800 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.KvartPlatagroupBox.SuspendLayout();
            this.ElectricitygroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // button5
            // 
            resources.ApplyResources(this.button5, "button5");
            this.button5.Name = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.Clear2_Click);
            // 
            // button7
            // 
            resources.ApplyResources(this.button7, "button7");
            this.button7.Name = "button7";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.Clear_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBoxBenefitChildrenOfWar);
            this.groupBox2.Controls.Add(this.TarifiLoad);
            this.groupBox2.Controls.Add(this.TarifiSave);
            this.groupBox2.Controls.Add(this.monthCalendar1);
            this.groupBox2.Controls.Add(this.button7);
            this.groupBox2.Controls.Add(this.button5);
            this.groupBox2.Controls.Add(this.button1Result);
            this.groupBox2.Controls.Add(this.button2);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // TarifiSave
            // 
            resources.ApplyResources(this.TarifiSave, "TarifiSave");
            this.TarifiSave.Name = "TarifiSave";
            this.TarifiSave.UseVisualStyleBackColor = true;
            this.TarifiSave.Click += new System.EventHandler(this.TarifiSave_Click);
            // 
            // button1Result
            // 
            resources.ApplyResources(this.button1Result, "button1Result");
            this.button1Result.Name = "button1Result";
            this.button1Result.UseVisualStyleBackColor = true;
            this.button1Result.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.HelpRequest += new System.EventHandler(this.folderBrowserDialog1_HelpRequest_1);
            // 
            // KvartPlatatextBox
            // 
            resources.ApplyResources(this.KvartPlatatextBox, "KvartPlatatextBox");
            this.KvartPlatatextBox.Name = "KvartPlatatextBox";
            this.KvartPlatatextBox.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // KvartPlatacheckBoxChetchik
            // 
            resources.ApplyResources(this.KvartPlatacheckBoxChetchik, "KvartPlatacheckBoxChetchik");
            this.KvartPlatacheckBoxChetchik.Name = "KvartPlatacheckBoxChetchik";
            this.KvartPlatacheckBoxChetchik.UseVisualStyleBackColor = true;
            this.KvartPlatacheckBoxChetchik.CheckedChanged += new System.EventHandler(this.KvartPlatacheckBoxChetchik_CheckedChanged);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // KvartPlatagroupBox
            // 
            this.KvartPlatagroupBox.Controls.Add(this.KvartPlatatextBox5);
            this.KvartPlatagroupBox.Controls.Add(this.KvartPlataTarif);
            this.KvartPlatagroupBox.Controls.Add(this.KvartPlatatextBox3);
            this.KvartPlatagroupBox.Controls.Add(this.KvartPlatatextBox2);
            this.KvartPlatagroupBox.Controls.Add(this.KvartPlatacheckBoxChetchik);
            this.KvartPlatagroupBox.Controls.Add(this.KvartPlatatextBox);
            resources.ApplyResources(this.KvartPlatagroupBox, "KvartPlatagroupBox");
            this.KvartPlatagroupBox.Name = "KvartPlatagroupBox";
            this.KvartPlatagroupBox.TabStop = false;
            this.KvartPlatagroupBox.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // KvartPlatatextBox5
            // 
            resources.ApplyResources(this.KvartPlatatextBox5, "KvartPlatatextBox5");
            this.KvartPlatatextBox5.Name = "KvartPlatatextBox5";
            // 
            // KvartPlataTarif
            // 
            resources.ApplyResources(this.KvartPlataTarif, "KvartPlataTarif");
            this.KvartPlataTarif.Name = "KvartPlataTarif";
            // 
            // KvartPlatatextBox3
            // 
            resources.ApplyResources(this.KvartPlatatextBox3, "KvartPlatatextBox3");
            this.KvartPlatatextBox3.Name = "KvartPlatatextBox3";
            // 
            // KvartPlatatextBox2
            // 
            resources.ApplyResources(this.KvartPlatatextBox2, "KvartPlatatextBox2");
            this.KvartPlatatextBox2.Name = "KvartPlatatextBox2";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // monthCalendar1
            // 
            resources.ApplyResources(this.monthCalendar1, "monthCalendar1");
            this.monthCalendar1.Name = "monthCalendar1";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // ElectricitygroupBox
            // 
            this.ElectricitygroupBox.Controls.Add(this.label11);
            this.ElectricitygroupBox.Controls.Add(this.label10);
            this.ElectricitygroupBox.Controls.Add(this.label9);
            this.ElectricitygroupBox.Controls.Add(this.ElectricityTarif800);
            this.ElectricitygroupBox.Controls.Add(this.ElectricityTarif150);
            this.ElectricitygroupBox.Controls.Add(this.ElectricityTarif150_800);
            this.ElectricitygroupBox.Controls.Add(this.ElectricitytextBox5);
            this.ElectricitygroupBox.Controls.Add(this.ElectricitytextBox3);
            this.ElectricitygroupBox.Controls.Add(this.ElectricitytextBox2);
            this.ElectricitygroupBox.Controls.Add(this.ElectricitycheckBox1);
            this.ElectricitygroupBox.Controls.Add(this.ElectricitytextBox1);
            resources.ApplyResources(this.ElectricitygroupBox, "ElectricitygroupBox");
            this.ElectricitygroupBox.Name = "ElectricitygroupBox";
            this.ElectricitygroupBox.TabStop = false;
            // 
            // ElectricitytextBox5
            // 
            resources.ApplyResources(this.ElectricitytextBox5, "ElectricitytextBox5");
            this.ElectricitytextBox5.Name = "ElectricitytextBox5";
            // 
            // ElectricitytextBox3
            // 
            resources.ApplyResources(this.ElectricitytextBox3, "ElectricitytextBox3");
            this.ElectricitytextBox3.Name = "ElectricitytextBox3";
            // 
            // ElectricitytextBox2
            // 
            resources.ApplyResources(this.ElectricitytextBox2, "ElectricitytextBox2");
            this.ElectricitytextBox2.Name = "ElectricitytextBox2";
            // 
            // ElectricitycheckBox1
            // 
            resources.ApplyResources(this.ElectricitycheckBox1, "ElectricitycheckBox1");
            this.ElectricitycheckBox1.Checked = true;
            this.ElectricitycheckBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ElectricitycheckBox1.Name = "ElectricitycheckBox1";
            this.ElectricitycheckBox1.UseVisualStyleBackColor = true;
            // 
            // ElectricitytextBox1
            // 
            resources.ApplyResources(this.ElectricitytextBox1, "ElectricitytextBox1");
            this.ElectricitytextBox1.Name = "ElectricitytextBox1";
            // 
            // TarifiLoad
            // 
            resources.ApplyResources(this.TarifiLoad, "TarifiLoad");
            this.TarifiLoad.Name = "TarifiLoad";
            this.TarifiLoad.UseVisualStyleBackColor = true;
            this.TarifiLoad.Click += new System.EventHandler(this.TarifiLoad_Click);
            // 
            // checkBoxBenefitChildrenOfWar
            // 
            resources.ApplyResources(this.checkBoxBenefitChildrenOfWar, "checkBoxBenefitChildrenOfWar");
            this.checkBoxBenefitChildrenOfWar.Name = "checkBoxBenefitChildrenOfWar";
            this.checkBoxBenefitChildrenOfWar.UseVisualStyleBackColor = true;
            // 
            // ElectricityTarif150_800
            // 
            resources.ApplyResources(this.ElectricityTarif150_800, "ElectricityTarif150_800");
            this.ElectricityTarif150_800.Name = "ElectricityTarif150_800";
            // 
            // ElectricityTarif150
            // 
            resources.ApplyResources(this.ElectricityTarif150, "ElectricityTarif150");
            this.ElectricityTarif150.Name = "ElectricityTarif150";
            // 
            // ElectricityTarif800
            // 
            resources.ApplyResources(this.ElectricityTarif800, "ElectricityTarif800");
            this.ElectricityTarif800.Name = "ElectricityTarif800";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ElectricitygroupBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.KvartPlatagroupBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.KvartPlatagroupBox.ResumeLayout(false);
            this.KvartPlatagroupBox.PerformLayout();
            this.ElectricitygroupBox.ResumeLayout(false);
            this.ElectricitygroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1Result;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox KvartPlatatextBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox KvartPlatagroupBox;
        public System.Windows.Forms.CheckBox KvartPlatacheckBoxChetchik;
        private System.Windows.Forms.TextBox KvartPlatatextBox2;
        private System.Windows.Forms.TextBox KvartPlatatextBox5;
        private System.Windows.Forms.TextBox KvartPlataTarif;
        private System.Windows.Forms.TextBox KvartPlatatextBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Button TarifiSave;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox ElectricitygroupBox;
        private System.Windows.Forms.TextBox ElectricitytextBox5;
        private System.Windows.Forms.TextBox ElectricitytextBox3;
        private System.Windows.Forms.TextBox ElectricitytextBox2;
        public System.Windows.Forms.CheckBox ElectricitycheckBox1;
        private System.Windows.Forms.TextBox ElectricitytextBox1;
        private System.Windows.Forms.Button TarifiLoad;
        private System.Windows.Forms.CheckBox checkBoxBenefitChildrenOfWar;
        private System.Windows.Forms.TextBox ElectricityTarif800;
        private System.Windows.Forms.TextBox ElectricityTarif150;
        private System.Windows.Forms.TextBox ElectricityTarif150_800;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
    }
}

