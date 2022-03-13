using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Dashboard
{
    public partial class Form1 : Form
    {
        //Connection connect = new Connection();
        User user = new User();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void placeholderTextBox2_TextChanged(object sender, EventArgs e)
        {
            lUsernameError.Visible = false;
            lPasswordError.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.ForeColor = Color.White;
        }

        private void placeholderTextBox1_TextChanged(object sender, EventArgs e)
        {
            lUsernameError.Visible = false;
            lPasswordError.Visible = false;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.ForeColor = Color.Red;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void loginbtn_MouseEnter(object sender, EventArgs e)
        {
            loginbtn.BackColor = Color.FromArgb(0, 0, 192);
        }

        private void loginbtn_MouseLeave(object sender, EventArgs e)
        {
            loginbtn.BackColor = Color.FromArgb(0, 0, 64);
        }

        private void loginbtn_Click(object sender, EventArgs e)
        {
            if (lusername.Text == string.Empty && lpassword.Text == string.Empty)
            {
                lUsernameError.Text = "Username field must not be blank.";
                lUsernameError.Visible = true;

                lPasswordError.Text = "Password field must not be blank";
                lPasswordError.Visible = true;
            }
            else if (lusername.Text == string.Empty)
            {
                lUsernameError.Text = "Username field must not be blank.";
                lUsernameError.Visible = true;
            }
            else if (lpassword.Text == string.Empty)
            {
                lPasswordError.Text = "Password field must not be blank";
                lPasswordError.Visible = true;
            }
            else
            {
                string username_email = lusername.Text;
                string password = lpassword.Text;
                try
                {
                    using (DataTable userTable = user.getUserList(new MySqlCommand("SELECT * FROM user WHERE UserName='" + username_email + "' OR Email='" + username_email + "' AND Password='" + password + "'")))
                    {
                        if (userTable.Rows.Count > 0)
                        {
                            Main main = new Main();
                            this.Hide();
                            main.Show();
                        }
                        else
                        {
                            MessageBox.Show("Your username and password are invalid", "Invalid Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    lUsernameError.Text = "Connecting to server failed!, Contact the system administrator for help. '" + ex.Message + "'";
                    lUsernameError.Visible=true;
                }
                finally
                {
                    //connect.closeConnect();
                }
            }
            
        }
    }
}
