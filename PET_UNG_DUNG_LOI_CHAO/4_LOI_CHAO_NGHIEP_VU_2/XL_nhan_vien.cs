using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.IO;


public class nhanvien
{
    public int Ma_so { get; set; }
    public string Ho_Ten { get; set; }
    public string Ten_dang_nhap { get; set; }
    public string Mat_khau { get; set; }
    public List<DateTime> Danh_sach_lan_dang_nhap { get; set; }
    public List<Dictionary<string, string>> Danh_sach_ma_so_nhom_hang { get; set; }
}
public class XL_nhan_vien
{
    public static nhanvien doc(string Ten_dang_nhap, string Mat_khau)
    {
        #region
        string file_path = HttpContext.Current.Server.MapPath($"\\Du_lieu\\danh_sach_nhan_vien.json");
        if( File.Exists(file_path))
        {
            StreamReader f = new StreamReader(file_path);
            string content = f.ReadLine();
            f.Close();
            var  ds_nhan_vien = JsonConvert.DeserializeObject<List<nhanvien>>(content);
            //foreach (nhanvien nv in ds_nhan_vien )
            //{
            //    if(nv.Ma_so == Ma_so)
            //    {
            //        nv.danh_sach_lan_dang_nhap.Add(DateTime.Now);
            //        ghi(file_path, ds_nhan_vien);
            //        return nv;
            //    }
            //}
            nhanvien nv = ds_nhan_vien.First(p => p.Ten_dang_nhap == Ten_dang_nhap && p.Mat_khau == Mat_khau);
            if (nv != null)
            {
                nv.Danh_sach_lan_dang_nhap.Add(DateTime.Now);
                nv.Danh_sach_ma_so_nhom_hang.Add( new Dictionary<string, string> { { "Nhóm hàng_5","NH_5" }} );
                ghi(file_path, ds_nhan_vien);
                return nv;
            }

        }
        return null;
        #endregion
    }
    public static void ghi(string filepath, List<nhanvien> ds_nhan_vien)
    {
        StreamWriter f = new StreamWriter(filepath);
        string content = JsonConvert.SerializeObject(ds_nhan_vien);
        f.WriteLine(content);
        f.Close();
    }
}
