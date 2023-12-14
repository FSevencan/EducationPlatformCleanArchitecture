using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class Category : Entity<Guid>
    {
        public string Name { get; set; }
        public virtual ICollection<Module> Modules { get; set; }

        #region virtual
        //virtual
        //var urun = context.Urunler.FirstOrDefault();
        //Console.WriteLine(urun.Kategori.KategoriAdi);

        //Yukarıdaki örnekte Kategori property'si virtual olarak işaretlenmemiştir. Bu durumda, Urun nesnesinin Kategori property'sine erişildiğinde, ilgili Kategori nesnesi veritabanından yüklenmez.Eğer bu nesneye erişilmeye çalışılırsa, null olarak döner.

        //var urun = context.Urunler.FirstOrDefault();
        //// Aşağıdaki satırda Kategori özelliği null olacaktır, çünkü lazy loading yapılmaz.
        //Console.WriteLine(urun.Kategori.KategoriAdi); 

        //virtual Kullanımı:

        //Lazy Loading(Tembel Yükleme): virtual anahtar kelimesi, lazy loading özelliğini destekler.İlişkili nesnelere erişildiğinde, veritabanından otomatik olarak yüklenir.Bu, performansı artırabilir ve yalnızca gerekli verilerin alınmasını sağlar.

        //Proxy Sınıfları: virtual anahtar kelimesi, EF'nin proxy sınıfları oluşturmasına olanak tanır. Bu, değişiklikleri izleme ve veritabanına yansıtma konusunda daha fazla esneklik sağlar.

        //Include Kullanımı:

        //Eager Loading(Hemen Yükleme): Include metodu, ilişkili nesneleri "eager loading" ile yükler.Bu, verileri tek bir sorguda alır ve ilişkili nesneleri yükleyerek performans avantajı sağlar. Ancak, tüm ilişkili verileri almak, gereksiz veri çekmeye neden olabilir.

        //Belirli Durumlar İçin Özelleştirilebilirlik: Include kullanmak, belirli durumlar için daha fazla özelleştirilebilirlik sağlar.Örneğin, sadece belirli bir derinlikteki ilişkili verileri alabilirsiniz. 
        #endregion
    }
}
