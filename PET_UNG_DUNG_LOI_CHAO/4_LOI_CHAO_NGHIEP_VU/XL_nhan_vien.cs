using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.IO;


public class nhanvien
{
    public string Ho_ten;
    public string Ma_so;
    public List<DateTime> danh_sach_lan_dang_nhap = new List<DateTime>();
}
public class XL_nhan_vien
{
    public static nhanvien doc(string Ma_so)
    {
        #region
        string file_path = HttpContext.Current.Server.MapPath($"\\Du_lieu\\danh_sach_nhan_vien.json");
        if( File.Exists(file_path))
        {
            StreamReader f = new StreamReader(file_path);
            string content = f.ReadLine();
            f.Close();
            var  ds_nhan_vien = JsonConvert.DeserializeObject<List<nhanvien>>(content);
            foreach (nhanvien nv in ds_nhan_vien )
            {
                if(nv.Ma_so == Ma_so)
                {
                    nv.danh_sach_lan_dang_nhap.Add(DateTime.Now);
                    ghi(file_path, ds_nhan_vien);
                    return nv;
                }
            }
        }
        return null;
        #endregion
    }
    public static void ghi(string filepath, List<nhanvien> ds_nv)
    {
        StreamWriter f = new StreamWriter(filepath);
        string content = JsonConvert.SerializeObject(ds_nv);
        f.WriteLine(content);
        f.Close();
    }
}
