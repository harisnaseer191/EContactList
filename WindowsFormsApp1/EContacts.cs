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
                Clear();
            }
            else
            {
                MessageBox.Show("Failed. Please try again.");
            }

            //Load Data to grif
            Load_Datagrid();

        }

        private void Load_Datagrid()
        {
            DataTable dt = c.Select();
            dataGridView.DataSource = dt;
        }

        private void EContacts_Load(object sender, EventArgs e)
        {
            //Load Data to grid
            Load_Datagrid();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Clear()
        {
            textBoxContactID.Text = "";
            textBoxName.Text = "";
            textBoxContactNo.Text = "";
            textBoxAddress.Text = "";
            comboGender.Text = "";
        }

        private void dataGridView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowindex = e.RowIndex;
            textBoxContactID.Text = dataGridView.Rows[rowindex].Cells[0].Value.ToString();
            textBoxName.Text = dataGridView.Rows[rowindex].Cells[1].Value.ToString();
            textBoxContactNo.Text = dataGridView.Rows[rowindex].Cells[2].Value.ToString();
            textBoxAddress.Text = dataGridView.Rows[rowindex].Cells[3].Value.ToString();
            comboGender.Text = dataGridView.Rows[rowindex].Cells[4].Value.ToString();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            c.ContactID = int.Parse(textBoxContactID.Text);
            c.Name = textBoxName.Text;
            c.ContactNo = textBoxContactNo.Text;
            c.Address = textBoxAddress.Text;
            c.Gender = comboGender.Text;

            //Update Entry

            bool success = c.Update(c);
            if (success)
            {
                MessageBox.Show("Updated Successfully");
                Clear();
            }
            else
            {
                MessageBox.Show("Failed. Please try again.");
            }

            //Load Data to grif
            Load_Datagrid();

        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            c.ContactID = int.Parse(textBoxContactID.Text);
          
            //Delete Entry

            bool success = c.Delete(c);
            if (success)
            {
                MessageBox.Show("Deleted Successfully");
                Clear();
            }
            else
            {
                MessageBox.Show("Failed. Please try again.");
            }

            //Load Data to grif
            Load_Datagrid();

        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            string Keyword = textBoxSearch.Text;

            DataTable dt = c.Search(Keyword);
            dataGridView.DataSource = dt;
        }
    }
}
