using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace home1
{
    public partial class join : Form
    {
        public join()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            home1 frm2 = new home1();
            frm2.Show();
            this.Hide();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "Image files | *.jpg";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    textBox8.Text = openFileDialog1.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string FileName = textBox8.Text;
            byte[] ImageData;
            FileStream fs = new FileStream(FileName, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            ImageData = br.ReadBytes((int)fs.Length);
            br.Close();
            fs.Close();
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
            SqlCommand cmd = new SqlCommand("insert into joinus(doc_name,doc_Specification,national_id,doc_email,doc_phone,doc_governorate,doc_city,doc_gender,doc_salary,doc_education,medicalid) values(@n,@s,@nid,@e,@p,@g,@c,@gen,@sal,@edu,@img)", con);
            cmd.Parameters.AddWithValue("@n", textBox1.Text);
            cmd.Parameters.AddWithValue("@s", comboBox2.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@nid", textBox2.Text);
            cmd.Parameters.AddWithValue("@e", textBox3.Text);
            cmd.Parameters.AddWithValue("@p", textBox4.Text);
            cmd.Parameters.AddWithValue("@g", comboBox1.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@c", textBox5.Text);
            cmd.Parameters.AddWithValue("@gen", gender);
            cmd.Parameters.AddWithValue("@sal", textBox6.Text);
            cmd.Parameters.AddWithValue("@edu", textBox7.Text);
           // MessageBox.Show("1");
            cmd.Parameters.AddWithValue("@img", ImageData);
            //MessageBox.Show("2");
            cmd.ExecuteNonQuery();
            //MessageBox.Show("3");
            con.Close();
            MessageBox.Show("YOUR DATA IS SAVED WITH US");
            home1 frm2 = new home1();
            frm2.Show();
            this.Hide();
        }

        private void join_Load(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {
            //contact frm2 = new contact();
            //frm2.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //about frm2 = new about();
            //frm2.Show();
            this.Hide();
        }
    }
}
