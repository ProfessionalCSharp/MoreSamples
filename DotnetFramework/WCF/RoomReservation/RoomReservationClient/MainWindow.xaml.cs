using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wrox.ProCSharp.WCF.RoomReservationService;

namespace Wrox.ProCSharp.WCF
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    private RoomReservation reservation;
    public MainWindow()
    {
      InitializeComponent();
      reservation = new RoomReservation { StartTime = DateTime.Now, EndTime = DateTime.Now.AddHours(1) };
      this.DataContext = reservation;
    }

    private async void OnReserveRoom(object sender, RoutedEventArgs e)
    {
      var client = new RoomServiceClient();
      bool reserved = await client.ReserveRoomAsync(reservation);
      client.Close();

      if (reserved)
        MessageBox.Show("reservation ok");
    }

  }
}
