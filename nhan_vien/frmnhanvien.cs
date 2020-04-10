using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace nhan_vien
{
    public partial class frmnhanvien : Form
    {
        public frmnhanvien()
        {
            InitializeComponent();
        }
        public void ketnoi()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6TI18BN\SQLEXPRESS;Initial Catalog=quanlythuesach;Integrated Security=True");
            con.Open();
            string sql = "select * from nhanvien";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adp.Fill(table);
            dataGridView1.DataSource = table;

        }
        private void frmnhanvien_Load(object sender, EventArgs e)
        {
            ketnoi();
        }
        int index;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            {

                index = dataGridView1.CurrentRow.Index;
                txtmanhanvien.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
                txttennhanvien.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
                txtmaca.Text = dataGridView1.Rows[index].Cells[2].Value.ToString();
                txtnamsinh.Text = dataGridView1.Rows[index].Cells[3].Value.ToString();
                txtgioitinh.Text = dataGridView1.Rows[index].Cells[4].Value.ToString();
                txtdiachi.Text = dataGridView1.Rows[index].Cells[5].Value.ToString();
                txtsodienthoai.Text = dataGridView1.Rows[index].Cells[6].Value.ToString();
                txtluongthang.Text = dataGridView1.Rows[index].Cells[7].Value.ToString();
            }

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            txtmanhanvien.ReadOnly = false;
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6TI18BN\SQLEXPRESS;Initial Catalog=quanlythuesach;Integrated Security=True");
                con.Open();
                string sql = "insert into nhanvien values('" + txtmanhanvien.Text + "','" + txttennhanvien.Text + "','" + txtmaca.Text + "','" + txtnamsinh.Text + "','" + txtgioitinh.Text + "','" + txtdiachi.Text + "','" + txtsodienthoai.Text + "','" + txtluongthang.Text + "')";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                ketnoi();
                MessageBox.Show("bạn lưu thành công");
            }
            catch
            {
                MessageBox.Show("bạn chưa điền đủ thông tin hoặc trùng mã");
                txtmanhanvien.Clear();
                txttennhanvien.Clear();
                txtsodienthoai.Clear();
                txtmaca.Clear();
                txtluongthang.Clear();
                txtgioitinh.Clear();
                txtnamsinh.Clear();
                txtdiachi.Clear();
            }
            finally
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6TI18BN\SQLEXPRESS;Initial Catalog=quanlykhachsan;Integrated Security=True");
                con.Close();
            }
            btnXoa.Enabled = true;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            txtmanhanvien.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnHuy.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            txtmanhanvien.Text = "";
            txttennhanvien.Text = "";
            txtnamsinh.Text = "";
            txtmaca.Text = "";
            txtdiachi.Text = "";
            txtsodienthoai.Text = "";
            txtluongthang.Text = "";
            txtgioitinh.Text = "";
            txtmanhanvien.Enabled = true;
            txtmanhanvien.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtmanhanvien.ReadOnly = true;
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6TI18BN\SQLEXPRESS;Initial Catalog=quanlythuesach;Integrated Security=True");
            con.Open();
            string sql = "update nhanvien set tennhanvien='" + txttennhanvien.Text + "',maca='" + txtmaca.Text + "',namsinh='" + txtnamsinh.Text + "',gioitinh='" + txtgioitinh.Text + "',diachi='" + txtdiachi.Text + "',sodienthoai='" + txtsodienthoai.Text + "',luongthang='" + txtluongthang.Text + "' where manhanvien='" + txtmanhanvien.Text + "'";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            ketnoi();
            btnHuy.Enabled = false;
            MessageBox.Show("bạn sửa thành công");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtmanhanvien.TextLength == 0)
            {
                MessageBox.Show("bạn chưa chọn dòng xóa");
            }
            txtmanhanvien.ReadOnly = false;
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-6TI18BN\SQLEXPRESS;Initial Catalog=quanlythuesach;Integrated Security=True");
            con.Open();
            MessageBox.Show("không xóa được vì mã nhân viên đã tồn tại ở các bảng khác");
            ketnoi();
            txtmanhanvien.Clear();
            txttennhanvien.Clear();
            txtnamsinh.Clear();
            txtgioitinh.Clear();
            txtdiachi.Clear();
            txtluongthang.Clear();
            txtmaca.Clear();
            txtsodienthoai.Clear();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtmanhanvien.Text = "";
            txttennhanvien.Text = "";
            txtnamsinh.Text = "";
            txtgioitinh.Text = "";
            txtdiachi.Text = "";
            txtluongthang.Text = "";
            txtmaca.Text = "";
            txtsodienthoai.Text = "";
            btnHuy.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
            txtmanhanvien.Enabled = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
