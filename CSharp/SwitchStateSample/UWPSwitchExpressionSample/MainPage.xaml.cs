using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UWPSwitchExpressionSample
{
    public sealed partial class MainPage : Page
    {
       
        public MainPage()
        {
            this.InitializeComponent();
            LightState = LightState.Red;
            previousState = LightState.Yellow;

            var switcher = new TrafficLightStateSwitcher();

            var timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(3);
            timer.Tick += (sender, e) =>
            {
                (LightState, previousState) = switcher.GetLight(LightState, previousState);
            };
            timer.Start();

        }

        private LightState previousState;

        public LightState LightState
        {
            get => (LightState)GetValue(LightStateProperty);
            set => SetValue(LightStateProperty, value);
        }

        public static readonly DependencyProperty LightStateProperty =
            DependencyProperty.Register("LightState", typeof(LightState), typeof(MainPage), new PropertyMetadata(null));

    }
}
