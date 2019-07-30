using System;
using System.Windows.Forms;
using System.Drawing;


namespace main
{
    partial class Program
    {
        private void InitializeForm()
        {
            form = new Form
            {
                FormBorderStyle = FormBorderStyle.None,
                BackColor = ColorTranslator.FromHtml("#FFF7E7"),
                ControlBox = false,
                Size = new Size(364, 502),
                StartPosition = FormStartPosition.CenterScreen
            };

            titleLabel = new Label()
            {
                Size = titleImage.Size,
                Location = new Point(12, 12)
            };
            titleLabel.Image = titleImage;
            form.Controls.Add(titleLabel);

            githubButton = new Button()
            {
                Size = new Size(githubButtonImage.Width + 1, h2 + 1),
                Location = new Point(12, titleLabel.Bottom + 12),
                BackColor = Color.Transparent,
                FlatStyle = FlatStyle.Flat,
            };
            githubButton.Image = githubButtonImage;
            githubButton.FlatAppearance.BorderSize = 0;
            githubButton.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            githubButton.Click += new EventHandler(githubButton_Clicked);
            form.Controls.Add(githubButton);

            shutdownButton = new Button()
            {
                Size = new Size(shutdownButtonImage.Width + 1, h2 + 1),
                Location = new Point(form.Width - 13 - shutdownButtonImage.Width, 12),
                BackColor = Color.Transparent,
                FlatStyle = FlatStyle.Flat,
            };
            shutdownButton.Image = shutdownButtonImage;
            shutdownButton.FlatAppearance.BorderSize = 0;
            shutdownButton.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            shutdownButton.Click += new EventHandler(shutdownButton_Clicked);
            form.Controls.Add(shutdownButton);
            shutdownButton.BringToFront();

            relinkButton = new Button()
            {
                Size = new Size(relinkButtonImage.Width + 1, h2 + 1),
                Location = new Point(100, 300),
                BackColor = Color.Transparent,
                FlatStyle = FlatStyle.Flat,
            };
            relinkButton.Image = relinkButtonImage;
            relinkButton.FlatAppearance.BorderSize = 0;
            relinkButton.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            relinkButton.Click += new EventHandler(relinkButton_Clicked);
            form.Controls.Add(relinkButton);
            relinkButton.BringToFront();

            serialTextBox = new TextBox()
            {
                Location = new Point(241, 374),
                AcceptsReturn = true,
                Font = new Font("Lucida Console", 8, FontStyle.Bold),
                Text = Properties.Settings.Default.serial
            };
            form.Controls.Add(serialTextBox);

            schemaPicBox = new PictureBox()
            {
                Size = schemaBothUnlinkedImage.Size,
                Location = new Point(12, githubButton.Bottom + 12)
            };
            schemaPicBox.Image = schemaBothLinkedImage;
            form.Controls.Add(schemaPicBox);

            cubePicBox = new PictureBox()
            {
                Size = schemaPicBox.Size,
                Location = new Point(0, 0),
                BackColor = Color.Transparent
            };
            schemaPicBox.Controls.Add(cubePicBox);

            externalPicBox = new PictureBox()
            {
                Size = schemaPicBox.Size,
                Location = new Point(0, 0),
                BackColor = Color.Transparent
            };
            cubePicBox.Controls.Add(externalPicBox);

            schemaProgress = new Progress<Image>(s => schemaPicBox.Image = s);
            cubeProgress = new Progress<Image>(s => cubePicBox.Image = s);
            externalProgress = new Progress<Image>(s => externalPicBox.Image = s);

            form.MouseDown += new MouseEventHandler(MouseDown);
            form.MouseMove += new MouseEventHandler(MouseMove);
            form.MouseUp += new MouseEventHandler(MouseUp);

            titleLabel.MouseDown += new MouseEventHandler(MouseDown);
            titleLabel.MouseMove += new MouseEventHandler(MouseMove);
            titleLabel.MouseUp += new MouseEventHandler(MouseUp);

            externalPicBox.MouseDown += new MouseEventHandler(MouseDown);
            externalPicBox.MouseMove += new MouseEventHandler(MouseMove);
            externalPicBox.MouseUp += new MouseEventHandler(MouseUp);
        }  
    }
}
