using System;
using System.Threading.Tasks;

namespace SwitchStateSample
{
    public class TrafficLightRunner
    {
        private readonly TrafficLightSwitcher _switcher = new TrafficLightSwitcher();

        public async Task UseTuplesAsync()
        {
            LightState current = LightState.FlashingYellow;
            LightState previous = LightState.Undefined;
            while (true)
            {
                (current, previous) = _switcher.GetNextLight2(current, previous);
                Console.WriteLine($"new light: {current}, previous: {previous}");
                await Task.Delay(2000);
            }
        }
    }
}
