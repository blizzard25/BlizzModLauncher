using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace BlizzModLauncher
{
    public partial class Form1 : Form
    {
        private const string WatcherExePath = @"C:\MCOCMods\watcher\watcher.exe";
        private const string InjectionDllPath = @"C:\MCOCMods\modloader\BlizzMod.dll";

        private Process watcherProcess;

        public Form1()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            UpdateStatus();
        }

        private void checkBoxLaunchWatcher_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxLaunchWatcher.Checked)
            {
                LaunchWatcher();
            }
            else
            {
                StopWatcher();
            }

            UpdateStatus();
        }

        private void LaunchWatcher()
        {
            try
            {
                if (!File.Exists(WatcherExePath))
                {
                    MessageBox.Show("watcher.exe not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    checkBoxLaunchWatcher.Checked = false;
                    return;
                }

                if (!File.Exists(InjectionDllPath))
                {
                    MessageBox.Show("Injection DLL not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    checkBoxLaunchWatcher.Checked = false;
                    return;
                }

                if (watcherProcess == null || watcherProcess.HasExited)
                {
                    watcherProcess = new Process
                    {
                        StartInfo = new ProcessStartInfo
                        {
                            FileName = WatcherExePath,
                            Arguments = $"\"{InjectionDllPath}\"",
                            UseShellExecute = false,
                            CreateNoWindow = true
                        }
                    };
                    watcherProcess.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to launch watcher:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StopWatcher()
        {
            try
            {
                if (watcherProcess != null && !watcherProcess.HasExited)
                {
                    watcherProcess.Kill();
                    watcherProcess.WaitForExit();
                    watcherProcess = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to stop watcher:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateStatus()
        {
            labelStatus.Text = (watcherProcess != null && !watcherProcess.HasExited)
                ? "Running"
                : "Not Running";
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopWatcher();
        }
    }
}
