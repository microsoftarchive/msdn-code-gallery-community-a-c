using System;
using System.Collections.Generic;
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
using System.Net;
using System.Net.Sockets;
using System.Timers;
using System.IO;
using System.Diagnostics;


namespace talk2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        public static System.Timers.Timer aTimer = new System.Timers.Timer(2);
        public static System.Timers.Timer bTimer = new System.Timers.Timer(1500);

        //initialising global variables
        public static string _ip_address;
        public static string text_db_format;
        public static string _time_stamp;
        public static double progressBarValue;
        public static string messageFormat;


        //Strict definition of users
        static string[] users = new string[] { "pass", "Raymond", "raymond"};
        static string pass = users[0];


        // == variables ==
        // variables used for communication
        Socket sckCommunication;
        EndPoint epLocal, epRemote;

        byte[] buffer;

        // return your own ip
        private string GetLocalIP()
        {
            IPHostEntry host;
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return "127.0.0.1";
        }

        private void talk2load(object sender, EventArgs e)
        {
            // set up socket
            sckCommunication = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            sckCommunication.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

            // fill textbox with own ip
            txtLocalIp.Text = GetLocalIP();
        }


        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (epLocal == null && epRemote == null)
                {
                    if (txtFriendsPort.Text != "" && txtLocalPort.Text != "")
                    {
                        // bind socket                        
                        epLocal = new IPEndPoint(IPAddress.Parse(txtLocalIp.Text), Convert.ToInt32(txtLocalPort.Text));
                        sckCommunication.Bind(epLocal);

                        // connect to remote ip and port
                        epRemote = new IPEndPoint(IPAddress.Parse(txtFriendsIp.Text), Convert.ToInt32(txtFriendsPort.Text));
                        sckCommunication.Connect(epRemote);

                        // starts to listen to an specific port
                        buffer = new byte[1464];
                        sckCommunication.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epRemote, new AsyncCallback(OperatorCallBack), buffer);

                        // release button to send message
                        btnSend.IsEnabled = true;

                        status.Text = "Connected";
                    }
                    else
                    {
                        status.Text = "Port input cannot be Empty";
                    }
                }
                else
                {
                    status.Text = "You are already Connected";
                    btnSend.IsEnabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void OperatorCallBack(IAsyncResult ar)
        {
            try
            {
                int size = sckCommunication.EndReceiveFrom(ar, ref epRemote);

                this.Dispatcher.Invoke(() =>
                {
                    // check if theres actually information
                    if (size > 0)
                    {
                        // used to help us on getting the data
                        byte[] aux = new byte[1464];

                        // gets the data
                        aux = (byte[])ar.AsyncState;


                        // Remove byte array trailing zeros
                        int i = aux.Length - 1;
                        while (aux[i] == 0)
                            --i;

                        byte[] auxtrim = new byte[i + 1];
                        Array.Copy(aux, auxtrim, i + 1);


                        // converts from data[] to string
                        System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
                                            
                        string msg = enc.GetString(auxtrim);

                        // adds to listbox
                        listBox1.Items.Add(msg);

                        if ((bool)save_chat_check.IsChecked)
                        {
                            messageFormat =  msg;
                            saveToText();
                        }

                    }
                });

                // starts to listen again
                buffer = new byte[1464];
                sckCommunication.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref epRemote, new AsyncCallback(OperatorCallBack), buffer);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtMessage.Text != "")
                {
                    // converts from string to byte[]
                    System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();

                    byte[] msg = new byte[1464];

                    messageFormat = id_in.Text + ": " + txtMessage.Text;

                    msg = enc.GetBytes(messageFormat);

                    // sending the message
                    sckCommunication.Send(msg);

                    // add to listbox
                    listBox1.Items.Add(messageFormat);

                    //save to text if box is checked
                    if ((bool)save_chat_check.IsChecked)
                    {
                        saveToText();
                    }

                    // clear txtMessage
                    txtMessage.Clear();
                }
                else
                {
                    status.Text = "Cannot Send Blank Message!";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string get_Time()
        {
            _time_stamp = DateTime.Now.ToString("h:mm:ss tt");
            return _time_stamp;
        }



        private void isUserTyping(object sender, KeyEventArgs e)
        {
            if (btnSend.IsEnabled == true)
            {
                status.Text = "You are typing";
            }
            else
            {
                status.Text = "You are not Connected";
            }
        }

        //saves chat to text file
        private void saveToText()
        {
            try
            {
                string path = @"C:\talk2.txt";

                //check if text file already exists, if not create one
                if (!File.Exists(path))
                {
                    File.WriteAllText(@"C:\talk2.txt", String.Empty);
                }
                using (StreamWriter file = new StreamWriter(@"C:\talk2.txt", true))
                {
                    file.WriteLine(get_Time() +": "+ messageFormat);
                }
            }
            catch (UnauthorizedAccessException)
            {
                status.Text = "Error. Run as Administrator";
                MessageBox.Show("Run as Administrator to save chat");
            }
            catch (Exception ex)
            {
                status.Text = ex.Message;
            }
        }

        //user login authentication
        private void loginBtnClicked(object sender, RoutedEventArgs e)
        {
            if (users.Contains(id_in.Text) && pass_in.Password == pass)
            {
                aTimer.Enabled = true;
                aTimer.Start();
                aTimer.Elapsed += new ElapsedEventHandler(progressBarAdd);

                bTimer.Enabled = true;
                bTimer.Start();
                bTimer.Elapsed += new ElapsedEventHandler(loggedIn);
                progressBar.Visibility = Visibility.Visible;
            }
            else
            {
                status.Text = "Login Failed. Try Again with valid credentials";
            }
        }

        private void loggedIn(object sender, ElapsedEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                status.Text = "Logged In";
                id_in.Visibility = Visibility.Hidden;
                pass_in.Visibility = Visibility.Hidden;
                idTag.Content = id_in.Text;
                passTag.Content = "****";
                Canvas.SetZIndex(access_blocker, (int)-1);
                txtLocalIp.IsEnabled = true;
                txtFriendsIp.IsEnabled = true;
                txtLocalPort.IsEnabled = true;
                txtFriendsPort.IsEnabled = true;
                logout_btn.IsEnabled = true;
                login_btn.IsEnabled = false;
                btnStart.IsEnabled = true;
                progressBar.Visibility = Visibility.Hidden;
            });
        }

        private void logoutBtnClicked(object sender, RoutedEventArgs e)
        {
            status.Text = "Logged Out";
            id_in.Visibility = Visibility.Visible;
            pass_in.Visibility = Visibility.Visible;
            idTag.Content = "";
            passTag.Content = "";
            Canvas.SetZIndex(access_blocker, (int)1);
            txtLocalIp.IsEnabled = false;
            txtFriendsIp.IsEnabled = false;
            txtLocalPort.IsEnabled = false;
            txtFriendsPort.IsEnabled = false;
            logout_btn.IsEnabled = false;
            login_btn.IsEnabled = true;
            btnStart.IsEnabled = false;
            btnSend.IsEnabled = false;
            listBox1.Items.Clear();
            progressBar.Value = 0;
            bTimer.Stop();

        }

        private void progressBarAdd(object sender, ElapsedEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                if (progressBar.Value != 100)
                {
                    progressBar.Value += 1;
                    progressBarValue = progressBar.Value;
                }
                else
                {
                    aTimer.Stop();
                }
            });
        }

        private void sendMessage(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                try
                {
                    if (txtMessage.Text != "")
                    {
                        // converts from string to byte[]
                        System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();

                        byte[] msg = new byte[1464];

                        messageFormat = id_in.Text + ": " + txtMessage.Text;

                        msg = enc.GetBytes(messageFormat);

                        // sending the message
                        sckCommunication.Send(msg);

                        // add to listbox
                        listBox1.Items.Add(messageFormat);

                        //save to text if box is checked
                        if ((bool)save_chat_check.IsChecked)
                        {
                            saveToText();
                        }

                        // clear txtMessage
                        txtMessage.Clear();
                    }
                    else
                    {
                        status.Text = "Cannot Send Blank Message!";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        //opens chat history from drive
        private void open_chat_history(object sender, RoutedEventArgs e)
        {
            string path = @"C:\talk2.txt";
            try
            {
                if (File.Exists(path))
                {
                    ProcessStartInfo start = new ProcessStartInfo();
                    start.FileName = @"C:\talk2.txt";
                    Process.Start(start);
                }
                else
                {
                    File.WriteAllText(@"C:\talk2.txt", String.Empty);
                    ProcessStartInfo start = new ProcessStartInfo();
                    start.FileName = @"C:\talk2.txt";
                    Process.Start(start);
                }
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Start Program as Administrator");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
  
    }
}
