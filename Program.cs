using System;
using System.Collections.Generic;

namespace evcilHayvanTakipSistemi

{
    using System;

    class VeterinerRandevu
    {
        public string EvcilhayvanAdi { get; set; }
        public DateTime RandevuTarihi { get; set; }
        public string Aciklama { get; set; }

        public VeterinerRandevu(string evcilHayvanAdi, DateTime randevuTarihi, string aciklama)
        {

            EvcilhayvanAdi = evcilHayvanAdi;
            RandevuTarihi = randevuTarihi;
            Aciklama = aciklama;
        }

        public override string ToString()
        {
            return $"{EvcilhayvanAdi} - {RandevuTarihi.ToShortDateString()} - {Aciklama}";
        }
    }

    class EvcilHayvan
    {
        public string Ad { get; set; }
        public string Tur { get; set; }
        public string Renk { get; set; }
        public DateTime DogumTarihi { get; set; }
        public List<string> VeterinerRandevular { get; set; }

        public EvcilHayvan(string ad, string tur, string renk, DateTime dogumTarihi)
        {
            Ad = ad;
            Tur = tur;
            Renk = renk;
            DogumTarihi = dogumTarihi;
            VeterinerRandevular = new List<string>();
        }

        public void BilgileriGoster()
        {
            Console.WriteLine($"Ad: {Ad}");
            Console.WriteLine($"Tür: {Tur}");
            Console.WriteLine($"Renk: {Renk}");
            Console.WriteLine($"Doğum Tarihi: {DogumTarihi.ToShortDateString()}");


        }
    }





