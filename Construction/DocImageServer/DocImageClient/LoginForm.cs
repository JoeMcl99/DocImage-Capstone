using System;
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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            passwordTextBox.PasswordChar = '*';

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (IsValidUser())
            {
                Form1 f = new Form1();
                this.Hide();
                f.Show();
            }           
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            AddUserForm f = new AddUserForm();
            this.Hide();
            f.Show();
        }

        private Boolean IsValidUser()
        {
            String username = usernameTextBox.Text;
            String password = passwordTextBox.Text;          
            User savedUser = GetSavedUser(username);

            Boolean isValid = true;
            if (savedUser.Password != null || savedUser.Password == "")
            {

                string savedPasswordHash = savedUser.Password;

                byte[] hashBytes = Convert.FromBase64String(savedPasswordHash);

                byte[] salt = new byte[16];
                Array.Copy(hashBytes, 0, salt, 0, 16);
                var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
                byte[] hash = pbkdf2.GetBytes(20);
                for (int i = 0; i < 20; i++)
                {

                    if (hashBytes[i + 16] != hash[i])
                    {
                        isValid = false;
                    }
                }
            }
            else {
                isValid = false;
                MessageBox.Show("Incorrect password");
            }
            return isValid;
        }



        private User GetSavedUser(String username) {

            User savedUser = new User();
            SqlDataReader reader = null;
            string connetionString = null;       
            SqlConnection cnn;
            connetionString = "Data Source=2A207-C06\\SQLEXPRESS;Initial Catalog=capstoneDB;Integrated Security=True";
            cnn = new SqlConnection(connetionString);
            String selectSql = "SELECT * from USERS "
                   + "WHERE userName=@username";

            SqlCommand cmd = new SqlCommand(selectSql, cnn);
            try
            {
                cnn.Open();
                cmd.Parameters.AddWithValue("@username", username);

                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        savedUser.Username = reader.GetString(1);
                        savedUser.Password = reader.GetString(2);
                    }
                }
                else {
                    MessageBox.Show("No User Found");
                }
                cnn.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());                
            }           
            return savedUser;
        }
    }
}
