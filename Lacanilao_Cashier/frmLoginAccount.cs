using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lacanilao_Cashier
{
    public partial class frmLoginAccount : Form
    {
        private Cashier activeCashier = new Cashier("Jofers", "password123");

        public frmLoginAccount()
        {
            InitializeComponent();
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string inputUser = txtUsername.Text;
            string inputPass = txtPassword.Text;

            if (activeCashier.validateLogin(inputUser, inputPass))
            {
                MessageBox.Show($"Welcome back!\n\nName: {activeCashier.FullName}",
                                "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Form1 mainDashboard = new Form1(this);
                mainDashboard.Show();
                this.Hide();

                txtUsername.Clear();
                txtPassword.Clear();
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.", "Authentication Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
