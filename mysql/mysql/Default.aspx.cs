using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //GetirFatura(17);
    }
    protected void GetirMusteriler()
    {

        UyeIslem musteri = new UyeIslem();
        var sonuc = musteri.GetirMusteriler();
        if (sonuc.BasariliMi)
        {
            rptMusteriler.DataSource = sonuc.Veri;
            rptMusteriler.DataBind();
        }
        else
        {

        }
    }



    protected void GetirFatura(int faturaid)
    {
        UrunIslem fatura = new UrunIslem();
        var sonuc = fatura.Getir(17);
        if (sonuc.BasariliMi)
        {
            rptMusteriler.DataSource = sonuc.Veri;
            rptMusteriler.DataBind();
        }
        else
        {

        }
    }

    protected void btnEsitle_Click(object sender, EventArgs e)
    {
        UrunIslem esitle = new UrunIslem();
        var sonuc = esitle.UrunEsitle();
        if (sonuc.BasariliMi)
        {
            lblSonuc.Text = "İşlem Sonuclandı";

        }
    }
}