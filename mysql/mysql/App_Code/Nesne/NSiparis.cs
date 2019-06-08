using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for NSiparis
/// </summary>
public class NSiparis
{
    public int UrunId { get; set; }
    public int UyeId { get; set; }
    public DateTime Tarih { get; set; }
    public string FaturaAdres { get; set; }
    public string TeslimatAdres { get; set; }
    public string TeslimatAdSoyad { get; set; }
    public string TeslimatTelefon { get; set; }
    public bool OdemeYapildiMi { get; set; }
    public decimal Fiyat { get; set; }
}