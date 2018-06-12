using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diem
    // tao animation giao dien login 
{
    public partial class LoadingAnimation : Form
    {
        public LoadingAnimation()
        {
            InitializeComponent();
        }
        int dir = 1;
        // tao timer de load animation 
        private void timer1_Tick(object sender, EventArgs e)
        {
            //gia tri cua thanh circleprocessbar giam khi dat max = 100
            if(circleprocess.Value==100)
            {
                dir = -1;
            }
            //gia tri cua thanh circleprocessbar tang khi min=0
            else if(circleprocess.Value==0)
            {
                dir += 1;
            }
            // gia tri cua thanh circleprocessbar tang khi trong khoang 0-100
            circleprocess.Value += dir;
            timer1.Stop(); 
        }
    }

}
