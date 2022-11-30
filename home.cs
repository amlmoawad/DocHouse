using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace home1
{
    public partial class home : Form
    {
        public home()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            home frm2 = new home();
            frm2.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //chat frm2 = new chat();
            //frm2.Show();
            this.Hide();
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

        private void button5_Click_1(object sender, EventArgs e)
        {
            //logout
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            book frm2 = new book();
            frm2.Show();
            this.Hide();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            //medicine frm2 = new medicine();
            //frm2.Show();
            this.Hide();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            //examination frm2 = new examination();
            //frm2.Show();
            this.Hide();
        }
    }
}
