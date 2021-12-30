using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nesne
{
    class Banka
    {
        string title = @" __       __                                   _______                    __       
|  \     /  \                                 |       \                  |  \      
| $$\   /  $$ ______   ______   ______        | $$$$$$$\ ______  _______ | $$   __ 
| $$$\ /  $$$/      \ /      \ |      \       | $$__/ $$|      \|       \| $$  /  \
| $$$$\  $$$|  $$$$$$|  $$$$$$\ \$$$$$$\      | $$    $$ \$$$$$$| $$$$$$$| $$_/  $$
| $$\$$ $$ $| $$    $| $$  | $$/      $$      | $$$$$$$\/      $| $$  | $| $$   $$ 
| $$ \$$$| $| $$$$$$$| $$__| $|  $$$$$$$      | $$__/ $|  $$$$$$| $$  | $| $$$$$$\ 
| $$  \$ | $$\$$     \\$$    $$\$$    $$      | $$    $$\$$    $| $$  | $| $$  \$$\
 \$$      \$$ \$$$$$$$_\$$$$$$$ \$$$$$$$       \$$$$$$$  \$$$$$$$\$$   \$$\$$   \$$
                     |  \__| $$                                                    
                      \$$    $$                                                    
                       \$$$$$$                                                  PARANIZA DEĞER KATAR   ";

        List<Hesap> hesaplar = new List<Hesap>();
        List<Hesap> islemKayitları = new List<Hesap>();
        public ArrayList ıslemGecmişi = new ArrayList();
        List<Hesap> cekilisListesi = new List<Hesap>();
        Hesap hesap = new Hesap(); 

        public void Start()
        {
            Console.Write(title);
            Console.ReadKey();
            Console.Write("\n  \n \n->>> Lütfen adınızı giriniz: ");
            String name = Console.ReadLine();
            Console.Write(" \n->>> Lütfen soyadınızı giriniz: ");
            String surname = Console.ReadLine();
            Console.WriteLine("\n->>> Hoşgeldiniz " + name + " " + surname + "\n");
            menu();
            while (true)
            {
                var secim = Console.ReadKey(true);
                if (secim.Key == ConsoleKey.NumPad8)
                {
                    break;
                }
                switch (secim.Key)
                {
                    case ConsoleKey.NumPad8:
                        {
                            Console.WriteLine("\n Çıkış Yapılıyor... ");
                            break;
                        }
                    case ConsoleKey.NumPad1:
                        {
                            hesapAc();
                            break;
                        }
                    case ConsoleKey.NumPad2:
                        {
                            paraYatir();
                            break;
                        }
                    case ConsoleKey.NumPad3:
                        {
                            paraCek();
                            break;
                        }
                    case ConsoleKey.NumPad4:
                        {
                            hesapListesi();
                            menu();
                            break;
                        }
                    case ConsoleKey.NumPad5:
                        {
                            Console.Write("\nHesap Numarasını Giriniz : ");
                            string bankaHesapId = Console.ReadLine();
                            hesap.HesapDurum(bankaHesapId, hesaplar);
                            Console.WriteLine("Anasayfaya yönlendiriliyorsunuz...");
                            Console.WriteLine("\n");
                            menu();
                            break;
                        }
                    case ConsoleKey.NumPad6:
                        {
                            //islemGecmisiGoster();
                            //hesapIslemKayitlari(); 
                            Console.WriteLine("\n");
                            String hesapNoGiris;
                            Console.Write("Hesap Numarasını Giriniz : ");
                            hesapNoGiris = Console.ReadLine();
                            if (hesap.Id == hesapNoGiris)
                            {
                                hesap.HesapIslemKayitlari();  
                                Console.WriteLine("Anasayfaya yönlendiriliyorsunuz...");
                                Console.WriteLine("\n");
                                menu();
                            } else
                            {
                                Console.WriteLine("Yanlış hesap numarası girdiniz. Ana menüye yönlendiriliyorsunuz! ");
                                menu();
                            }
                            break;
                        }
                    case ConsoleKey.NumPad7:
                        {
                            cekilis();
                            break;
                        }

                }
            }

        }

        public void hesapAc()
        {
            Console.Clear();
            Console.WriteLine("\t 1 Kısa Vadeli Hesap Açma");
            Console.WriteLine("\t 2 Uzun Vadeli Hesap Açma");
            Console.WriteLine("\t 3 Özel Hesap Açma");
            Console.WriteLine("\t 4 Cari Hesap Açma");
            Console.Write("Lütfen açmak istediğiniz hesap türünü seçiniz (1-4)");
            int hesapSecim = Convert.ToInt32(Console.ReadLine());
            if (hesapSecim == 1)
            {
                Console.Write("Hesap Açmak İçin Para Yatırınız. Yatırmak istediğiniz :");
                int yatir = Convert.ToInt32(Console.ReadLine());
                hesap.Olustur(HesapTuru.KISA_VADE, yatir);
                Console.WriteLine("Kısa Vadeli Hesabınız Oluşturuldu.");
                Console.WriteLine("Hesap Numaranız: " + hesap.Id);
                hesaplar.Add(hesap);
                
                //ıslemGecmişi.Add(HesapTuru.KISA_VADE, hesap.Id, yatir); // asdasdadsadsads
                Console.Write("Ana Menüye Dönmek için 1'i tuşlayınız: ");
                int anaMenu = Convert.ToInt32(Console.ReadLine());
                if (anaMenu == 1)
                {
                    menu();
                }
            }
            else if (hesapSecim == 2)
            {
                Console.Write("Hesap Açmak İçin Para Yatırınız. Yatırmak istediğiniz :");
                int yatir = Convert.ToInt32(Console.ReadLine());
                hesap.Olustur(HesapTuru.UZUN_VADE, yatir);
                Console.WriteLine("Uzun Vadeli Hesabınız Oluşturuldu.");
                Console.WriteLine("Hesap Numaranız: " + hesap.Id);
                hesaplar.Add(hesap);
                Console.Write("Ana Menüye Dönmek için 1'i tuşlayınız: ");
                int anaMenu = Convert.ToInt32(Console.ReadLine());
                if (anaMenu == 1)
                {
                    menu();
                }
            }
            else if (hesapSecim == 3)
            {
                Console.Write("Hesap Açmak İçin Para Yatırınız. Yatırmak istediğiniz :");
                int yatir = Convert.ToInt32(Console.ReadLine());
                hesap.Olustur(HesapTuru.OZEL, yatir);
                Console.WriteLine("Özel Hesabınız Oluşturuldu.");
                Console.WriteLine("Hesap Numaranız: " + hesap.Id);
                hesaplar.Add(hesap);
                Console.Write("Ana Menüye Dönmek için 1'i tuşlayınız: ");
                int anaMenu = Convert.ToInt32(Console.ReadLine());
                if (anaMenu == 1)
                {
                    menu();
                }
            }
            else if (hesapSecim == 4)
            {
                Console.Write("Hesap Açmak İçin Para Yatırınız. Yatırmak istediğiniz :");
                int yatir = Convert.ToInt32(Console.ReadLine());
                hesap.Olustur(HesapTuru.CARI, yatir);
                Console.WriteLine("Cari Hesabınız Oluşturuldu.");
                Console.WriteLine("Hesap Numaranız: " + hesap.Id);
                hesaplar.Add(hesap);
                Console.Write("Ana Menüye Dönmek için 1'i tuşlayınız");
                int anaMenu = Convert.ToInt32(Console.ReadLine());
                if (anaMenu == 1)
                {
                    menu();
                }
            }
            else
            {
                Console.WriteLine("Geçersiz Seçim Yaptınız. Ana menüye yönlendiriliyorsunuz !");
                menu();
            }
            
        }
        public void paraYatir()
        {
            String hesapNoGiris;
            Console.Write("\nLütfen para yatırmak istediğiniz hesabın hesap numarasını giriniz : ");
            hesapNoGiris = Console.ReadLine();
            if (hesap.Id == hesapNoGiris)
            {
                Console.Write("Lütfen yatırmak istediğiniz miktarı giriniz: ");
                int tutar = Convert.ToInt32(Console.ReadLine());
                hesap.ParaYatir(tutar);
                Console.WriteLine("Para yatırma işlemi başarılı!! \n");
                Console.Write("Ana Menüye Dönmek için 1'i tuşlayınız: ");
                int anaMenu = Convert.ToInt32(Console.ReadLine());
                if (anaMenu == 1)
                {
                    menu();
                }
                else
                {
                    Console.WriteLine("Geçersiz Seçim Yaptınız. Ana menüye yönlendiriliyorsunuz !");
                    menu();
                }
            } else
            {
                Console.WriteLine("\nYanlış Hesap Numarası Giriniz. Ana Menüye Yönlendiriliyorsunuz"); 
            }
            
        }
        public void paraCek()
        {
            String hesapNoGiris;
            Console.Write("\nLütfen para çekmek istediğiniz hesabın hesap numarasını giriniz : ");
            hesapNoGiris = Console.ReadLine();
            if (hesap.Id == hesapNoGiris)
            {
                Console.Write("Lütfen çekmek istediğiniz miktarı giriniz : ");
                int tutar = Convert.ToInt32(Console.ReadLine());
                hesap.ParaCek(tutar);
                Console.WriteLine("Para çekme işlemi başarılı \n");
                Console.Write("Ana Menüye Dönmek için 1'i tuşlayınız ");
                int anaMenu = Convert.ToInt32(Console.ReadLine());
                if (anaMenu == 1)
                {
                    menu();
                }
                else
                {
                    Console.WriteLine("Geçersiz Seçim Yaptınız. Ana menüye yönlendiriliyorsunuz !");
                    menu();
                }
            }
        }
        public void hesapListesi()
        {
            foreach (var hesap in hesaplar)
            {
                Console.WriteLine("Aşağıda bankamızda bulunan hesaplar listelenmiştir.");
                Console.WriteLine("Hesap no: " + hesap.Id);
                Console.WriteLine("Hesap türü: " + hesap.HesapTuru);
                Console.WriteLine("Hesap oluşturulma tarihi : " + hesap.OlusturulmaTarihi);
                Console.WriteLine("Hesap bakiyesi: " + hesap.Para);
                Console.WriteLine("Hesap çekiliş hakkı: " + hesap.CekilisHakki);
                Console.WriteLine("\n");
            }
        }

        //public void hesapDurumuGoster()
        //{
        //    String hesapNoGiris;
        //    Console.Write("Hesap durumunu görmek için hesap numarasını girmeniz gerekmektedir : ");
        //    hesapNoGiris = Console.ReadLine();
        //    if (hesap.Id == hesapNoGiris)
        //    {
        //        hesap.HesapDurum();
        //    }

        //}

        public void cekilis()
        {
            Random cekilisPara = new Random(); 
            int a = cekilisPara.Next(200, 1000); // Çekilişle verilecek para 
            foreach (var hesap in hesaplar)
            {
                hesap.dek = 4;
                Random deneme = new Random();
                int b = deneme.Next(hesaplar.Count);
                Console.WriteLine("Çekilişi kazanan hesap: " + b + " numaralı hesap");
                hesap.ParaYatir(a);
                hesap.IslemDekontu(IslemTuru.CEKİLİS, a , hesap.dek);


            }

        }

        
        public void islemGecmisiGoster()
        {

            //hesap.hesapOzet();
        }

        public static void menu()
        {
            Console.WriteLine("1. Hesap Açma İşlemleri");
            Console.WriteLine("\t 1.1 Kısa Vadeli Hesap Açma");
            Console.WriteLine("\t 1.2 Uzun Vadeli Hesap Açma");
            Console.WriteLine("\t 1.3 Özel Hesap Açma");
            Console.WriteLine("\t 1.4 Cari Hesap Açma");
            Console.WriteLine("2. Para Yatırma İşlemleri (HESAP NO İLE !)");
            Console.WriteLine("3. Para Çekme İşlemleri (HESAP NO İLE !)");
            Console.WriteLine("4. Hesap Listesi");
            Console.WriteLine("5. Hesap Durum (HESAP NO İLE !)");
            Console.WriteLine("6. Hesap İşlem Kayıtları (HESAP NO İLE !)");
            Console.WriteLine("7. Çekiliş");  // TODO - kişinin çekiliş hakkı yoksa uyarı verilebilir.
            Console.WriteLine("8. ÇIKIŞ ");
            Console.WriteLine("\n");
            Console.Write("->>> Yapmak İstediğiniz İşlemi Seçiniz: ");
        }
    }
}
