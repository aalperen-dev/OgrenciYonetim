using System;
using System.Collections.Generic;

namespace OgrenciYonetimG027
{
    class Program
    {
        static List<Ogrenci> Ogrenciler = new List<Ogrenci>();
        
        static void Main(string[] args)
        {           
            Uygulama();
        }

        static void Uygulama()
        {
            SahteVeriGir();
            //kullanıcının seçimine göre aşağıdaki metodlardan ilgili olan çağrılacak
            //o metot çalıştıktan sonra Seçiminiz satırı tekrardan çalışıp yeni metot için
            //seçim isteyecek.
            Menu();
            int sayacKontrol = 1;
            Console.WriteLine();
            string secim = ""; //string.Empty; string ifadeyi null'dan cıkardım.
            while (true)
            {
                Console.WriteLine();
                Console.Write("Seçiminiz : ");
                secim = Console.ReadLine().ToUpper();

                if (SecimAl(secim) == true)
                {
                    //SecimAl metodundan true dönmüşse menü çalışmaya devam ediyor.
                    switch (secim)
                    {
                        case "1":
                        case "E":
                            OgrenciEkle();
                            break;
                        case "2":
                        case "L":
                            OgrenciListele();
                            break;
                        case "3":
                        case "S":
                            OgrenciSil();
                            break;
                        case "4":
                        case "X":
                            Environment.Exit(0);
                            break;
                    }
                }
                else
                {
                    //SecimAl metotdundan false dönmüşse uyarı verip sayacı bir arttırıyoruz.
                    //extradan kullanıcının kac defa hatalı giriş yaptıgını ve kac hata hakkının kaldıgını yazdırdım.
                    Console.WriteLine(sayacKontrol + " defa hatalı giriş yaptınız!");
                    if (sayacKontrol < 10)
                    {
                        Console.WriteLine((10 - sayacKontrol) + " kez daha hatalı giriş yaparsanız program sonlanacak!");
                    }
                    sayacKontrol++;
                }
                if (sayacKontrol == 11)
                {
                    //sayac 10'a ulaşmışsa programın sonlanacağına dair uyarı verip
                    //sonsuz döngüden çıkıyoruz ve programı kapatıyoruz.
                    Console.WriteLine("Üzgünüm sizi anlayamıyorum. Program sonlandırılıyor.");
                    Environment.Exit(0);
                    break;
                }

            }
        }
        static void Menu()
        {
            Console.WriteLine("Öğrenci Yönetim Uygulaması");
            Console.WriteLine("1 - Öğrenci Ekle (E)      ");
            Console.WriteLine("2 - Öğrenci Listele (L)   ");
            Console.WriteLine("3 - Öğrenci Sil (S)       ");
            Console.WriteLine("4 - Çıkış (X)             ");
        }
        
