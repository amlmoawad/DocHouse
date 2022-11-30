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

namespace home1
{
    public partial class book : Form
    {
        string DocName = "";
        public book()
        {
            InitializeComponent();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            DocName = comboBox3.Text;
            SqlConnection con1 = new SqlConnection("Server=localhost;Database=DocHouse_desktop;Trusted_Connection=True;");
            con1.Open();
            SqlCommand cmd1 = new SqlCommand("select doc_id from doctors where doc_name=@docname", con1);
            cmd1.Parameters.AddWithValue("@docname", DocName);
            DataTable dt1 = new DataTable();
            SqlDataAdapter adapt1 = new SqlDataAdapter(cmd1);
            adapt1.Fill(dt1);
            comboBox4.DataSource = dt1;
            comboBox4.DisplayMember = "doc_id";
            con1.Close();
            string gender = "";
            if (radioButton1.Checked)
            {
                gender = "Male";
            }
            else
            {
                gender = "Female";
            }
            SqlConnection con = new SqlConnection("Server=localhost;Database=DocHouse_desktop;Trusted_Connection=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into appointment values(@f,@l,@e,@p,@g,@c,@gen,@a,@d,@h,@s,@dn,@di,@dc)", con);
            cmd.Parameters.AddWithValue("@f", textBox1.Text);
            cmd.Parameters.AddWithValue("@l", textBox2.Text);
            cmd.Parameters.AddWithValue("@e", textBox3.Text);
            cmd.Parameters.AddWithValue("@p", textBox4.Text);
            cmd.Parameters.AddWithValue("@g", comboBox1.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@c", textBox5.Text);
            cmd.Parameters.AddWithValue("@gen", gender);
            cmd.Parameters.AddWithValue("@a", (int)(numericUpDown1.Value));
            cmd.Parameters.AddWithValue("@d", textBox6.Text);
            cmd.Parameters.AddWithValue("@h", textBox7.Text);
            cmd.Parameters.AddWithValue("@s", comboBox2.SelectedItem.ToString());
            //MessageBox.Show("1");
            cmd.Parameters.AddWithValue("@dn", comboBox3.Text);
            // MessageBox.Show("2");
            cmd.Parameters.AddWithValue("@di", comboBox4.Text);
            // MessageBox.Show("3");
            cmd.Parameters.AddWithValue("@dc", comboBox5.Text);
            //  MessageBox.Show("4");
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("YOUR APPOINTMENT HAS LANDED SAFELY");
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            //contact frm2 = new contact();
            //frm2.Show();
            this.Hide();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            //about frm2 = new about();
            //frm2.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            home frm2 = new home();
            frm2.Show();
            this.Hide();
        }

        private void book_Load_1(object sender, EventArgs e)
        {
            comboBox1.Text = "Select Governorate";
            comboBox1.Items.Add("Dakahlia");
            comboBox1.Items.Add("Alexandria");
            comboBox1.Items.Add("Kafr ElSheikh");
            comboBox1.Items.Add("Gharbia");
            comboBox1.Items.Add("Cairo");
            comboBox2.Text = "Select Specilization";
            comboBox2.Items.Add("Internal medicine");
            comboBox2.Items.Add("Family medicine");
            comboBox2.Items.Add("Emergency medicine");
            comboBox2.Items.Add("Rheumatology");
            comboBox2.Items.Add("Otorhinolaryngology");
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //comboBox3.Items.Clear();
            SqlConnection con = new SqlConnection("Server=localhost;Database=DocHouse_desktop;Trusted_Connection=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("select doc_name from doctors where doc_Specification=@specilization and doc_governorate=@governorate", con);
            cmd.Parameters.AddWithValue("@specilization", comboBox2.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@governorate", comboBox1.SelectedItem.ToString());
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            comboBox3.DataSource = dt;
            comboBox3.DisplayMember = "doc_name";
            //comboBox3.Text = "Select Doctor";
            con.Close();
            DocName = comboBox3.Text;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            DocName = comboBox3.Text;
            SqlConnection con = new SqlConnection("Server=localhost;Database=DocHouse_desktop;Trusted_Connection=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("select doc_salary from doctors where doc_name=@docname ", con);
            cmd.Parameters.AddWithValue("@docname", DocName);
            SqlDataAdapter adapt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            comboBox5.DataSource = dt;
            comboBox5.DisplayMember = "doc_salary";
            comboBox5.Text = "Show Cost";
            con.Close();
        }
    }
}
