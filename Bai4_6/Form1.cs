
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Bai4_6
{
    public partial class Form1 : Form
    {
        private BindingList<Student> students = new BindingList<Student>();

        public Form1()
        {
            InitializeComponent();
            SetupBinding();
            LoadSampleData();
        }

        private void SetupBinding()
        {
            bindingSource.DataSource = students;
            dgvStudents.DataSource = bindingSource;

            txtStudentId.DataBindings.Add(
                "Text", bindingSource, "StudentId",
                true, DataSourceUpdateMode.OnValidation);

            txtFullName.DataBindings.Add(
                "Text", bindingSource, "FullName",
                true, DataSourceUpdateMode.OnValidation);

            txtAge.DataBindings.Add(
                "Text", bindingSource, "Age",
                true, DataSourceUpdateMode.OnValidation);

            cboGender.DataBindings.Add(
                "SelectedItem", bindingSource, "Gender",
                true, DataSourceUpdateMode.OnPropertyChanged);

            bindingSource.PositionChanged += (s, e) => LoadAvatar();

            dgvStudents.DataBindingComplete += (s, e) =>
            {
                if (dgvStudents.Columns["StudentId"] != null)
                    dgvStudents.Columns["StudentId"].HeaderText = "Mã SV";

                if (dgvStudents.Columns["FullName"] != null)
                    dgvStudents.Columns["FullName"].HeaderText = "Họ tên";

                if (dgvStudents.Columns["Age"] != null)
                    dgvStudents.Columns["Age"].HeaderText = "Tuổi";

                if (dgvStudents.Columns["Gender"] != null)
                    dgvStudents.Columns["Gender"].HeaderText = "Giới tính";

                if (dgvStudents.Columns["AvatarPath"] != null)
                    dgvStudents.Columns["AvatarPath"].Visible = false;
            };
        }

        private void LoadSampleData()
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

            bindingSource.Position = 0;
            LoadAvatar();
        }

        private void LoadAvatar()
        {
            if (picAvatar.Image != null)
            {
                picAvatar.Image.Dispose();
                picAvatar.Image = null;
            }

            if (bindingSource.Current is not Student student)
                return;

            if (string.IsNullOrWhiteSpace(student.AvatarPath))
                return;

            if (!File.Exists(student.AvatarPath))
                return;

            try
            {
                using (Image image = Image.FromFile(student.AvatarPath))
                {
                    picAvatar.Image = new Bitmap(image);
                }
            }
            catch
            {
                picAvatar.Image = null;
            }
        }

        private void BtnChooseImage_Click(object? sender, EventArgs e)
        {
            if (bindingSource.Current is not Student student)
            {
                MessageBox.Show("Vui lòng chọn sinh viên trước.");
                return;
            }

            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "Chọn ảnh đại diện";
                dialog.Filter =
                    "File ảnh (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    student.AvatarPath = dialog.FileName;
                    LoadAvatar();
                    bindingSource.ResetCurrentItem();
                }
            }
        }

        private void BtnAdd_Click(object? sender, EventArgs e)
        {
            Validate();
            bindingSource.EndEdit();

            Student student = new Student
            {
                StudentId = "",
                FullName = "",
                Age = 0,
                Gender = "Nam",
                AvatarPath = ""
            };

            students.Add(student);
            bindingSource.Position = students.Count - 1;
            txtStudentId.Focus();
            LoadAvatar();
        }

        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            if (bindingSource.Current is not Student student)
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần xóa.");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa sinh viên này?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                students.Remove(student);
                LoadAvatar();
            }
        }

        private void BtnUpdate_Click(object? sender, EventArgs e)
        {
            Validate();
            bindingSource.EndEdit();

            if (bindingSource.Current is not Student student)
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần cập nhật.");
                return;
            }

            string id = student.StudentId.Trim();
            string name = student.FullName.Trim();

            if (id == "" || name == "")
            {
                MessageBox.Show("Mã sinh viên và họ tên không được để trống.");
                return;
            }

            if (student.Age < 1 || student.Age > 150)
            {
                MessageBox.Show("Tuổi phải nằm trong khoảng từ 1 đến 150.");
                return;
            }

            foreach (Student item in students)
            {
                if (item != student &&
                    item.StudentId.Trim().Equals(
                        id, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Mã sinh viên đã tồn tại.");
                    return;
                }
            }

            student.StudentId = id;
            student.FullName = name;

            bindingSource.ResetCurrentItem();
            dgvStudents.Refresh();

            MessageBox.Show("Cập nhật sinh viên thành công.");
        }

        private void BtnExport_Click(object? sender, EventArgs e)
        {
            Validate();
            bindingSource.EndEdit();

            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Title = "Xuất danh sách sinh viên";
                dialog.Filter = "CSV file (*.csv)|*.csv";
                dialog.FileName = "DanhSachSinhVien.csv";

                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    using (StreamWriter writer = new StreamWriter(
                        dialog.FileName, false, new UTF8Encoding(true)))
                    {
                        writer.WriteLine(
                            "StudentId,FullName,Age,Gender,AvatarPath");

                        foreach (Student student in students)
                        {
                            writer.WriteLine(
                                CsvField(student.StudentId) + "," +
                                CsvField(student.FullName) + "," +
                                student.Age + "," +
                                CsvField(student.Gender) + "," +
                                CsvField(student.AvatarPath));
                        }
                    }

                    MessageBox.Show("Xuất file CSV thành công.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể xuất file: " + ex.Message);
                }
            }
        }

        private string CsvField(string? value)
        {
            return "\"" + (value ?? "").Replace("\"", "\"\"") + "\"";
        }

        private void DgvStudents_DataError(
            object? sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            if (picAvatar.Image != null)
            {
                picAvatar.Image.Dispose();
                picAvatar.Image = null;
            }

            base.OnFormClosed(e);
        }
    }
}
