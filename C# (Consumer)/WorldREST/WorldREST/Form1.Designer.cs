namespace WorldREST
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend8 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series15 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series16 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.generalTab = new System.Windows.Forms.TabPage();
            this.capitalLabel = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.headofstateLabel = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.gnpLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lifeLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.populationLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.areaLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.regionLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.continentLabel = new System.Windows.Forms.Label();
            this.continentLabelText = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.languageTab = new System.Windows.Forms.TabPage();
            this.pieChart1 = new LiveCharts.WinForms.PieChart();
            this.citiesTab = new System.Windows.Forms.TabPage();
            this.cityPopulation = new System.Windows.Forms.Label();
            this.cityPopulationLabel = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.populationTab = new System.Windows.Forms.TabPage();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.generalTab.SuspendLayout();
            this.languageTab.SuspendLayout();
            this.citiesTab.SuspendLayout();
            this.populationTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.generalTab);
            this.tabControl1.Controls.Add(this.languageTab);
            this.tabControl1.Controls.Add(this.citiesTab);
            this.tabControl1.Controls.Add(this.populationTab);
            this.tabControl1.Location = new System.Drawing.Point(19, 84);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1085, 523);
            this.tabControl1.TabIndex = 0;
            // 
            // generalTab
            // 
            this.generalTab.Controls.Add(this.capitalLabel);
            this.generalTab.Controls.Add(this.label10);
            this.generalTab.Controls.Add(this.headofstateLabel);
            this.generalTab.Controls.Add(this.label9);
            this.generalTab.Controls.Add(this.gnpLabel);
            this.generalTab.Controls.Add(this.label8);
            this.generalTab.Controls.Add(this.lifeLabel);
            this.generalTab.Controls.Add(this.label7);
            this.generalTab.Controls.Add(this.populationLabel);
            this.generalTab.Controls.Add(this.label6);
            this.generalTab.Controls.Add(this.areaLabel);
            this.generalTab.Controls.Add(this.label5);
            this.generalTab.Controls.Add(this.regionLabel);
            this.generalTab.Controls.Add(this.label4);
            this.generalTab.Controls.Add(this.continentLabel);
            this.generalTab.Controls.Add(this.continentLabelText);
            this.generalTab.Controls.Add(this.nameLabel);
            this.generalTab.Controls.Add(this.label3);
            this.generalTab.Controls.Add(this.label2);
            this.generalTab.Location = new System.Drawing.Point(4, 22);
            this.generalTab.Margin = new System.Windows.Forms.Padding(2);
            this.generalTab.Name = "generalTab";
            this.generalTab.Padding = new System.Windows.Forms.Padding(2);
            this.generalTab.Size = new System.Drawing.Size(1077, 497);
            this.generalTab.TabIndex = 0;
            this.generalTab.Text = "General";
            this.generalTab.UseVisualStyleBackColor = true;
            this.generalTab.Click += new System.EventHandler(this.GeneralTab_Click);
            // 
            // capitalLabel
            // 
            this.capitalLabel.AutoSize = true;
            this.capitalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.capitalLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.capitalLabel.Location = new System.Drawing.Point(299, 422);
            this.capitalLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.capitalLabel.Name = "capitalLabel";
            this.capitalLabel.Size = new System.Drawing.Size(131, 20);
            this.capitalLabel.TabIndex = 18;
            this.capitalLabel.Text = "<Select Country>";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(150, 422);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 20);
            this.label10.TabIndex = 17;
            this.label10.Text = "Capital";
            // 
            // headofstateLabel
            // 
            this.headofstateLabel.AutoSize = true;
            this.headofstateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headofstateLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.headofstateLabel.Location = new System.Drawing.Point(768, 228);
            this.headofstateLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.headofstateLabel.Name = "headofstateLabel";
            this.headofstateLabel.Size = new System.Drawing.Size(131, 20);
            this.headofstateLabel.TabIndex = 16;
            this.headofstateLabel.Text = "<Select Country>";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(595, 228);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 20);
            this.label9.TabIndex = 15;
            this.label9.Text = "Head of State";
            // 
            // gnpLabel
            // 
            this.gnpLabel.AutoSize = true;
            this.gnpLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gnpLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.gnpLabel.Location = new System.Drawing.Point(299, 228);
            this.gnpLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.gnpLabel.Name = "gnpLabel";
            this.gnpLabel.Size = new System.Drawing.Size(131, 20);
            this.gnpLabel.TabIndex = 14;
            this.gnpLabel.Text = "<Select Country>";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(150, 228);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 20);
            this.label8.TabIndex = 13;
            this.label8.Text = "GNP";
            // 
            // lifeLabel
            // 
            this.lifeLabel.AutoSize = true;
            this.lifeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lifeLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lifeLabel.Location = new System.Drawing.Point(768, 321);
            this.lifeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lifeLabel.Name = "lifeLabel";
            this.lifeLabel.Size = new System.Drawing.Size(131, 20);
            this.lifeLabel.TabIndex = 12;
            this.lifeLabel.Text = "<Select Country>";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(595, 321);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 20);
            this.label7.TabIndex = 11;
            this.label7.Text = "Life Expactancy";
            // 
            // populationLabel
            // 
            this.populationLabel.AutoSize = true;
            this.populationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.populationLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.populationLabel.Location = new System.Drawing.Point(768, 127);
            this.populationLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.populationLabel.Name = "populationLabel";
            this.populationLabel.Size = new System.Drawing.Size(131, 20);
            this.populationLabel.TabIndex = 10;
            this.populationLabel.Text = "<Select Country>";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(595, 127);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 20);
            this.label6.TabIndex = 9;
            this.label6.Text = "Population";
            // 
            // areaLabel
            // 
            this.areaLabel.AutoSize = true;
            this.areaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.areaLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.areaLabel.Location = new System.Drawing.Point(299, 127);
            this.areaLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.areaLabel.Name = "areaLabel";
            this.areaLabel.Size = new System.Drawing.Size(131, 20);
            this.areaLabel.TabIndex = 8;
            this.areaLabel.Text = "<Select Country>";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(150, 127);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "Surface Area";
            // 
            // regionLabel
            // 
            this.regionLabel.AutoSize = true;
            this.regionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.regionLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.regionLabel.Location = new System.Drawing.Point(299, 321);
            this.regionLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.regionLabel.Name = "regionLabel";
            this.regionLabel.Size = new System.Drawing.Size(131, 20);
            this.regionLabel.TabIndex = 6;
            this.regionLabel.Text = "<Select Country>";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(150, 321);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Region";
            // 
            // continentLabel
            // 
            this.continentLabel.AutoSize = true;
            this.continentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.continentLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.continentLabel.Location = new System.Drawing.Point(768, 34);
            this.continentLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.continentLabel.Name = "continentLabel";
            this.continentLabel.Size = new System.Drawing.Size(131, 20);
            this.continentLabel.TabIndex = 4;
            this.continentLabel.Text = "<Select Country>";
            // 
            // continentLabelText
            // 
            this.continentLabelText.AutoSize = true;
            this.continentLabelText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.continentLabelText.Location = new System.Drawing.Point(595, 34);
            this.continentLabelText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.continentLabelText.Name = "continentLabelText";
            this.continentLabelText.Size = new System.Drawing.Size(78, 20);
            this.continentLabelText.TabIndex = 3;
            this.continentLabelText.Text = "Continent";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.nameLabel.Location = new System.Drawing.Point(299, 34);
            this.nameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(131, 20);
            this.nameLabel.TabIndex = 2;
            this.nameLabel.Text = "<Select Country>";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(183, 18);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 20);
            this.label3.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(150, 34);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Name";
            // 
            // languageTab
            // 
            this.languageTab.Controls.Add(this.pieChart1);
            this.languageTab.Location = new System.Drawing.Point(4, 22);
            this.languageTab.Margin = new System.Windows.Forms.Padding(2);
            this.languageTab.Name = "languageTab";
            this.languageTab.Padding = new System.Windows.Forms.Padding(2);
            this.languageTab.Size = new System.Drawing.Size(1077, 497);
            this.languageTab.TabIndex = 1;
            this.languageTab.Text = "Languages";
            this.languageTab.UseVisualStyleBackColor = true;
            // 
            // pieChart1
            // 
            this.pieChart1.Location = new System.Drawing.Point(13, 9);
            this.pieChart1.Margin = new System.Windows.Forms.Padding(1);
            this.pieChart1.Name = "pieChart1";
            this.pieChart1.Size = new System.Drawing.Size(678, 471);
            this.pieChart1.TabIndex = 0;
            this.pieChart1.Text = "pieChart1";
            // 
            // citiesTab
            // 
            this.citiesTab.Controls.Add(this.cityPopulation);
            this.citiesTab.Controls.Add(this.cityPopulationLabel);
            this.citiesTab.Controls.Add(this.listBox1);
            this.citiesTab.Location = new System.Drawing.Point(4, 22);
            this.citiesTab.Margin = new System.Windows.Forms.Padding(2);
            this.citiesTab.Name = "citiesTab";
            this.citiesTab.Size = new System.Drawing.Size(1077, 497);
            this.citiesTab.TabIndex = 2;
            this.citiesTab.Text = "Cities";
            this.citiesTab.UseVisualStyleBackColor = true;
            // 
            // cityPopulation
            // 
            this.cityPopulation.AutoSize = true;
            this.cityPopulation.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cityPopulation.Location = new System.Drawing.Point(214, 86);
            this.cityPopulation.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.cityPopulation.Name = "cityPopulation";
            this.cityPopulation.Size = new System.Drawing.Size(148, 46);
            this.cityPopulation.TabIndex = 2;
            this.cityPopulation.Text = "label11";
            // 
            // cityPopulationLabel
            // 
            this.cityPopulationLabel.AutoSize = true;
            this.cityPopulationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cityPopulationLabel.Location = new System.Drawing.Point(217, 35);
            this.cityPopulationLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.cityPopulationLabel.Name = "cityPopulationLabel";
            this.cityPopulationLabel.Size = new System.Drawing.Size(142, 31);
            this.cityPopulationLabel.TabIndex = 1;
            this.cityPopulationLabel.Text = "Population";
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(23, 35);
            this.listBox1.Margin = new System.Windows.Forms.Padding(2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(168, 196);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.ListBox1_SelectedIndexChanged);
            // 
            // populationTab
            // 
            this.populationTab.Controls.Add(this.comboBox2);
            this.populationTab.Controls.Add(this.chart1);
            this.populationTab.Location = new System.Drawing.Point(4, 22);
            this.populationTab.Margin = new System.Windows.Forms.Padding(2);
            this.populationTab.Name = "populationTab";
            this.populationTab.Size = new System.Drawing.Size(1077, 497);
            this.populationTab.TabIndex = 3;
            this.populationTab.Text = "Population";
            this.populationTab.UseVisualStyleBackColor = true;
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(29, 43);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(175, 28);
            this.comboBox2.TabIndex = 1;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.ComboBox2_SelectedIndexChanged);
            // 
            // chart1
            // 
            chartArea8.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea8);
            legend8.Name = "Legend1";
            this.chart1.Legends.Add(legend8);
            this.chart1.Location = new System.Drawing.Point(93, 112);
            this.chart1.Margin = new System.Windows.Forms.Padding(2);
            this.chart1.Name = "chart1";
            series15.ChartArea = "ChartArea1";
            series15.Legend = "Legend1";
            series15.Name = "Series1";
            series16.ChartArea = "ChartArea1";
            series16.Legend = "Legend1";
            series16.Name = "Series2";
            this.chart1.Series.Add(series15);
            this.chart1.Series.Add(series16);
            this.chart1.Size = new System.Drawing.Size(855, 365);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select country";
            this.label1.Click += new System.EventHandler(this.Label1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(25, 41);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(169, 24);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.ComboBox1_SelectedIndexChanged);
            // 
            // comboBox3
            // 
            this.comboBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(253, 41);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 24);
            this.comboBox3.TabIndex = 3;
            this.comboBox3.SelectedIndexChanged += new System.EventHandler(this.ComboBox3_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(249, 6);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(118, 20);
            this.label11.TabIndex = 4;
            this.label11.Text = "Select API type";
            this.label11.Click += new System.EventHandler(this.Label11_Click_1);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(380, 44);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(57, 17);
            this.label12.TabIndex = 5;
            this.label12.Text = "Is Valid:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(436, 44);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(0, 17);
            this.label13.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1125, 614);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = " ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.generalTab.ResumeLayout(false);
            this.generalTab.PerformLayout();
            this.languageTab.ResumeLayout(false);
            this.citiesTab.ResumeLayout(false);
            this.citiesTab.PerformLayout();
            this.populationTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage generalTab;
        private System.Windows.Forms.TabPage languageTab;
        private System.Windows.Forms.TabPage citiesTab;
        private System.Windows.Forms.TabPage populationTab;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label continentLabelText;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label continentLabel;
        private System.Windows.Forms.Label lifeLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label populationLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label areaLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label regionLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label capitalLabel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label headofstateLabel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label gnpLabel;
        private System.Windows.Forms.Label label8;
        private LiveCharts.WinForms.PieChart pieChart1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label cityPopulation;
        private System.Windows.Forms.Label cityPopulationLabel;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
    }
}

