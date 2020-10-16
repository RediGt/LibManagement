using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibManagement
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            tBoxUsername.SelectionStart = tBoxUsername.Text.Length;
            tBoxUsername.DeselectAll();
        }
        
        private void bttExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tBoxUsername_MouseClick(object sender, MouseEventArgs e)
        {
            if (tBoxUsername.Text == "Username")
            {
                tBoxUsername.Clear();
            }
        }

        private void tBoxPassword_MouseClick(object sender, MouseEventArgs e)
        {
            if (tBoxPassword.Text == "Password")
            {
                tBoxPassword.Clear();
                tBoxPassword.PasswordChar = '*';
            }
        }

        private void tBoxUsername_MouseLeave(object sender, EventArgs e)
        {
            if (tBoxUsername.Text == "")
                tBoxUsername.Text = "Username";
        }

        private void tBoxPassword_MouseLeave(object sender, EventArgs e)
        {
            if (tBoxPassword.Text == "")
            {
                tBoxPassword.Text = "Password";
                tBoxPassword.PasswordChar = default;
            }          
        }

        private void pBoxYoutube_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/");
        }

        private void pBoxFacebook_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/");
        }

        private void pBoxInstagram_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("chrome", "https://www.instagram.com/?hl=en");
            }
            catch
            {
                System.Diagnostics.Process.Start("https://www.instagram.com/?hl=en");

            }
        }

        private void bttLogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = DESKTOP-TVBPA8T; database=LibManagement; integrated security=True ";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "SELECT * FROM loginTable WHERE username = '"+tBoxUsername.Text+"' AND pass = '"+tBoxPassword.Text+"'";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            MessageBox.Show("Connecton succeded");
        }
    }
}
