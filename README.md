![Title](https://github.com/megafauna64/Kinesis-S/blob/master/ReadMe%20Assets/title.png)

---
# General

## Features
 
* Toggle your K-Cube Solenoid Controller using an input device.
* Control your K-Cube while using other programs.
* Monitor solenoid status.
* Use input devices with only one input option (e.g. pedal).
* Efficient device polling (unlike Thorlabs' recommended custom solution).
* Dll files for your K-Cube are included.

![Operating](https://github.com/megafauna64/Kinesis-S/blob/master/ReadMe%20Assets/Capture.PNG)

## Download

[Click here to download.]

## Instructions

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

## Issues

* After each relinking, your K-Cube's solenoid may not toggle only on the first input recieved from your input device.
* After each relinking, your K-Cube's solenoid may toggle between both states rapidly only on the first input recieved from your input device.

___

# Documentation

## ui_events.cs
This file contains code for button actions and UI updating.

```C#
CreateEmptyImage(int w, int h);
```

**Description**

Creates an empty bitmap to be used for dissappearing UI elements.

**Parameters**

*w* is the width
*h* is the height

```C#
shutdownButton_Clicked(object sender, EventArgs e);
```
**Description**

When the 'Shut down' button is clicked, this will be called. It will:
* End device polling.
* Updating UI.
* Disconnect from devices.
* Create an artificial delay to allow K-Cube to deinitialize.
* Closes Kinesis S.

```C#
relinkButton_Clicked(object sender, EventArgs e);
```

**Description**

When the 'Relink' button is clicked, this will be called. It will:
* End and restart device polling.
* Update UI.
* Save the text-box (serial number) information to settings .
* Disconnect and connect to devices.
* Create more artificial delays for device initialization and deinitialization.

```C#
SchemaUpdate(IProgress<Image> schema);
```

**Description**

Updates the schema to reflect the links.

**Parameters**

*schema* is a progress interface that will update the schema image between threads.

```C#
SolenoidStatusUpdate(IProgress<Image> cube)
```

**Description**

Updates the schema to reflect the solenoid status.

**Parameters**

*cube* is a progress interface that will update the cube image between threads.

```C#
MouseDown(object sender, MouseEventArgs e);
MouseMove(object sender, MouseEventArgs e);
MouseUp(object sender, MouseEventArgs e);
```
**Description**

These events will allow the Kinesis S window to be draggable.

## polling.cs
This file contains functions for operation during device polling.

```C#
InitializePolling();
```

**Description**

This exists to create an asynchronous thread, along with its token.

```C#
StartPolling(CancellationToken token, IProgress<Image> schema, IProgress<Image> external, IProgress<Image> cube);
```

**Description**

Allows the input device to toggle K-Cube's solenoid. Also updates the UI properly.

```C#
await Task.Factory.StartNew(() =>
            {
        
            }, token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
```

**Description**

The parameters at the end will keep the polling process running efficiently. Without this, Kinesis S will be using >90% of the CPU as opposed to 0%.

## kcube.cs
This file contains code for controlling the K-Cube.

```C#
Connect();
```

**Description**

Connects to, initializes and polls the K-Cube.

```C#
Destroy();
```

**Description**

Toggles the solenoid off, disables polling and disconnects from K-Cube.

```C#
ToggleShutter();
```

**Description**

Gets the solenoid's current state and then toggles to the opposite of that state.

```C#
ShuttOff();
```

**Description**

If the solenoid's current state is 'ON', then it toggles it to 'OFF'

## extdevice.cs
This file contains code for controlling the external input device.

```C#
Connect();
```

**Description**

Finds, connects to and initializes and polls a registered gamepad / joystick (input device).

```C#
Destroy();
```

**Description**

Disconnects from gamepad / joystick (input device).

```C#
Enable();
Disable();
```

**Description**

Connects to or disconnects from gamepad / joystick (input device) without building a list of possible connected devices.


```C#
GetBuffer();
```

**Description**

Gets input signal data from gamepad / joystick (input device).

**Returns**

`JoystickUpdate[]` object that contains input data.

## ui_form.cs
This file contains code to initialize the UI. The schema images are all contained in pictureboxes so that they can be overlayed on top of each other while maintaing background transparency.

---
# Information & Contributions
* Developed for use at [California State University San Bernardino].
* Dll files and K-Cube images are taken from [Thorlabs].
* Development commenced under and for Dodsworth Jeremy, PhD.
* Developed by Srinivasan Kumaresan.

---
# Contact
* Developer's email: srnkmrsn@gmail.com

[Thorlabs]: https://www.thorlabs.com/about_us.cfm
[California State University San Bernardino]: https://cns.csusb.edu/biology
[Click here to download.]: https://github.com/megafauna64/Kinesis-S/releases/download/1.0/Kinesis_S.zip
