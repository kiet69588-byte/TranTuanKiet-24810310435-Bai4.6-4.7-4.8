
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Bai4_7
{
    public class FormMain : Form
    {
        private MenuStrip menuStrip;
        private ToolStrip toolStrip;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel lblUser;
        private ToolStripStatusLabel lblMessage;
        private ToolStripStatusLabel lblTime;
        private System.Windows.Forms.Timer timer;

        public FormMain()
        {
            Text = "Hệ thống quản lý";
            IsMdiContainer = true;
            WindowState = FormWindowState.Maximized;
            StartPosition = FormStartPosition.CenterScreen;

            TaoMenu();
            TaoToolStrip();
            TaoStatusStrip();
            TaoDongHo();
        }

        private void TaoMenu()
        {
            menuStrip = new MenuStrip();

            ToolStripMenuItem heThong =
                new ToolStripMenuItem("Hệ thống");

            ToolStripMenuItem dangXuat =
                new ToolStripMenuItem("Đăng xuất");

            ToolStripMenuItem thoat =
                new ToolStripMenuItem("Thoát");

            dangXuat.Click += (s, e) =>
            {
                DialogResult result = MessageBox.Show(
                    "Bạn có muốn đóng các cửa sổ chức năng không?",
                    "Đăng xuất",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    foreach (Form f in MdiChildren)
                        f.Close();

                    CapNhatTrangThai("Đã đóng các cửa sổ chức năng.");
                }
            };

            thoat.Click += (s, e) => Close();

            heThong.DropDownItems.Add(dangXuat);
            heThong.DropDownItems.Add(thoat);

            ToolStripMenuItem danhMuc =
                new ToolStripMenuItem("Danh mục");

            ToolStripMenuItem sinhVien =
                new ToolStripMenuItem("Quản lý sinh viên");

            ToolStripMenuItem sanPham =
                new ToolStripMenuItem("Quản lý sản phẩm");

            sinhVien.Click += (s, e) =>
                MoFormCon<FormStudent>();

            sanPham.Click += (s, e) =>
                MoFormCon<FormProduct>();

            danhMuc.DropDownItems.Add(sinhVien);
            danhMuc.DropDownItems.Add(sanPham);

            ToolStripMenuItem cuaSo =
                new ToolStripMenuItem("Cửa sổ");

            ToolStripMenuItem cascade =
                new ToolStripMenuItem("Cascade");

            ToolStripMenuItem horizontal =
                new ToolStripMenuItem("Tile Horizontal");

            ToolStripMenuItem vertical =
                new ToolStripMenuItem("Tile Vertical");

            cascade.Click += (s, e) =>
                LayoutMdi(MdiLayout.Cascade);

            horizontal.Click += (s, e) =>
                LayoutMdi(MdiLayout.TileHorizontal);

            vertical.Click += (s, e) =>
                LayoutMdi(MdiLayout.TileVertical);

            cuaSo.DropDownItems.Add(cascade);
            cuaSo.DropDownItems.Add(horizontal);
            cuaSo.DropDownItems.Add(vertical);

            menuStrip.Items.Add(heThong);
            menuStrip.Items.Add(danhMuc);
            menuStrip.Items.Add(cuaSo);

            MainMenuStrip = menuStrip;
            Controls.Add(menuStrip);
        }

        private void TaoToolStrip()
        {
            toolStrip = new ToolStrip();
            toolStrip.Dock = DockStyle.Top;

            ToolStripButton btnSinhVien =
                new ToolStripButton("Sinh viên");

            ToolStripButton btnSanPham =
                new ToolStripButton("Sản phẩm");

            btnSinhVien.Click += (s, e) =>
                MoFormCon<FormStudent>();

            btnSanPham.Click += (s, e) =>
                MoFormCon<FormProduct>();

            toolStrip.Items.Add(btnSinhVien);
            toolStrip.Items.Add(btnSanPham);

            Controls.Add(toolStrip);
        }

        private void TaoStatusStrip()
        {
            statusStrip = new StatusStrip();

            lblUser = new ToolStripStatusLabel("Người dùng: Admin");
            lblMessage = new ToolStripStatusLabel("Sẵn sàng");
            lblTime = new ToolStripStatusLabel();

            lblMessage.Spring = true;
            lblMessage.TextAlign = ContentAlignment.MiddleLeft;

            statusStrip.Items.Add(lblUser);
            statusStrip.Items.Add(lblMessage);
            statusStrip.Items.Add(lblTime);

            Controls.Add(statusStrip);
        }

        private void TaoDongHo()
        {
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;

            timer.Tick += (s, e) =>
            {
                lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
            };

            timer.Start();
        }

        public void CapNhatTrangThai(string thongBao)
        {
            lblMessage.Text = thongBao;
        }

        private void MoFormCon<T>() where T : Form, new()
        {
            foreach (Form form in MdiChildren)
            {
                if (form is T)
                {
                    form.Activate();
                    return;
                }
            }

            T formMoi = new T();
            formMoi.MdiParent = this;
            formMoi.Show();

            CapNhatTrangThai("Đã mở: " + formMoi.Text);
        }
    }
}
