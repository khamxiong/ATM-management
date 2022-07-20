namespace ATM_Management
{
    public partial class Load : Form
    {
        public Load()
        {
            InitializeComponent();
        }
        int starting = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            starting += 1;
            MyprogressBar.Value = starting;
            Percentage.Text = "" + starting;
            if(MyprogressBar.Value == 100)
            {
                MyprogressBar.Value = 0;
                timer1.Stop();

                Login log = new Login();
                this.Hide();
                log.Show();

            }
        }

        private void Load_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}