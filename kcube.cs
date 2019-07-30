using System.Threading.Tasks;
using Thorlabs.MotionControl.DeviceManagerCLI;
using Thorlabs.MotionControl.KCube.SolenoidCLI;

namespace cube_space
{
    public class Cube
    {
        private KCubeSolenoid device;
        private string serialNo;
        public bool connected { get; private set; }
        public bool solenoidStatus { get; private set; }

        public Cube() => Connect();

        public void Connect()
        {
            connected = false;
            serialNo = main.Properties.Settings.Default.serial;
            DeviceManagerCLI.BuildDeviceList();
            device = KCubeSolenoid.CreateKCubeSolenoid(serialNo);

            try
            {
                device.Connect(serialNo);
            }
            catch (DeviceNotReadyException)
            {
                connected = false;
                return;
            }

            device.WaitForSettingsInitialized(5000);
            device.StartPolling(250);
            device.EnableDevice();

            connected = true;
            if (device.GetOperatingState() == SolenoidStatus.OperatingStates.Active) solenoidStatus = true;
            if (device.GetOperatingState() == SolenoidStatus.OperatingStates.Inactive) solenoidStatus = false;
        }

        public void Destroy()
        {
            ShuttOff();
            device.StopPolling();
            device.DisableDevice();
            device.Disconnect(true);
            device.DisconnectTidyUp();
            connected = false;
        }

        public void ToggleShutter()
        {
            switch (device.GetOperatingState())
            {
                case SolenoidStatus.OperatingStates.Inactive:
                    device.SetOperatingState(SolenoidStatus.OperatingStates.Active);
                    solenoidStatus = true;
                    break;
                default:
                    device.SetOperatingState(SolenoidStatus.OperatingStates.Inactive);
                    solenoidStatus = false;
                    break;
            }
        }

        public void ShuttOff()
        {
            if (device.GetOperatingState() == SolenoidStatus.OperatingStates.Active)
            {
                device.SetOperatingState(SolenoidStatus.OperatingStates.Inactive);
            }
        } 
    }
}