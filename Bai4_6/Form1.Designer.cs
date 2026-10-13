
namespace Bai4_6
{
    partial class Form1
    {
        private System.ComponentModel.IContainer? components = null;

        private System.Windows.Forms.BindingSource bindingSource;
        private System.Windows.Forms.DataGridView dgvStudents;
        private System.Windows.Forms.TextBox txtStudentId;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.TextBox txtAge;
        private System.Windows.Forms.ComboBox cboGender;
        private System.Windows.Forms.PictureBox picAvatar;
        private System.Windows.Forms.Button btnChooseImage;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label lblStudentId;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Label lblAvatar;
        private System.Windows.Forms.Label lblTitle;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            bindingSource = new System.Windows.Forms.BindingSource(components);
            dgvStudents = new System.Windows.Forms.DataGridView();
            txtStudentId = new System.Windows.Forms.TextBox();
            txtFullName = new System.Windows.Forms.TextBox();
            txtAge = new System.Windows.Forms.TextBox();
            cboGender = new System.Windows.Forms.ComboBox();
            picAvatar = new System.Windows.Forms.PictureBox();
            btnChooseImage = new System.Windows.Forms.Button();
            btnAdd = new System.Windows.Forms.Button();
            btnDelete = new System.Windows.Forms.Button();
            btnUpdate = new System.Windows.Forms.Button();
            btnExport = new System.Windows.Forms.Button();
            lblStudentId = new System.Windows.Forms.Label();
            lblFullName = new System.Windows.Forms.Label();
            lblAge = new System.Windows.Forms.Label();
            lblGender = new System.Windows.Forms.Label();
            lblAvatar = new System.Windows.Forms.Label();
            lblTitle = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)bindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvStudents).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picAvatar).BeginInit();
            SuspendLayout();

            // Form
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1100, 650);
            MinimumSize = new System.Drawing.Size(900, 550);
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Quản lý sinh viên";
            Font = new System.Drawing.Font("Segoe UI", 10F);

            // Title
            lblTitle.AutoSize = false;
            lblTitle.Text = "QUẢN LÝ SINH VIÊN";
            lblTitle.Font = new System.Drawing.Font(
                "Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblTitle.SetBounds(10, 10, 1080, 45);
            lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Top
                | System.Windows.Forms.AnchorStyles.Left
                | System.Windows.Forms.AnchorStyles.Right;

            // Labels
            lblStudentId.Text = "Mã sinh viên:";
            lblStudentId.SetBounds(20, 80, 130, 25);

            lblFullName.Text = "Họ và tên:";
            lblFullName.SetBounds(20, 125, 130, 25);

            lblAge.Text = "Tuổi:";
            lblAge.SetBounds(20, 170, 130, 25);

            lblGender.Text = "Giới tính:";
            lblGender.SetBounds(20, 215, 130, 25);

            lblAvatar.Text = "Ảnh đại diện:";
            lblAvatar.SetBounds(20, 260, 130, 25);

            // TextBox and ComboBox
            txtStudentId.SetBounds(150, 78, 210, 30);
            txtFullName.SetBounds(150, 123, 210, 30);
            txtAge.SetBounds(150, 168, 210, 30);

            cboGender.DropDownStyle =
                System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboGender.Items.AddRange(new object[] { "Nam", "Nữ" });
            cboGender.SetBounds(150, 213, 210, 30);

            // PictureBox
            picAvatar.BorderStyle =
                System.Windows.Forms.BorderStyle.FixedSingle;
            picAvatar.SizeMode =
                System.Windows.Forms.PictureBoxSizeMode.Zoom;
            picAvatar.BackColor = System.Drawing.Color.WhiteSmoke;
            picAvatar.SetBounds(150, 258, 210, 170);

            // Choose image button
            btnChooseImage.Text = "Chọn ảnh...";
            btnChooseImage.SetBounds(150, 438, 210, 35);
            btnChooseImage.Click += BtnChooseImage_Click;

            // CRUD buttons
            btnAdd.Text = "Thêm";
            btnAdd.SetBounds(20, 495, 105, 38);
            btnAdd.Click += BtnAdd_Click;

            btnUpdate.Text = "Cập nhật";
            btnUpdate.SetBounds(135, 495, 105, 38);
            btnUpdate.Click += BtnUpdate_Click;

            btnDelete.Text = "Xóa";
            btnDelete.SetBounds(250, 495, 105, 38);
            btnDelete.Click += BtnDelete_Click;

            btnExport.Text = "Xuất CSV";
            btnExport.SetBounds(20, 540, 335, 38);
            btnExport.Click += BtnExport_Click;

            // DataGridView
            dgvStudents.AllowUserToAddRows = false;
            dgvStudents.AllowUserToDeleteRows = false;
            dgvStudents.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvStudents.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvStudents.MultiSelect = false;
            dgvStudents.ReadOnly = true;
            dgvStudents.RowHeadersVisible = false;
            dgvStudents.BackgroundColor = System.Drawing.Color.White;
            dgvStudents.SetBounds(390, 70, 690, 510);
            dgvStudents.Anchor =
                System.Windows.Forms.AnchorStyles.Top
                | System.Windows.Forms.AnchorStyles.Bottom
                | System.Windows.Forms.AnchorStyles.Left
                | System.Windows.Forms.AnchorStyles.Right;
            dgvStudents.DataError += DgvStudents_DataError;

            // Add controls to Form
            Controls.Add(lblTitle);
            Controls.Add(lblStudentId);
            Controls.Add(lblFullName);
            Controls.Add(lblAge);
            Controls.Add(lblGender);
            Controls.Add(lblAvatar);
            Controls.Add(txtStudentId);
            Controls.Add(txtFullName);
            Controls.Add(txtAge);
            Controls.Add(cboGender);
            Controls.Add(picAvatar);
            Controls.Add(btnChooseImage);
            Controls.Add(btnAdd);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
            Controls.Add(btnExport);
            Controls.Add(dgvStudents);

            ((System.ComponentModel.ISupportInitialize)bindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvStudents).EndInit();
            ((System.ComponentModel.ISupportInitialize)picAvatar).EndInit();
            ResumeLayout(false);
        }
    }
}
