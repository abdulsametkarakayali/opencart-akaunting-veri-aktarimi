using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UyeIslem
/// </summary>
public class UyeIslem : UyeVeritabani
{
     

    public NIslemSonuc<bool> GetirMusteriler()
    {
        var sonuc = base.GetirMusteriler();
        if (sonuc.HataBilgi != null)
        {
            //Hata mesajını veritabanına kaydet
        }
        return sonuc;
    }
}