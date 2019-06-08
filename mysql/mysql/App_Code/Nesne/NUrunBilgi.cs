using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for NUrunBilgi
/// </summary>
public class NUrunBilgi
{
    public int UrunId { get; set; }
  //  public int KategoriId { get; set; }
    public string Kod { get; set; }
    public int MediableId{ get; set; }
    public string Ad { get; set; }
    public int Adet { get; set; }
    public string Sku { get; set; }
    public int Categori_id { get; set; }
    public string Aciklama { get; set; }
   public double Fiyat { get; set; }
    public string Resim { get; set; }
    public List<string> Resimler { get; set; }
}