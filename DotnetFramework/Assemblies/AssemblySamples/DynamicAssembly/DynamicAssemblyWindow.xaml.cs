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

namespace Wrox.ProCSharp.Assemblies
{
  /// <summary>
  /// Interaction logic for Window1.xaml
  /// </summary>
  public partial class DynamicAssemblyWindow : Window
  {
    public DynamicAssemblyWindow()
    {
      InitializeComponent();
    }

    private void Compile_Click(object sender, RoutedEventArgs e)
    {
      textOutput.Background = Brushes.White;
      var driver = new CodeDriverInAppDomain();
      bool isError;
      textOutput.Text = driver.CompileAndRun(textCode.Text, out isError);
      if (isError)
      {
        textOutput.Background = Brushes.Red;
      }




    }
  }
}
