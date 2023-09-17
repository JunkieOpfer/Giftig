using Ionic.Zip;
using Microsoft.Win32;
using SharpCompress.Archives.Zip;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Giftig
{
    public partial class Giftig : Form
    {
        private const string VersionUrl = "https://junkieopfer.github.io/Giftig/Updates/version.txt";
        private const string UpdateUrl = "https://junkieopfer.github.io/Giftig/Updates/Giftig1.1.zip";
        public Giftig()
        {
            InitializeComponent();
            CheckAndApplyUpdate();

            disable_btn.Click += disable_btn_Click;
            enable_btn.Click += enable_btn_Click;
            refresh_btn.Click += refresh_btn_Click;
            addtostartup_btn.Click += addtostartup_btn_Click;

            LoadStartupPrograms();
        }

        public void CheckAndApplyUpdate()
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    string latestVersionString = client.DownloadString(VersionUrl);
                    Version latestVersion = new Version(latestVersionString);
                    Version currentVersion = new Version(Application.ProductVersion);

                    if (latestVersion > currentVersion)
                    {
                        if (MessageBox.Show("An update is available. Do you want to update?", "Update Available", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            DownloadAndApplyUpdate();
                        }
                        else
                        {
                            Environment.Exit(0);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No updates available.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking for updates: " + ex.Message);
            }
        }

        private void DownloadAndApplyUpdate()
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    string zipFilePath = Path.Combine(Application.StartupPath, "update.zip");
                    client.DownloadFile(UpdateUrl, zipFilePath);

                    ExtractUpdate(zipFilePath);

                    MessageBox.Show("Update successfully applied!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error applying update: " + ex.Message);
            }
        }

        private void ExtractUpdate(string zipFilePath)
        {
            try
            {
                using (var zip = Ionic.Zip.ZipFile.Read(zipFilePath))
                {
                    foreach (var entry in zip)
                    {
                        string destinationPath = Path.Combine(Application.StartupPath, entry.FileName);

                        if (File.Exists(destinationPath))
                        {
                            continue;
                        }

                        Directory.CreateDirectory(Path.GetDirectoryName(destinationPath));

                        entry.Extract(destinationPath, ExtractExistingFileAction.DoNotOverwrite);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error extracting update: " + ex.Message);
            }
        }


        private void actvSpotify_btn_Click(object sender, EventArgs e)
        {
            try
            {
                string exeDirectory = Path.GetDirectoryName(Application.ExecutablePath);
                string batchScriptPath = Path.Combine(exeDirectory, "assets", "spot.bat");

                Process process = new Process();
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.Arguments = $"/C \"{batchScriptPath}\"";
                process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;

                process.Start();

                process.WaitForExit();
                process.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error-Log File created!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                string logFilePath = "spotify-error-log.txt";

                using (StreamWriter sw = File.AppendText(logFilePath))
                {
                    sw.WriteLine($"Error while running this Batch-Script: {ex.Message}");
                    sw.WriteLine($"StackTrace: {ex.StackTrace}");
                    sw.WriteLine();
                }
            }
        }

        private void actvWindows_btn_Click(object sender, EventArgs e)
        {
            try
            {
                string exeDirectory = Path.GetDirectoryName(Application.ExecutablePath);
                string batchScriptPath = Path.Combine(exeDirectory, "assets", "win.bat");

                Process process = new Process();
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.Arguments = $"/C \"{batchScriptPath}\"";
                process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;

                process.Start();

                process.WaitForExit();
                process.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error-Log File created!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                string logFilePath = "windows-error-log.txt";

                using (StreamWriter sw = File.AppendText(logFilePath))
                {
                    sw.WriteLine($"Error while running this Batch-Script: {ex.Message}");
                    sw.WriteLine($"StackTrace: {ex.StackTrace}");
                    sw.WriteLine();
                }
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Succesful copied!", "VMware Pro License Key", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Clipboard.SetText("MC60H-DWHD5-H80U9-6V85M-8280D");
        }

        private void checkall_check_Click(object sender, EventArgs e)
        {
            if (checkall_check.Checked == true)
            {
                winrar_check.Checked = true;
                notepadplusplus_check.Checked = true;
                librewolf_check.Checked = true;

                vscode_check.Checked = true;
                visualstudio_check.Checked = true;
                githubdesktop_check.Checked = true;

                idapro_check.Checked = true;
                dnspy_check.Checked = true;
                //premierepro_check.Checked = true;

                session_check.Checked = true;
                webcord_check.Checked = true;
                discord_check.Checked = true;

                pidgin_check.Checked = true;
                perfectprivacy_check.Checked = true;
                mullvad_check.Checked = true;

                keepassxc_check.Checked = true;
                atomicwallet_check.Checked = true;
                exodus_check.Checked = true;

                betterchatgpt_check.Checked = true;
            }
            else
            {
                winrar_check.Checked = false;
                notepadplusplus_check.Checked = false;
                librewolf_check.Checked = false;

                vscode_check.Checked = false;
                visualstudio_check.Checked = false;
                githubdesktop_check.Checked = false;

                idapro_check.Checked = false;
                dnspy_check.Checked = false;
                premierepro_check.Checked = false;

                session_check.Checked = false;
                webcord_check.Checked = false;
                discord_check.Checked = false;

                pidgin_check.Checked = false;
                perfectprivacy_check.Checked = false;
                mullvad_check.Checked = false;

                keepassxc_check.Checked = false;
                atomicwallet_check.Checked = false;
                exodus_check.Checked = false;

                betterchatgpt_check.Checked = false;
            }
        }

        private void install_btn_Click(object sender, EventArgs e)
        {
            if (winrar_check.Checked)
            {
                string downloadUrl = "https://cdn.discordapp.com/attachments/1150535987932442755/1150536046224883793/winrar-x64-622d.exe";

                string downloadedFileName = "winrar-setup.exe";

                try
                {
                    using (WebClient webClient = new WebClient())
                    {
                        webClient.DownloadFile(downloadUrl, downloadedFileName);

                        Process.Start(downloadedFileName);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            if (notepadplusplus_check.Checked)
            {
                string downloadUrl = "https://cdn.discordapp.com/attachments/1150535987932442755/1150537520464019556/npp.8.5.6.Installer.x64.exe";

                string downloadedFileName = "notepadplusplus-setup.exe";

                try
                {
                    using (WebClient webClient = new WebClient())
                    {
                        webClient.DownloadFile(downloadUrl, downloadedFileName);

                        Process.Start(downloadedFileName);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            if (librewolf_check.Checked)
            {
                string downloadUrl = "https://cdn.discordapp.com/attachments/1150535987932442755/1150537289747927090/librewolf-115.0.2-2-windows-x86_64-setup.exe";

                string downloadedFileName = "librewolf-setup.exe";

                try
                {
                    using (WebClient webClient = new WebClient())
                    {
                        webClient.DownloadFile(downloadUrl, downloadedFileName);

                        Process.Start(downloadedFileName);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            if (vscode_check.Checked)
            {
                string downloadUrl = "https://cdn.discordapp.com/attachments/1150535987932442755/1150537750462877696/VSCodeUserSetup-x64-1.80.1.exe";

                string downloadedFileName = "vscode-setup.exe";

                try
                {
                    using (WebClient webClient = new WebClient())
                    {
                        webClient.DownloadFile(downloadUrl, downloadedFileName);

                        Process.Start(downloadedFileName);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            if(visualstudio_check.Checked)
            {
                string downloadUrl = "https://cdn.discordapp.com/attachments/1150535987932442755/1150537750118928435/VisualStudioSetup.exe";

                string downloadedFileName = "visualstudio-setup.exe";

                try
                {
                    using (WebClient webClient = new WebClient())
                    {
                        webClient.DownloadFile(downloadUrl, downloadedFileName);

                        Process.Start(downloadedFileName);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            if(githubdesktop_check.Checked)
            {
                string downloadUrl = "https://cdn.discordapp.com/attachments/1150535987932442755/1150537999373832214/GitHubDesktopSetup-x64.exe";

                string downloadedFileName = "githubdesktop-setup.exe";

                try
                {
                    using (WebClient webClient = new WebClient())
                    {
                        webClient.DownloadFile(downloadUrl, downloadedFileName);

                        Process.Start(downloadedFileName);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            if (idapro_check.Checked)
            {
                string downloadUrl = "https://cdn.discordapp.com/attachments/1150535987932442755/1150797181842894949/IDA_Pro_7.5_SP3.msi";

                string downloadedFileName = "idapro-setup.exe";

                try
                {
                    using (WebClient webClient = new WebClient())
                    {
                        webClient.DownloadFile(downloadUrl, downloadedFileName);

                        Process.Start(downloadedFileName);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            if (dnspy_check.Checked)
            {
                string downloadUrl = "https://cdn.discordapp.com/attachments/1150535987932442755/1150798233141002270/dnSpy-net-win64.zip";

                string downloadedFileName = "dnspy-setup.zip";

                try
                {
                    using (WebClient webClient = new WebClient())
                    {
                        webClient.DownloadFile(downloadUrl, downloadedFileName);

                        Process.Start(downloadedFileName);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            if (session_check.Checked)
            {
                string downloadUrl = "";

                string downloadedFileName = "session-setup.exe";

                try
                {
                    using (WebClient webClient = new WebClient())
                    {
                        webClient.DownloadFile(downloadUrl, downloadedFileName);

                        Process.Start(downloadedFileName);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            if (premierepro_check.Checked)
            {
                string downloadUrl = "";

                string downloadedFileName = "premierepro-setup.exe";

                try
                {
                    using (WebClient webClient = new WebClient())
                    {
                        webClient.DownloadFile(downloadUrl, downloadedFileName);

                        Process.Start(downloadedFileName);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            if (discord_check.Checked)
            {
                string downloadUrl = "https://cdn.discordapp.com/attachments/1150535987932442755/1150903542450761890/DiscordSetup.exe";

                string downloadedFileName = "discord-setup.exe";

                try
                {
                    using (WebClient webClient = new WebClient())
                    {
                        webClient.DownloadFile(downloadUrl, downloadedFileName);

                        Process.Start(downloadedFileName);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            if (webcord_check.Checked)
            {
                string downloadUrl = "https://github.com/SpacingBat3/WebCord/releases/download/v4.4.0/WebCord-4.4.0.Setup-x64.exe";

                string downloadedFileName = "webcord-setup.exe";

                try
                {
                    using (WebClient webClient = new WebClient())
                    {
                        webClient.DownloadFile(downloadUrl, downloadedFileName);

                        Process.Start(downloadedFileName);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            if (pidgin_check.Checked)
            {
                string downloadUrl = "https://cdn.discordapp.com/attachments/1150535987932442755/1150904498252959784/pidgin-2.14.12.exe";

                string downloadedFileName = "pidgin-setup.exe";

                try
                {
                    using (WebClient webClient = new WebClient())
                    {
                        webClient.DownloadFile(downloadUrl, downloadedFileName);

                        Process.Start(downloadedFileName);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            if (perfectprivacy_check.Checked)
            {
                string downloadUrl = "https://cdn.discordapp.com/attachments/1150535987932442755/1150904997790367785/Perfect_Privacy_Setup.exe";

                string downloadedFileName = "perfect-privacy-setup.exe";

                try
                {
                    using (WebClient webClient = new WebClient())
                    {
                        webClient.DownloadFile(downloadUrl, downloadedFileName);

                        Process.Start(downloadedFileName);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            if (mullvad_check.Checked)
            {
                string downloadUrl = "https://cdn.discordapp.com/attachments/1150535987932442755/1150906666947190935/MullvadVPN-2023.4.exe";

                string downloadedFileName = "mullvad-setup.exe";

                try
                {
                    using (WebClient webClient = new WebClient())
                    {
                        webClient.DownloadFile(downloadUrl, downloadedFileName);

                        Process.Start(downloadedFileName);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            if (keepassxc_check.Checked)
            {
                string downloadUrl = "https://cdn.discordapp.com/attachments/1150535987932442755/1150905298593271869/KeePassXC-2.7.6-Win64.msi";

                string downloadedFileName = "keepassxc-setup.msi";

                try
                {
                    using (WebClient webClient = new WebClient())
                    {
                        webClient.DownloadFile(downloadUrl, downloadedFileName);

                        Process.Start(downloadedFileName);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            if (atomicwallet_check.Checked)
            {
                string downloadUrl = "https://cdn.discordapp.com/attachments/1150535987932442755/1150906799692730430/atomicwallet-2.70.12.exe";

                string downloadedFileName = "atomicwallet-setup.exe";

                try
                {
                    using (WebClient webClient = new WebClient())
                    {
                        webClient.DownloadFile(downloadUrl, downloadedFileName);

                        Process.Start(downloadedFileName);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            if (exodus_check.Checked)
            {
                string downloadUrl = "https://cdn.discordapp.com/attachments/1150535987932442755/1150907630219440203/exodus-windows-x64-23.9.11.exe";

                string downloadedFileName = "exodus-setup.exe";

                try
                {
                    using (WebClient webClient = new WebClient())
                    {
                        webClient.DownloadFile(downloadUrl, downloadedFileName);

                        Process.Start(downloadedFileName);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            if (betterchatgpt_check.Checked)
            {
                string downloadUrl = "https://cdn.discordapp.com/attachments/1150535987932442755/1152607490366771210/win-better-chatgpt-1.0.4-x64.exe";

                string downloadedFileName = "betterchatgpt-setup.exe";

                try
                {
                    using (WebClient webClient = new WebClient())
                    {
                        webClient.DownloadFile(downloadUrl, downloadedFileName);

                        Process.Start(downloadedFileName);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void guna2CirclePictureBox2_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/JunkieOpfer");
        }

        private void guna2CirclePictureBox3_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/JunkieOpfer");
        }

        private void guna2CirclePictureBox4_Click(object sender, EventArgs e)
        {
            Process.Start("https://discord.gg/kittycord");
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            try
            {
                string newsettingsfile = "https://cdn.discordapp.com/attachments/1150535987932442755/1150884711674155138/settings.json";

                string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string discordSettingsPath = Path.Combine(appDataPath, "discord", "settings.json");

                using (WebClient webClient = new WebClient())
                {
                    webClient.DownloadFile(newsettingsfile, discordSettingsPath);
                }

                MessageBox.Show("Succesful!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);         
            }
            catch(Exception ex)
            {
                MessageBox.Show("The settings file does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            try
            {
                string newsettingsfile = "https://cdn.discordapp.com/attachments/1150535987932442755/1150884711674155138/settings.json";

                string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string discordSettingsPath = Path.Combine(appDataPath, "discordcanary", "settings.json");

                using (WebClient webClient = new WebClient())
                {
                    webClient.DownloadFile(newsettingsfile, discordSettingsPath);
                }

                MessageBox.Show("Succesful!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("The settings file does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            try
            {
                string newsettingsfile = "https://cdn.discordapp.com/attachments/1150535987932442755/1150884711674155138/settings.json";

                string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string discordSettingsPath = Path.Combine(appDataPath, "discordptb", "settings.json");

                using (WebClient webClient = new WebClient())
                {
                    webClient.DownloadFile(newsettingsfile, discordSettingsPath);
                }

                MessageBox.Show("Succesful!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("The settings file does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadStartupPrograms()
        {
            listViewStartupPrograms.Items.Clear();

            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");

            if (key != null)
            {
                foreach (string valueName in key.GetValueNames())
                {
                    string programPath = key.GetValue(valueName).ToString();

                    ListViewItem item = new ListViewItem(valueName);
                    item.SubItems.Add("Enabled");
                    item.Tag = programPath;

                    listViewStartupPrograms.Items.Add(item);
                }

                key.Close();
            }
        }

        private void UpdateListViewItemState(string programPath, bool enabled)
        {
            foreach (ListViewItem item in listViewStartupPrograms.Items)
            {
                if (item.Tag.ToString() == programPath)
                {
                    item.SubItems[1].Text = enabled ? "Enabled" : "Disabled";
                    break;
                }
            }
        }

        private void EnableStartupProgram(string programName, string programPath)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
            key.SetValue(programName, programPath);
            key.Close();

            UpdateListViewItemState(programPath, true);
        }

        private void DisableStartupProgram(string programPath)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
            key.DeleteValue(System.IO.Path.GetFileNameWithoutExtension(programPath), false);
            key.Close();

            UpdateListViewItemState(programPath, false);
        }

        private void RemoveStartupProgram(string programPath)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
            key.DeleteValue(System.IO.Path.GetFileNameWithoutExtension(programPath), false);
            key.Close();

            ListViewItem itemToRemove = null;
            foreach (ListViewItem item in listViewStartupPrograms.Items)
            {
                if (item.Tag.ToString() == programPath)
                {
                    itemToRemove = item;
                    break;
                }
            }

            if (itemToRemove != null)
                listViewStartupPrograms.Items.Remove(itemToRemove);
        }


        private void disable_btn_Click(object sender, EventArgs e)
        {
            if (listViewStartupPrograms.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listViewStartupPrograms.SelectedItems[0];
                string programPath = selectedItem.Tag.ToString();
                DisableStartupProgram(programPath);
            }
        }

        private void enable_btn_Click(object sender, EventArgs e)
        {
            if (listViewStartupPrograms.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listViewStartupPrograms.SelectedItems[0];
                string programName = selectedItem.Text;
                string programPath = selectedItem.Tag.ToString();
                EnableStartupProgram(programName, programPath);
            }
        }

        private void refresh_btn_Click(object sender, EventArgs e)
        {
            LoadStartupPrograms();
        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void addtostartup_btn_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Title = "Select Program";
                dialog.Filter = "Executable Files|*.exe";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string programPath = dialog.FileName;
                    string programName = System.IO.Path.GetFileNameWithoutExtension(programPath);

                    bool isAlreadyAdded = listViewStartupPrograms.Items.Cast<ListViewItem>()
                        .Any(item => item.Tag.ToString().Equals(programPath, StringComparison.OrdinalIgnoreCase));

                    if (isAlreadyAdded)
                    {
                        MessageBox.Show("This program is already in the startup list.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        EnableStartupProgram(programName, programPath);
                        MessageBox.Show("Program added to startup successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
    }   
}
