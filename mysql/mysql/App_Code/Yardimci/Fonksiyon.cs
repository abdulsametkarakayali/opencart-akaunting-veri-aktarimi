using System;
using System.IO;
using System.Net;

/// <summary>
/// Summary description for Fonksiyon
/// </summary>
public class Fonksiyon
{
    public Fonksiyon()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string UploadFileToFtp(string dosyaAdi)

    {
        string ftpServerIP = "ftp.ilgim.com.tr";

        FileInfo dosyaBilgisi = new FileInfo(dosyaAdi);

        string uri = "ftp://" + ftpServerIP + "/" + dosyaBilgisi.Name;

        FtpWebRequest ftpIstegi;

        ftpIstegi = (FtpWebRequest)FtpWebRequest.Create(new Uri(

                  "ftp://" + ftpServerIP + "/" + dosyaBilgisi.Name));

        ftpIstegi.Credentials = new NetworkCredential("deneme@ugurkizmaz.com", "123");

        // Baglantiyi sürekli açik tutuyor.

        ftpIstegi.KeepAlive = false;

        // Yapilacak islem (Upload)

        ftpIstegi.Method = WebRequestMethods.Ftp.UploadFile;

        //Verinin gönderim sekli.

        ftpIstegi.UseBinary = true;

        //Sunucuya gönderilecek dosya uzunlugu bilgisi

        ftpIstegi.ContentLength = dosyaBilgisi.Length;

        // Buffer uzunlugu 2048 byte

        int bufferUzunlugu = 2048;

        byte[] buff = new byte[10000000];

        int sayi;

        FileStream stream = dosyaBilgisi.OpenRead();

        try

        {
            Stream str = ftpIstegi.GetRequestStream();

            sayi = stream.Read(buff, 0, bufferUzunlugu);

            while (sayi != 0)

            {
                str.Write(buff, 0, sayi);

                sayi = stream.Read(buff, 0, bufferUzunlugu);
            }

            return "";

            str.Close();

            stream.Close();
        }
        catch (Exception ex)

        {
            return ex.Message;
        }
    }
}