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
    public partial class Fast_cash : Form
    {
        public Fast_cash()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-JMO7UOM\\SQLNAME;Initial Catalog=AtmDB;Integrated Security=True");
        string Acc = Login.Accnumber;
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }
        int bal;
        private void getbalance()
        {
            con.Open();

            SqlDataAdapter sda = new SqlDataAdapter("select Balance from Accountbtl where Accnum ='" + Acc + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            balancelbl.Text = "ຍອດເງີນໃນບັນຊີຂອງທ່ານ:" + dt.Rows[0][0].ToString() + "ກີບ";
            bal = Convert.ToInt32(dt.Rows[0][0].ToString());

            con.Close();
        }

        private void Fast_cash_Load(object sender, EventArgs e)
        {
            getbalance();
        }

        private void Addtransaction1() //transaction 
        
        {
            String trType = "ຖອນເງີນອອກຈາກບັນຊີ";
            try
            {
                con.Open();
                string query = "insert into Transactiontbl   values('" + Acc + "',N'" + trType + "'," + 200000 + ",'" + DateTime.Today.Date.ToString() + "')";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();

                //  MessageBox.Show("ຂໍ້ມູນຖືກເພີ້ມສຳເລັດແລ້ວ");

                con.Close();

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

        }
        private void Addtransaction2() //transaction 

        {
            String trType = "ຖອນເງີນອອກຈາກບັນຊີ";
            try
            {
                con.Open();
                string query = "insert into Transactiontbl   values('" + Acc + "',N'" + trType + "'," + 500000 + ",'" + DateTime.Today.Date.ToString() + "')";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();

                //  MessageBox.Show("ຂໍ້ມູນຖືກເພີ້ມສຳເລັດແລ້ວ");

                con.Close();

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

        }
        private void Addtransaction3() //transaction 
        {
            String trType = "ຖອນເງີນອອກຈາກບັນຊີ";
            try
            {
                con.Open();
                string query = "insert into Transactiontbl   values('" + Acc + "',N'" + trType + "'," + 1500000 + ",'" + DateTime.Today.Date.ToString() + "')";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();

                //  MessageBox.Show("ຂໍ້ມູນຖືກເພີ້ມສຳເລັດແລ້ວ");

                con.Close();

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

        }
        private void Addtransaction4() //transaction 
        {
            String trType = "ຖອນເງີນອອກຈາກບັນຊີ";
            try
            {
                con.Open();
                string query = "insert into Transactiontbl   values('" + Acc + "',N'" + trType + "'," + 2000000 + ",'" + DateTime.Today.Date.ToString() + "')";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();

                //  MessageBox.Show("ຂໍ້ມູນຖືກເພີ້ມສຳເລັດແລ້ວ");

                con.Close();

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

        }
        private void Addtransaction5() //transaction 
        {
            String trType = "ຖອນເງີນອອກຈາກບັນຊີ";
            try
            {
                con.Open();
                string query = "insert into Transactiontbl   values('" + Acc + "',N'" + trType + "'," + 2500000 + ",'" + DateTime.Today.Date.ToString() + "')";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();

                //  MessageBox.Show("ຂໍ້ມູນຖືກເພີ້ມສຳເລັດແລ້ວ");

                con.Close();

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

        }


        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(bal < 200000)
            {
                MessageBox.Show("ຂໍອາໄພ! ຍອດເງີນໃນບັນຊີຂອງທ່ານບໍ່ພຽງພໍ");
            }
            else
            {
                int newbalance = bal - 200000;
                try
                {
                    con.Open();
                    string query = "update Accountbtl set Balance = " + newbalance + "where AccNum = '" + Acc + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("ຖອນສຳເລັດ !");
                    

                    Home home = new Home();
                    home.Show();
                    this.Hide();

                    con.Close();
                    Addtransaction1();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (bal < 500000)
            {
                MessageBox.Show("ຂໍອາໄພ! ຍອດເງີນໃນບັນຊີຂອງທ່ານບໍ່ພຽງພໍ");
            }
            else
            {
                int newbalance = bal - 500000;
                try
                {
                    con.Open();
                    string query = "update Accountbtl set Balance =" + newbalance + "where AccNum = '" + Acc + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("ຖອນສຳເລັດ !");
                   

                    Home home = new Home();
                    home.Show();
                    this.Hide();

                    con.Close();
                    Addtransaction2();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (bal < 1500000)
            {
                MessageBox.Show("ຂໍອາໄພ! ຍອດເງີນໃນບັນຊີຂອງທ່ານບໍ່ພຽງພໍ");
            }
            else
            {
                int newbalance = bal - 1500000;
                try
                {
                    con.Open();
                    string query = "update Accountbtl set Balance =" + newbalance + "where AccNum = '" + Acc + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("ຖອນສຳເລັດ !");
                    Addtransaction3();

                    Home home = new Home();
                    home.Show();
                    this.Hide();

                    con.Close();
                    Addtransaction3();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (bal < 2000000)
            {
                MessageBox.Show("ຂໍອາໄພ! ຍອດເງີນໃນບັນຊີຂອງທ່ານບໍ່ພຽງພໍ");
            }
            else
            {
                int newbalance = bal - 2000000;
                try
                {
                    con.Open();
                    string query = "update Accountbtl set Balance =" + newbalance + "where AccNum = '" + Acc + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("ຖອນສຳເລັດ !");
                    Addtransaction4();

                    Home home = new Home();
                    home.Show();
                    this.Hide();

                    con.Close();
                    Addtransaction4();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (bal < 2500000)
            {
                MessageBox.Show("ຂໍອາໄພ! ຍອດເງີນໃນບັນຊີຂອງທ່ານບໍ່ພຽງພໍ");
            }
            else
            {
                int newbalance = bal - 2500000;
                try
                {
                    con.Open();
                    string query = "update Accountbtl set Balance =" + newbalance + "where AccNum = '" + Acc + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("ຖອນສຳເລັດ !");
                    Addtransaction5();
                    Home home = new Home();
                    home.Show();
                    this.Hide();

                    con.Close();
                    Addtransaction5();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            WidthDraw wd = new WidthDraw();
            wd.Show();
            this.Hide();
        }
    }
}
