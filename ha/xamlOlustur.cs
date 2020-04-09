using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ha
{
    class xamlOlustur
    {
        public static bool XamlOlustur(params string[] nesneIsimleri)
        {
            try
            {
                string dosya = "" + nesneIsimleri[0] + ".xaml", yolu = @"C:\HA_OutpuFolder", _dosyaYolu = Path.Combine(yolu, dosya);
                if (!Directory.Exists(yolu))
                {
                    Directory.CreateDirectory(yolu);
                }
                if (!File.Exists(_dosyaYolu))
                {
                    File.Create(_dosyaYolu).Close();
                }
                FileStream fs = new FileStream(_dosyaYolu, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                string yazilacakVeri = "<Window x:Class='ProjectName." + nesneIsimleri[0] + "'\n xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'\n";
                yazilacakVeri += "xmlns:x='http://schemas.microsoft.com/winfx/2006/xaml'\n";
                yazilacakVeri += "xmlns:d='http://schemas.microsoft.com/expression/blend/2008'\n";
                yazilacakVeri += "xmlns:mc='http://schemas.openxmlformats.org/markup-compatibility/2006'\n";
                yazilacakVeri += "xmlns:local='clr-namespace:ProjectName'\n";
                yazilacakVeri += "mc:Ignorable='d' Background='#75A0C0'\n";
                yazilacakVeri += "Title='MainWindow' Height='580' Width='800'>\n";
                yazilacakVeri += "<Grid>";
                yazilacakVeri += "<Grid.RowDefinitions>\n <RowDefinition Height='250'/>\n <RowDefinition Height='1*'/>\n </Grid.RowDefinitions>\n";
                yazilacakVeri += "<Grid Grid.Row='0' Margin='5'>\n <Grid.ColumnDefinitions>\n <ColumnDefinition Width='550'/>\n<ColumnDefinition Width='1*'/>\n</Grid.ColumnDefinitions>\n";
                yazilacakVeri += "<Grid Grid.Column='0'>\n<WrapPanel Orientation='Vertical'>\n";

                for (int i = 1; i < nesneIsimleri.Length; i++)
                {
                    yazilacakVeri += "<StackPanel Orientation='Horizontal' Margin='3'>\n";
                    yazilacakVeri += "<Label Content='" + Program.karakterCevir(nesneIsimleri[i]) + ": ' Width='60' Height='20' Padding='0 0 0 0' Foreground='White'/>\n";
                    yazilacakVeri += "<TextBox x:Name='txt" + nesneIsimleri[i] + "' Width='180' Height='20' FontSize='13' IsReadOnly='False' />\n";
                    yazilacakVeri += "</StackPanel>\n";
                }

                yazilacakVeri += "</WrapPanel>\n</Grid>\n";
                yazilacakVeri += "<WrapPanel Grid.Column='1' Margin='10 0 0 0'>\n";
                yazilacakVeri += "<Button x:Name='btnKaydet' Width='210' Height='30' FontFamily='Raleway' FontSize='12' Content='KAYDET' Margin='4' Click='BtnKaydet_Click'/>\n";
                yazilacakVeri += "<Button x:Name='btnsil' Width='210' Height='30' FontFamily='Raleway' FontSize='12' Content='SİL' Margin='4' Click='Btnsil_Click'/>\n";
                yazilacakVeri += "<Button x:Name='btnGuncelle' Width='210' Height='30' FontFamily='Raleway' FontSize='12' Content='GÜNCELLE' Margin='4' Click='BtnGuncelle_Click'/>\n";
                yazilacakVeri += "<Button x:Name='btnIcerigiTemizle' Width='210' Height='30' FontFamily='Raleway' FontSize='12' Content='İÇERİĞİ TEMİZLE' Margin='4' Click='BtnIcerigiTemizle_Click'/>\n";
                yazilacakVeri += "<Button x:Name='btnYazdir' Width='210' Height='30' FontFamily='Raleway' FontSize='12' Content='YAZDIR' Margin='4' Click='BtnYazdir_Click'/>\n";
                yazilacakVeri += "<Button x:Name='btnExceleAktar' Width='210' Height='30' FontFamily='Raleway' FontSize='12' Content='VERİLERİ EXCELE AKTAR' Margin='4' Click='BtnExceleAktar_Click'/>\n</WrapPanel>\n";
                yazilacakVeri += "</Grid>\n";
                yazilacakVeri += "<DataGrid x:Name='dgvNotlar' Grid.Row='2' MinHeight='0' \n GridLinesVisibility='All' FontSize='14' \n CanUserSortColumns='True' CanUserAddRows='False' \n CanUserDeleteRows='False'  IsReadOnly='True' RowHeaderWidth='20' HeadersVisibility='All'\n HorizontalScrollBarVisibility='Auto' VerticalScrollBarVisibility='Auto'>\n</DataGrid>\n";
                yazilacakVeri += "</Grid>\n</Window>";
                sw.WriteLine(yazilacakVeri.Replace("'", "\""));
                sw.Flush(); //Veriyi tampon bölgeden dosyaya aktardık.
                sw.Close();
                fs.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static void dosyaOlustur(params string[] nesneIsimleri)
        {
            string dosya = "metinbelgesi.txt", yolu = @"C:\HA_OutpuFolder", _dosyaYolu = Path.Combine(yolu, dosya);
            if (!Directory.Exists(yolu))
            {
                Directory.CreateDirectory(yolu);
            }
            if (!File.Exists(_dosyaYolu))
            {
                File.Create(_dosyaYolu).Close();
            }
            FileStream fs = new FileStream(_dosyaYolu, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("1.Satır:Merhaba\nsdfsff");
            sw.Flush(); //Veriyi tampon bölgeden dosyaya aktardık.
            sw.Close();
            fs.Close();
        }
    }
}