
using System.Device.Gpio;

int ledPin = 24; //GPIO24 is pin 18 on RPi
int ledOnTime = 1000; //led on time in ms
int ledOffTime = 500; //led off time in ms

using GpioController controller = new();
controller.OpenPin(ledPin, PinMode.Output);

Console.CancelKeyPress += (s, e) =>
{
    controller.Dispose();
};

while (true)
{
    controller.Write(ledPin, PinValue.High);
    Thread.Sleep(ledOnTime);

    controller.Write(ledPin, PinValue.Low);
    Thread.Sleep(ledOffTime);
}