    class AnaSayfa
    {
        static List<VeterinerRandevu> veterinerRandevulari = new List<VeterinerRandevu>();
        static List<EvcilHayvan> evcilHayvanlar = new List<EvcilHayvan>();
        static void Main()
        {
            // Kullanıcı adı ve şifreyi 
            string dogruKullaniciAdi = "Ceren";
            string dogruSifre = "sifrem";

            bool girisBasarili = false;
            do
            {
                Console.WriteLine("Kullanıcı Girişi");

                // Kullanıcıdan kullanıcı adı ve şifre isteme
                Console.Write("Kullanıcı Adı: ");
                string kullaniciAdi = Console.ReadLine();

                Console.Write("Şifre: ");
                string sifre = Console.ReadLine();

                // Kullanıcı adı ve şifreyi kontrol etme
                if (kullaniciAdi == dogruKullaniciAdi && sifre == dogruSifre)
                {
                    Console.WriteLine("Giriş Başarılı. Hoşgeldiniz, " + kullaniciAdi + "!");
                    while (true)
                    {
                        Console.WriteLine("****************");
                        Console.WriteLine(" AnaSayfa");
                        Console.WriteLine("1. Evcil Hayvan Ekle");
                        Console.WriteLine("2. Evcil Hayvan Bilgileri Görüntüle");
                        Console.WriteLine("3. Randevular");
                        Console.WriteLine("4. Randevu göster");
                        Console.WriteLine("5. Çıkış");
                        Console.WriteLine("Seçiminiz: ");
                        Console.WriteLine("****************");


                        string secim = Console.ReadLine();

                        switch (secim)
                        {
                            case "1":
                                EvcilHayvanEkle();
                                break;
                            case "2":
                                EvcilHayvanBilgileriGoruntule();
                                break;
                            case "3":
                                RandevuEkle();
                                break;
                            case "4":
                                RandevuGoster();
                                break;
                            case "5":
                                Environment.Exit(0);
                                break;
                            default:
                                Console.WriteLine("Geçersiz seçim. Lütfen tekrar deneyin.");
                                break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Giriş Başarısız. Kullanıcı adı veya şifre hatalı.Tekrar deneyiniz.");
                }
            } while (!girisBasarili);

            Console.ReadLine(); // Konsol penceresinin kapatılmaması için bekleme
        }



        static void EvcilHayvanEkle()
        {
            Console.WriteLine("\nEvcil Hayvan Ekle");

            Console.Write("Ad: ");
            string ad = Console.ReadLine();

            Console.Write("Tür: ");
            string text = "";
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);

                if (char.IsLetter(key.KeyChar))
                {
                    text += key.KeyChar;
                    Console.Write(key.KeyChar);
                }
                else if (key.Key == ConsoleKey.Backspace && text.Length > 0)
                {
                    text = text.Substring(0, (text.Length - 1));
                    Console.Write("\b \b");
                }
            } while (key.Key != ConsoleKey.Enter);
            Console.ReadLine();

            Console.Write("Renk: ");
            string renk = Console.ReadLine();

            Console.Write("Doğum Tarihi (YYYY-AA-GG): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime dogumTarihi))
            {
                EvcilHayvan yeniEvcilHayvan = new EvcilHayvan(ad, text, renk, dogumTarihi);
                evcilHayvanlar.Add(yeniEvcilHayvan);

                Console.WriteLine("Evcil hayvan başarıyla eklendi.");
            }
            else
            {
                Console.WriteLine("Geçersiz tarih formatı. Evcil hayvan eklenemedi.");
            }
        }

        static void EvcilHayvanBilgileriGoruntule()
        {
            Console.WriteLine("\nEvcil Hayvan Bilgileri Görüntüle");

            if (evcilHayvanlar.Count == 0)
            {
                Console.WriteLine("Henüz hiç evcil hayvan eklenmemiş.");
                return;
            }

            Console.Write("Evcil Hayvan Adı: ");
            string arananAd = Console.ReadLine();

            EvcilHayvan bulunanHayvan = evcilHayvanlar.Find(h => h.Ad.Equals(arananAd, StringComparison.OrdinalIgnoreCase));

            if (bulunanHayvan != null)
            {
                bulunanHayvan.BilgileriGoster();


            }
            else
            {
                Console.WriteLine($"\"{arananAd}\" adında bir evcil hayvan bulunamadı.");
            }
        }

        static public void RandevuEkle()
        {
            Console.Write("Evcil Hayvan Adı: ");
            string evcilHayvanAdi = Console.ReadLine();

            EvcilHayvan hedefEvcilHayvan = evcilHayvanlar.Find(evcilHayvan => evcilHayvan.Ad.ToLower() == evcilHayvanAdi.ToLower());

            if (hedefEvcilHayvan != null)
            {
                DateTime randevuTarihi;

                // Kullanıcıdan randevu tarihini al
                Console.Write("Randevu Tarihi (YYYY-AA-GG): ");
                if (DateTime.TryParse(Console.ReadLine(), out randevuTarihi))
                {
                    // Mevcut tarih
                    DateTime mevcutTarih = DateTime.Now;

                    // Randevu tarihini kontrol et
                    if (randevuTarihi < mevcutTarih)
                    {
                        Console.WriteLine("Hatalı giriş: Randevu tarihi geçmiş bir tarih olamaz.");
                    }
                    else
                    {
                        Console.WriteLine("Randevu tarihi uygun.");
                        Console.Write("Açıklama: ");
                        string aciklama = Console.ReadLine();

                        VeterinerRandevu yeniRandevu = new VeterinerRandevu(hedefEvcilHayvan.Ad, randevuTarihi, aciklama);
                        veterinerRandevulari.Add(yeniRandevu);

                        Console.WriteLine("Veteriner Randevusu Eklendi: " + yeniRandevu);
                    }
                    // İşlemleri devam ettir
                }


                else
                {
                    Console.WriteLine("Evcil hayvan bulunamadı.");
                }
            }
        }

        static public void RandevuGoster()
        {
            Console.WriteLine("Veteriner Randevuları:");
            foreach (var randevu in veterinerRandevulari)
            {
                Console.WriteLine(randevu);
            }
        }


    }
}
