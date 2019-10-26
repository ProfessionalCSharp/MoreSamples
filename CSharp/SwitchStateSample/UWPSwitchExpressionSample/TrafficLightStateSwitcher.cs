using System;

namespace UWPSwitchExpressionSample
{
    public class TrafficLightStateSwitcher
    {
        public (LightState Current, LightState Previous) GetNextLight(LightState currentLight, LightState previousLight)
        => (currentLight, previousLight) switch
        {
            (LightState.Red, _) => (LightState.Yellow, currentLight),
            (LightState.Yellow, LightState.Red) => (LightState.Green, currentLight),
            (LightState.Green, _) => (LightState.Yellow, currentLight),
            (LightState.Yellow, LightState.Green) => (LightState.Red, currentLight),
            _ => throw new InvalidOperationException()
        };

        public LightState GetNextLight(LightState currentLight)
          => currentLight switch
          {
              LightState.Red => LightState.Yellow,
              LightState.Yellow => LightState.Green,
              LightState.Green => LightState.Red,
              _ => throw new InvalidOperationException()
          };
    }
}
