using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NAudio.CoreAudioApi;

namespace WindowsFormsApplication1
{
    class SimpleServer
    {
        
        private TcpListener mTcpListener;
        private byte[] mRx;
        public  List<ClientNode> mlclientsocks;
        public delegate void ClientResponseCompleteEventHandler(string msg);
        public event ClientResponseCompleteEventHandler ClientResponse;
        private readonly IniFile _myIni;
        public SimpleServer()
        {
            _myIni = new IniFile();
            StartListener();

        }

        private  void StartListener()
        {
            mlclientsocks = new List<ClientNode>(2);
            IPAddress ipaddr = IPAddress.Any;
            int nPort = Convert.ToInt32(_myIni.Read("Serverport", "ServerClient"));

            mTcpListener = new TcpListener(ipaddr,nPort);

            mTcpListener.Start();

            mTcpListener.BeginAcceptTcpClient(OnCompleteAcceptTcpClient, mTcpListener);

        }

        void OnCompleteAcceptTcpClient(IAsyncResult iar)
        {
            TcpListener tcpl = (TcpListener)iar.AsyncState;
            TcpClient tclient = null;
            ClientNode cNode = null;

            try
            {

                tclient = tcpl.EndAcceptTcpClient(iar);
                // mTcpClient = tcpl.EndAcceptTcpClient(iar);
                Console.WriteLine("Client Connected");


                tcpl.BeginAcceptTcpClient(OnCompleteAcceptTcpClient, tcpl);

             
               mlclientsocks.Add((cNode = new ClientNode(tclient,new byte[512],new byte[512],tclient.Client.RemoteEndPoint.ToString())));




                tclient.GetStream().BeginRead(cNode.Rx, 0, cNode.Rx.Length, OnCompleteReadFromTcpClientStream, tclient);
            }
            catch (Exception exc)
            {
                
                Console.Write(exc.Message);
            }
           

        }

      public  void writeToStream(TcpClient tc,string messageToWrite)
        {

            byte[] tx = new byte[512];
            try
            {
                if (tc != null)
                {
                    if (tc.Client.Connected)
                    {
                        tx = Encoding.ASCII.GetBytes(messageToWrite);
                        Console.WriteLine(tx.Length);
                        tc.GetStream().BeginWrite(tx, 0, tx.Length, OnCompleteWriteToClientStream, tc);
                    }
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void OnCompleteWriteToClientStream(IAsyncResult iar)
        {
            try
            {
                TcpClient tcpc = (TcpClient) iar.AsyncState;
                tcpc.GetStream().EndWrite(iar);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        void OnCompleteReadFromTcpClientStream(IAsyncResult iar)
        {
            TcpClient tcpc;
            int nCountReadBytes = 0;
            string strRecv;
            ClientNode cn = null;
            try
            {
                tcpc = (TcpClient) iar.AsyncState;

                cn = mlclientsocks.Find(x => x.strId == tcpc.Client.RemoteEndPoint.ToString());

                nCountReadBytes = tcpc.GetStream().EndRead(iar);

                if (nCountReadBytes == 0)
                {
                    Console.WriteLine("Client Disconnected");
                    mlclientsocks.Remove(cn);
                   
                    return;
                }

                strRecv = Encoding.ASCII.GetString(cn.Rx, 0, nCountReadBytes).Trim();

                Console.WriteLine("Rev: " + strRecv);
                if (strRecv != "\0")
                {
                      if (ClientResponse != null) ClientResponse(strRecv);
                }
              

                mRx = new byte[512];

                tcpc.GetStream().BeginRead(cn.Rx, 0, cn.Rx.Length, OnCompleteReadFromTcpClientStream, tcpc);
            }
            catch (Exception)
            {
               
                    mlclientsocks.Remove(cn);
                
                
            }
        }
    }
}
