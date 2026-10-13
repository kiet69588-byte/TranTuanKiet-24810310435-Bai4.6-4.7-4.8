
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Bai4_8
{
    public class Student
    {
        public string MaSV { get; set; } = "";
        public string HoTen { get; set; } = "";
        public int Tuoi { get; set; }
    }

    public class FormStudent : Form
    {
        private DataGridView dgvStudents;
        private Button btnLoad;
        private ProgressBar progressBar;
        private Label lblPercent;
        private Label lblTitle;

        public FormStudent()
        {
            Text = "Quản lý sinh viên";
            Width = 800;
            Height = 500;

            TaoGiaoDien();
        }

        private void TaoGiaoDien()
        {
            lblTitle = new Label();
            lblTitle.Text = "DANH SÁCH SINH VIÊN";
            lblTitle.Font = new Font(
                "Segoe UI", 16, FontStyle.Bold);
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Height = 50;
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            Panel pnlBottom = new Panel();
            pnlBottom.Dock = DockStyle.Bottom;
            pnlBottom.Height = 90;

            btnLoad = new Button();
            btnLoad.Text = "Nạp dữ liệu";
            btnLoad.Width = 120;
            btnLoad.Height = 32;
            btnLoad.Location = new Point(15, 10);
            btnLoad.Click += async (s, e) => await NapDuLieu();

            progressBar = new ProgressBar();
            progressBar.Minimum = 0;
            progressBar.Maximum = 100;
            progressBar.Value = 0;
            progressBar.Location = new Point(150, 15);
            progressBar.Size = new Size(450, 22);

            lblPercent = new Label();
            lblPercent.Text = "0%";
            lblPercent.Location = new Point(615, 15);
            lblPercent.AutoSize = true;

            pnlBottom.Controls.Add(btnLoad);
            pnlBottom.Controls.Add(progressBar);
            pnlBottom.Controls.Add(lblPercent);

            dgvStudents = new DataGridView();
            dgvStudents.Dock = DockStyle.Fill;
            dgvStudents.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
            dgvStudents.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvStudents.ReadOnly = true;
            dgvStudents.AllowUserToAddRows = false;
            dgvStudents.RowHeadersVisible = false;

            Controls.Add(dgvStudents);
            Controls.Add(pnlBottom);
            Controls.Add(lblTitle);
        }

        private async Task<List<Student>> TaiDanhSachSinhVien(
            IProgress<int> progress)
        {
            return await Task.Run(async () =>
            {
                List<Student> list = new List<Student>();

                int total = 100;

                for (int i = 1; i <= total; i++)
                {
                    await Task.Delay(50);

                    list.Add(new Student
                    {
                        MaSV = "SV" + i.ToString("D3"),
                        HoTen = "Sinh viên " + i,
                        Tuoi = 18 + i % 8
                    });

                    int percent = i * 100 / total;
                    progress.Report(percent);
                }

                return list;
            });
        }

        private async Task NapDuLieu()
        {
            btnLoad.Enabled = false;
            progressBar.Value = 0;
            lblPercent.Text = "0%";

            CapNhatCha("Đang nạp dữ liệu sinh viên...");

            try
            {
                IProgress<int> progress = new Progress<int>(percent =>
                {
                    progressBar.Value = percent;
                    lblPercent.Text = percent + "%";

                    CapNhatCha(
                        "Đang nạp dữ liệu sinh viên: "
                        + percent + "%");
                });

                List<Student> students =
                    await TaiDanhSachSinhVien(progress);

                dgvStudents.DataSource = null;
                dgvStudents.DataSource = students;

                CapNhatCha("Nạp thành công "
                    + students.Count + " sinh viên.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi khi nạp dữ liệu: " + ex.Message,
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                CapNhatCha("Nạp dữ liệu thất bại.");
            }
            finally
            {
                btnLoad.Enabled = true;
            }
        }

        private void CapNhatCha(string message)
        {
            if (MdiParent is FormMain main)
            {
                main.CapNhatTrangThai(message);
            }
        }
    }
}
