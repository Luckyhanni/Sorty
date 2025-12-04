namespace Sorty
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            BTN_Open_Excel = new Button();
            BTN_Clear_Excel = new Button();
            IMG_Logo = new PictureBox();
            BTN_NamenSuchen = new Button();
            BTN_NamenEintragen = new Button();
            p_NamenEintragen = new Panel();
            l_wennVorhanden = new Label();
            tB_Vorname = new TextBox();
            l_Vorname = new Label();
            tB_Price = new TextBox();
            l_Kosten = new Label();
            tB_Kiste = new TextBox();
            l_Chest = new Label();
            cB_Ort = new ComboBox();
            BTN_AddSave = new Button();
            l_Ort = new Label();
            tB_AddName = new TextBox();
            l_NamenEintragen = new Label();
            p_SearchName = new Panel();
            BTN_ShowL3 = new Button();
            BTN_ShowL2 = new Button();
            BTN_ShowL1 = new Button();
            l_AllLagerNumber = new Label();
            l_AllLager = new Label();
            l_L3Number = new Label();
            l_L3 = new Label();
            l_L2Number = new Label();
            l_L2 = new Label();
            l_L1Number = new Label();
            l_L1 = new Label();
            BTN_All = new Button();
            dGV_Results = new DataGridView();
            Namen = new DataGridViewTextBoxColumn();
            Vorname = new DataGridViewTextBoxColumn();
            Orte = new DataGridViewTextBoxColumn();
            Number = new DataGridViewTextBoxColumn();
            Aenlichkeit = new DataGridViewTextBoxColumn();
            Delete = new DataGridViewButtonColumn();
            BTN_Search = new Button();
            tB_SearchName = new TextBox();
            l_SearchName = new Label();
            BTN_Open_Abgeholten = new Button();
            ((System.ComponentModel.ISupportInitialize)IMG_Logo).BeginInit();
            p_NamenEintragen.SuspendLayout();
            p_SearchName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dGV_Results).BeginInit();
            SuspendLayout();
            // 
            // BTN_Open_Excel
            // 
            BTN_Open_Excel.BackColor = Color.White;
            BTN_Open_Excel.FlatStyle = FlatStyle.Flat;
            BTN_Open_Excel.Font = new Font("Microsoft Sans Serif", 36F);
            BTN_Open_Excel.Location = new Point(40, 570);
            BTN_Open_Excel.Name = "BTN_Open_Excel";
            BTN_Open_Excel.Size = new Size(304, 90);
            BTN_Open_Excel.TabIndex = 9;
            BTN_Open_Excel.Text = "LAGER";
            BTN_Open_Excel.UseVisualStyleBackColor = false;
            BTN_Open_Excel.Click += btnOpenExcel_Click;
            // 
            // BTN_Clear_Excel
            // 
            BTN_Clear_Excel.BackColor = Color.White;
            BTN_Clear_Excel.FlatStyle = FlatStyle.Flat;
            BTN_Clear_Excel.Font = new Font("Microsoft Sans Serif", 36F);
            BTN_Clear_Excel.Location = new Point(39, 806);
            BTN_Clear_Excel.Name = "BTN_Clear_Excel";
            BTN_Clear_Excel.Size = new Size(304, 90);
            BTN_Clear_Excel.TabIndex = 10;
            BTN_Clear_Excel.Text = "CLEAR EXCEL";
            BTN_Clear_Excel.UseVisualStyleBackColor = false;
            BTN_Clear_Excel.Click += btnClearExcel_Click;
            // 
            // IMG_Logo
            // 
            IMG_Logo.BackgroundImage = (Image)resources.GetObject("IMG_Logo.BackgroundImage");
            IMG_Logo.Location = new Point(39, 195);
            IMG_Logo.Name = "IMG_Logo";
            IMG_Logo.Size = new Size(377, 258);
            IMG_Logo.TabIndex = 6;
            IMG_Logo.TabStop = false;
            // 
            // BTN_NamenSuchen
            // 
            BTN_NamenSuchen.BackColor = Color.White;
            BTN_NamenSuchen.FlatStyle = FlatStyle.Flat;
            BTN_NamenSuchen.Font = new Font("Microsoft Sans Serif", 36F);
            BTN_NamenSuchen.Location = new Point(1132, 87);
            BTN_NamenSuchen.Name = "BTN_NamenSuchen";
            BTN_NamenSuchen.Size = new Size(322, 78);
            BTN_NamenSuchen.TabIndex = 7;
            BTN_NamenSuchen.Text = "Namen Suchen";
            BTN_NamenSuchen.UseVisualStyleBackColor = false;
            BTN_NamenSuchen.Click += BTN_NamenSuchen_Click;
            // 
            // BTN_NamenEintragen
            // 
            BTN_NamenEintragen.BackColor = Color.White;
            BTN_NamenEintragen.FlatStyle = FlatStyle.Flat;
            BTN_NamenEintragen.Font = new Font("Microsoft Sans Serif", 36F);
            BTN_NamenEintragen.Location = new Point(681, 87);
            BTN_NamenEintragen.Name = "BTN_NamenEintragen";
            BTN_NamenEintragen.Size = new Size(322, 78);
            BTN_NamenEintragen.TabIndex = 8;
            BTN_NamenEintragen.Text = "Namen Eintragen";
            BTN_NamenEintragen.UseVisualStyleBackColor = false;
            BTN_NamenEintragen.Click += BTN_NamenEintragen_Click;
            // 
            // p_NamenEintragen
            // 
            p_NamenEintragen.Controls.Add(l_wennVorhanden);
            p_NamenEintragen.Controls.Add(tB_Vorname);
            p_NamenEintragen.Controls.Add(l_Vorname);
            p_NamenEintragen.Controls.Add(tB_Price);
            p_NamenEintragen.Controls.Add(l_Kosten);
            p_NamenEintragen.Controls.Add(tB_Kiste);
            p_NamenEintragen.Controls.Add(l_Chest);
            p_NamenEintragen.Controls.Add(cB_Ort);
            p_NamenEintragen.Controls.Add(BTN_AddSave);
            p_NamenEintragen.Controls.Add(l_Ort);
            p_NamenEintragen.Controls.Add(tB_AddName);
            p_NamenEintragen.Controls.Add(l_NamenEintragen);
            p_NamenEintragen.Location = new Point(497, 177);
            p_NamenEintragen.Name = "p_NamenEintragen";
            p_NamenEintragen.Size = new Size(1098, 719);
            p_NamenEintragen.TabIndex = 10;
            // 
            // l_wennVorhanden
            // 
            l_wennVorhanden.AutoSize = true;
            l_wennVorhanden.BackColor = Color.Transparent;
            l_wennVorhanden.Font = new Font("Microsoft Sans Serif", 15.7499981F, FontStyle.Regular, GraphicsUnit.Point, 0);
            l_wennVorhanden.Location = new Point(467, 235);
            l_wennVorhanden.Name = "l_wennVorhanden";
            l_wennVorhanden.Size = new Size(185, 25);
            l_wennVorhanden.TabIndex = 12;
            l_wennVorhanden.Text = "(wenn vorhanden)";
            // 
            // tB_Vorname
            // 
            tB_Vorname.Font = new Font("Microsoft Sans Serif", 36F);
            tB_Vorname.Location = new Point(392, 167);
            tB_Vorname.Name = "tB_Vorname";
            tB_Vorname.Size = new Size(270, 62);
            tB_Vorname.TabIndex = 2;
            // 
            // l_Vorname
            // 
            l_Vorname.AutoSize = true;
            l_Vorname.Font = new Font("Microsoft Sans Serif", 36F);
            l_Vorname.Location = new Point(440, 104);
            l_Vorname.Name = "l_Vorname";
            l_Vorname.Size = new Size(220, 55);
            l_Vorname.TabIndex = 10;
            l_Vorname.Text = "Vorname";
            // 
            // tB_Price
            // 
            tB_Price.Font = new Font("Microsoft Sans Serif", 36F);
            tB_Price.Location = new Point(310, 370);
            tB_Price.Name = "tB_Price";
            tB_Price.Size = new Size(108, 62);
            tB_Price.TabIndex = 4;
            tB_Price.TextChanged += tB_Price_TextChanged;
            // 
            // l_Kosten
            // 
            l_Kosten.AutoSize = true;
            l_Kosten.Font = new Font("Microsoft Sans Serif", 36F);
            l_Kosten.Location = new Point(310, 304);
            l_Kosten.Name = "l_Kosten";
            l_Kosten.Size = new Size(133, 55);
            l_Kosten.TabIndex = 8;
            l_Kosten.Text = "Preis";
            // 
            // tB_Kiste
            // 
            tB_Kiste.Font = new Font("Microsoft Sans Serif", 36F);
            tB_Kiste.Location = new Point(855, 167);
            tB_Kiste.Name = "tB_Kiste";
            tB_Kiste.Size = new Size(67, 62);
            tB_Kiste.TabIndex = 3;
            tB_Kiste.TextChanged += tB_Kiste_TextChanged;
            // 
            // l_Chest
            // 
            l_Chest.AutoSize = true;
            l_Chest.Font = new Font("Microsoft Sans Serif", 36F);
            l_Chest.Location = new Point(751, 104);
            l_Chest.Name = "l_Chest";
            l_Chest.Size = new Size(355, 55);
            l_Chest.TabIndex = 6;
            l_Chest.Text = "Kisten Nummer";
            // 
            // cB_Ort
            // 
            cB_Ort.DropDownStyle = ComboBoxStyle.DropDownList;
            cB_Ort.Font = new Font("Microsoft Sans Serif", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cB_Ort.FormattingEnabled = true;
            cB_Ort.Items.AddRange(new object[] { "Lager 1", "Lager 2", "Lager 3", "Lager 4" });
            cB_Ort.Location = new Point(751, 367);
            cB_Ort.Name = "cB_Ort";
            cB_Ort.Size = new Size(287, 63);
            cB_Ort.TabIndex = 5;
            cB_Ort.SelectedIndexChanged += cB_Ort_SelectedIndexChanged;
            // 
            // BTN_AddSave
            // 
            BTN_AddSave.BackColor = Color.DarkGray;
            BTN_AddSave.Enabled = false;
            BTN_AddSave.Font = new Font("Microsoft Sans Serif", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BTN_AddSave.ForeColor = SystemColors.ControlText;
            BTN_AddSave.Location = new Point(440, 548);
            BTN_AddSave.Name = "BTN_AddSave";
            BTN_AddSave.Size = new Size(281, 88);
            BTN_AddSave.TabIndex = 6;
            BTN_AddSave.Text = "Speichern";
            BTN_AddSave.UseVisualStyleBackColor = false;
            BTN_AddSave.Click += BTN_AddSave_Click;
            // 
            // l_Ort
            // 
            l_Ort.AutoSize = true;
            l_Ort.Font = new Font("Microsoft Sans Serif", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            l_Ort.Location = new Point(855, 304);
            l_Ort.Name = "l_Ort";
            l_Ort.Size = new Size(90, 55);
            l_Ort.TabIndex = 2;
            l_Ort.Text = "Ort";
            // 
            // tB_AddName
            // 
            tB_AddName.Font = new Font("Microsoft Sans Serif", 36F);
            tB_AddName.Location = new Point(35, 167);
            tB_AddName.Name = "tB_AddName";
            tB_AddName.Size = new Size(303, 62);
            tB_AddName.TabIndex = 0;
            tB_AddName.TextChanged += tB_AddName_TextChanged;
            // 
            // l_NamenEintragen
            // 
            l_NamenEintragen.AutoSize = true;
            l_NamenEintragen.Font = new Font("Microsoft Sans Serif", 36F);
            l_NamenEintragen.Location = new Point(84, 104);
            l_NamenEintragen.Name = "l_NamenEintragen";
            l_NamenEintragen.Size = new Size(258, 55);
            l_NamenEintragen.TabIndex = 0;
            l_NamenEintragen.Text = "Nachname";
            // 
            // p_SearchName
            // 
            p_SearchName.Controls.Add(BTN_ShowL3);
            p_SearchName.Controls.Add(BTN_ShowL2);
            p_SearchName.Controls.Add(BTN_ShowL1);
            p_SearchName.Controls.Add(l_AllLagerNumber);
            p_SearchName.Controls.Add(l_AllLager);
            p_SearchName.Controls.Add(l_L3Number);
            p_SearchName.Controls.Add(l_L3);
            p_SearchName.Controls.Add(l_L2Number);
            p_SearchName.Controls.Add(l_L2);
            p_SearchName.Controls.Add(l_L1Number);
            p_SearchName.Controls.Add(l_L1);
            p_SearchName.Controls.Add(BTN_All);
            p_SearchName.Controls.Add(dGV_Results);
            p_SearchName.Controls.Add(BTN_Search);
            p_SearchName.Controls.Add(tB_SearchName);
            p_SearchName.Controls.Add(l_SearchName);
            p_SearchName.Location = new Point(488, 180);
            p_SearchName.Name = "p_SearchName";
            p_SearchName.Size = new Size(1110, 716);
            p_SearchName.TabIndex = 11;
            p_SearchName.Visible = false;
            // 
            // BTN_ShowL3
            // 
            BTN_ShowL3.Font = new Font("Microsoft Sans Serif", 15.7499981F);
            BTN_ShowL3.Location = new Point(179, 140);
            BTN_ShowL3.Name = "BTN_ShowL3";
            BTN_ShowL3.Size = new Size(79, 35);
            BTN_ShowL3.TabIndex = 24;
            BTN_ShowL3.Text = "show";
            BTN_ShowL3.UseVisualStyleBackColor = true;
            BTN_ShowL3.Click += BTN_ShowL3_Click;
            // 
            // BTN_ShowL2
            // 
            BTN_ShowL2.Font = new Font("Microsoft Sans Serif", 15.7499981F);
            BTN_ShowL2.Location = new Point(179, 92);
            BTN_ShowL2.Name = "BTN_ShowL2";
            BTN_ShowL2.Size = new Size(79, 35);
            BTN_ShowL2.TabIndex = 23;
            BTN_ShowL2.Text = "show";
            BTN_ShowL2.UseVisualStyleBackColor = true;
            BTN_ShowL2.Click += BTN_ShowL2_Click;
            // 
            // BTN_ShowL1
            // 
            BTN_ShowL1.Font = new Font("Microsoft Sans Serif", 15.7499981F);
            BTN_ShowL1.Location = new Point(179, 42);
            BTN_ShowL1.Name = "BTN_ShowL1";
            BTN_ShowL1.Size = new Size(79, 35);
            BTN_ShowL1.TabIndex = 22;
            BTN_ShowL1.Text = "show";
            BTN_ShowL1.UseVisualStyleBackColor = true;
            BTN_ShowL1.Click += BTN_ShowL1_Click;
            // 
            // l_AllLagerNumber
            // 
            l_AllLagerNumber.AutoSize = true;
            l_AllLagerNumber.Font = new Font("Microsoft Sans Serif", 20.2499981F);
            l_AllLagerNumber.Location = new Point(113, 186);
            l_AllLagerNumber.Name = "l_AllLagerNumber";
            l_AllLagerNumber.Size = new Size(29, 31);
            l_AllLagerNumber.TabIndex = 16;
            l_AllLagerNumber.Text = "0";
            // 
            // l_AllLager
            // 
            l_AllLager.AutoSize = true;
            l_AllLager.Font = new Font("Microsoft Sans Serif", 20.2499981F);
            l_AllLager.Location = new Point(57, 186);
            l_AllLager.Name = "l_AllLager";
            l_AllLager.Size = new Size(67, 31);
            l_AllLager.TabIndex = 15;
            l_AllLager.Text = "Alle:";
            // 
            // l_L3Number
            // 
            l_L3Number.AutoSize = true;
            l_L3Number.Font = new Font("Microsoft Sans Serif", 20.2499981F);
            l_L3Number.Location = new Point(113, 142);
            l_L3Number.Name = "l_L3Number";
            l_L3Number.Size = new Size(29, 31);
            l_L3Number.TabIndex = 14;
            l_L3Number.Text = "0";
            // 
            // l_L3
            // 
            l_L3.AutoSize = true;
            l_L3.Font = new Font("Microsoft Sans Serif", 20.2499981F);
            l_L3.Location = new Point(22, 142);
            l_L3.Name = "l_L3";
            l_L3.Size = new Size(113, 31);
            l_L3.TabIndex = 13;
            l_L3.Text = "Lager 3:";
            // 
            // l_L2Number
            // 
            l_L2Number.AutoSize = true;
            l_L2Number.Font = new Font("Microsoft Sans Serif", 20.2499981F);
            l_L2Number.Location = new Point(113, 92);
            l_L2Number.Name = "l_L2Number";
            l_L2Number.Size = new Size(29, 31);
            l_L2Number.TabIndex = 12;
            l_L2Number.Text = "0";
            // 
            // l_L2
            // 
            l_L2.AutoSize = true;
            l_L2.Font = new Font("Microsoft Sans Serif", 20.2499981F);
            l_L2.Location = new Point(22, 92);
            l_L2.Name = "l_L2";
            l_L2.Size = new Size(113, 31);
            l_L2.TabIndex = 11;
            l_L2.Text = "Lager 2:";
            // 
            // l_L1Number
            // 
            l_L1Number.AutoSize = true;
            l_L1Number.Font = new Font("Microsoft Sans Serif", 20.2499981F);
            l_L1Number.Location = new Point(113, 42);
            l_L1Number.Name = "l_L1Number";
            l_L1Number.Size = new Size(29, 31);
            l_L1Number.TabIndex = 10;
            l_L1Number.Text = "0";
            // 
            // l_L1
            // 
            l_L1.AutoSize = true;
            l_L1.Font = new Font("Microsoft Sans Serif", 20.2499981F);
            l_L1.Location = new Point(22, 42);
            l_L1.Name = "l_L1";
            l_L1.Size = new Size(113, 31);
            l_L1.TabIndex = 9;
            l_L1.Text = "Lager 1:";
            // 
            // BTN_All
            // 
            BTN_All.Font = new Font("Microsoft Sans Serif", 15.7499981F);
            BTN_All.Location = new Point(179, 182);
            BTN_All.Name = "BTN_All";
            BTN_All.Size = new Size(79, 47);
            BTN_All.TabIndex = 21;
            BTN_All.Text = "ALLE";
            BTN_All.UseVisualStyleBackColor = true;
            BTN_All.Click += BTN_All_Click;
            // 
            // dGV_Results
            // 
            dataGridViewCellStyle1.BackColor = Color.Transparent;
            dGV_Results.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dGV_Results.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dGV_Results.BackgroundColor = Color.Silver;
            dGV_Results.BorderStyle = BorderStyle.None;
            dGV_Results.ColumnHeadersHeight = 40;
            dGV_Results.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dGV_Results.Columns.AddRange(new DataGridViewColumn[] { Namen, Vorname, Orte, Number, Aenlichkeit, Delete });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.Transparent;
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 18F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dGV_Results.DefaultCellStyle = dataGridViewCellStyle3;
            dGV_Results.EditMode = DataGridViewEditMode.EditOnF2;
            dGV_Results.Font = new Font("Microsoft Sans Serif", 18F);
            dGV_Results.Location = new Point(204, 265);
            dGV_Results.Name = "dGV_Results";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dGV_Results.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dGV_Results.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dGV_Results.RowTemplate.DefaultCellStyle.BackColor = Color.Silver;
            dGV_Results.RowTemplate.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dGV_Results.Size = new Size(762, 431);
            dGV_Results.TabIndex = 7;
            dGV_Results.CellContentClick += dGV_Results_CellContentClick;
            dGV_Results.CellToolTipTextNeeded += dGV_Results_CellToolTipTextNeeded;
            // 
            // Namen
            // 
            Namen.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Namen.HeaderText = "Name";
            Namen.Name = "Namen";
            // 
            // Vorname
            // 
            Vorname.HeaderText = "Vorname";
            Vorname.Name = "Vorname";
            // 
            // Orte
            // 
            Orte.HeaderText = "Ort";
            Orte.Name = "Orte";
            // 
            // Number
            // 
            Number.HeaderText = "Nummer";
            Number.Name = "Number";
            // 
            // Aenlichkeit
            // 
            Aenlichkeit.HeaderText = "Ähnlichkeit";
            Aenlichkeit.Name = "Aenlichkeit";
            // 
            // Delete
            // 
            Delete.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.Red;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 8.249999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Delete.DefaultCellStyle = dataGridViewCellStyle2;
            Delete.HeaderText = "Abgeholt";
            Delete.Name = "Delete";
            Delete.Resizable = DataGridViewTriState.True;
            Delete.SortMode = DataGridViewColumnSortMode.Automatic;
            Delete.Text = "X";
            Delete.ToolTipText = "X";
            Delete.UseColumnTextForButtonValue = true;
            Delete.Width = 134;
            // 
            // BTN_Search
            // 
            BTN_Search.Font = new Font("Microsoft Sans Serif", 27.7499962F);
            BTN_Search.Location = new Point(484, 156);
            BTN_Search.Name = "BTN_Search";
            BTN_Search.Size = new Size(182, 57);
            BTN_Search.TabIndex = 20;
            BTN_Search.Text = "Suchen";
            BTN_Search.UseVisualStyleBackColor = true;
            BTN_Search.Click += btnSearchName_Click;
            // 
            // tB_SearchName
            // 
            tB_SearchName.Font = new Font("Microsoft Sans Serif", 27.7499962F);
            tB_SearchName.Location = new Point(428, 85);
            tB_SearchName.Name = "tB_SearchName";
            tB_SearchName.Size = new Size(283, 49);
            tB_SearchName.TabIndex = 19;
            tB_SearchName.KeyDown += tB_SearchName_KeyDown;
            // 
            // l_SearchName
            // 
            l_SearchName.AutoSize = true;
            l_SearchName.Font = new Font("Microsoft Sans Serif", 27.7499962F);
            l_SearchName.Location = new Point(526, 42);
            l_SearchName.Name = "l_SearchName";
            l_SearchName.Size = new Size(117, 42);
            l_SearchName.TabIndex = 0;
            l_SearchName.Text = "Name";
            // 
            // BTN_Open_Abgeholten
            // 
            BTN_Open_Abgeholten.BackColor = Color.White;
            BTN_Open_Abgeholten.FlatStyle = FlatStyle.Flat;
            BTN_Open_Abgeholten.Font = new Font("Microsoft Sans Serif", 36F);
            BTN_Open_Abgeholten.Location = new Point(40, 688);
            BTN_Open_Abgeholten.Name = "BTN_Open_Abgeholten";
            BTN_Open_Abgeholten.Size = new Size(303, 90);
            BTN_Open_Abgeholten.TabIndex = 10;
            BTN_Open_Abgeholten.Text = "ABGEHOLTEN";
            BTN_Open_Abgeholten.UseVisualStyleBackColor = false;
            BTN_Open_Abgeholten.Click += BTN_Open_Abgeholten_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gainsboro;
            ClientSize = new Size(1661, 925);
            Controls.Add(BTN_Open_Abgeholten);
            Controls.Add(BTN_NamenSuchen);
            Controls.Add(IMG_Logo);
            Controls.Add(BTN_NamenEintragen);
            Controls.Add(BTN_Clear_Excel);
            Controls.Add(BTN_Open_Excel);
            Controls.Add(p_NamenEintragen);
            Controls.Add(p_SearchName);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)IMG_Logo).EndInit();
            p_NamenEintragen.ResumeLayout(false);
            p_NamenEintragen.PerformLayout();
            p_SearchName.ResumeLayout(false);
            p_SearchName.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dGV_Results).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button BTN_Open_Excel;
        private Button BTN_Clear_Excel;
        private PictureBox IMG_Logo;
        private Button BTN_NamenSuchen;
        private Button BTN_NamenEintragen;
        private Panel p_NamenEintragen;
        private TextBox tB_AddName;
        private Label l_NamenEintragen;
        private Label l_Ort;
        private Button BTN_AddSave;
        private ComboBox cB_Ort;
        private Panel p_SearchName;
        private Button BTN_Search;
        private TextBox tB_SearchName;
        private Label l_SearchName;
        private DataGridView dGV_Results;
        private TextBox tB_Kiste;
        private Label l_Chest;
        private Button BTN_All;
        private Label l_L3Number;
        private Label l_L3;
        private Label l_L2Number;
        private Label l_L2;
        private Label l_L1Number;
        private Label l_L1;
        private Label l_AllLagerNumber;
        private Label l_AllLager;
        private TextBox tB_Price;
        private Label l_Kosten;
        private Button BTN_Open_Abgeholten;
        private TextBox tB_Vorname;
        private Label l_Vorname;
        private Label l_wennVorhanden;
        private Button BTN_ShowL3;
        private Button BTN_ShowL2;
        private Button BTN_ShowL1;
        private DataGridViewTextBoxColumn Namen;
        private DataGridViewTextBoxColumn Vorname;
        private DataGridViewTextBoxColumn Orte;
        private DataGridViewTextBoxColumn Number;
        private DataGridViewTextBoxColumn Aenlichkeit;
        private DataGridViewButtonColumn Delete;
    }
}
