using System;
using System.Drawing;
using System.Windows.Forms;

namespace MiAppWinForms
{
    public partial class Form1 : Form
    {
        int secondsLeft = 300; // 5 minutos
        Label countdownLabel;
        System.Windows.Forms.Timer countdownTimer;
        ListBox fakeFiles;
        TextBox keyBox;
        Label statusLabel;

        public Form1()
        {
            InitializeComponent();

            // VENTANA
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = Color.Black;
            this.KeyPreview = true;

            // TITULO
            Label title = new Label();
            title.Text = "YOUR FILES ARE ENCRYPTED";
            title.ForeColor = Color.Red;
            title.Font = new Font("Consolas", 40, FontStyle.Bold);
            title.AutoSize = true;
            title.Location = new Point(80, 60);
            this.Controls.Add(title);

            // TEXTO PRINCIPAL
            Label body = new Label();
            body.Text =
                "FSOCIETY SECURITY BREACH\n\n" +
                "All your important files have been encrypted.\n" +
                "To recover them, you must enter the correct decryption key.\n\n" +
                "⚠ THIS IS A VISUAL SIMULATION ⚠\n" +
                "No real files were harmed.\n\n" +
                "Press ESC to exit.";
            body.ForeColor = Color.White;
            body.Font = new Font("Consolas", 18);
            body.AutoSize = true;
            body.Location = new Point(80, 160);
            this.Controls.Add(body);

            // CONTADOR
            countdownLabel = new Label();
            countdownLabel.ForeColor = Color.Red;
            countdownLabel.Font = new Font("Consolas", 26, FontStyle.Bold);
            countdownLabel.AutoSize = true;
            countdownLabel.Location = new Point(80, 380);
            this.Controls.Add(countdownLabel);

            countdownTimer = new System.Windows.Forms.Timer();
            countdownTimer.Interval = 1000;
            countdownTimer.Tick += CountdownTick;
            countdownTimer.Start();

            // LISTA DE ARCHIVOS FALSOS
            fakeFiles = new ListBox();
            fakeFiles.BackColor = Color.Black;
            fakeFiles.ForeColor = Color.Lime;
            fakeFiles.Font = new Font("Consolas", 14);
            fakeFiles.Location = new Point(850, 120);
            fakeFiles.Size = new Size(500, 500);
            this.Controls.Add(fakeFiles);

            string[] fakeFileNames =
            {
                "family_photos.zip.locked",
                "homework.docx.locked",
                "passwords.txt.locked",
                "bank_info.xlsx.locked",
                "backup_2024.rar.locked",
                "notes.txt.locked",
                "projects.csproj.locked",
                "music_collection.mp3.locked",
                "videos.mp4.locked"
            };

            foreach (var f in fakeFileNames)
                fakeFiles.Items.Add(f);

            // TEXTO CLAVE
            Label keyLabel = new Label();
            keyLabel.Text = "ENTER DECRYPTION KEY:";
            keyLabel.ForeColor = Color.White;
            keyLabel.Font = new Font("Consolas", 18);
            keyLabel.AutoSize = true;
            keyLabel.Location = new Point(80, 460);
            this.Controls.Add(keyLabel);

            keyBox = new TextBox();
            keyBox.Font = new Font("Consolas", 18);
            keyBox.Size = new Size(400, 40);
            keyBox.Location = new Point(80, 500);
            keyBox.UseSystemPasswordChar = true;
            this.Controls.Add(keyBox);

            // BOTÓN
            Button decryptBtn = new Button();
            decryptBtn.Text = "DECRYPT FILES";
            decryptBtn.Font = new Font("Consolas", 16, FontStyle.Bold);
            decryptBtn.BackColor = Color.DarkRed;
            decryptBtn.ForeColor = Color.White;
            decryptBtn.Location = new Point(80, 560);
            decryptBtn.Size = new Size(260, 50);
            decryptBtn.Click += DecryptClicked;
            this.Controls.Add(decryptBtn);

            // ESTADO
            statusLabel = new Label();
            statusLabel.ForeColor = Color.Red;
            statusLabel.Font = new Font("Consolas", 16);
            statusLabel.AutoSize = true;
            statusLabel.Location = new Point(80, 630);
            this.Controls.Add(statusLabel);

            // SALIR CON ESC
            this.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Escape)
                    this.Close();
            };
        }

        void CountdownTick(object? sender, EventArgs e)
        {
            if (secondsLeft <= 0)
            {
                countdownLabel.Text = "TIME EXPIRED";
                countdownTimer.Stop();
                statusLabel.Text = "All files permanently lost. (simulation)";
                return;
            }

            TimeSpan t = TimeSpan.FromSeconds(secondsLeft);
            countdownLabel.Text = $"TIME LEFT: {t:mm\\:ss}";
            secondsLeft--;
        }

        void DecryptClicked(object? sender, EventArgs e)
        {
            if (keyBox.Text == "fsociety")
            {
                countdownTimer.Stop();
                statusLabel.ForeColor = Color.Lime;
                statusLabel.Text = "Key accepted. Files decrypted successfully.";

                fakeFiles.Items.Clear();
                fakeFiles.Items.Add("All files restored ✔");

            }
            else
            {
                statusLabel.ForeColor = Color.Red;
                statusLabel.Text = "Invalid key. Try again.";
            }
        }
    }
}
