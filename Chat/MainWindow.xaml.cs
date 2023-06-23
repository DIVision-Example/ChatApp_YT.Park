using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Net;
using System.Net.Sockets;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Chat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<string> messageList = new ObservableCollection<string>();
        public MainWindow() //윈도우 실행
        {
            InitializeComponent();
            messageListView.ItemsSource = messageList;
        }

        private void Send_btn_Click(object sender, RoutedEventArgs e)       //'전송'버튼 클릭시 채팅 전송
        {
            if (string.IsNullOrEmpty(Send_Text_Box.Text)) return;

            string message = Send_Text_Box.Text;

            messageList.Add("나: " + message);   //메세지 채팅창에 입력
            Send_Text_Box.Clear();               //메세지 지우기  

            if(VisualTreeHelper.GetChildrenCount(messageListView) > 0)  // 채팅량이 넘어갔을때 채팅창 유지
            {
                Border border = (Border)VisualTreeHelper.GetChild(messageListView, 0);
                ScrollViewer scrollViewer = (ScrollViewer)VisualTreeHelper.GetChild(border, 0);
                scrollViewer.ScrollToBottom();
            }
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)   //'엔터키' 입력시 채팅 전송
        {
            if(e.Key == Key.Enter) { 
                if (string.IsNullOrEmpty(Send_Text_Box.Text)) return;

                string message = Send_Text_Box.Text;

                messageList.Add("나: " + message);   //메세지 채팅창에 입력
                Send_Text_Box.Clear();               //메세지 지우기  
            }

            if (VisualTreeHelper.GetChildrenCount(messageListView) > 0)  // 채팅량이 넘어갔을때 채팅창 유지
            {
                Border border = (Border)VisualTreeHelper.GetChild(messageListView, 0);
                ScrollViewer scrollViewer = (ScrollViewer)VisualTreeHelper.GetChild(border, 0);
                scrollViewer.ScrollToBottom();
            }
        }
    }
}
