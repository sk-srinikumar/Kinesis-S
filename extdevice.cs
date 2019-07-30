using System;
using SharpDX.DirectInput;

namespace extdevice_space
{
    public class ExternalDevice
    {
        private DirectInput directInput;
        private Guid joystickGuid;
        private Joystick joystick;
        public bool connected { get; private set; }

        public ExternalDevice() => Connect();

        public void Connect()
        {
            directInput = new DirectInput();
            joystickGuid = Guid.Empty;

            foreach (DeviceInstance deviceInstance in directInput.GetDevices(DeviceType.Gamepad, DeviceEnumerationFlags.AllDevices))
            {
                joystickGuid = deviceInstance.InstanceGuid;
            }
                
            if (joystickGuid == Guid.Empty)
            {
                foreach (DeviceInstance deviceInstance in directInput.GetDevices(DeviceType.Joystick, DeviceEnumerationFlags.AllDevices))
                {
                    joystickGuid = deviceInstance.InstanceGuid;
                }
            }

            if (joystickGuid == Guid.Empty)
            {
                connected = false;
                return;
            }

            connected = true;
            joystick = new Joystick(directInput, joystickGuid);
            System.Collections.Generic.IList<EffectInfo> allEffects = joystick.GetEffects();
            foreach (EffectInfo effectInfo in allEffects) ;
            joystick.Properties.BufferSize = 128;
            joystick.Acquire();
            joystick.Poll();
        }

        public void Destroy()
        {
            joystick.Unacquire();
            joystick.Dispose();
            directInput.Dispose();
        }

        public void Enable()
        {
            joystick.Acquire();
            joystick.Poll();
        }

        public void Disable() => joystick.Unacquire();
        public JoystickUpdate[] GetBuffer() => joystick.GetBufferedData();
    }     
}