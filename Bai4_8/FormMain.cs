
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Bai4_8
{
    public class FormMain : Form
    {
        private MenuStrip menuStrip;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel lblMessage;
        private ToolStripStatusLabel lblTime;
        private System.Windows.Forms.Timer timer;

        public FormMain()
        {
            Text = "Bài 4.8 - Async/Await";
            IsMdiContainer = true;
            WindowState = FormWindowState.Maximized;

            TaoMenu();
            TaoTrangThai();
            TaoDongHo();
        }

        private void TaoMenu()
        {
            menuStrip = new MenuStrip();

            ToolStripMenuItem danhMuc =
                new ToolStripMenuItem("Danh mục");

            ToolStripMenuItem sinhVien =
                new ToolStripMenuItem("Quản lý sinh viên");

            sinhVien.Click += (s, e) => MoFormSinhVien();

            danhMuc.DropDownItems.Add(sinhVien);

            ToolStripMenuItem cuaSo =
                new ToolStripMenuItem("Cửa sổ");

            ToolStripMenuItem cascade =
                new ToolStripMenuItem("Cascade");

            ToolStripMenuItem ngang =
                new ToolStripMenuItem("Tile Horizontal");

            ToolStripMenuItem doc =
                new ToolStripMenuItem("Tile Vertical");

            cascade.Click += (s, e) =>
                LayoutMdi(MdiLayout.Cascade);

            ngang.Click += (s, e) =>
                LayoutMdi(MdiLayout.TileHorizontal);

            doc.Click += (s, e) =>
                LayoutMdi(MdiLayout.TileVertical);

            cuaSo.DropDownItems.Add(cascade);
            cuaSo.DropDownItems.Add(ngang);
            cuaSo.DropDownItems.Add(doc);

            menuStrip.Items.Add(danhMuc);
            menuStrip.Items.Add(cuaSo);

            MainMenuStrip = menuStrip;
            Controls.Add(menuStrip);
        }

        private void TaoTrangThai()
        {
            statusStrip = new StatusStrip();

            lblMessage =
                new ToolStripStatusLabel("Sẵn sàng");

            lblMessage.Spring = true;
            lblMessage.TextAlign = ContentAlignment.MiddleLeft;

            lblTime = new ToolStripStatusLabel();

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

        private void MoFormSinhVien()
        {
            foreach (Form f in MdiChildren)
            {
                if (f is FormStudent)
                {
                    f.Activate();
                    return;
                }
            }

            FormStudent form = new FormStudent();
            form.MdiParent = this;
            form.Show();
        }

        public void CapNhatTrangThai(string message)
        {
            lblMessage.Text = message;
        }
    }
}