        static void OgrenciEkle()
        {
            Ogrenci o = new Ogrenci();
            Console.WriteLine("1- Öğrenci Ekle ----------");
            Console.WriteLine((Ogrenciler.Count + 1) + ". öğrencinin : ");
            //eklenecek öğrencinin sırası ana listedeki öğrenci sayısının bir fazlasıdır.

            bool sonuc;
            do
            {
                Console.Write("No: ");
                o.No = int.Parse(Console.ReadLine());
                sonuc = OgrenciVarMi(o.No); //metot ile numaranın daha once kayıtlı olup olmadıgını kontrol ediyoruz.
                if (sonuc) //(sonuc == true)
                {
                    Console.WriteLine("Bu numarada bir öğrenci var. Farklı bir numara girin. ");
                }

            } while (sonuc); //(sonuc == true);

            Console.Write("Adı: ");
            o.Ad = IlkHarfBuyut(Console.ReadLine());
            // isim, soyisim ve şube bilgilernin ilk harflerini
            //metot yazarak buyulttum.
            Console.Write("Soyadı: ");
            o.Soyad = IlkHarfBuyut(Console.ReadLine());
            Console.Write("Şubesi: ");
            o.Sube = IlkHarfBuyut(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("Öğrenciyi kaydetmek istediğinize emin misiniz? (E/H) ");
            string giris = Console.ReadLine().ToUpper();

            if (giris == "E")
            {
                Ogrenciler.Add(o);
                Console.WriteLine("Öğrenci eklendi.");
            }
            else
            {
                Console.WriteLine("Öğrenci eklenemedi.");
            }

        }
        
        static void SahteVeriGir()
        {
            Ogrenci o1 = new Ogrenci();
            o1.No = 4;
            o1.Ad = "Ayla";
            o1.Soyad = "Aykar";
            o1.Sube = "DDDD";
            Ogrenciler.Add(o1);
            Ogrenci o2 = new Ogrenci();
            o2.Ad = "Burak";
            o2.Soyad = "Bera";
            o2.No = 45;
            o2.Sube = "CCC";
            Ogrenciler.Add(o2);
            Ogrenci o3 = new Ogrenci();
            o3.Ad = "Ceyda";
            o3.Soyad = "Çay";
            o3.No = 120;
            o3.Sube = "BB";
            Ogrenciler.Add(o3);
            Ogrenci o4 = new Ogrenci();
            o4.Ad = "Alp";
            o4.Soyad = "Eren";
            o4.No = 2626;
            o4.Sube = "A";
            Ogrenciler.Add(o4);
        }
        
        static void OgrenciListele()
        {
            if (Ogrenciler.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Gösterilecek öğrenci yok!");
            }
            else
            {
                Console.WriteLine("2- Öğrenci Listele -------"); 
                Console.WriteLine();
                Console.WriteLine("Şube  No     Ad Soyad"); 
                Console.WriteLine("--------------------------"); 
                foreach (Ogrenci x in Ogrenciler)
                {
                    Console.WriteLine(x.Sube.PadRight(6, ' ') + x.No.ToString().PadRight(7, ' ') + x.Ad + " " + x.Soyad);
                    //subeden itibaren 6 karakterlik, nodan itibaren 7 karakterlik padright ile saga dogru ayarlama yaptım.
                    //isim ve soyisimi standart bir şekilde aralarında bir boşluk bırakarak yazdırdım.
                }
            }
        }
        
        static void OgrenciSil()
        {
            Console.WriteLine("3- Öğrenci Sil -----------"); 
            int no = 0;
            Ogrenci o = null;
            if (Ogrenciler.Count == 0)
            {
                Console.WriteLine("Listede silinecek öğrenci yok!");
            }
            else
            {
                Console.WriteLine("Silmek istediğiniz öğrencinin");
                Console.Write("No: ");
                no = int.Parse(Console.ReadLine());
                foreach (Ogrenci item in Ogrenciler)
                {
                    if (item.No == no)
                    {
                        o = item;
                        break;
                    }
                }

                if (o != null)
                {
                    Console.WriteLine("Adı: " + o.Ad);
                    Console.WriteLine("Soyadı: " + o.Soyad);
                    Console.WriteLine("Şubesi: " + o.Sube);
                    Console.WriteLine();
                    Console.WriteLine("Silmek istediğinize emin misiniz? (E/H)");
                    string secim = Console.ReadLine().ToUpper();

                    if (secim == "E")
                    {
                        Ogrenciler.Remove(o);
                        Console.WriteLine("Öğrenci silindi.");
                    }
                    else
                    {
                        Console.WriteLine("Öğrenci silinmedi.");
                    }
                }
                else
                {
                    Console.WriteLine("Listede böyle bir öğrenci yok.");
                }
            }
        }

        public static bool SecimAl(string giris)
        {
            //girişin doğru yapıplıp yapılmadığını kontrol etmek için yazdığım metot
            //eğer metota gelen değer dizi içerisinde tanımlanmışsa metot true döndurüyor.
            //eğer dizi dışı bir değer gelmişse metot false döndürüyor.
            bool durum = false;
            string[] kontroldizisi = { "1", "2", "3", "4", "E", "L", "S", "X" };
            //bu şekilde dizi oluşturup içine manuel olarak değer atamayı internette gördüm
            //çıkışın doğru çalışması için 4'ün ve X'in de dizi içinde olması lazım.
            for (int i = 0; i < kontroldizisi.Length; i++)
            {
                if (kontroldizisi[i] == giris)
                {
                    durum = true;
                    break;
                }
                else
                {
                    durum = false;
                }
            }
            return durum;
        }

        static bool OgrenciVarMi(int no)
        {
            foreach (Ogrenci item in Ogrenciler)
            {
                if (item.No == no)
                {
                    return true;
                }
            }
            return false;
        }

        static string IlkHarfBuyut(string veri)
        {
            //gönderilen string verilerin ilk haflerini büyültüp
            //geri gönderen metot.
            veri = veri.Substring(0, 1).ToUpper() + veri.Substring(1).ToLower();
            return veri;
        }
    }
}
