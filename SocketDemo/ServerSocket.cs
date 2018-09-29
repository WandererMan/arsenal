using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketDemo
{
    #region 第一次写

    /*public   class ServerSocket
      {

          public Socket _serverSocket { get; set; }
          /// <summary>
          /// 缓冲区
          /// </summary>
          byte[] MsgBuffer = new byte[1024];

          /// <summary>
          /// 建立连接
          /// </summary>
          /// <param name="ip"></param>
          /// <param name="port"></param>
          //public void Connect(IPAddress ip, int port)
          //{
          //    this._serverSocket.BeginConnect(ip, port, new AsyncCallback(ConnectCallback), this._serverSocket); 
          //}

          //private void ConnectCallback(IAsyncResult ar)
          //{
          //    try
          //    {
          //        Socket handler = (Socket)ar.AsyncState;
          //        handler.EndConnect(ar);
          //    }
          //    catch (Exception ex)
          //    {
          //        Console.WriteLine(ex.Message);
          //    }
          //}

          #region 发送信息
          /// <summary>
          /// 发送消息
          /// </summary>
          /// <param name="data"></param>
          public void Send(string data)
          {
              Send(Encoding.UTF8.GetBytes(data));
          }

          private void Send(byte[] byteData)
          {
              try
              {
                  int length = byteData.Length;
                  byte[] head = BitConverter.GetBytes(length);
                  byte[] data = new byte[head.Length + byteData.Length];
                  Array.Copy(head, data, head.Length);
                  Array.Copy(byteData, 0, data, head.Length, byteData.Length);
                  this._serverSocket.BeginSend(data, 0, data.Length, 0, new AsyncCallback(SendCallback), this._serverSocket);
              }
              catch (Exception ex)
              {
                  Console.WriteLine(ex.Message);
              }
          }

          private void SendCallback(IAsyncResult ar)
          {
              try
              {
                  Socket handle = (Socket)ar.AsyncState;
                  handle.EndSend(ar);
              }
              catch (Exception ex)
              {
                  Console.WriteLine(ex.Message);
              }
          }
          #endregion

          #region 接收信息
          public void ReceiveData()
          {
              _serverSocket.BeginReceive(MsgBuffer, 0, MsgBuffer.Length, 0, new AsyncCallback(ReceiveCallback), null);
          }
          private void ReceiveCallback(IAsyncResult ar)
          {
              try
              {
                  int REnd = _serverSocket.EndReceive(ar);
                  if (REnd > 0)
                  {
                      byte[] data = new byte[REnd];
                      Array.Copy(MsgBuffer, 0, data, 0, REnd);
                      //在此可以对data进行按需处理
                      _serverSocket.BeginReceive(MsgBuffer, 0, MsgBuffer.Length, 0, new AsyncCallback(ReceiveCallback), null);  

                      Console.WriteLine($"服务器端获得信息{Encoding.UTF8.GetString(data)}");
                  }
                  else
                  {
                      Dispose();
                  }
              }
              catch (Exception ex)
              {
                  Console.WriteLine(ex.Message);
              }
          }

          private void Dispose()
          {
              try
              {
                  this._serverSocket.Shutdown(SocketShutdown.Both);
                  this._serverSocket.Close();
              }
              catch (Exception ex)
              {
                  Console.WriteLine(ex.Message);
              }
          }
          #endregion
      }*/
    #endregion

    #region 第二次写TCP
    public class AsynTcpServer
    {
        #region Tcp协议异步监听
        /// <summary>
        /// Tcp协议异步通讯类（服务器端）
        /// </summary>
        public void StartListening()
        {
            IPEndPoint serverIp = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8686);
            Socket tcpServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            tcpServer.Bind(serverIp);
            tcpServer.Listen(100);
            Console.WriteLine("异步开启监听");
            AsynAccept(tcpServer);
        }
        #endregion

        #region 异步链接客户端
        /// <summary>
        /// 异步链接客户端
        /// </summary>
        /// <param name="tcpServer"></param>
        public void AsynAccept(Socket tcpServer)
        {
            tcpServer.BeginAccept(asyncResult =>
            {
                Socket tcpClient = tcpServer.EndAccept(asyncResult);
                Console.WriteLine($"server<---<--{tcpClient.RemoteEndPoint}");
                AsynAccept(tcpServer);
                AsynRecive(tcpClient);

            }, null);
        }
        #endregion

        #region 异步接受客户端消息
        /// <summary>
        /// 异步接受客户端消息
        /// </summary>
        /// <param name="tcpClient"></param>
        public void AsynRecive(Socket tcpClient)
        {
            byte[] data = new byte[1024];
            try
            {
                tcpClient.BeginReceive(data, 0, data.Length, SocketFlags.None,
                    asyncResult =>
                    {
                        int length = tcpClient.EndReceive(asyncResult);
                        Console.WriteLine($"server<--<--client:{Encoding.UTF8.GetString(data)}");
                        AsynSend(tcpClient, "服务端收到消息");
                        AsynRecive(tcpClient);
                    }, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine("异常信息：{0}", ex.Message);
            }
        }
        #endregion

        #region 异步发送消息
        /// <summary>
        /// 异步发送消息
        /// </summary>
        public void AsynSend(Socket tcpClient, string message)
        {
            byte[] data = Encoding.UTF8.GetBytes(message);
            try
            {
                tcpClient.BeginSend(data, 0, data.Length, SocketFlags.None,
                    asyncResult =>
                    {
                        int length = tcpClient.EndSend(asyncResult);
                        Console.WriteLine($"server-->-->client:{message}");
                    }, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine("异常信息：{0}", ex.Message);
            }
        }
        #endregion
    }
    #endregion

    #region 第二次写Udp

    public class AsynUdpServer
    {
        #region 容器对象
        /// <summary>
        /// 容器对象
        /// </summary>
        public class StateObject
        {
            /// <summary>
            /// 服务器端
            /// </summary>
            public Socket udpServer = null;

            /// <summary>
            /// 接收数据缓冲区
            /// </summary>
            public byte[] buffer = new byte[1024];

            /// <summary>
            /// 远程终端
            /// </summary>
            public EndPoint remoteEP;

        }
        public StateObject state;
        #endregion

        #region 服务器绑定终端节点
        /// <summary>
        /// 服务器绑定终端节点
        /// </summary>
        public void ServerBind()
        {
            //主机IP
            IPEndPoint serverIp = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8686);
            Socket udpServer = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            udpServer.Bind(serverIp);
            Console.WriteLine("服务端 读取中.....");
            IPEndPoint clientIp = new IPEndPoint(IPAddress.Any, 0);
            state = new StateObject();
            state.udpServer = udpServer;
            state.remoteEP = clientIp;
            AsynRecive();
        }
        #endregion

        #region 异步接收消息
        /// <summary>
        /// 异步接收消息
        /// </summary>
        public void AsynRecive()
        {
            state.udpServer.BeginReceiveFrom(state.buffer, 0, state.buffer.Length, SocketFlags.None, ref state.remoteEP, new AsyncCallback(ReciveCallback), state);//这里写入为state案例为null
        }
        #endregion

        #region 异步接收消息回调函数
        /// <summary>
        /// 异步接收消息回调函数
        /// </summary>
        /// <param name="asyncResult"></param>
        public void ReciveCallback(IAsyncResult asyncResult)
        {
            //是否完成异步操作
            if (asyncResult.IsCompleted)
            {
                IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 0);
                EndPoint remoteEP = ipep;
                state.udpServer.EndReceiveFrom(asyncResult, ref remoteEP);
                Console.WriteLine($"server<--<--client:{Encoding.UTF8.GetString(state.buffer)}");
                //向发送端通知：收到消息
                state.remoteEP = remoteEP;
                AsynSend("收到消息");
                //继续接受消息
                AsynRecive();
            }
        }
        #endregion

        #region 异步发送消息
        /// <summary>
        /// 异步发送消息
        /// </summary>
        /// <param name="message"></param>
        public void AsynSend(string message)
        {
            Console.WriteLine("server-->-->client:{0}", message);
            byte[] buffer = Encoding.UTF8.GetBytes(message);
            state.udpServer.BeginSendTo(buffer, 0, buffer.Length, SocketFlags.None, state.remoteEP,
                new AsyncCallback(SendCallback), null);
        }
        #endregion

        #region 异步发送消息回调函数
        /// <summary>
        /// 异步发送消息回调函数
        /// </summary>
        /// <param name="asyncResult"></param>
        public void SendCallback(IAsyncResult asyncResult)
        {
            //消息发送完毕
            if (asyncResult.IsCompleted)
            {
                state.udpServer.EndSendTo(asyncResult);
            }
        }
        #endregion
    }
    #endregion
}
