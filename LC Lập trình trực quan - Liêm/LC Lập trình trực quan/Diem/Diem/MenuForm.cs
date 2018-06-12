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
{
    public partial class MenuForm : Form
    {
        // khai bao cac kieu du lieu
        string ten;
        string maso;
        // list user friendtab de hient hi taon bao ban trong file xml
        List<FriendTab> friendTabs;

        public MenuForm()
        {
            InitializeComponent();
        }
        // tao constructor cho form chat gan hai tham so truyen vao ten hien thi va ma so
        public MenuForm(string Ten, string Maso)
        {
            InitializeComponent();
            ten = Ten;
            maso = Maso;
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            createButtonList();
            // duyet taon bo ban trong file xml moi lan doc tu dong them mot friendtab moi 
            foreach(FriendTab g in friendTabs)
            {
                FriendList.Controls.Add(g);
            }

            
        }
        // ham tao cac user ban list
        void createButtonList()
        {
            friendTabs = new List<FriendTab>();
            //khai bao list tk,mk,stt
            List<string> tk;
            List<string> stt;
            List<string> mk;


            tk = new List<string>();
            stt = new List<string>();
            mk = new List<string>();

            try
            {
                //  gan du lieu xml
                DataSet dataSet = new DataSet();
                // tao file xml
                dataSet.ReadXml("..\\..\\XMLTK.xml");
                // tao mot bang danh sach de gan du lieu tai khoan
                DataTable dt = new DataTable();
                dt = dataSet.Tables["TaiKhoan"];

                foreach (DataRow dr in dt.Rows)
                {
                    // duyet vong lap foreach de gan cac kieu trong xml 
                    tk.Add(dr["Ten"].ToString());
                    mk.Add(dr["Matkhau"].ToString());
                    stt.Add(dr["stt"].ToString());

                }
            }
            catch (Exception)
            { }
            //MessageBox.Show(tk.Count.ToString());
            // vi tri locaiton
            int start = 3;
            int end = 3;
            // duyet vong for de gan stt 
            for (int i = 0; i < stt.Count; i++)
            {
                // so sanh neu stt cau tk dang nhap = stt thu tu cua mot tai khoai trong xml thi continue khong hien thi ban len
                if (String.Compare(maso, stt[i].ToString()) == 0)
                {
                    continue;
                }
                else
                {
                    // list fiendtab them user ban 
                    friendTabs.Add(new FriendTab(tk[i], stt[i], start, end,maso));
                    end += 60;
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
