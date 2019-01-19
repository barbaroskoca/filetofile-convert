namespace FileToFileApp.Main
{
    partial class MainPage
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
            this.components = new System.ComponentModel.Container();
            this.grid_Address = new System.Windows.Forms.DataGridView();
            this.cityNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cityCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.districtNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zipCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addressBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_ExportedFile = new System.Windows.Forms.Label();
            this.lbl_SelectedFile = new System.Windows.Forms.Label();
            this.btn_ExportToFile = new System.Windows.Forms.Button();
            this.btn_Preview = new System.Windows.Forms.Button();
            this.btn_SelectFile = new System.Windows.Forms.Button();
            this.panel_Multi = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.check_SecondaryIsAscending = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmb_SecondarySort = new System.Windows.Forms.ComboBox();
            this.check_MultiSorting = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.check_IsAscending = new System.Windows.Forms.CheckBox();
            this.cmb_SortBy1 = new System.Windows.Forms.ComboBox();
            this.cmb_CityNames = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dia_OpenFile = new System.Windows.Forms.OpenFileDialog();
            this.dia_SaveFile = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.grid_Address)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addressBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel_Multi.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grid_Address
            // 
            this.grid_Address.AutoGenerateColumns = false;
            this.grid_Address.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_Address.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cityNameDataGridViewTextBoxColumn,
            this.cityCodeDataGridViewTextBoxColumn,
            this.districtNameDataGridViewTextBoxColumn,
            this.zipCodeDataGridViewTextBoxColumn});
            this.grid_Address.DataSource = this.addressBindingSource;
            this.grid_Address.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid_Address.Location = new System.Drawing.Point(3, 16);
            this.grid_Address.Name = "grid_Address";
            this.grid_Address.Size = new System.Drawing.Size(619, 231);
            this.grid_Address.TabIndex = 0;
            // 
            // cityNameDataGridViewTextBoxColumn
            // 
            this.cityNameDataGridViewTextBoxColumn.DataPropertyName = "CityName";
            this.cityNameDataGridViewTextBoxColumn.HeaderText = "CityName";
            this.cityNameDataGridViewTextBoxColumn.Name = "cityNameDataGridViewTextBoxColumn";
            // 
            // cityCodeDataGridViewTextBoxColumn
            // 
            this.cityCodeDataGridViewTextBoxColumn.DataPropertyName = "CityCode";
            this.cityCodeDataGridViewTextBoxColumn.HeaderText = "CityCode";
            this.cityCodeDataGridViewTextBoxColumn.Name = "cityCodeDataGridViewTextBoxColumn";
            // 
            // districtNameDataGridViewTextBoxColumn
            // 
            this.districtNameDataGridViewTextBoxColumn.DataPropertyName = "DistrictName";
            this.districtNameDataGridViewTextBoxColumn.HeaderText = "DistrictName";
            this.districtNameDataGridViewTextBoxColumn.Name = "districtNameDataGridViewTextBoxColumn";
            // 
            // zipCodeDataGridViewTextBoxColumn
            // 
            this.zipCodeDataGridViewTextBoxColumn.DataPropertyName = "ZipCode";
            this.zipCodeDataGridViewTextBoxColumn.HeaderText = "ZipCode";
            this.zipCodeDataGridViewTextBoxColumn.Name = "zipCodeDataGridViewTextBoxColumn";
            // 
            // addressBindingSource
            // 
            this.addressBindingSource.DataSource = typeof(FileToFile.Models.Address);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl_ExportedFile);
            this.groupBox1.Controls.Add(this.lbl_SelectedFile);
            this.groupBox1.Controls.Add(this.btn_ExportToFile);
            this.groupBox1.Controls.Add(this.btn_Preview);
            this.groupBox1.Controls.Add(this.btn_SelectFile);
            this.groupBox1.Controls.Add(this.panel_Multi);
            this.groupBox1.Controls.Add(this.check_MultiSorting);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.check_IsAscending);
            this.groupBox1.Controls.Add(this.cmb_SortBy1);
            this.groupBox1.Controls.Add(this.cmb_CityNames);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(625, 278);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // lbl_ExportedFile
            // 
            this.lbl_ExportedFile.AutoSize = true;
            this.lbl_ExportedFile.Location = new System.Drawing.Point(15, 251);
            this.lbl_ExportedFile.Name = "lbl_ExportedFile";
            this.lbl_ExportedFile.Size = new System.Drawing.Size(0, 13);
            this.lbl_ExportedFile.TabIndex = 20;
            // 
            // lbl_SelectedFile
            // 
            this.lbl_SelectedFile.AutoSize = true;
            this.lbl_SelectedFile.Location = new System.Drawing.Point(12, 171);
            this.lbl_SelectedFile.Name = "lbl_SelectedFile";
            this.lbl_SelectedFile.Size = new System.Drawing.Size(0, 13);
            this.lbl_SelectedFile.TabIndex = 19;
            // 
            // btn_ExportToFile
            // 
            this.btn_ExportToFile.BackColor = System.Drawing.Color.LightCoral;
            this.btn_ExportToFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_ExportToFile.Location = new System.Drawing.Point(12, 220);
            this.btn_ExportToFile.Name = "btn_ExportToFile";
            this.btn_ExportToFile.Size = new System.Drawing.Size(600, 24);
            this.btn_ExportToFile.TabIndex = 18;
            this.btn_ExportToFile.Text = "EXPORT TO FILE";
            this.btn_ExportToFile.UseVisualStyleBackColor = false;
            this.btn_ExportToFile.Click += new System.EventHandler(this.Btn_ExportToFile_Click);
            // 
            // btn_Preview
            // 
            this.btn_Preview.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btn_Preview.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_Preview.Location = new System.Drawing.Point(12, 190);
            this.btn_Preview.Name = "btn_Preview";
            this.btn_Preview.Size = new System.Drawing.Size(600, 24);
            this.btn_Preview.TabIndex = 16;
            this.btn_Preview.Text = "PREVIEW";
            this.btn_Preview.UseVisualStyleBackColor = false;
            this.btn_Preview.Click += new System.EventHandler(this.Btn_Preview_Click);
            // 
            // btn_SelectFile
            // 
            this.btn_SelectFile.BackColor = System.Drawing.Color.PaleGreen;
            this.btn_SelectFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_SelectFile.Location = new System.Drawing.Point(12, 139);
            this.btn_SelectFile.Name = "btn_SelectFile";
            this.btn_SelectFile.Size = new System.Drawing.Size(600, 24);
            this.btn_SelectFile.TabIndex = 16;
            this.btn_SelectFile.Text = "SELECT FILE";
            this.btn_SelectFile.UseVisualStyleBackColor = false;
            this.btn_SelectFile.Click += new System.EventHandler(this.Btn_SelectFile_Click);
            // 
            // panel_Multi
            // 
            this.panel_Multi.Controls.Add(this.label6);
            this.panel_Multi.Controls.Add(this.check_SecondaryIsAscending);
            this.panel_Multi.Controls.Add(this.label5);
            this.panel_Multi.Controls.Add(this.cmb_SecondarySort);
            this.panel_Multi.Location = new System.Drawing.Point(304, 49);
            this.panel_Multi.Name = "panel_Multi";
            this.panel_Multi.Size = new System.Drawing.Size(309, 74);
            this.panel_Multi.TabIndex = 10;
            this.panel_Multi.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(6, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 15);
            this.label6.TabIndex = 6;
            this.label6.Text = "Secondary Sort By :";
            // 
            // check_SecondaryIsAscending
            // 
            this.check_SecondaryIsAscending.AutoSize = true;
            this.check_SecondaryIsAscending.Checked = true;
            this.check_SecondaryIsAscending.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_SecondaryIsAscending.Location = new System.Drawing.Point(150, 41);
            this.check_SecondaryIsAscending.Name = "check_SecondaryIsAscending";
            this.check_SecondaryIsAscending.Size = new System.Drawing.Size(76, 17);
            this.check_SecondaryIsAscending.TabIndex = 14;
            this.check_SecondaryIsAscending.Text = "Ascending";
            this.check_SecondaryIsAscending.UseVisualStyleBackColor = true;
            this.check_SecondaryIsAscending.CheckedChanged += new System.EventHandler(this.Check_SecondaryIsAscending_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(6, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 15);
            this.label5.TabIndex = 5;
            this.label5.Text = "Secondary Is Ascending?";
            // 
            // cmb_SecondarySort
            // 
            this.cmb_SecondarySort.FormattingEnabled = true;
            this.cmb_SecondarySort.Items.AddRange(new object[] {
            "",
            "CityName",
            "CityCode",
            "DistrictName",
            "ZipCode"});
            this.cmb_SecondarySort.Location = new System.Drawing.Point(150, 7);
            this.cmb_SecondarySort.Name = "cmb_SecondarySort";
            this.cmb_SecondarySort.Size = new System.Drawing.Size(133, 21);
            this.cmb_SecondarySort.TabIndex = 12;
            // 
            // check_MultiSorting
            // 
            this.check_MultiSorting.AutoSize = true;
            this.check_MultiSorting.Location = new System.Drawing.Point(417, 30);
            this.check_MultiSorting.Name = "check_MultiSorting";
            this.check_MultiSorting.Size = new System.Drawing.Size(40, 17);
            this.check_MultiSorting.TabIndex = 8;
            this.check_MultiSorting.Text = "No";
            this.check_MultiSorting.UseVisualStyleBackColor = true;
            this.check_MultiSorting.CheckedChanged += new System.EventHandler(this.Check_MultiSorting_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(310, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Is Multi Sorting?";
            // 
            // check_IsAscending
            // 
            this.check_IsAscending.AutoSize = true;
            this.check_IsAscending.Checked = true;
            this.check_IsAscending.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_IsAscending.Location = new System.Drawing.Point(118, 90);
            this.check_IsAscending.Name = "check_IsAscending";
            this.check_IsAscending.Size = new System.Drawing.Size(76, 17);
            this.check_IsAscending.TabIndex = 6;
            this.check_IsAscending.Text = "Ascending";
            this.check_IsAscending.UseVisualStyleBackColor = true;
            this.check_IsAscending.CheckedChanged += new System.EventHandler(this.Check_IsAscending_CheckedChanged);
            // 
            // cmb_SortBy1
            // 
            this.cmb_SortBy1.FormattingEnabled = true;
            this.cmb_SortBy1.Items.AddRange(new object[] {
            "",
            "CityName",
            "CityCode",
            "DistrictName",
            "ZipCode"});
            this.cmb_SortBy1.Location = new System.Drawing.Point(118, 56);
            this.cmb_SortBy1.Name = "cmb_SortBy1";
            this.cmb_SortBy1.Size = new System.Drawing.Size(133, 21);
            this.cmb_SortBy1.TabIndex = 4;
            // 
            // cmb_CityNames
            // 
            this.cmb_CityNames.FormattingEnabled = true;
            this.cmb_CityNames.Items.AddRange(new object[] {
            "",
            "Adana",
            "Adıyaman",
            "Afyonkarahisar",
            "Ağrı",
            "Aksaray",
            "Amasya",
            "Ankara",
            "Antalya",
            "Ardahan",
            "Artvin",
            "Aydın",
            "Balıkesir",
            "Bartın",
            "Batman",
            "Bayburt",
            "Bilecik",
            "Bingöl",
            "Bitlis",
            "Bolu",
            "Burdur",
            "Bursa",
            "Çanakkale",
            "Çankırı",
            "Çorum",
            "Denizli",
            "Diyarbakır",
            "Düzce",
            "Edirne",
            "Elazığ",
            "Erzincan",
            "Erzurum",
            "Eskişehir",
            "Gaziantep",
            "Giresun",
            "Gümüşhane",
            "Hakkari",
            "Hatay",
            "Iğdır",
            "Isparta",
            "İstanbul",
            "İzmir",
            "Kahramanmaraş",
            "Karabük",
            "Karaman",
            "Kars",
            "Kastamonu",
            "Kayseri",
            "Kırıkkale",
            "Kırklareli",
            "Kırşehir",
            "Kilis",
            "Kocaeli",
            "Konya",
            "Kütahya",
            "Malatya",
            "Manisa",
            "Mardin",
            "Mersin",
            "Muğla",
            "Muş",
            "Nevşehir",
            "Niğde",
            "Ordu",
            "Osmaniye",
            "Rize",
            "Sakarya",
            "Samsun",
            "Siirt",
            "Sinop",
            "Sivas",
            "Şanlıurfa",
            "Şırnak",
            "Tekirdağ",
            "Tokat",
            "Trabzon",
            "Tunceli",
            "Uşak",
            "Van",
            "Yalova",
            "Yozgat",
            "Zonguldak"});
            this.cmb_CityNames.Location = new System.Drawing.Point(118, 27);
            this.cmb_CityNames.Name = "cmb_CityNames";
            this.cmb_CityNames.Size = new System.Drawing.Size(133, 21);
            this.cmb_CityNames.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(12, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Is Ascending?";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(12, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Sort By :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Filter :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.grid_Address);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 278);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(625, 250);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Preview";
            // 
            // dia_OpenFile
            // 
            this.dia_OpenFile.Filter = "XML File |*.xml|CSV File |*.csv";
            this.dia_OpenFile.Title = "Please select an XML or CSV File";
            // 
            // dia_SaveFile
            // 
            this.dia_SaveFile.Filter = "XML File |*.xml|CSV File |*.csv";
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 528);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainPage";
            this.Load += new System.EventHandler(this.MainPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid_Address)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addressBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel_Multi.ResumeLayout(false);
            this.panel_Multi.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grid_Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn cityNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cityCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn districtNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn zipCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource addressBindingSource;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmb_CityNames;
        private System.Windows.Forms.ComboBox cmb_SortBy1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox check_IsAscending;
        private System.Windows.Forms.CheckBox check_MultiSorting;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox check_SecondaryIsAscending;
        private System.Windows.Forms.ComboBox cmb_SecondarySort;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel_Multi;
        private System.Windows.Forms.Button btn_ExportToFile;
        private System.Windows.Forms.Button btn_SelectFile;
        private System.Windows.Forms.Button btn_Preview;
        private System.Windows.Forms.Label lbl_SelectedFile;
        private System.Windows.Forms.OpenFileDialog dia_OpenFile;
        private System.Windows.Forms.SaveFileDialog dia_SaveFile;
        private System.Windows.Forms.Label lbl_ExportedFile;
    }
}