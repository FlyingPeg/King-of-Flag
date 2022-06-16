using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Server
{
    public partial class ServerForm : Form
    {
        public ServerForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

        }
        IPEndPoint IP;
        Socket server;
        List<Socket> clientList;

        void Receive(Object obj)
        {
            Socket client = obj as Socket;
            try
            {
                while (true)
                {
                    byte[] data = new byte[4096];
                    client.Receive(data);

                    string message = (string)Deserialize(data);

                    foreach (var item in clientList)
                    {
                        if (item != null && item != client)
                            item.Send(Serialize(message));
                    }
                }
            }
            catch
            {
                clientList.Remove(client);
                client.Close();
            }
        }
        
        byte[] Serialize(object obj)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, obj);
            return stream.ToArray();
        }

        object Deserialize(byte[] data)
        {
            MemoryStream stream = new MemoryStream(data);
            BinaryFormatter formatter = new BinaryFormatter();
            return formatter.Deserialize(stream);
        }

        private void btnLis_Click(object sender, EventArgs e)
        {
            try
            {
                lbl_Check.Text = "";
                clientList = new List<Socket>();
                IP = new IPEndPoint(IPAddress.Any, 8888);
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                server.Bind(IP);

                Thread Listen = new Thread(() =>
                {
                    try
                    {
                        while (true)
                        {
                            server.Listen(100);
                            Socket client = server.Accept();
                            clientList.Add(client);
                            Thread receive = new Thread(Receive);
                            receive.IsBackground = true;
                            receive.Start(client);
                            lbl_Check.Text = "Listening...";
                        }
                    }
                    catch
                    {
                        IP = new IPEndPoint(IPAddress.Any, 8888);
                        server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

                    }
                });
                Listen.IsBackground = true;
                Listen.Start();
            }
            catch (Exception){}
            
        }
    }
}

