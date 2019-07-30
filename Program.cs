using System;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

using cube_space;
using extdevice_space;

namespace main
{
    internal class Start
    {
        [STAThread]
        private static void Main()
        {
            Program program = new Program();
        }
    }
    partial class Program
    {
        private const int w = 340;
        private const int h = 336;
        private const int h2 = 15;
        private string website = "https://github.com/megafauna64/Kinesis-S";

        private Form form;
        private Label titleLabel;
        private PictureBox schemaPicBox;
        private PictureBox cubePicBox;
        private PictureBox externalPicBox;
        private TextBox serialTextBox;
        private Button githubButton;
        private Button shutdownButton;
        private Button relinkButton;

        private Image titleImage = new Bitmap(Properties.Resources.title, 310, 102);
        private Image schemaBothUnlinkedImage = new Bitmap(Properties.Resources.both_unlinked, w, h);
        private Image schemaBothLinkedImage = new Bitmap(Properties.Resources.both_linked, w, h);
        private Image schemaCubeUnlinkedImage = new Bitmap(Properties.Resources.cube_unlinked, w, h);
        private Image schemaExternalUnlinkedImage = new Bitmap(Properties.Resources.external_unlinked, w, h);
        private Image schemaLoadImage = new Bitmap(Properties.Resources.update, w, h);
        private Image cubeStatusOnImage = new Bitmap(Properties.Resources.cube_on, w, h);
        private Image cubeStatusOffImage = new Bitmap(Properties.Resources.cube_off, w, h);
        private Image externalStatusImage = new Bitmap(Properties.Resources.input_signal, w, h);
        private Image emptyImage;
        private Image githubButtonImage = new Bitmap(Properties.Resources.info_button, 67, h2);
        private Image shutdownButtonImage = new Bitmap(Properties.Resources.shutdown_button, 61, h2);
        private Image shutdownButtonLoadImage = new Bitmap(Properties.Resources.shutdown_load, 61, h2);
        private Image relinkButtonImage = new Bitmap(Properties.Resources.relink_button, 40, h2);
        private Image relinkButtonLoadImage = new Bitmap(Properties.Resources.relink_load, 40, h2);

        Progress<Image> schemaProgress;
        Progress<Image> cubeProgress;
        Progress<Image> externalProgress;

        private bool mouseDown;
        private Point lastLocation;

        private Cube kCube = new Cube();
        private ExternalDevice extDevice = new ExternalDevice();
        CancellationTokenSource source;

        public Program()
        {
            CreateEmptyImage(w,h);
            InitializeForm();
            SchemaUpdate(schemaProgress);
            InitializePolling();
            form.ShowDialog();
        }
    }
}