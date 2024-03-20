
using Newtonsoft.Json;
using System.ComponentModel;
using System.Text.Json.Serialization;
using System.Text;

namespace INeedAnApp;

public partial class ProfilePage : INotifyPropertyChanged
{
    private string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "LocalStorageText.txt");

    private Profile _details;
    public Profile Details
    {
        get => _details;
        set
        {
            _details = value;
            OnPropertyChanged();
        }
    }
    public ProfilePage()
    {
        InitializeComponent();
        BindingContext = this;
    }

    #region eventhandlers
    private void SaveBtn_Clicked(object sender, EventArgs e)
    {
        SaveData(Details);
    }

    public void SaveData(Profile profile)
    {
        string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "LocalStorageText.txt");
        string json = JsonConvert.SerializeObject(profile);
        File.WriteAllText(filePath, json);
        // TextBox.Text = File.ReadAllText(filePath);

    }
    #endregion




    public void LoadBtn_Clicked(object sender, EventArgs e)
    {
        Details = loadData();
    }

    public static Profile loadData()
    {
        string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "LocalStorageText.txt");

        if (File.Exists(filePath))
        {
            string currentprofile = File.ReadAllText(filePath);
            Profile newdetails = JsonConvert.DeserializeObject<Profile>(currentprofile);
            return newdetails;
        }
        else
        {
            return new Profile();
        }


    }




    public partial class Profile : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
            }
        }
        private string _surname;
        public string Surname
        {
            get => _surname;
            set
            {
                _surname = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Surname)));
            }
        }

        private string _emailaddress;
        public string EmailAddress
        {
            get => _emailaddress;
            set
            {
                _emailaddress = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Email)));
            }
        }

        private string _password;

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Password)));
            }
        }
    }
}