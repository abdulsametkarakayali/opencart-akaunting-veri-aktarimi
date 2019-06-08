using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UrunIslem
/// </summary>
public class UrunIslem:UrunVeritabani
{
    public NIslemSonuc<List<NUrunBilgi>> Getir(int faturaId)
    {
        var sonuc = base.Getir(faturaId);
        if (sonuc.HataBilgi != null)
        {
            //Hata mesajını veritabanına kaydet
        }
        return sonuc;
    }
    public NIslemSonuc<List<NUrunBilgi>> UrunEsitle()
    {
        var sonuc = base.UrunEsitle();
        if (sonuc.HataBilgi != null)
        {

        }
        return sonuc;
    }
}