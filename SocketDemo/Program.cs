using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SocketDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 第一次写

            //ServerSocket serverSocket = new ServerSocket();
            //int port = 6000;
            //string host = "127.0.0.1";
            //IPAddress ip = IPAddress.Parse(host);
            //IPEndPoint ipe = new IPEndPoint(ip, port);

            //sSocket.Connect(ip, port);

            //sSocket.ReceiveData();

            //sSocket.Send("你好我是服务器端的信息：hellow");

            //Socket sSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //sSocket.Bind(ipe);
            //sSocket.Listen(0);
            //Console.WriteLine("监听已打开，请等待");

            //接收消息
            //Socket serverSocket = sSocket.Accept();
            //serverSocket._serverSocket = sSocket.Accept();
            //Console.WriteLine("连接已经建立");
            //serverSocket.ReceiveData();
            //string recStr = "";
            //byte[] recByte = new byte[4096];
            //int bytes = serverSocket.Receive(recByte, recByte.Length, 0);
            //recStr += Encoding.ASCII.GetString(recByte, 0, bytes);
            //Console.WriteLine($"服务器端获得信息{recStr}");

            ////发送消息
            //serverSocket.Send("你好我是服务器端的信息：hellow");
            //string sendStr = "发送到客户端：hello";
            //byte[] sendByte = Encoding.ASCII.GetBytes(sendStr);
            //serverSocket.Send(sendByte, sendByte.Length, 0);
            //serverSocket.Close();
            //sSocket.Close();
            #endregion

            #region 第二次写
            /*//主机IP
            IPEndPoint serverIP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8686);
            Console.WriteLine("请选择连接方式：");
            Console.WriteLine("A.Tcp");
            Console.WriteLine("B.Udp");
            ConsoleKey key;
            while (true)
            {
                key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.A)
                {
                    TcpServer(serverIP);
                }
                else if (key == ConsoleKey.B)
                {
                    UdpServer(serverIP);
                }
                else
                {
                    Console.WriteLine("输入有误,请重新输入：");
                    continue;
                }
                break;
            }*/

            #endregion

            #region 第二次使用异步
            AsynTcpServer tcpServer = new AsynTcpServer();
            tcpServer.StartListening();
            #endregion
            Console.Read();
        }

        #region 第二次写使用TCP方法
        /// <summary>
        /// Tcp链接方式
        /// </summary>
        /// <param name="serverIP"></param>
        public static void TcpServer(IPEndPoint serverIP)
        {
            Console.WriteLine("服务端端Tcp连接模式");
            Socket tcpServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            tcpServer.Bind(serverIP);
            tcpServer.Listen(100);//链接队列长度
            Console.WriteLine("开启监听...");

            new Thread(() =>
            {
                while (true)
                {
                    try
                    {
                        //创建一个新的socket链接
                        TcpRecive(tcpServer.Accept());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(string.Format("出现异常：{0}", ex.Message));
                        break;
                    }
                }
            }).Start();
            Console.WriteLine("\n\n输入\"Q\"键退出。");
            ConsoleKey key;
            do
            {
                key = Console.ReadKey(true).Key;
            } while (key != ConsoleKey.Q);
            tcpServer.Close();
        }

        /// <summary>
        /// 接收消息
        /// </summary>
        /// <param name="tcpClient"></param>
        public static void TcpRecive(Socket tcpClient)
        {
            new Thread(() =>
            {
                while (true)
                {
                    byte[] data = new byte[1024];
                    try
                    {
                        int length = tcpClient.Receive(data);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(string.Format("出现异常：{0}", ex.Message));
                        break;
                    }
                    Console.WriteLine($"收到消息：{Encoding.UTF8.GetString(data)}");
                    string sendMsg = "服务端收到信息!";
                    tcpClient.Send(Encoding.UTF8.GetBytes(sendMsg));
                }
            }).Start();
        }
        #endregion

        #region 第二次写用Udp连接方式
        /// <summary>
        /// Udp连接方式
        /// </summary>
        /// <param name="serverIP"></param>
        public static void UdpServer(IPEndPoint serverIP)
        {
            Console.WriteLine("服务端Udp模式");
            Socket udpServer = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            udpServer.Bind(serverIP);
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 0);
            EndPoint Remote = (EndPoint)ipep;
            new Thread(() =>
            {
                while (true)
                {
                    byte[] data = new byte[1024];
                    try
                    {
                        //接收来自服务器的数组
                        int length = udpServer.ReceiveFrom(data, ref Remote);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(string.Format("出现异常：{0}", ex.Message));
                        break;
                    }
                    Console.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} 收到消息：{Encoding.UTF8.GetString(data)}");
                    string sendMsg = "收到消息！";
                    udpServer.SendTo(Encoding.UTF8.GetBytes(sendMsg), SocketFlags.None, Remote);
                }
            }).Start();
            Console.WriteLine("\n\n输入\"Q\"键退出。");
            ConsoleKey key;
            do
            {
                key = Console.ReadKey(true).Key;
            } while (key != ConsoleKey.Q);
            udpServer.Close();
        }
        #endregion
    }
}
