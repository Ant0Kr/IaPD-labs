using System;
using System.Linq;
using System.Windows.Forms;
using IMAPI2;

namespace CDBurn
{
    public partial class Form1 : Form
    {
        private readonly BurnController _burnController = BurnController.GetInstance();
        private readonly DiskSpace _dickSpace = new DiskSpace();
        private const string DiskNotFound = @"Disk not found.";

        private const int BytesInMegabyte = 1024 * 1024;

        public Form1()
        {
            InitializeComponent();
            InitializeHandlers();
            InitializeGui();
        }

        private void InitializeHandlers()
        {
            _dickSpace.UsedSpaceChanged += UsedSpaceValueChanged;
        }

        private void InitializeGui()
        {
            cdDriverComboBox.Items.Clear();
            cdDriverComboBox.Items.AddRange(_burnController.GetRecorders());
            filesListBox.Items.Clear();
            addFileButton.Enabled = false;
            discSizeLabel.Text = @"0 MB";
            _dickSpace.UsedSpace = 0;
        }

        private void AddFileButtonClick(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (_burnController.IsDiscAvailable())
                {
                    foreach (var filePath in openFileDialog.FileNames)
                    {
                        if (!filesListBox.Items.OfType<FileNode>().Any(x => x.Path.Equals(filePath)))
                        {
                            var file = new FileNode(filePath);
                            if (!((_dickSpace.UsedSpace + file.SizeOnDisc) > _dickSpace.TotalSpace))
                            {
                                filesListBox.Items.Add(file);
                                _dickSpace.UsedSpace += file.SizeOnDisc;
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show(DiskNotFound, @"Warning");
                    InitializeGui();
                }
            }
        }

        private void UsedSpaceValueChanged(long value)
        {
            burnButton.Enabled = _dickSpace.UsedSpace > 0;
            usedSpaceBar.Value = (int)(_dickSpace.UsedSpace / BytesInMegabyte);
            usedSpaceLabel.Text = $@"{_dickSpace.UsedSpace / BytesInMegabyte} MB";
        }

        private void CdDriverComboBoxFormat(object sender, ListControlConvertEventArgs e)
        {
            var recorder = (DiscRecorder)e.ListItem;
            e.Value = $"{recorder.VolumePath} {recorder.RecorderId}";
        }

        private void CheckDiskButtonClick(object sender, EventArgs e)
        {
            InitializeGuiByDiscInfo(_burnController.GetDiscInfo((DiscRecorder)cdDriverComboBox.SelectedItem));
        }

        private void InitializeGuiByDiscInfo(Disc disc)
        {           
            if (disc.DiscType == PhysicalMedia.Unknown)
            {
                MessageBox.Show(DiskNotFound, @"Warning");
            }
            else if (disc.DiscState != MediaState.Blank)
            {
                MessageBox.Show(@"Disk not empty.", @"Warning");
            }
            else
            {
                MessageBox.Show(@"Ok!", @"Warning");
                discSizeLabel.Text = $@"{disc.DiscSize / BytesInMegabyte} MB";
                addFileButton.Enabled = true;
                usedSpaceBar.Maximum = (int)(disc.DiscSize / BytesInMegabyte);
                _dickSpace.TotalSpace = disc.DiscSize;
            }
        }

        private void FilesListBoxFormat(object sender, ListControlConvertEventArgs e)
        {
            e.Value = ((FileNode)e.ListItem).Name;
        }

        private void FilesListBoxMouseClick(object sender, MouseEventArgs e)
        {
            removeFileButton.Enabled = filesListBox.SelectedIndex != -1;
        }

        private void RemoveFileButtonClick(object sender, EventArgs e)
        {
            if (filesListBox.SelectedIndex != -1)
            {
                var removedFile = (FileNode)filesListBox.Items[filesListBox.SelectedIndex];
                _dickSpace.UsedSpace -= removedFile.SizeOnDisc;
                filesListBox.Items.Remove(removedFile);
                removeFileButton.Enabled = false;
            }
        }

        private void BurnButtonClick(object sender, EventArgs e)
        {
            if (_burnController.IsDiscAvailable())
            {
                _burnController.PrepareFilesToBurn(filesListBox.Items.OfType<FileNode>().ToList());
                Hide();
                var progressWindow = new Progress();
                progressWindow.FormClosed += BurnProgressWindowFormClosed;
                progressWindow.Show();
            }
            else
            {
                MessageBox.Show(DiskNotFound, @"Warning");
                InitializeGui();
            }
        }

        private void BurnProgressWindowFormClosed(object sender, FormClosedEventArgs e)
        {
            InitializeGui();
            Show();
        }
    }
}
