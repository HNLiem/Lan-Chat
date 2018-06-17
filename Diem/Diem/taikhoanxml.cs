using System;
using System.Collections.Generic;
using System.Data;
using System.Xml;

namespace Diem
{
    internal class taikhoanxml
    {
        //tao bien de doc file xml va goc xml
        private XmlDocument doc = new XmlDocument();

        // tao goc xml
        private XmlElement root;

        //string fileName = @"C:\Users\ADMIN\Desktop\DoAnTrucQuan-master\LanChat\Client\taikhoanxml.cs";
        private string fileName = @"XMLTK.xml";

        public string Stt;

        public taikhoanxml()
        {
            //doc file xml
            doc.Load(fileName);
            //gan goc cua file xml

            root = doc.DocumentElement;
        }

        public void dangky(Taikhoan taikhoan)
        {
            //tao danh sach so thu tu 
            List<string> stt;

            stt = new List<string>();

            
            try
            {   //lay stt de dang ki
                DataSet dataSet = new DataSet();
                dataSet.ReadXml("..\\..\\XMLTK.xml");
                DataTable dt = new DataTable();
                dt = dataSet.Tables["TaiKhoan"];

                // them stt vao list stt
                foreach (DataRow dr in dt.Rows)
                {
                    stt.Add(dr["stt"].ToString());
                }
            }
            catch (Exception)
            { }

            //stt dang ki moi bang stt nguoi dang ki cuoi cung +1 
            string sothutu = (stt.Count + 1).ToString();

            //tao phan tu tai khoan
            XmlElement tk = doc.CreateElement("TaiKhoan");
            //tao phan tu ten
            XmlElement Ten = doc.CreateElement("Ten");

            //gan du lieu vao ten
            Ten.InnerText = taikhoan.Tentaikhoan;
            //add vao ten
            tk.AppendChild(Ten);
            //gan du lieu vao mk
            XmlElement Matkhau = doc.CreateElement("Matkhau");
            Matkhau.InnerText = taikhoan.Matkhau;
            //add vao mat khau
            tk.AppendChild(Matkhau);

            XmlElement tt = doc.CreateElement("stt");
            tt.InnerText = sothutu;
            //add stt
            tk.AppendChild(tt);
            //luu vao file xml
            root.AppendChild(tk);
            doc.Save(fileName);
        }

        //sua tai khoan
        public void sua(Taikhoan taikhoan)
        {
            XmlNode taikhoancu = root.SelectSingleNode("TaiKhoan[Ten='" + taikhoan.Tentaikhoan + "']");
            if (taikhoancu != null)
            {
                XmlNode taikhoansuamoi = doc.CreateElement("Taikhoan");

                XmlElement Ten = doc.CreateElement("Ten");
                Ten.InnerText = taikhoan.Tentaikhoan;
                taikhoansuamoi.AppendChild(Ten);

                XmlElement Matkhau = doc.CreateElement("Matkhau");
                Matkhau.InnerText = taikhoan.Matkhau;
                taikhoansuamoi.AppendChild(Matkhau);
                doc.Save(fileName);
            }
        }

        //tim kiem ten tk
        public bool timkiem(string name)
        {
            XmlNode taikhoan = root.SelectSingleNode("TaiKhoan[Ten='" + name + "']");
            if (taikhoan != null)
            {
                return false;
            }
            return true;
        }

        //dang nhap vao phan mem
        public bool dangnhap(Taikhoan taikhoan)
        {
            List<string> tk;
            List<string> mk;

            bool isTonTaiTk = false;
            int i = 0;
            tk = new List<string>();
            mk = new List<string>();

            try
            {
                //doc file xml
                DataSet dataSet = new DataSet();
                dataSet.ReadXml("..\\..\\XMLTK.xml");
                DataTable dt = new DataTable();
                dt = dataSet.Tables["TaiKhoan"];

                //them ten va mat khau
                foreach (DataRow dr in dt.Rows)
                {
                    tk.Add(dr["Ten"].ToString());
                    mk.Add(dr["Matkhau"].ToString());
                }
            }
            catch (Exception)
            {
            }
            string id = taikhoan.Tentaikhoan;
            string mk1 = taikhoan.Matkhau;

            //kiem tra tai khoan ton tai 
            foreach (string tk1 in tk)
            {
                if (tk1 == id)
                {
                    isTonTaiTk = true;
                    Stt = (i + 1).ToString();
                    break;
                }
                i++;
            }

            //kiem tra pass cua tai khoan
            if (isTonTaiTk == true)
            {
                if (mk[i] == mk1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}