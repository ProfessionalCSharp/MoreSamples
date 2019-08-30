namespace SwitchStateSample
{
    public class TrafficLightSwitcher
    {
        public (LightState Current, LightState Previous) GetNextLight1(LightState currentLight, LightState previousLight)
        {
            return (currentLight, previousLight) switch
            {
                (LightState.FlashingYellow, LightState.Undefined) => (LightState.Red, currentLight),
                (LightState.FlashingYellow, LightState.Red) => (LightState.Red, currentLight),
                (LightState.FlashingYellow, LightState.Green) => (LightState.Red, currentLight),
                (LightState.FlashingYellow, LightState.Yellow) => (LightState.Red, currentLight),
                (LightState.Red, LightState.FlashingYellow) => (LightState.Yellow, currentLight),
                (LightState.Red, LightState.Yellow) => (LightState.Yellow, currentLight),
                (LightState.Yellow, LightState.Red) => (LightState.Green, currentLight),
                (LightState.Green, LightState.Yellow) => (LightState.FlashingGreen, currentLight),
                (LightState.FlashingGreen, LightState.Green) => (LightState.Yellow, currentLight),
                (LightState.Yellow, LightState.FlashingGreen) => (LightState.Red, currentLight),
                _ => (LightState.FlashingYellow, currentLight)
            };
        }

        public (LightState Current, LightState Previous) GetNextLight2(LightState currentLight, LightState previousLight)
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

        public (LightState Current, LightState Previous, int count) GetNextLight3(LightState currentLight, LightState previousLight, int currentCount = 0)
            => (currentLight, previousLight, currentCount) switch
            {
                (LightState.FlashingYellow, _, _) => (LightState.Red, currentLight, 0),
                (LightState.Red, _, _) => (LightState.Yellow, currentLight, 0),
                (LightState.Yellow, LightState.Red, _) => (LightState.Green, currentLight, 0),
                (LightState.Green, _, _) => (LightState.FlashingGreen, currentLight, 0),
                (LightState.FlashingGreen, _, 2) => (LightState.Yellow, currentLight, 0),
                (LightState.FlashingGreen, _, _) => (LightState.FlashingGreen, currentLight, ++currentCount),
                (LightState.Yellow, LightState.FlashingGreen, _) => (LightState.Red, currentLight, 0),
                _ => (LightState.FlashingYellow, currentLight, 0)
            };

        public LightStatus GetNextLight4(LightStatus lightStatus)
            => lightStatus switch
            {
                { Current: LightState.FlashingYellow } => new LightStatus(LightState.Red, LightState.FlashingYellow, 5000),
                { Current: LightState.Red } => new LightStatus(LightState.Yellow, lightStatus.Current, 3000),
                { Current: LightState.Yellow, Previous: LightState.Red } => new LightStatus(LightState.Green, lightStatus.Current, 5000),
                { Current: LightState.Green } => new LightStatus(LightState.FlashingGreen, lightStatus.Current, 1000),
                { Current: LightState.FlashingGreen, FlashCount: 2 } => new LightStatus(LightState.Yellow, lightStatus.Current, 2000),
                { Current: LightState.FlashingGreen } => new LightStatus(LightState.FlashingGreen, lightStatus.Current, 1000, lightStatus.FlashCount + 1),
                { Current: LightState.Yellow, Previous: LightState.FlashingGreen } => new LightStatus(LightState.Red, lightStatus.Current, 5000),
                _ => new LightStatus(LightState.FlashingYellow, lightStatus.Current, 1000)
            };
    }
}
