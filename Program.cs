using System;
using System.Collections.Generic;

namespace GorevYonetimSistemi
{
    class Program
    {
        static List<Gorev> gorevListesi = new List<Gorev>();

        static void Main()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Görev Yönetim Sistemi ===");
                Console.WriteLine("1. Görev Ekle");
                Console.WriteLine("2. Görevleri Listele");
                Console.WriteLine("3. Görev Güncelle");
                Console.WriteLine("4. Görev Sil");
                Console.WriteLine("5. Görev Durumu Değiştir");
                Console.WriteLine("6. Çıkış");
                Console.Write("Seçiminizi yapın: ");

                string secim = Console.ReadLine();
                switch (secim)
                {
                    case "1":
                        GorevEkle();
                        break;
                    case "2":
                        GorevleriListele();
                        break;
                    case "3":
                        GorevGuncelle();
                        break;
                    case "4":
                        GorevSil();
                        break;
                    case "5":
                        GorevDurumuDegistir();
                        break;
                    case "6":
                        Console.WriteLine("Çıkış yapılıyor...");
                        return;
                    default:
                        Console.WriteLine("Geçersiz seçim. Lütfen tekrar deneyin.");
                        break;
                }
                Console.WriteLine("\nDevam etmek için bir tuşa basın...");
                Console.ReadKey();
            }
        }

        static void GorevEkle()
        {
            Console.Clear();
            Console.WriteLine("=== Görev Ekle ===");
            Console.Write("Görev adı: ");
            string ad = Console.ReadLine();
            Console.Write("Görev açıklaması: ");
            string aciklama = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(ad))
            {
                Console.WriteLine("Görev adı boş bırakılamaz.");
                return;
            }

            gorevListesi.Add(new Gorev { Ad = ad, Aciklama = aciklama, Durum = "Beklemede" });
            Console.WriteLine("Görev başarıyla eklendi!");
        }

        static void GorevleriListele()
        {
            Console.Clear();
            Console.WriteLine("=== Görevler ===");
            if (gorevListesi.Count == 0)
            {
                Console.WriteLine("Henüz eklenmiş bir görev yok.");
                return;
            }

            for (int i = 0; i < gorevListesi.Count; i++)
            {
                Gorev gorev = gorevListesi[i];
                Console.WriteLine($"[{i + 1}] {gorev.Ad} - {gorev.Aciklama} (Durum: {gorev.Durum})");
            }
        }

        static void GorevGuncelle()
        {
            GorevleriListele();
            if (gorevListesi.Count == 0) return;

            Console.Write("\nGüncellemek istediğiniz görevin numarasını girin: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= gorevListesi.Count)
            {
                Gorev gorev = gorevListesi[index - 1];
                Console.Write("Yeni görev adı (boş bırakılırsa eski adı korunur): ");
                string yeniAd = Console.ReadLine();
                Console.Write("Yeni görev açıklaması (boş bırakılırsa eski açıklama korunur): ");
                string yeniAciklama = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(yeniAd)) gorev.Ad = yeniAd;
                if (!string.IsNullOrWhiteSpace(yeniAciklama)) gorev.Aciklama = yeniAciklama;

                Console.WriteLine("Görev başarıyla güncellendi!");
            }
            else
            {
                Console.WriteLine("Geçersiz görev numarası.");
            }
        }

        static void GorevSil()
        {
            GorevleriListele();
            if (gorevListesi.Count == 0) return;

            Console.Write("\nSilmek istediğiniz görevin numarasını girin: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= gorevListesi.Count)
            {
                gorevListesi.RemoveAt(index - 1);
                Console.WriteLine("Görev başarıyla silindi!");
            }
            else
            {
                Console.WriteLine("Geçersiz görev numarası.");
            }
        }

        static void GorevDurumuDegistir()
        {
            GorevleriListele();
            if (gorevListesi.Count == 0) return;

            Console.Write("\nDurumunu değiştirmek istediğiniz görevin numarasını girin: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= gorevListesi.Count)
            {
                Gorev gorev = gorevListesi[index - 1];
                Console.WriteLine("Mevcut durum: " + gorev.Durum);
                Console.Write("Yeni durum (Beklemede, Yapılıyor, Tamamlandı): ");
                string yeniDurum = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(yeniDurum))
                {
                    gorev.Durum = yeniDurum;
                    Console.WriteLine("Görev durumu başarıyla güncellendi!");
                }
                else
                {
                    Console.WriteLine("Geçersiz durum.");
                }
            }
            else
            {
                Console.WriteLine("Geçersiz görev numarası.");
            }
        }

        class Gorev
        {
            public string Ad { get; set; }
            public string Aciklama { get; set; }
            public string Durum { get; set; }
        }
    }
}
