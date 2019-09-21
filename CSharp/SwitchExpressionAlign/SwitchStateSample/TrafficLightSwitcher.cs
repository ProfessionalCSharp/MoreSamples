using static SwitchStateSample.LightState;

namespace SwitchStateSample
{
    public class TrafficLightSwitcher
    {
        public (LightState Current, LightState Previous) GetNextLight1(LightState currentLight, LightState previousLight)
            => (currentLight, previousLight) switch
            {
                (LightState.FlashingYellow, _) => (LightState.Red, currentLight),
                (LightState.Red, _) => (LightState.Yellow, currentLight),
                (LightState.Yellow, LightState.Red) => (LightState.Green, currentLight),
                (LightState.Green, _) => (LightState.FlashingGreen, currentLight),
                (LightState.FlashingGreen, _) => (LightState.Yellow, currentLight),
                (LightState.Yellow, LightState.FlashingGreen) => (LightState.Red, currentLight),
                _ => (LightState.FlashingYellow, currentLight)
            };

        public (LightState Current, LightState Previous) GetNextLight2(LightState currentLight, LightState previousLight)
            => (currentLight, previousLight) switch
            {
                (FlashingYellow, _) => (Red, currentLight),
                (Red, _) => (Yellow, currentLight),
                (Yellow, Red) => (Green, currentLight),
                (Green, _) => (FlashingGreen, currentLight),
                (FlashingGreen, _) => (Yellow, currentLight),
                (Yellow, FlashingGreen) => (Red, currentLight),
                _ => (FlashingYellow, currentLight)
            };

        public (LightState Current, LightState Previous) GetNextLight3(LightState currentLight, LightState previousLight)
            => (currentLight, previousLight) switch
            {
                    (FlashingYellow, _) => (Red, currentLight),
                               (Red, _) => (Yellow, currentLight),
                          (Yellow, Red) => (Green, currentLight),
                             (Green, _) => (FlashingGreen, currentLight),
                     (FlashingGreen, _) => (Yellow, currentLight),
                (Yellow, FlashingGreen) => (Red, currentLight),
                                      _ => (FlashingYellow, currentLight)
            };

        public (LightState Current, LightState Previous) GetNextLight4(LightState currentLight, LightState previousLight)
            => (currentLight, previousLight) switch
            {
                (FlashingYellow, _)     => (Red, currentLight),
                (Red, _)                => (Yellow, currentLight),
                (Yellow, Red)           => (Green, currentLight),
                (Green, _)              => (FlashingGreen, currentLight),
                (FlashingGreen, _)      => (Yellow, currentLight),
                (Yellow, FlashingGreen) => (Red, currentLight),
                _                       => (FlashingYellow, currentLight)
            };

        public (LightState Current, LightState Previous) GetNextLight5(
            LightState currentLight, 
            LightState previousLight)
            => (currentLight, previousLight) switch
            {
                (FlashingYellow, _) 
                    => (Red, currentLight),
                (Red, _) 
                    => (Yellow, currentLight),
                (Yellow, Red) 
                    => (Green, currentLight),
                (Green, _) 
                    => (FlashingGreen, currentLight),
                (FlashingGreen, _) 
                    => (Yellow, currentLight),
                (Yellow, FlashingGreen) 
                    => (Red, currentLight),
                _ 
                    => (FlashingYellow, currentLight)
            };

        public (LightState Current, LightState Previous) GetNextLight6(LightState currentLight, LightState previousLight)
            => (currentLight, previousLight) switch
            {
                (FlashingYellow, _)             => (Red,            currentLight),
                (Red,            _)             => (Yellow,         currentLight),
                (Yellow,         Red)           => (Green,          currentLight),
                (Green,          _)             => (FlashingGreen,  currentLight),
                (FlashingGreen,  _)             => (Yellow,         currentLight),
                (Yellow,         FlashingGreen) => (Red,            currentLight),
                _                               => (FlashingYellow, currentLight)
            };
    }
}
