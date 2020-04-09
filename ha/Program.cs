using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ha
{
    class Program
    {
        public static string karakterCevir(string kelime)
        {
            string mesaj = kelime;
            char[] oldValue = new char[] { 'ö', 'Ö', 'ü', 'Ü', 'ç', 'Ç', 'İ', 'ı', 'Ğ', 'ğ', 'Ş', 'ş' };
            char[] newValue = new char[] { 'o', 'O', 'u', 'U', 'c', 'C', 'I', 'i', 'G', 'g', 'S', 's' };
            for (int sayac = 0; sayac < oldValue.Length; sayac++)
            {
                mesaj = mesaj.Replace(oldValue[sayac], newValue[sayac]);
            }
            return mesaj;
        }

        private string ConvertTRCharToENChar(string text)
        {
            return String.Join("", text.Normalize(NormalizationForm.FormD)
            .Where(c => char.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark));
        }

        static int Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Sistemi kullanabilmek için parametre gönderiniz.\nYardım dökümantasyonu yapım aşamasındadır.\nSürüm: 0.0.5\nGeliştirici: Hasan Adıgüzel");
                Console.ForegroundColor = ConsoleColor.White;
                return 1;
            }
            if (args[0] == "--help" || args[0] == "-h")
            {
                Console.WriteLine("Sistemin bu sürümünde metinsel ifadeler gönderebilirsiniz.\n***Örnek Kullanım:\nha DosyaAdı Varlık1 Varlık2 Varlık3 ...");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n\nSistemi kullanabilmek için parametre gönderiniz.\nYardım dökümantasyonu yapım aşamasındadır.\nSürüm: 0.0.5\nGeliştirici: Hasan Adıgüzel");
                Console.ForegroundColor = ConsoleColor.White;
                return 1;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("İşlem başlıyor...");
            for (int i = 0; i < args.Length; i++)
            {
                try
                {
                    Convert.ToInt32(args[i]);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Hata! Sistemin bu sürümünde metinsel ifadeler gönderebilirsiniz.\nYardım dökümantasyonu yapım aşamasındadır.\nSürüm: 0.0.5\nGeliştirici: Hasan Adıgüzel");
                    Console.ForegroundColor = ConsoleColor.White;
                    return 1;
                }
                catch (Exception)
                {
                    args[i] = karakterCevir(args[i]);
                }
            }

            Console.WriteLine("Dosya oluşturuluyor...");
            bool durum = xamlOlustur.XamlOlustur(args);
            if (durum) Console.WriteLine("Başarılı İşlem!\nÇıktı Klasörü: C:\\HA_OutputFolder\nÇıktı Adı: " + args[0] + ".xaml");
            else Console.WriteLine("Başarısız İşlem!");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n\nSistemi kullanabilmek için parametre gönderiniz.\nYardım dökümantasyonu yapım aşamasındadır.\nSürüm: 0.0.5\nGeliştirici: Hasan Adıgüzel");
            Console.ForegroundColor = ConsoleColor.White;
            return 0;
        }
    }
}