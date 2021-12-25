using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class XL_nghiep_vu
{
    public static int rand ()
    {
        Random ran = new Random();
        return ran.Next(0, 5);
    }
}
