using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diem
{
    public partial class LoginForm : Form
    {

        private Taikhoan taikhoan = new Taikhoan();
        private taikhoanxml tkxml = new taikhoanxml();
        MenuForm menuForm;



        public LoginForm()
        {
            InitializeComponent();
            //this.Size =new Size (330, 580);
            
        }

        //event nut dangnhap ,kiem tra dung ten tai khoan va mat khau

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            taikhoan.Tentaikhoan = txbTaiKhoan.Text;
            taikhoan.Matkhau = txbMatKhau.Text;
            if(tkxml.dangnhap(taikhoan)== true)
            {
                this.Hide();

                Thread t = new Thread(new ThreadStart(Loadinganimation));
                t.Start();
                Thread.Sleep(3000);
                t.Abort();

                menuForm = new MenuForm(txbTaiKhoan.Text, tkxml.Stt);
                menuForm.Show();

                void Loadinganimation()
                {
                    Application.Run(new LoadingAnimation());
                }
                
                //MessageBox.Show("Đăng nhập thành công");
                
                //menuForm = new MenuForm(txbTaiKhoan.Text, tkxml.Stt);            
                //menuForm.Show();
                //menuForm.Activate();
                
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng");
            }
        }

        //animation cho nut chuyen form sign in toi register
        
        

        //event nut dangki , kiem tra viec nhap ten tai khoan,tai khoan da ton tai .
        private void btdangki_Click(object sender, EventArgs e)
        {
            if (txbtendk.Text.Trim() != "" && txbmkdk.Text.Trim() != "")
            {
                if (tkxml.timkiem(txbtendk.Text) == true)
                {
                    taikhoan.Tentaikhoan = txbtendk.Text;
                    taikhoan.Matkhau = txbmkdk.Text;
                    tkxml.dangky(taikhoan);
                }
                else
                {
                    MessageBox.Show("Tài khoản đã tồn tại");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin tài khoản");
            }



        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

      

      

        private void label1_Click(object sender, EventArgs e)
        {
            this.timer1.Enabled = true;
           
        }
        // timer login load form dang ky
        private void timer1_Tick(object sender,EventArgs e)
        {
            if (this.Width > 676)
                this.timer1.Enabled = false;
            else this.Width += 12;

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.timer2.Enabled = true;
        }

     // timer loadlogin vào ứng dụng form chuyển giao diện 

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (this.Width < 338)
                this.timer2.Enabled = false;
            else this.Width -= 12;
        }
    }
}
