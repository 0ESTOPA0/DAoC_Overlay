using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Winook;


namespace DAoC_Overlay_Target
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MouseHook _mouseHook;

        public MainWindow()
        {
            InitializeComponent();

            var _mouseHook = new MouseHook(Process.GetProcessesByName("game.dll").FirstOrDefault().Id);
            _mouseHook.MessageReceived += MouseHook_MessageReceived;

            _mouseHook.AddMouseHandler(MouseMessageCode.LeftButtonDown, MouseHook_ButtonDown);
            _mouseHook.AddMouseHandler(MouseMessageCode.LeftButtonUp, MouseHook_ButtonUp);
            //_mouseHook.MessageReceived += MouseHook_LeftButtonDown;
            //_mouseHook.LeftButtonUp += MouseHook_LeftButtonUp;
            _mouseHook.InstallAsync();
        }

        private void MouseHook_ButtonUp(object sender, MouseMessageEventArgs e)
        {
            Debug.WriteLine($"Mouse Message UUPPPPPP Code: {e.MessageCode}; X: {e.X}; Y: {e.Y}; Delta: {e.Delta}");

        }

        private void MouseHook_ButtonDown(object sender, MouseMessageEventArgs e)
        {
            Debug.WriteLine($"Mouse Message DOWWWWWWN Code: {e.MessageCode}; X: {e.X}; Y: {e.Y}; Delta: {e.Delta}");
        }

        private void MouseHook_MessageReceived(object sender, MouseMessageEventArgs e)
        {
           // Debug.WriteLine($"Mouse Message Code: {e.MessageCode}; X: {e.X}; Y: {e.Y}; Delta: {e.Delta}");
        }

    }
}
