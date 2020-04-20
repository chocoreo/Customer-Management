using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Customer_Management
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //PROSES REFRESH
        private void refreshData()
        {
            //DO REFRESH
            txtName.Text = "";
            txtLName.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
        }

        //PROSES TAMBAH
        private void addData(String name, String lname, String phone, String email, String address)
        {
            //int countRow = 0;
            //count = countRow+1.ToString();
            String[] row = { name, lname, phone, email, address };
                ListViewItem data = new ListViewItem(row);
                listView1.Items.Add(data);
        }
        
        //PROSES DELETE
        private void deleteData()
        {
            //Buat Message Box untuk Warning
            if(txtName.Text == "")
            {
                MessageBox.Show("Tidak ada data yang dipilih.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } else
            {
                if (DialogResult.OK == (MessageBox.Show("Anda yakin ingin menghapus data ini? Data yang sudah dihapus tidak dapat dikembalikan", "Alert", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)))
                {
                    listView1.Items.RemoveAt(listView1.SelectedIndices[0]);
                    refreshData();
                    btnSubmit.Enabled = true;
                }
            }
        }

        //PROSES UPDATE 
        private void updateData()
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("Belum ada data yang Anda pilih. Silahkan pilih data yang ingin di update terlebih dahulu dan Pastikan field First Name tidak kosong.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                listView1.SelectedItems[0].SubItems[0].Text = txtName.Text;
                listView1.SelectedItems[0].SubItems[1].Text = txtLName.Text;
                listView1.SelectedItems[0].SubItems[2].Text = txtPhone.Text;
                listView1.SelectedItems[0].SubItems[3].Text = txtEmail.Text;
                listView1.SelectedItems[0].SubItems[4].Text = txtAddress.Text;
                refreshData();
                btnSubmit.Enabled = true;
            }
        }
        
        //START
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == (MessageBox.Show("Anda yakin ingin menghapus semua data Customer? Data yang sudah dihapus tidak dapat dikembalikan", "DELETE ALL DATA", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)))
            {
                listView1.Items.Clear();
                refreshData();
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //Jika Nama Customer Kosong
            if (txtName.Text == "")
            {
                var notification = MessageBox.Show("Maaf, Nama Customer tidak boleh kosong! Harap masukkan nama customer", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else {
                btnSubmit.Enabled = true;
                addData(
                    txtName.Text,
                    txtLName.Text,
                    txtPhone.Text,
                    txtEmail.Text,
                    txtAddress.Text
                );
                refreshData();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            updateData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            deleteData();
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            txtName.Text = listView1.SelectedItems[0].SubItems[0].Text;
            txtLName.Text = listView1.SelectedItems[0].SubItems[1].Text;
            txtPhone.Text = listView1.SelectedItems[0].SubItems[2].Text;
            txtEmail.Text = listView1.SelectedItems[0].SubItems[3].Text;
            txtAddress.Text = listView1.SelectedItems[0].SubItems[4].Text;
            btnSubmit.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
