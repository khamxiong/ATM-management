using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ATM_Management
{
    public partial class ChangePin : Form
    {
        public ChangePin()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-JMO7UOM\\SQLNAME;Initial Catalog=AtmDB;Integrated Security=True");
        String Acc = Login.Accnumber;
        private void ChageBtn_Click(object sender, EventArgs e)
        {

            if (pin1Tb.Text =="" || pin2Tb.Text =="" )
            {
                MessageBox.Show("ກະລຸນາໃສ່ລະ;ັດໃໝ່ທີຕ້ອງການປຽ່ນ");
            }
            else if(pin1Tb.Text != pin2Tb.Text)
            {
                MessageBox.Show("ກະລຸນາປ້ອມຂໍ້ມູນໃຫ້ຕົງກັນ");
            }

            else
            {

              //  newbalance = oldbalance + Convert.ToInt32(depositAmtb.Text);
                try
                {
                    con.Open();
                    string query = "update Accountbtl set PIN ='" + pin1Tb.Text + "' where AccNum = '" + Acc + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("ການປຽນລະຫັດຜ່ານ ຫຼື ລະຫັດ PIN ສຳເລັດເເລ້ວ");

                    Login login = new Login();
                    login.Show();
                    this.Hide();

                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
