![Title](https://github.com/megafauna64/Kinesis-S/blob/master/ReadMe%20Assets/title.png)

---
# General

### Features

* Toggle your K-Cube Solenoid Controller using an input device.
* Monitor solenoid status.
* Use input devices with only one input option (e.g. pedal).
* Efficient device polling (unlike Thorlabs' recommended custom solution).
* Dll files for your K-Cube are included.

![Operating](https://github.com/megafauna64/Kinesis-S/blob/master/ReadMe%20Assets/Capture.PNG)

### Download

https://github.com/megafauna64/Kinesis-S/releases

### Instructions

1. Download & unzip the file.
2. Right click on the Kinesis S.exe and choose to create a shortcut.
3. Make sure this shortcut goes on your desktop or taskbar.
4. Open the Kinsesis S software.
5. In the bottom right of the schema, enter your K-Cube's serial number into the textbox.
* Your K-Cube's serial number can be found here on the back of the device.

![Serial](https://github.com/megafauna64/Kinesis-S/blob/master/ReadMe%20Assets/serial.png)

6. Turn on and connect your K-Cube to the computer through USB.
7. Turn on and connect your input device to the computer.

* Your input devices must be registered as a gamepad / joystick by Windows. This needs be done either by the device's manufacturer's software or through a third-party software. Kinesis S will not be able to do this for you.
8. Press 'Relink'.

* Kinesis S will present you a graphic (shown below) to indicate that linking is in progress. Please wait for the graphic to dissappear before attempting to operate your devices.

![Update](https://github.com/megafauna64/Kinesis-S/blob/master/ReadMe%20Assets/Capture2.PNG)

9. If both if your devices are linked, you can now operate your K-Cube.
* The Kinesis S window is draggable.
* Due to the implementation of the K-Cube's code, Kinesis S will not be able to automatically indicate sudden disconnections of the K-Cube or your input device. You can update the connection status by relinking.
* Please allow the program to shut down on its own time once you click the 'Shut down' button.
* When relinking or shutting down, Kinesis S will automatically toggle your K-Cube's solenoid off.
