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

            BackColor = Color.White;


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;

            txtSingleResult.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
            txtSingleResult.Visible = false;
        }

        private void single_Btn_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
            panel3.Visible = false;
            txtSingleResult.Visible = true;
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
            txtSingleResult.Visible = false;

        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "CSV|*.csv", ValidateNames = true, Multiselect = false })
                {

                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        DataTable dt = new DataTable();
                        System.IO.FileInfo fi = new System.IO.FileInfo(ofd.FileName);
                        
                        txtCsv.Text = fi.Name;
                     //   BindDataCSV(txtCsv.Text);
                        CSVParser cv = new CSVParser(ofd);
                        dt.Columns.Add("HstNumber", typeof(string));
                        dt.Columns.Add("BusinessName", typeof(string));
                        dt.Columns.Add("Result", typeof(string));

                        List<string[]> splitCsv = cv.ParseCsv();
                        foreach (var item in splitCsv)
                        {
                            
                            DataRow dr = dt.NewRow();
                            string hstNumber = item[0];
                            string legalName = item[1];
                            Dictionary<string, bool> returnDictionary = proxy.scrapeTest(hstNumber, legalName);

                            string errorString = "";
                            bool first = true;
                            foreach (var error in returnDictionary)
                            {
                                if (first)
                                {
                                    errorString += error.Key;
                                    first = false;
                                }
                                else
                                {
                                    errorString += ", " + error.Key;
                                }
                                
                                
                            }
                            
                            dt.Rows.Add(hstNumber, legalName, errorString);
                            dataGridView1.DataSource = dt;
                        }
                    }
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BindDataCSV(string filePath)
        {
            DataTable dt = new DataTable();
            string[] lines = System.IO.File.ReadAllLines(filePath);
            if(lines.Length > 0)
            {
                string firstLine = lines[0];
                string[] headerLables = firstLine.Split(',');

                foreach(string headerWord in headerLables)
                {
                    dt.Columns.Add(new DataColumn(headerWord));
                }

                //for data

            for(int r =1; r<lines.Length;r++)
                {
                    string[] dataWords = lines[r].Split(',');
                    DataRow dr = dt.NewRow();
                    int columnIndex = 0;
                    foreach (string headerWord in headerLables)
                    {
                       
                        
                        dr[headerWord] = dataWords[columnIndex++];
                    }
                    dt.Rows.Add(dr);
                }
            }
            if(dt.Rows.Count>0)
            {
                dataGridView1.DataSource = dt;
            }
        }
    }
}
