using System;
using System.ServiceModel;
using System.Windows;
using Wrox.ProCSharp.WCF.Contracts;

namespace RoomReservationClientSharedAssembly
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    private RoomReservation roomReservation;
    public MainWindow()
    {
      InitializeComponent();
      roomReservation = new RoomReservation
      {
        StartTime = DateTime.Now,
        EndTime = DateTime.Now.AddHours(1)
      };
      this.DataContext = roomReservation;
    }

    private void OnReserveRoom(object sender, RoutedEventArgs e)
    {
      var binding = new BasicHttpBinding();
      var address = new EndpointAddress("http://localhost:9000/RoomReservation");

      var factory = new ChannelFactory<IRoomService>(binding, address);
      IRoomService channel = factory.CreateChannel();
      if (channel.ReserveRoom(roomReservation))
      {
        MessageBox.Show("success");
      }
    }
  }
}
