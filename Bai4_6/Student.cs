using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Bai4_6
{
    public class Student : INotifyPropertyChanged
    {
        private string studentId = "";
        private string fullName = "";
        private int age;
        private string gender = "Nam";
        private string avatarPath = "";

        public string StudentId
        {
            get { return studentId; }
            set
            {
                studentId = value;
                OnPropertyChanged();
            }
        }

        public string FullName
        {
            get { return fullName; }
            set
            {
                fullName = value;
                OnPropertyChanged();
            }
        }

        public int Age
        {
            get { return age; }
            set
            {
                age = value;
                OnPropertyChanged();
            }
        }

        public string Gender
        {
            get { return gender; }
            set
            {
                gender = value;
                OnPropertyChanged();
            }
        }

        public string AvatarPath
        {
            get { return avatarPath; }
            set
            {
                avatarPath = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(
            [CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(propertyName));
        }
    }
}