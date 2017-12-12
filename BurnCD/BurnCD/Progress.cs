using System.Threading;
using System.Windows.Forms;
using IMAPI2;

namespace CDBurn
{
    public partial class Progress : Form
    {
        private readonly BurnController _burnController = BurnController.GetInstance();
        private readonly BurnAction _burnAction = new BurnAction();

        public Progress()
        {
            InitializeComponent();
            PrepareToBurn();
            Burn();
        }

        private void PrepareToBurn()
        {
            _burnAction.WriteActionChanged += BurnAction;
            _burnController.UpdateBurn += UpdateBurningInformation;
        }

        private void UpdateBurningInformation(FormatWriteUpdateEventArgs e)
        {
            burnProgressBar.Value = (e.LastWrittenLba - e.StartLba + 1) * 100 / e.SectorCount;
            _burnAction.WriteAction = e._currentAction;
        }

        private void Burn()
        {
            new Thread(_burnController.Burn).Start();
        }

        private void TrayIconMouseClick(object sender, MouseEventArgs e)
        {
            WindowState = FormWindowState.Normal;
            trayIcon.Visible = false;
            ShowInTaskbar = true;
        }

        private void BurnProgressWindowResize(object sender, System.EventArgs e)
        {
            if (FormWindowState.Minimized != WindowState) return;
            trayIcon.Visible = true;
            ShowInTaskbar = false;
        }

        private void BurnProgressWindowFormClosing(object sender, FormClosingEventArgs e)
        {
            if (_burnAction.WriteAction == FormatDataWriteAction.Completed)
            {
                e.Cancel = false;
            }
            else
            {
                WindowState = FormWindowState.Minimized;
                e.Cancel = true;
            }
        }

        private void BurnAction(FormatDataWriteAction action)
        {
            progressLabel.Text = action.ToReadableString();
            if (FormWindowState.Minimized == WindowState)
            {
                trayIcon.BalloonTipText = action.ToReadableString();
                trayIcon.ShowBalloonTip(1);
            }
            if (action == FormatDataWriteAction.Completed)
            {
                Close();
            }
        }
    }
}
