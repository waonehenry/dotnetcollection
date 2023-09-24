using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private List<Mahasiswa> list = new List<Mahasiswa>();

        public Form1()
        {
            InitializeComponent();
            InisialisasiListView();
        }

        private void InisialisasiListView()
        {
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;

            listView1.Columns.Add("No.", 30, HorizontalAlignment.Center);
            listView1.Columns.Add("Nama.", 150, HorizontalAlignment.Center);
            listView1.Columns.Add("Nilai.", 50, HorizontalAlignment.Center);

        }

        private bool NumericOnly(KeyPressEventArgs e)
        {
            var strValid = "0123456789";

            if (!(e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                if (strValid.IndexOf(e.KeyChar) < 0)
                {
                    return true;
                }

                return false;
            }
            else

                return false;

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = NumericOnly(e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Mahasiswa mhs = new Mahasiswa();

            mhs.Nama = textBox1.Text;
            mhs.Nilai = int.Parse(textBox2.Text);

            list.Add(mhs);

            var msg = "Data berhasil disimpan";

            MessageBox.Show(msg, "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ResetForm();
            TampilkanData();
        }

        private void ResetForm()
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void TampilkanData()
        {
            listView1.Items.Clear();

            foreach (var mhs in list)
            {
                var noUrut = listView1.Items.Count + 1;
                var item = new ListViewItem(noUrut.ToString());
                item.SubItems.Add(mhs.Nama);
                item.SubItems.Add(mhs.Nilai.ToString());

                listView1.Items.Add(item);
            }
        }
    }
}
