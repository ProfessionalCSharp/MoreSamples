using System;

namespace UWPSwitchExpressionSample
{
    public class TrafficLightStateSwitcher
    {
        public (LightState Current, LightState Previous) GetLight(LightState currentLight, LightState previousLight)
        => (currentLight, previousLight) switch
        {
            (LightState.Red, _) => (LightState.Yellow, currentLight),
            (LightState.Yellow, LightState.Red) => (LightState.Green, currentLight),
            (LightState.Green, _) => (LightState.Yellow, currentLight),
            (LightState.Yellow, LightState.Green) => (LightState.Red, currentLight),
            _ => throw new InvalidOperationException()
        };
    }
}
