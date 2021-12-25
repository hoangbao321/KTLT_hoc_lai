using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

//public class Root
//{
//    public string source_code { get; set; }
//    public string code { get; set; }
//    public string name { get; set; }
//    public List<Dictionary<string,float>> data { get; set; }
//}


public class Zzz
{
    public int ccc { get; set; }
    public int SubValue { get; set; }
}

public class C
{
    public int Value { get; set; }
    public List<Zzz> zzz { get; set; }
}

public class Root
{
    public int a { get; set; }
    public string b { get; set; }
    public List<C> c { get; set; }
}
class Program
{
    static void Main(string[] args)
    {
        //string file_parent = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        //string file_path = file_parent + "\\Du_lieu\\file_1.json";
        //StreamReader f = new StreamReader(file_path);
        //string content = f.ReadLine();
        //f.Close();
        //var my_list = JsonConvert.DeserializeObject<Root>(content);
        //Console.WriteLine(my_list.data.Count);
        //foreach ( var item in my_list.data)
        //{
        //    foreach (KeyValuePair<string, float> a in item)
        //    {
        //        Console.WriteLine(a.Key+" "+a.Value);
        //    }
        //}

        string file_parent = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        string file_path = file_parent + "\\Du_lieu\\file_2.json";
        StreamReader f = new StreamReader(file_path);
        string content = f.ReadLine();
        f.Close();
        var my_list = JsonConvert.DeserializeObject<Root>(content);

        var z = new Zzz() { ccc = 2, SubValue = 4 };
        var c = new C
        {
            Value = 5,
            zzz = new List<Zzz>(),
        };
        c.zzz.Add(z);

        my_list.c.Add(c);


    }
}

