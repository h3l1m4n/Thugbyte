using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace WindowsFormsApplication1
{
    internal class SimpleClient
    {
        public delegate void ResponseCompleteEventHandler();
        public event ResponseCompleteEventHandler ResponsComplete;
        private readonly IniFile _myIni;
        private TcpClient mTcpClient;
        private byte[] mRx;
        public SimpleClient()
        {
            _myIni = new IniFile();
            IPAddress ipa = System.Net.IPAddress.Parse((_myIni.Read("Serverip", "ServerClient")));
            int nPort = Convert.ToInt32(_myIni.Read("Serverport", "ServerClient")); 

            mTcpClient = new TcpClient();
            mTcpClient.BeginConnect(ipa, nPort, onCompleteConnect, mTcpClient);
        }

        void onCompleteConnect(IAsyncResult iar)
        {
            TcpClient tcpc;

            try
            {
                tcpc = (TcpClient) iar.AsyncState;
                    tcpc.EndConnect(iar);
                mRx = new byte[512];
                tcpc.GetStream().BeginRead(mRx, 0, mRx.Length, OnCompleteReadFromServerStream, tcpc);
            }
            catch (Exception)
            {
                Console.WriteLine("Error connecting");
             
            }
        }

        public void Send(string msg)
        {
            byte[] tx;
            Console.WriteLine(msg);
            try
            {
                tx = Encoding.ASCII.GetBytes(msg);
                Console.WriteLine(tx.Length);
                if (mTcpClient != null)
                {
                    if (mTcpClient.Client.Connected)
                    {
                        mTcpClient.GetStream().BeginWrite(tx, 0, tx.Length, onCompleteWriteToServer, mTcpClient);
                    }
                }
            }
            catch (Exception)
            {
                
                throw;
            }

        }

        void onCompleteWriteToServer(IAsyncResult iar)
        {
            TcpClient tcpc;
            try
            {
                tcpc = (TcpClient) iar.AsyncState;
                tcpc.GetStream().EndWrite(iar);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        void OnCompleteReadFromServerStream(IAsyncResult iar)
        {
            TcpClient tcpc;
            int nCountBytes;
            string strRec;
            try
            {
                tcpc = (TcpClient) iar.AsyncState;
                nCountBytes = tcpc.GetStream().EndRead(iar);
                if (nCountBytes == 0)
                {
                    Console.WriteLine("Connection Aborted");
                    return;
                }
                strRec = Encoding.ASCII.GetString(mRx, 0, nCountBytes);

                Console.WriteLine("Server Said: " + strRec);
                if (ResponsComplete != null) ResponsComplete();
                mRx = new byte[512];
                tcpc.GetStream().BeginRead(mRx, 0, mRx.Length, OnCompleteReadFromServerStream, tcpc);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

 
    }

}
