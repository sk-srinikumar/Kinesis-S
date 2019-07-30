using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using Thorlabs.MotionControl.KCube.SolenoidCLI;

namespace main
{
    partial class Program
    {
        private async void InitializePolling()
        {
            source = new CancellationTokenSource();
            CancellationToken token = source.Token;

            await Task.Factory.StartNew(() =>
            {
                StartPolling(token, schemaProgress, externalProgress, cubeProgress);
            }, token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
        }

        private async void StartPolling(CancellationToken token, IProgress<Image> schema, IProgress<Image> external, IProgress<Image> cube)
        {
            while (true)
            {
                if (token.IsCancellationRequested) return;
                
                SolenoidStatusUpdate(cube);

                if (extDevice.connected == true)
                {
                    var datas = extDevice.GetBuffer();
                    foreach (var state in datas)
                    {
                        // Pressing a button down counts as 1 input sequence. Releasing that same button counts as 1 input sequence.
                        if (state.Sequence % 2 == 0 && state.Sequence != 0) 
                        {
                            external.Report(externalStatusImage);

                            if (kCube.connected == true)
                            {
                                kCube.ToggleShutter();
                                SolenoidStatusUpdate(cube);
                            }
                            await Task.Delay(100);
                            external.Report(emptyImage);
                        }
                    }
                }
                Thread.Sleep(1);
            }
        } 
    }
}