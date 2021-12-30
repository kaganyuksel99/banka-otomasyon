using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nesne
{
    class Hesap
    {
        public String Id { get; set; }
        public HesapTuru HesapTuru { get; set; }
        public decimal Para { get; set; }
        public int KarOrani { get; set; }
        public DateTime OlusturulmaTarihi { get; set; } = DateTime.Now;
        public DateTime IslemTarihi { get; set; } = DateTime.Now;
        public IslemTuru IslemTuru { get; set; } 
        public int CekilisHakki { get; set; } 
        public ArrayList islemGecmisi = new ArrayList();
        public int dek = 0;
        public string IslemNumarasi;
        public ArrayList islemDekontuEkle = new ArrayList();

        public void Olustur(HesapTuru hesapTuru, decimal tutar) 
        { 
            if (HesapTuru.KISA_VADE == hesapTuru && tutar >= 5000)
            {
                Id = hesapNo();
                HesapTuru = HesapTuru.KISA_VADE;
                Para = tutar;
                KarOrani = (int)HesapTuru.KISA_VADE;
                islemGecmisi.Add(Id + " hesap numaralı " + " hesabınız Oluşturuldu : Kısa Vade" + IslemTarihi);
                
            }
            else if (HesapTuru.UZUN_VADE == hesapTuru && tutar >= 10000)
            {
                Id = hesapNo();
                HesapTuru = HesapTuru.UZUN_VADE;
                Para = tutar;
                KarOrani = (int)HesapTuru.UZUN_VADE;
                islemGecmisi.Add(Id + " hesap numaralı " + " hesabınız Oluşturuldu : Uzun Vade" + IslemTarihi);   }
            else if (HesapTuru.OZEL == hesapTuru && tutar > 0) 
            {
                Id = hesapNo();
                HesapTuru = HesapTuru.OZEL;
                Para = tutar;
                KarOrani = (int)HesapTuru.OZEL;
                islemGecmisi.Add(Id + " hesap numaralı " + "hesabınız Oluşturuldu : Özel Hesap" + IslemTarihi);
            }
            else if (HesapTuru.CARI == hesapTuru && tutar > 0)
            {
                Id = hesapNo();
                HesapTuru = HesapTuru.OZEL;
                Para = tutar;
                KarOrani = (int)HesapTuru.CARI;
                islemGecmisi.Add(Id + " hesap numaralı " + "hesabınız Oluşturuldu : Cari Hesap" + IslemTarihi);
            }
            else
            {
                if (HesapTuru.KISA_VADE == hesapTuru)
                {
                    System.Console.WriteLine("Kısa vadeli hesap açabilmeniz için paraya en az {0} eklemeniz gerek!", (5000 - tutar));
                }
                else
                {
                    System.Console.WriteLine("Uzun vadeli hesap açabilmeniz için paraya en az {0} eklemeniz gerek!", (10000 - tutar));
                }
            }
        }
        public String hesapNo()
        {
            Random rand = new Random();
            return rand.Next(10000000, 99999999).ToString();
        }

        public void ParaYatir(int tutar)
        {
            Para += tutar;
            CekilisHakki = (tutar / 1000);
            int dek = 1;
            //System.Console.WriteLine("Son 4 hanesi {2} ile biten hesabınıza", IslemTarihi, " tarihinde {1} para yatırıldı!", (Id.Substring(4)), tutar);
            //Console.WriteLine("********"); 
            IslemDekontu(IslemTuru.PARA_YATİR, tutar, dek);
            islemGecmisi.Add(Id + " hesap numaralı " + HesapTuru + " hesabınıza " + IslemTarihi + " 'nde " + tutar + " tutarında para yatırıldı! "); 
            if(HesapTuru != HesapTuru.CARI)
            {
                CekilisHakki += tutar / 1000;
            }
            
        }

        public void ParaCek(int tutar)
        {
            if (tutar > Para)
            {
                System.Console.WriteLine("Hesabınızda yeterli miktarda para yoktur!");
            }
            CekilisHakki = (tutar / 1000);
            Para -= tutar;
            int dek = 2;
            //System.Console.WriteLine("Son 4 hanesi {0} ile biten hesabınıza ", IslemTarihi, " tarihinde {1} para  çekildi!", (Id.Substring(4)), tutar);
            //Console.WriteLine("********");
            IslemDekontu(IslemTuru.PARA_CEK, tutar, dek);
            islemGecmisi.Add(Id + " hesap numaralı "+ HesapTuru + " hesabınıza " + IslemTarihi + " 'nde " + tutar + " tutarında para çekildi! ");
            CekilisHakki += tutar / 1000;
            if (HesapTuru != HesapTuru.CARI)
            {
                CekilisHakki += tutar / 1000;
            }
        }

        public void HesapDurum(string Id, List<Hesap> hesaplar)
        {
            int hesapIndex = hesaplar.FindIndex(hesap => hesap.Id == Id);
            if (hesapIndex != 1)
            {
                System.Console.WriteLine("Hesap No: " + hesaplar[hesapIndex].Id);
                System.Console.WriteLine("Hesap Türü: " + hesaplar[hesapIndex].HesapTuru);
                System.Console.WriteLine("Hesap Bakiye: " + hesaplar[hesapIndex].Para);
                System.Console.WriteLine("Hesap Kar Oranı: " + hesaplar[hesapIndex].KarOrani);
                System.Console.WriteLine("Hesap Oluşturulma Tarihi: " + hesaplar[hesapIndex].OlusturulmaTarihi); 
                //System.Console.WriteLine("Çekiliş Hakkı: " + hesaplar[hesapIndex].CekilisHakki); 

            }
            else
            {
                Console.WriteLine("Hesap Bulunamadı!");
            }


        }

        public void KarTutari()
        {
            decimal gunlukPara = (Para * ((int)HesapTuru / 100m)) / 365m;
            TimeSpan deneme = DateTime.Now - OlusturulmaTarihi;
            System.Console.WriteLine((int)deneme.TotalDays * (Para * ((int)HesapTuru / 100m)) / 365m);
        }

        public ArrayList hesapOzet()
        {
            return islemGecmisi;
        }


        public void IslemDekontu(IslemTuru İslemTuru, decimal tutar, int dek)
        {
            if (dek == 1)
            {
                System.Console.WriteLine("************* İŞLEM DEKONTU *************");
                Console.WriteLine("İşlem Numarası  :" + islemNumarasiekle());
                System.Console.WriteLine("İşlem Yapılan Hesap Turu  :" + HesapTuru);
                System.Console.WriteLine("İşlem Tarihi  :" + IslemTarihi);
                System.Console.WriteLine("İşlem Türü :" + İslemTuru);
                System.Console.WriteLine("İşlem Yapılan Tutar :" + tutar);
                System.Console.WriteLine("İşlem Öncesi Bakiye" + (Para - tutar));
                System.Console.WriteLine("İşlem Sonrası Bakiye " + Para);
                System.Console.WriteLine("************* İŞLEM DEKONTU *************");
            }else if(dek == 4)
            {
                System.Console.WriteLine("İşlem Numarası  :" + islemNumarasiekle());
                System.Console.WriteLine("İşlem Yapılan Hesap Turu  :" + HesapTuru);
                System.Console.WriteLine("İşlem Tarihi  :" + IslemTarihi);
                System.Console.WriteLine("İşlem Türü :" + İslemTuru); 
            }
            else if (dek == 2)
            {
                System.Console.WriteLine("************* İŞLEM DEKONTU *************");
                System.Console.WriteLine("İşlem Numarası  :" + islemNumarasiekle());
                System.Console.WriteLine("İşlem Yapılan Hesap Turu  :" + HesapTuru);
                System.Console.WriteLine("İşlem Tarihi  :" + IslemTarihi);
                System.Console.WriteLine("İşlem Türü :" + İslemTuru);
                System.Console.WriteLine("İşlem Yapılan Tutar :" + tutar);
                System.Console.WriteLine("İşlem Öncesi Bakiye" + (Para + tutar));
                System.Console.WriteLine("İşlem Sonrası Bakiye " + Para );
                System.Console.WriteLine("************* İŞLEM DEKONTU *************");
            }

        } 
        public void HesapIslemKayitlari()
        {
            Id = hesapNo(); 
            for (int i = 0; i < islemGecmisi.Count; i++)
            {
                Console.WriteLine(islemGecmisi[i]);
            }
        }

        public String islemNumarasiekle()
        {
            Random isrand = new Random();
            return isrand.Next(1, 20).ToString();
            IslemNumarasi = islemNumarasiekle();
            Console.WriteLine(IslemNumarasi);
        }



        //public void IslemOzeti(string Id, List<Hesap> hesaplar)
        //{
        //    System.Console.WriteLine("**********  İŞLEM ÖZETİ  **********");
        //    System.Console.WriteLine("İşlem Tarihi: " + IslemTarihi);  
        //    System.Console.WriteLine("İşlem Tarihi: " + IslemTarihi); 
        //    System.Console.WriteLine("İşlem Türü: " + IslemTarihi); 
        //    System.Console.WriteLine("Hesap No: " + Id); 
        //    System.Console.WriteLine("İşlem Yapılan Miktar: " + Para); 

        //    System.Console.WriteLine("**********  İŞLEM ÖZETİ  **********");

        //}

    }
}
