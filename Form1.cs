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


namespace terminal1
{
    public partial class Form1 : Form
    {
        Timer t = new Timer();
        SqlConnection conn = new SqlConnection(@"Data Source=NZLA-PC\SHOPY;Initial Catalog=shopy;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            label3.Text = today.ToString("dd/MM/yyyy");
            t.Interval = 1000;
            t.Tick += new EventHandler(this.t_Tick);
            t.Start();
            readorder();
        }
        public void t_Tick(object sender, EventArgs e)
        {
            int hh = DateTime.Now.Hour;
            int mm = DateTime.Now.Minute;
            int ss = DateTime.Now.Second;
            string time = "";
            if (hh < 10)
            {
                time += "0" + hh;
            }
            else
            {
                time += hh;
            }
            time += ":";
            if (mm < 10)
            {
                time += "0" + mm;
            }
            else
            {
                time += mm;
            }
            time += ":";
            if (ss < 10)
            {
                time += "0" + ss;
            }
            else
            {
                time += ss;
            }
            label4.Text = time;

        }
        private void readorder()
        {
            // read order details
            SqlCommand command = new SqlCommand("Select * from Orders", conn);
            //command.Parameters.AddWithValue("@orderidno", orderno);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable tableO = new DataTable();
            adapter.Fill(tableO);
            dataGridView1.DataSource = tableO;
            // dataGridView2.CurrentCell = dataGridView2[0, 1];
            //button130.Text = tableO.Rows[0][3].ToString();
            //button131.Text = tableO.Rows[0][4].ToString();
            //dataGridView1.Columns[0].Visible = false;
            // dataGridView1.Columns[1].Visible = false; // sales line no
            // dataGridView1.Columns[2].Visible = false;
            //dataGridView1.Columns[3].Visible = false;
            //dataGridView1.Columns[4].Visible = false;
            //dataGridView1.Columns[5].Visible = false;
            //dataGridView1.Columns[6].Visible = false;
            // dataGridView1.Columns[7].Visible = false;
            //dataGridView1.Columns[8].Visible = false;
            dataGridView1.RowTemplate.Height = 40;
            dataGridView1.DefaultCellStyle.BackColor = Color.Beige;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Yellow;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Black;
            dataGridView1.DefaultCellStyle.Font = new Font("Tahoma", 14);
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[19].Visible = false;
            dataGridView1.Columns[20].Visible = false;
            dataGridView1.Columns[21].Visible = false;
            int rowcnt1 = dataGridView1.Rows.Count;
            dataGridView1.CurrentCell = dataGridView1[4, rowcnt1 - 1];

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sales sls = new Sales();
            sls.Show();
            this.Hide();
        }
    }
}
