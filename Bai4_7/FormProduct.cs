
using System.Windows.Forms;

namespace Bai4_7
{
    public class FormProduct : Form
    {
        private DataGridView dgvProducts;

        public FormProduct()
        {
            Text = "Quản lý sản phẩm";
            Width = 750;
            Height = 450;

            dgvProducts = new DataGridView();
            dgvProducts.Dock = DockStyle.Fill;
            dgvProducts.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
            dgvProducts.AllowUserToAddRows = false;
            dgvProducts.ReadOnly = true;

            dgvProducts.Columns.Add("ProductId", "Mã sản phẩm");
            dgvProducts.Columns.Add("ProductName", "Tên sản phẩm");
            dgvProducts.Columns.Add("Price", "Đơn giá");

            dgvProducts.Rows.Add("SP001", "Laptop", "15000000");
            dgvProducts.Rows.Add("SP002", "Chuột máy tính", "200000");
            dgvProducts.Rows.Add("SP003", "Bàn phím", "500000");

            Controls.Add(dgvProducts);
        }
    }
}
