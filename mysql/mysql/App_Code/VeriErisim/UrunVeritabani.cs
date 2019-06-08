using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Summary description for UrunVeritabani
/// </summary>
public class UrunVeritabani : Veritabani
{
    protected NIslemSonuc<List<NUrunBilgi>> Getir(int faturaId)
    {
        try
        {
            var kayitlar = (from u in Entity.vzb_invoice_items
                            join y in Entity.vzb_mediables on u.item_id.Value equals y.mediable_id

                            join z in Entity.vzb_media on y.mediable_id equals z.id

                            where u.invoice_id == faturaId && u.deleted_at == null
                            select new NUrunBilgi
                            {
                                //Aciklama = u.
                                Ad = u.name,
                                //Fiyat =(decimal)u.price,
                                //KategoriId =u.
                                Adet = (int)u.quantity,
                                Kod = u.sku,
                                UrunId = (int)u.id,
                                MediableId = (int)y.mediable_id
                            }).ToList();

            for (int i = 0; i < kayitlar.Count; i++)
            {
                int urunId = kayitlar[i].MediableId;
                var kayitResim = (from r in Entity.vzb_media
                                  join z in Entity.vzb_mediables on r.id equals z.mediable_id
                                  where z.mediable_id == urunId
                                  select "http://muhasebe.ilgim.net/uploads/" + z.media_id + "." + r.extension);
                if (kayitResim.Count() > 0)
                {
                    kayitlar[i].Resim = kayitResim.FirstOrDefault();
                }
            }

            return new NIslemSonuc<List<NUrunBilgi>>
            {
                BasariliMi = true,
                Veri = kayitlar
            };
        }
        catch (Exception hata)
        {
            return new NIslemSonuc<List<NUrunBilgi>>
            {
                BasariliMi = false,
                HataBilgi = new NHata
                {
                    HataMesaj = hata.Message,
                    Metod = "Getir",
                    Sinif = "UrunVeritabani"
                }
            };
        }
    }

    protected NIslemSonuc<List<NUrunBilgi>> UrunEsitle()
    {
        try
        {
            var kayitlar = (from u in Entity.vzb_items
                            join y in Entity.vzb_mediables on u.id  equals y.mediable_id
                            join z in Entity.vzb_media on y.media_id equals z.id
                            select new NUrunBilgi
                            {
                                //Aciklama = u.
                                Ad = u.name,
                                //Fiyat =(decimal)u.price,
                                //KategoriId =u.
                                Adet = (int)u.quantity,
                                Sku = u.sku,
                                Fiyat = u.sale_price,
                                Resim = "catalog/items/" + z.filename + "." + z.extension,
                                Categori_id = 60,
                                UrunId = (int)u.id,
                                MediableId = (int)y.mediable_id
                            }).ToList();

            //for (int i = 0; i < kayitlar.Count; i++)
            //{
            //    int urunId = kayitlar[i].UrunId;

            //    var kayitResim = (from r in Entity.vzb_media
            //                      join z in Entity.vzb_mediables on r.id equals z.media_id
            //                      where z.mediable_id == urunId
            //                      select "catalog/items/" + r.filename + "." + r.extension);
            //    if (kayitResim.Count() > 0)
            //    {
            //        kayitlar[i].Resim = kayitResim.FirstOrDefault();
            //    }
            //}
            for (int i = 0; i < kayitlar.Count; i++)
            {

                string ID = kayitlar[i].Sku; 


                var kayitvarmi = (from x in OpencartEntity.oc_product
                                  where x.sku == ID
                                  select x).Count();
                
                if (kayitvarmi == 0)
                {
                    var urun = new Entity.oc_product
                    {
                        model = kayitlar[i].Sku,
                        sku = kayitlar[i].Sku,
                        quantity = kayitlar[i].Adet,
                        stock_status_id = 6,
                        image = kayitlar[i].Resim,
                        shipping = true,
                        points = 0,
                        status = true,
                        subtract = true,
                        minimum = 1,
                        weight= 0,
                        sort_order = 1,
                        price = Convert.ToDecimal(kayitlar[i].Fiyat),
                        manufacturer_id = 0,
                        tax_class_id = 0,
                        date_added=DateTime.Now,
                        date_available=DateTime.Now
                    };

                    OpencartEntity.oc_product.Add(urun);
                    OpencartEntity.SaveChanges();

                    var aciklama = new Entity.oc_product_description
                    {
                        name = kayitlar[i].Ad,
                        meta_title = kayitlar[i].Ad,
                        product_id = urun.product_id,
                        language_id = 1,
                        description = "",
                        tag = "",
                        meta_description = "",
                        meta_keyword = "",
                    };
                    var kategori = new Entity.oc_product_to_category
                    {
                        product_id = urun.product_id,
                        category_id = 59,
                    };
                    var magaza = new Entity.oc_product_to_store
                    {
                        product_id = urun.product_id,
                        store_id = 0
                    };
                    OpencartEntity.oc_product_description.Add(aciklama);
                    OpencartEntity.oc_product_to_category.Add(kategori);
                    OpencartEntity.oc_product_to_store.Add(magaza);
                    OpencartEntity.SaveChanges();
                }
            }
            return new NIslemSonuc<List<NUrunBilgi>>
            {
                BasariliMi = true,
                Veri = kayitlar
            };
        }
        catch (Exception hata)
        {
            return new NIslemSonuc<List<NUrunBilgi>>
            {
                BasariliMi = false,
                HataBilgi = new NHata
                {
                    HataMesaj = hata.Message,
                    Metod = "Getir",
                    Sinif = "UrunVeritabani"
                }
            };
        }
    }
}