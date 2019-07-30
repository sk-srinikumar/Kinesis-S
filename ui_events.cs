using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;


namespace main
{
   partial class Program
    {

        private void CreateEmptyImage(int w, int h)
        {
            emptyImage = new Bitmap(w, h);
            using (Graphics graph = Graphics.FromImage(emptyImage))
            {
                Rectangle ImageSize = new Rectangle(0, 0, w, h);
                graph.FillRectangle(Brushes.Transparent, ImageSize);
            }
        }

        private async void shutdownButton_Clicked(object sender, EventArgs e)
        {
            source.Cancel();

            shutdownButton.Image = shutdownButtonLoadImage;
            schemaPicBox.Image = schemaLoadImage;
            cubePicBox.Image = emptyImage;
            externalPicBox.Image = emptyImage;
            

            if (extDevice.connected == true) await Task.Run(() => extDevice.Destroy());
            if (kCube.connected == true)
            {
                await Task.Run(() => kCube.Destroy());
                await Task.Delay(3000);
            }

            form.Close();
        }

        private void githubButton_Clicked(object sender, EventArgs e) => System.Diagnostics.Process.Start(website);

        private async void relinkButton_Clicked(object sender, EventArgs e)
        {
            source.Cancel();

            schemaPicBox.Image = schemaLoadImage;
            relinkButton.Image = relinkButtonLoadImage;
            cubePicBox.Image = emptyImage;
            externalPicBox.Image = emptyImage;

            Properties.Settings.Default.serial = serialTextBox.Text;
            Properties.Settings.Default.Save();
            if (kCube.connected == true)
            {
                await Task.Run(() => kCube.Destroy());
                await Task.Delay(3000);
            }

            if (extDevice.connected == true) await Task.Run(() => extDevice.Destroy());
            await Task.Delay(3000);

            await Task.Run(() => kCube.Connect());
            await Task.Run(() => extDevice.Connect());
            if (kCube.connected == true) await Task.Delay(3000);

            source.Dispose();
            SolenoidStatusUpdate(cubeProgress);
            InitializePolling();
            SchemaUpdate(schemaProgress);
            relinkButton.Image = relinkButtonImage;
        }

        private  void SchemaUpdate(IProgress<Image> schema)
        {
            if (kCube.connected == true && extDevice.connected == false)
            {
                schema.Report(schemaExternalUnlinkedImage);
            }
            else if (kCube.connected == false && extDevice.connected == true)
            {
                schema.Report(schemaCubeUnlinkedImage);
            }
            else if (kCube.connected == true && extDevice.connected == true)
            {
                schema.Report(schemaBothLinkedImage);
            }
            else schema.Report(schemaBothUnlinkedImage);
        }

        private void SolenoidStatusUpdate(IProgress<Image> cube)
        {
            if (kCube.solenoidStatus == true) cube.Report(cubeStatusOnImage);
            else cube.Report(cubeStatusOffImage);

            if (kCube.connected == false) cube.Report(emptyImage);
        }

        private void MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                form.Location = new Point(
                    (form.Location.X - lastLocation.X) + e.X, (form.Location.Y - lastLocation.Y) + e.Y);

                form.Update();
            }
        }

        private void MouseUp(object sender, MouseEventArgs e) => mouseDown = false;
    }
}