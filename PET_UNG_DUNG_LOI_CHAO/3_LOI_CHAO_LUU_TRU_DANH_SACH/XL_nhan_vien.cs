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
    public int So_lan_Chao;
}
public class XL_nhan_vien
{
    public static nhanvien doc(string Ma_so)
    {
        #region cách 1 
        //string file_path = HttpContext.Current.Server.MapPath("\\Du_lieu");
        //string[] file_name = Directory.GetFiles(file_path, "*.json");
        //for (int i  = 0; i < file_name.Length;i++)
        //{
        //    var duong_dan = file_name[i];
        //    StreamReader f = new StreamReader(duong_dan);
        //    string content = f.ReadLine();
        //    f.Close();
        //    var nv = JsonConvert.DeserializeObject<nhanvien>(content);
        //    if (nv.Ma_so==Ma_so)
        //    {
        //        nv.So_lan_Chao++;
        //        ghi(duong_dan, nv);
        //        return nv;
        //    }
        //}
        //return null;
        #endregion

        #region cách 2
        string file_path = HttpContext.Current.Server.MapPath($"\\Du_lieu\\{Ma_so}.json");
        if( File.Exists(file_path))
        {
            StreamReader f = new StreamReader(file_path);
            string content = f.ReadLine();
            f.Close();
            var nv = JsonConvert.DeserializeObject<nhanvien>(content);
            nv.So_lan_Chao++;
            ghi(file_path, nv);
            return nv;
        }
        return null;
        #endregion

    }
    public static void ghi(string duong_dan, nhanvien nv)
    {
        StreamWriter f = new StreamWriter(duong_dan);
        string content = JsonConvert.SerializeObject(nv);
        f.WriteLine(content);
        f.Close();
    }
}
