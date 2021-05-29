using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.EcontactClasses;

namespace WindowsFormsApp1
{
    public partial class EContacts : Form
    {
        public EContacts()
        {
            InitializeComponent();
        }

        contactClass c = new contactClass();
        private void button1_Click(object sender, EventArgs e)
        {
            c.Name = textBoxName.Text;
            c.ContactNo = textBoxContactNo.Text;
            c.Address = textBoxAddress.Text;
            c.Gender = comboGender.Text;

            //Insert Into Database

            bool success = c.Insert(c);
            if (success)
            {
                MessageBox.Show("Entry Added Successfully");
            }
            else
            {
                MessageBox.Show("Failed. Please try again.");
            }

            //Load Data to grif
            DataTable dt = c.Select();
            dataGridView.DataSource = dt;

        }

        private void EContacts_Load(object sender, EventArgs e)
        {
            //Load Data to grif
            DataTable dt = c.Select();
            dataGridView.DataSource = dt;

        }
    }
}
