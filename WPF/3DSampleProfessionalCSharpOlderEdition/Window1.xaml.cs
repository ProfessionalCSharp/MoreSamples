using System;
using System.Collections.Generic;
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
using System.Windows.Media.Media3D;

namespace _3DSample
{
   /// <summary>
   /// Interaction logic for Window1.xaml
   /// </summary>
   public partial class Window1 : Window
   {
      public Window1()
      {
         InitializeComponent();
      }

      private void directionalLight_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
      {
         if (directionalLight != null)
         {
            Vector3D vec = this.directionalLight.Direction;
            vec.X = lightX.Value;
            vec.Y = lightY.Value;
            vec.Z = lightZ.Value;
            this.directionalLight.Direction = vec;
         }
      }

      private void axis_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
      {
         if (axisRotation != null)
         {
            Vector3D vec = this.axisRotation.Axis;
            vec.X = axisX.Value;
            vec.Y = axisY.Value;
            vec.Z = axisZ.Value;
            this.axisRotation.Axis = vec;
         }
      }

      private void axisRotation_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
      {
         if (axisRotation != null)
         {
            this.axisRotation.Angle = this.axisAngle.Value;
         }
      }

      private void camera_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
      {

      }

      private void checkDirectionalLight_Checked(object sender, RoutedEventArgs e)
      {
         if (directionalLight != null)
            directionalLight.Color = Colors.White;
      }

      private void checkDirectionalLight_Unchecked(object sender, RoutedEventArgs e)
      {
         if (directionalLight != null)
            directionalLight.Color = Colors.Black;
      }

      private void checkSpotLight_Checked(object sender, RoutedEventArgs e)
      {
         if (spotLight != null)
            spotLight.Color = Colors.White;

      }

      private void checkSpotLight_Unchecked(object sender, RoutedEventArgs e)
      {
         if (spotLight != null)
            spotLight.Color = Colors.Black;

      }

   }
}
