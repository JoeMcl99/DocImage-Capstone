using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocImageClient.DocImageServiceReference;

namespace DocImageClient
{
    public partial class Form1 : Form
    {
        DocImageServerClient proxy = new DocImageServerClient();
        public Form1()
        {
            InitializeComponent();



        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
        }

        private void single_Btn_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
            panel3.Visible = false;
        }

        private void btnSingleSearch_Click(object sender, EventArgs e)
        {
            txtSingleResult.Clear();
            Dictionary<string, bool> returnDictionary = proxy.scrapeTest(txtSingleHstNumber.Text, txtSingleBusinessName.Text);
            foreach (var message in returnDictionary)
            {
                txtSingleResult.Text += message.Key;
            }
        }

        private void chkList_Btn_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panel1.Visible = false;
            panel2.Visible = false;

        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "CSV|*.csv", ValidateNames = true, Multiselect = false })
                {

                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        System.IO.FileInfo fi = new System.IO.FileInfo(ofd.FileName);
                        txtCsv.Text = fi.Name;
                        CSVParser cv = new CSVParser(ofd);


                        List<string[]> splitCsv = cv.ParseCsv();
                        foreach (var item in splitCsv)
                        {
                            //Your code here
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
