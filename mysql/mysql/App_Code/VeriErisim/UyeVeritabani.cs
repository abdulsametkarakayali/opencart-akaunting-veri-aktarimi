using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using Entity;

/// <summary>
/// Summary description for UyeVeritabani
/// </summary>
public class UyeVeritabani : Veritabani
{
 
    protected NIslemSonuc<bool> GetirMusteriler()
    {
        try
        {
            var kayitlar = (from k in Entity.vzb_customers
                           
                            select new NUyeBilgi
                            {
                                 AdSoyad= k.name,
                                 Adres=k.address,
                                 EPosta=k.email,
                                 Telefon=k.phone,
                                 //Parola=k.
                                 
                            }).ToList();
 
                for (int i = 0; i < kayitlar.Count; i++)
                {
                    var eposta = kayitlar[i].EPosta;
                
                    var Uyeayisi = (from u in OpencartEntity.oc_customer
                                    where u.email.Equals(eposta)
                                    select u.customer_id).Count();

                    if (Uyeayisi > 0)
                    {
                        //return new NIslemSonuc<bool>
                        //{
                        //    BasariliMi = false,
                        //    Mesaj = "E-Posta adresine ait üye kaydı sistemde bulunmaktadır"
                        //};
                    }
                    else
                    {

                        var yeniUye = new oc_customer
                        {
                            customer_group_id = 1,
                            store_id = 0,
                            language_id = 1,
                            firstname = kayitlar[i].AdSoyad,
                            lastname = "deneme",
                            email =  kayitlar[i].EPosta,

                            telephone = kayitlar[i].Telefon,
                            fax = "",
                            newsletter =false,
                            address_id=0,
                            status=false,
                            safe=false,
                            date_added=DateTime.Now,
                           cart="",
                           wishlist="",
                            password= "db0f755a47f132f285989ba07f2cf89f68ef9781",
                            salt= "NuWWdLkTF",
                            custom_field= "[]",
                           token="",
                           code="",
                           ip="127.0.0.1",



                        };
                       
                        OpencartEntity.oc_customer.Add(yeniUye);
                      
                         OpencartEntity.SaveChanges();
  
                    }
            }
            return new NIslemSonuc<bool>
            {
                BasariliMi = true,
                Mesaj = "kayitlar güncellendi."
            };

        }
        catch (Exception hata)
        {
            return new NIslemSonuc<bool>
            {
                BasariliMi = false,
                HataBilgi = new NHata
                {
                    HataMesaj = hata.Message,
                    Metod = "GetirMusteriler",
                    Sinif = "UyeVeritabani"
                }
            };
        }
    }

}