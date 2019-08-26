using System;
using System.Threading.Tasks;

namespace SwitchStateSample
{
    public enum Light
    {
        Undefined,
        Red,
        Yellow,
        GreenBlink,
        Green,
        YellowBlink
    };

    internal class LightStatus
    {
        public LightStatus(Light current, Light previous, int seconds, int blinkCount)
            => (Current, Previous, Milliseconds, BlinkCount) = (current, previous, seconds, blinkCount);

        public LightStatus(Light current, Light previous, int seconds) : this(current, previous, seconds, 0) { }
        public LightStatus(Light current, Light previous) : this(current, previous, 3) { }
        public LightStatus() : this(Light.YellowBlink, Light.Undefined) { }

        public Light Current { get; }
        public Light Previous { get; }
        public int BlinkCount { get; }
        public int Milliseconds { get; }
    }

    class Program
    {
        static async Task Main()
        {
            await MainTuplesAsync();
            // await MainClassAsync();
        }

        static async Task MainTuplesAsync()
        {
            Light current = Light.YellowBlink;
            Light previous = Light.Undefined;
            int count = 0;
            while (true)
            {
                (current, previous) = GetLight1(current, previous);
                Console.WriteLine($"new light: {current}, previous: {previous}");
                //(current, previous, count) = GetLight3(current, previous, count);
                //Console.WriteLine($"new light: {current}, previous: {previous}, count: {count}");
                await Task.Delay(2000);
            }
        }

        static async Task MainClassAsync()
        {
            var lightStatus = new LightStatus();
            while (true)
            {
                lightStatus = GetLight4(lightStatus);
                Console.WriteLine($"new light: {lightStatus.Current}, previous: {lightStatus.Previous}, count: {lightStatus.BlinkCount}, time: {lightStatus.Milliseconds}");
                await Task.Delay(lightStatus.Milliseconds);
            }
        }

        static (Light Current, Light Previous) GetLight1(Light currentLight, Light previousLight)
        {
            return (currentLight, previousLight) switch
            {
                (Light.YellowBlink, Light.Undefined) => (Light.Red, Light.YellowBlink),
                (Light.YellowBlink, Light.Red) => (Light.Red, Light.YellowBlink),
                (Light.YellowBlink, Light.Green) => (Light.Red, Light.YellowBlink),
                (Light.YellowBlink, Light.Yellow) => (Light.Red, Light.YellowBlink),
                (Light.Red, Light.YellowBlink) => (Light.Yellow, currentLight),
                (Light.Red, Light.Yellow) => (Light.Yellow, currentLight),
                (Light.Yellow, Light.Red) => (Light.Green, currentLight),
                (Light.Green, Light.Yellow) => (Light.GreenBlink, currentLight),
                (Light.GreenBlink, Light.Green) => (Light.Yellow, currentLight),
                (Light.Yellow, Light.GreenBlink) => (Light.Red, currentLight),
                _ => (Light.YellowBlink, currentLight)
            };
        }

        static (Light Current, Light Previous) GetLight2(Light currentLight, Light previousLight)
            => (currentLight, previousLight) switch
            {
                (Light.YellowBlink, _) => (Light.Red, Light.YellowBlink),
                (Light.Red, _) => (Light.Yellow, currentLight),
                (Light.Yellow, Light.Red) => (Light.Green, currentLight),
                (Light.Green, _) => (Light.GreenBlink, currentLight),
                (Light.GreenBlink, _) => (Light.Yellow, currentLight),
                (Light.Yellow, Light.GreenBlink) => (Light.Red, currentLight),
                _ => (Light.YellowBlink, currentLight)
            };

        static (Light Current, Light Previous, int count) GetLight3(Light currentLight, Light previousLight, int currentCount = 0)
            => (currentLight, previousLight, currentCount) switch
            {
                (Light.YellowBlink, _, _) => (Light.Red, Light.YellowBlink, 0),
                (Light.Red, _, _) => (Light.Yellow, currentLight, 0),
                (Light.Yellow, Light.Red, _) => (Light.Green, currentLight, 0),
                (Light.Green, _, _) => (Light.GreenBlink, currentLight, 0),
                (Light.GreenBlink, _, 2) => (Light.Yellow, currentLight, 0),
                (Light.GreenBlink, _, _) => (Light.GreenBlink, currentLight, ++currentCount),
                (Light.Yellow, Light.GreenBlink, _) => (Light.Red, currentLight, 0),
                _ => (Light.YellowBlink, currentLight, 0)
            };

        static LightStatus GetLight4(LightStatus lightStatus)
            => lightStatus switch
            {
                { Current: Light.YellowBlink } => new LightStatus(Light.Red, Light.YellowBlink, 5000),
                { Current: Light.Red } => new LightStatus(Light.Yellow, lightStatus.Current, 3000),
                { Current: Light.Yellow, Previous: Light.Red } => new LightStatus(Light.Green, lightStatus.Current, 5000),
                { Current: Light.Green } => new LightStatus(Light.GreenBlink, lightStatus.Current, 1000),
                { Current: Light.GreenBlink, BlinkCount: 2 } => new LightStatus(Light.Yellow, lightStatus.Current, 2000),
                { Current: Light.GreenBlink } => new LightStatus(Light.GreenBlink, lightStatus.Current, 1000, lightStatus.BlinkCount + 1),
                { Current: Light.Yellow, Previous: Light.GreenBlink } => new LightStatus(Light.Red, lightStatus.Current, 5000),
                _ => new LightStatus(Light.YellowBlink, lightStatus.Current, 1000)
            };
    }
}
