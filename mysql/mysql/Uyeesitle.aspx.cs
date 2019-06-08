using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Uyeesitle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GetirMusteriler();
    }
    protected void GetirMusteriler()
    {

        UyeIslem musteri = new UyeIslem();
        var sonuc = musteri.GetirMusteriler();
        if (sonuc.BasariliMi)
        {
            lblSonuc.Text = sonuc.Mesaj;
        }
        else
        {

        }
    }

}