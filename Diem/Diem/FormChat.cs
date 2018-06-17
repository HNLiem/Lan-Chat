using System;
using System.IO;
using System.Media;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;

namespace Diem
{
    public partial class FormChat : Form
    {
        // tao ip va socket de ket noi du lieu toi sever
        private IPEndPoint IP;
        string myip;
        private Socket client;
        string maso;
        string friend;
        public FormChat()
        {
            InitializeComponent();
            Connect();
         
        }

       

    

        public FormChat(string maSoChu,string maSoCuaKhach)
        {
            // lay ma so cua may hien hanh va may khach 
            InitializeComponent();
            maso = maSoChu;
            friend = maSoCuaKhach;
            Connect();
            //MessageBox.Show("Ma so nguoi dung" + stt);
        }

        private void Connect()
        {
            // lay ip mac dinh cua may 
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress diachi in host.AddressList)
            {
                if (diachi.AddressFamily.ToString() == "InterNetwork")
                {
                    myip = diachi.ToString();
                }
            }
            // tao socket de ket noi toi sever ip: mac dinh cua may port 6740
            IP = new IPEndPoint(IPAddress.Parse(myip), 6740);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            try
            {
                client.Connect(IP);
            }
            catch
            {
                MessageBox.Show("Cannot connect to server" + MessageBoxButtons.OK + MessageBoxIcon.Error);
                return;
            }
            // tao luong de nhan tin nhan
            Thread listen = new Thread(Receive);
            listen.IsBackground = true;
            listen.Start();
        }
        // ham dong ket noi
        private void Disconnect()
        {
            client.Close();
        }
        // ham gui tin nhan
        private void Send()
        {
            if (tbMessage.Text != string.Empty)
            {
                // tin nhan =tin gui + ma so may hien hanh ma so may khach de xac dinh dia chi tin nhan den 
                string messcan = tbMessage.Text + maso + friend;
               
                client.Send(Serialize(messcan));
            }
        }
        //ham nhan tin nhan
        private void Receive()
        {
            try
            {
                while (true)
                {
                    // khai bao byte data de gui tin nhan
                    byte[] data = new byte[1024];
                    client.Receive(data);
                    // chuyen kieu trong ham gom manh 
                    string message = Deserialize(data) as string;
                    // lay tin nhan de hien thi tru ma so cua may hien hanh va may khach
                    string messHien = message.Substring(0, message.Length - 2);
                    // lay cac ma so cua may chu va may khach
                    string cuatoi = message.Substring(message.Length - 2, 1);
                    string cuaban = message.Substring(message.Length - 1);
                    if (maso == cuaban && friend  == cuatoi)
                    {
                        AddMessagemefriend(messHien);
                    }
                }
            }
            catch
            {
                // loi ngatket noi toi sever
                Disconnect();
            }
        }
        // add message len listview
        private void AddMessageme(string message)
        {
            // tin nhan cua may hien hanh guidi them vao truoc tin nhan " Me:"
            lvMessage.Items.Add(new ListViewItem() { Text = "Me: " + message });
            // chuyển tin nhắn tron textbox message thanh null sau moi lan gui
            tbMessage.Text = null;
        }
        // add tin nhan cua ban len listview
        private void AddMessagemefriend(string message)
        {
            // tin nhan cua ban them "Friend: " vao truoc tin nhan
            lvMessage.Items.Add(new ListViewItem() { Text = "Friend: " + message });

            tbMessage.Text = null;
        }
        // ham phan manh
        // truyen vao mot kieu du lieu string de tien hanh phan manh
        // lan chat khong nhan duoc cac kieu string ... nen phan manh thanh kieu nhi phan de gui di
        private byte[] Serialize(string obj)
        {
            // khai bao cac bien de tien hanh phan manh 
            MemoryStream stream = new MemoryStream();
            // phan manh thanh khieu nhi phan
            BinaryFormatter formatter = new BinaryFormatter();
            // phan manh du lieu truyen vao obj thanh kieu nhi phan va gan vao stream
            formatter.Serialize(stream, obj);
            // tra vemang nhi phan vua moi phan manh
            return stream.ToArray();
        }
        // gom manh tin nhan de hien thi tren listview
        // truyen vao mot manh byte de tien hanh gom manh tin nhan
        private object Deserialize(byte[] data)
        {
            // khai bao cac bien de tien hanh gom manh
            MemoryStream stream = new MemoryStream(data);
            BinaryFormatter formatter = new BinaryFormatter();
            // gom manh tu stream 
            return formatter.Deserialize(stream);
        }

        // khi nguoi dung nhan vao nut button gui tin nhan
        private void btnsend_Click(object sender, EventArgs e)
        {
            // goi ham send 
            Send();
            // add tin nhan vao man hinh listview
            AddMessageme(tbMessage.Text);
            // tao mot am thanh khi nguoi dung gui tin nhan de thong baoa
            SoundPlayer sp = new SoundPlayer();
            sp.SoundLocation = "click.wav";
            sp.Play();
            // thay click button thanh phim enter
            this.AcceptButton = btnsend;
        }
        // moi lan dong form thi tu dong ngat ket noi toi sever
        private void FormChat_FormClosed(object sender, FormClosedEventArgs e)
        {
            Disconnect();
        }

       
      
        // dong form 
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
