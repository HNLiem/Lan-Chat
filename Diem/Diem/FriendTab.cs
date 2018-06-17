using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// tao uer control hien thi ban
namespace Diem
{
    public partial class FriendTab : UserControl
    {
        // khia bao cac bien ma so ten host va bien ton tai
        string host;
        string name;
        string maso;
        bool isTonTai = false;
        public FriendTab()
        {
            InitializeComponent();
        }
        // khai bao constructor
        public FriendTab(string N,string M,int start,int end,string boss)
        {
            // truyen vao cac tham so mac dinh ma so va cac vi tri location
            InitializeComponent();
            this.Name = N;
            this.maso = M;
            this.Location = new Point(start, end);
            this.setName(N);
            host = boss;
        }
        // set lai ten co friend 
        public void setName(string N)
        {
            name = N;
            FriendName.Text = N;
        }
        // set ma so 
        public void setMaso(string M)
        {
            maso = M;
        }

        private void FriendTab_Load(object sender, EventArgs e)
        {
           
        }
        //viet su kien moi lan lick vao user 
        private void FriendTab_Click(object sender, EventArgs e)
        {
            if (isTonTai == false)
            {
                //khai bao mot form chat
                FormChat withFriend = new FormChat(host, maso);
                // hien thi form chat 
                withFriend.Show();
                // bat ien ton tai =true
                isTonTai = true;
            }
        }
    }
}
