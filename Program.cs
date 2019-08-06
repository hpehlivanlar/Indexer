using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexer_ornek
{
    //IEnumarable 
    // yield iki turlu kullanmı mevct
    /*

     * yield return <ifade>
     *  iteratöre çağrı yapılan foreach  döngüsüne bir eleman döndürme işlemi sırasında kullanılır
     *  
     *  
     * 
     * 
     * yield break
     * 
     * foreach içirissinde dönerken bulunan degerğin ardından iteratore aramadevam etmenın nın sonlandıralacağını bildirir
     * 
     * 
     * 
     * 
    */




    class Urun
    {
        public int No { get; set; }

        public string Adı { get; set; }

        public double Fiyat { get; set; }

        public Urun(int no, string ad, double fiyat)
        {
            this.No = no;
            this.Adı = ad;
            this.Fiyat = fiyat;

        }


    }


    class UrunYonet : IEnumerable<Urun>
    {



        /// <summary>
        /// Urun yönet kısmında türetilen nesne üzerinden Urun sınıfına gelen tüm dergerleri teker teker uruns lere ekliyoruz.
        /// </summary>
        Urun[] uruns;

        public Urun[] urunler
        {
            get { return  uruns; }
            set { uruns = value; }
        }
                

        /// <summary>
        /// Bu metot Urun sınıfında gelen degerleri teker teker  degerlerini geri döndürüdür.
        /// </summary>
        /// <returns></returns>
         private Urun[] UrunleriGetir()
        {
            return new Urun[]{
                new Urun(1, "Elma", 100.5),
                 new Urun(10, "Nar", 100.5),
                  new Urun(11, "Armut", 100.5) };

        }

        public UrunYonet()
        {
            uruns = UrunleriGetir();
        }

        /// <summary>
        ///    Liste yapısı içierinde Herbir indexe elemanını  tutuğu degeri geri gönderiyor 
        /// </summary>
        /// <returns></returns>
        public IEnumerator<Urun> GetEnumerator()
        {
            for (int i = 0; i < uruns.Length; i++)
            {

                
                yield return urunler[i];
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }




    }


    class Program
    {
        static void Main(string[] args)
        {
            //nesne türetildi
            UrunYonet urunyonet = new UrunYonet();

            //Urunu sinifina iterasyon yapılarını kazandıraak özellikleri barındıran, IEnumarator  nesneni dönen bir metotdur.
            IEnumerator<Urun> uruns = urunyonet.GetEnumerator();


            //iteratorde son eleman kada rolan degerleri alıyor
            while (uruns.MoveNext())
            {
                Console.WriteLine(uruns.Current.Adı + uruns.Current.Fiyat);
            }


        }
    }
}
