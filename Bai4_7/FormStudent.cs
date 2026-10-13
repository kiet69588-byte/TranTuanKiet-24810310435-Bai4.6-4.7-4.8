
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Bai4_7
{
    public class Student
    {
        public string StudentId { get; set; } = "";
        public string FullName { get; set; } = "";
        public int Age { get; set; }
        public string Gender { get; set; } = "";
    }

    public class FormStudent : Form
    {
        private DataGridView dgvStudents;

        private BindingList<Student> students =
            new BindingList<Student>();

        public FormStudent()
        {
            Text = "Quản lý sinh viên";
            Width = 800;
            Height = 500;
            StartPosition = FormStartPosition.CenterScreen;

            TaoGiaoDien();
            NapDuLieuMau();
            TaoMenuChuotPhai();
        }

        private void TaoGiaoDien()
        {
            Label lblTitle = new Label();

            lblTitle.Text = "DANH SÁCH SINH VIÊN";
            lblTitle.Font = new System.Drawing.Font(
                "Segoe UI", 16, System.Drawing.FontStyle.Bold);
            lblTitle.TextAlign =
                System.Drawing.ContentAlignment.MiddleCenter;
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Height = 50;

            dgvStudents = new DataGridView();
            dgvStudents.Dock = DockStyle.Fill;
            dgvStudents.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;
            dgvStudents.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvStudents.MultiSelect = false;
            dgvStudents.ReadOnly = true;
            dgvStudents.AllowUserToAddRows = false;
            dgvStudents.RowHeadersVisible = false;
            dgvStudents.DataSource = students;

            Controls.Add(dgvStudents);
            Controls.Add(lblTitle);
        }

        private void NapDuLieuMau()
        {
            students.Add(new Student
            {
                StudentId = "SV001",
                FullName = "Nguyễn Văn An",
                Age = 20,
                Gender = "Nam"
            });

            students.Add(new Student
            {
                StudentId = "SV002",
                FullName = "Trần Thị Bình",
                Age = 21,
                Gender = "Nữ"
            });

            students.Add(new Student
            {
                StudentId = "SV003",
                FullName = "Lê Văn Cường",
                Age = 19,
                Gender = "Nam"
            });
        }

        private void TaoMenuChuotPhai()
        {
            ContextMenuStrip menu = new ContextMenuStrip();

            ToolStripMenuItem xoa =
                new ToolStripMenuItem("Xóa dòng");

            ToolStripMenuItem lamMoi =
                new ToolStripMenuItem("Làm mới dữ liệu");

            ToolStripMenuItem chiTiet =
                new ToolStripMenuItem("Xem chi tiết");

            xoa.Click += (s, e) => XoaSinhVien();

            lamMoi.Click += (s, e) =>
            {
                dgvStudents.Refresh();
                CapNhatCha("Đã làm mới danh sách sinh viên.");
            };

            chiTiet.Click += (s, e) => XemChiTiet();

            menu.Items.Add(xoa);
            menu.Items.Add(lamMoi);
            menu.Items.Add(chiTiet);

            dgvStudents.ContextMenuStrip = menu;

            dgvStudents.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Right)
                {
                    var hit = dgvStudents.HitTest(e.X, e.Y);

                    if (hit.RowIndex >= 0)
                    {
                        dgvStudents.ClearSelection();

                        dgvStudents.Rows[hit.RowIndex].Selected = true;

                        dgvStudents.CurrentCell =
                            dgvStudents.Rows[hit.RowIndex].Cells[0];
                    }
                }
            };
        }

        private void XoaSinhVien()
        {
            if (dgvStudents.CurrentRow?.DataBoundItem
                is not Student student)
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần xóa.");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn xóa " + student.FullName + "?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                students.Remove(student);

                CapNhatCha(
                    "Đã xóa sinh viên " + student.StudentId + ".");
            }
        }

        private void XemChiTiet()
        {
            if (dgvStudents.CurrentRow?.DataBoundItem
                is not Student student)
            {
                MessageBox.Show("Vui lòng chọn sinh viên.");
                return;
            }

            MessageBox.Show(
                "Mã sinh viên: " + student.StudentId
                + "\nHọ tên: " + student.FullName
                + "\nTuổi: " + student.Age
                + "\nGiới tính: " + student.Gender,
                "Chi tiết sinh viên");
        }

        private void CapNhatCha(string thongBao)
        {
            if (MdiParent is FormMain main)
            {
                main.CapNhatTrangThai(thongBao);
            }
        }
    }
}
