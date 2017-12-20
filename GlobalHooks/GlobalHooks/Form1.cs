using System.Windows.Forms;

namespace GlobalHooks
{
    public partial class Form1 : Form
    {
        private readonly EventController _eventManager;
        private Settings _settings;
        private SettingsController _settingsController;
        public Form1()
        {
            InitializeComponent();
            InitSettings();
            _eventManager = new EventController(_settings, ShowWindow);
        }
        private void InitSettings()
        {
            _settingsController = new SettingsController();
            _settings = _settingsController.UpdateProgram();
            logCheckBox.Checked = _settings.IsLog;
            hideCheckBox.Checked = _settings.HideCheck;
            prtCheckBox.Checked = _settings.IsHotKey;
            emailTextBox.Text = _settings.Email;
            pathLabel.Text = _settings.PathForSave;
            numericUpDown.Value = _settings.FileSize == 0 ? 1000 : _settings.FileSize;    
        }

        private void ShowWindow()
        {
            Show();
        }

        private void Form1_Shown(object sender, System.EventArgs e)
        {
            if (_settings.HideCheck)
            {
                Hide();
            }
        }

        private void confirmBtn_Click(object sender, System.EventArgs e)
        {
            
            _settings.Email = emailTextBox.Text;
            _settings.PathForSave = pathLabel.Text;
            _settings.IsLog = logCheckBox.Checked;
            _settings.FileSize = (long)numericUpDown.Value;
            _settings.HideCheck = hideCheckBox.Checked;
            _settings.IsHotKey = prtCheckBox.Checked;
            if (hideCheckBox.Checked) Hide();
            _settingsController.SaveConfig(_settings);
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            var result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                pathLabel.Text = dialog.SelectedPath;
            }
        }
    }
}
