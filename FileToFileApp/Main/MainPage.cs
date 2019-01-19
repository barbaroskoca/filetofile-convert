using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FileToFile;
using System.IO;

namespace FileToFileApp.Main
{
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public static List<FileToFile.Models.Address> addresses;

        FileToFileConvert FileToFileconvert = FileToFileConvert.Instance;

        private void MainPage_Load(object sender, EventArgs e)
        {
            addresses = new List<FileToFile.Models.Address>();
        }

        private void Check_IsAscending_CheckedChanged(object sender, EventArgs e) => check_IsAscending.Text = check_IsAscending.Checked ? "Ascending" : "Descending";

        private void Check_MultiSorting_CheckedChanged(object sender, EventArgs e)
        {
            panel_Multi.Visible = check_MultiSorting.Checked;
            check_MultiSorting.Text = check_MultiSorting.Checked ? "Yes" :  "No";

        }

        private void Check_SecondaryIsAscending_CheckedChanged(object sender, EventArgs e) => check_SecondaryIsAscending.Text = check_SecondaryIsAscending.Checked ? "Ascending" : "Descending";

        private void Btn_SelectFile_Click(object sender, EventArgs e)
        {
            lbl_SelectedFile.Text = "";
            dia_OpenFile.FileName = "";

            dia_OpenFile.InitialDirectory = @"C:\";


            if (dia_OpenFile.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrWhiteSpace(dia_OpenFile.FileName))
                {
                    lbl_SelectedFile.Text = "SELECTED FILE = " + " ( " + dia_OpenFile.FileName + " )";
                }
            }

        }

        private void Btn_Preview_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(dia_OpenFile.FileName))
            {
                MessageBox.Show("Please select a file!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            addresses = FileToFileconvert.GetFilteredList(dataPath: dia_OpenFile.FileName,
                formatType: Path.GetExtension(dia_OpenFile.FileName),
                cityName: cmb_CityNames.Text,
                sortBy: cmb_SortBy1.Text,
                sortAscending: check_IsAscending.Checked,
                multiSorting: check_MultiSorting.Checked,
                sortBy2: cmb_SecondarySort.Text,
                sortAscending2: check_SecondaryIsAscending.Checked);

            grid_Address.DataSource = addresses;

        }

        private void Btn_ExportToFile_Click(object sender, EventArgs e)
        {
            lbl_ExportedFile.Text = "";
            dia_SaveFile.FileName = "";

            dia_SaveFile.InitialDirectory = @"C:\";
            if (dia_SaveFile.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrWhiteSpace(dia_SaveFile.FileName))
                {
                    lbl_ExportedFile.Text = "EXPORTED FILE = " + " ( " + dia_SaveFile.FileName + " )";

                    FileToFileconvert.ExportToFile(addresses, dia_SaveFile.FileName, Path.GetExtension(dia_SaveFile.FileName));
                    
                    MessageBox.Show("File Saved.", "INFO", MessageBoxButtons.OK, MessageBoxIcon.None);

                }

            }

        }
    }
}
