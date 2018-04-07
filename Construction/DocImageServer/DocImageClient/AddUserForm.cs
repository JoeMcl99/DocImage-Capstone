﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DocImageClient
{
    public partial class AddUserForm : Form
    {
        public AddUserForm()
        {
            InitializeComponent();
        }

        public object DBContext { get; private set; }

        private void addUser()
        {


            String username = usernameTB.Text;
            String password = passwordHash();

            String fullname = firstNameTB.Text;
            DateTime thisDay = DateTime.Today;


            string connetionString = null;
            string sql = null;
            SqlConnection cnn;
            connetionString = "Data Source=2A207-B03\\SQLEXPRESS;Initial Catalog=capstoneDatabase;Integrated Security=True";
            cnn = new SqlConnection(connetionString);

            try
            {
                cnn.Open();

                sql = "insert into USERS ([userName], [passwordHash], [fullName], [creationDate]) values(@username,@passwordHash,@fullname,@creationDate)";

                using (SqlCommand cmd = new SqlCommand(sql, cnn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@passwordHash", password);
                    cmd.Parameters.AddWithValue("@fullname", fullname);
                    cmd.Parameters.AddWithValue("@creationDate", thisDay);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Row inserted !! ");
                }

                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void registerBTN_Click(object sender, EventArgs e)
        {

            addUser();
        }

        private string passwordHash()
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            String password = passwordTB.Text;
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            string savedPasswordHash = Convert.ToBase64String(hashBytes);

            return savedPasswordHash;
        }
    }
}
