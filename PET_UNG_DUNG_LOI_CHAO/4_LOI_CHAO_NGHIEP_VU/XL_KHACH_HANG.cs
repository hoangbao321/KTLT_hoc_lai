using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class XL_KHACH_HANG
{
    public static int random()
    {
        var rand = new Random();
        int a = rand.Next(1, 5);
        return a;
    }
}
