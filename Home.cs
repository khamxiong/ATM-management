using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM_Management
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            WidthDraw wd = new WidthDraw();
            wd.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MiniStament mini = new MiniStament();
            mini.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Balance balance = new Balance();
            balance.Show();
            this.Hide();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            ChangePin PIN = new ChangePin();
            PIN.Show();
            this.Hide();
        }
        public static String Accnumber;
        private void Home_Load(object sender, EventArgs e)
        {
            AccountLabel.Text = "ເລກບັນຊີທີ່ເຂົ້າໃຊ້ລະບົບ:" + Login.Accnumber;
            Accnumber = Login.Accnumber;
        }
     
        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DepositBtn_Click(object sender, EventArgs e)
        {
            Deposit dep = new Deposit();
            dep.Show();
            this.Hide();
        }

        private void AccountLabel_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Fast_cash Fcash = new Fast_cash();
            Fcash.Show();
            this.Hide();
        }
    }
}
