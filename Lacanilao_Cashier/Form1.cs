using ItemNamespace;
using System;
using System.Windows.Forms;

namespace Lacanilao_Cashier
{
    public partial class Form1 : Form
    {
        private DiscountedItem purchaseItem;
        private frmLoginAccount _loginForm;

        public Form1()
        {
            InitializeComponent();
        }

        public Form1(frmLoginAccount loginForm) : this()
        {
            this._loginForm = loginForm;
        }

        private void btnCompute_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtItemName.Text;
                double price = Convert.ToDouble(numPrice.Text);
                double discount = Convert.ToDouble(txtDiscount.Text);
                int quantity = Convert.ToInt32(numQuantity.Text);

                purchaseItem = new DiscountedItem(name, price, quantity, discount);

                double totalAmount = purchaseItem.getDiscountedPrice();
                lblTotalAmount.Text = totalAmount.ToString("F2");
            }
            catch (FormatException)
            {
                MessageBox.Show("Please ensure all fields contain valid numerical inputs.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSubmitPayment_Click(object sender, EventArgs e)
        {
            try
            {
                if (purchaseItem == null)
                {
                    MessageBox.Show("Please compute the total bill before receiving a payment.", "Sequence Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                double payment = Convert.ToDouble(numPaymentAmount.Text);
                double changeAmount = purchaseItem.getChange(payment);

                if (changeAmount < 0)
                {
                    MessageBox.Show("Insufficient payment amount.", "Payment Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lblChange.Text = "0.00";
                }
                else
                {
                    lblChange.Text = changeAmount.ToString("F2");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid numeric currency amount for payment.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_loginForm != null)
            {
                this.FormClosing -= Form1_FormClosing;
                _loginForm.Show();
                this.Close();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}