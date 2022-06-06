using System;
using System.Collections.Generic;
using DataAccess.Context;
using Entity.POCO;

namespace DataAccess.DataSeed
{
    public static class DataSeed
    {
        public static void Seed()
        {
            GamesectionDbContext db = new GamesectionDbContext();
            List<Category> categories = new List<Category>
            {
                new Category{ CategoryName="Simülasyon",
                    CategoryImageURL="/img/cards/SimulationCategory.jpg"},
                new Category{ CategoryName="Açık Dünya",
                CategoryImageURL="/img/cards/OpenWorldCategory.jpg"},
                new Category{ CategoryName="FPS",
                CategoryImageURL="/img/cards/FPSCategory.jpg"},
            };
            db.Category.AddRange(categories);
            db.SaveChanges();

            List<Game> games = new List<Game>()
            {
                new Game{Name="Thief Simulator",Price=9,Stock=1000,Description="Gerçek hırsız ol. Serbest dolaşım sanal alan mahallelerinde çalın. Hedefinizi gözlemleyin ve hırsızlıkta size yardımcı olacak bilgileri toplayın. Meydan okumaya katılın ve en güvenli evleri sokun. Bazı yüksek teknolojili hırsız ekipmanları satın alın ve yeni hırsız numaralarını öğrenin. Yoldan geçenlere çalıntı mal satmak. Gerçek bir hırsızın yaptığı her şeyi yapın!"},
                new Game{Name="Farming Simulator 22",Price=215,Stock=1000,Description="Modern bir çiftçi olmaya ne dersin? Tarım, hayvancılık ve ormancılık faaliyetleri sırasında, her mevsim ama özellikle de kış geldiğinde, üstesinden gelmen gereken pek çok zorlukla yüzleşeceksin. Yaratıcılığını kullanarak çiftliğini inşa et ve ürün zincirleriyle çiftçilik operasyonlarını geliştirerek bir tarım imparatorluğu kur! İstersen çiftliğini arkadaşlarınla birlikte işletebilir ve çok oyunculu modla oyunun keyfini farklı platformlarda çıkarabilirsin."},
                new Game{Name="Internet Cafe Simulator 2",Price=32,Stock=1000,Description="Serinin ikinci oyunu çok daha detaylı ve farklı yeni mekanikler içeriyor.Harika bir internet kafe inşa et. Sokak haydutlarının ve gangsterlerin paranızı almasına izin vermeyin. Kafenizin içine bomba bile atabilirler."},
                new Game{Name="Red Dead Redemption 2",Price=149,Stock=1000,Description="Artur Morgan ve Van der Linde çetesi kaçıyor. Federal ajanlar ve ülkenin en iyi ödül avcılarının amansız takibi altında çete üyeleri hayatta kalabilmek için soyguna, yağmaya ve dövüşmeye devam ederek Amerika'nın kalbindeki çetin toprakları geçmek zorunda. Bu süreçte iç çatışmaları da iyice derinleşen çete artık dağılmanın eşiğine gelirken Artur da zor bir seçimle karşı karşıya: onu yetiştiren çeteye sadık mı kalacak yoksa kendi ideallerinin peşinden mi gidecek?"},
                new Game{Name="Grand Theft Auto V",Price=77,Stock=1000,Description="Genç bir serseri, inzivaya çekilmiş bir banka soyguncusu ve ürkütücü bir psikopat, kendilerini suç dünyasının, ABD hükümetinin ve eğlence sektörünün karışık ağlarında buluyor. Kendileri de dahil, hiç kimseye güvenemedikleri acımasız bir şehirde tehlikeli soygunlar yapmayı başarmak zorundalar."},
                new Game{Name="Forza Horizon 5",Price=299,Stock=1000,Description="Efsanevi Horizon Maceranız sizi bekliyor! Dünyanın en harika arabalarından yüzlercesiyle birlikte sınırsız, eğlenceli sürücülük aksiyonuyla Meksika'nın capcanlı ve her daim gelişmekte olan açık dünya manzaralarını keşfedin."},
                new Game{Name="Counter-Strike: Global Offensive",Price=69,Stock=1000,Description="Counter-Strike: Global Offensive (CS: GO), 19 yıl önce ilk çıktığında öncülük ettiği takım tabanlı aksiyon oyununu bir üst seviyeye taşıyor."},
                new Game{Name="PUBG: BATTLEGROUNDS",Price=69,Stock=1000,Description="SAHAYA İNİN, YAĞMALAYIN, HAYATTA KALIN! PUBG: BATTLEGROUNDS'u ücretsiz oynayın. Stratejik konumlara iniş yapın, silahları ve malzemeleri yağmalayın, çeşitli ve geniş Savaş Alanlarında hayatta kalan son takım olmak için mücadele edin.  Ekibinizi toplayın ve sadece PUBG: BATTLEGROUNDS'un sunabileceği orijinal Battle Royale deneyimi için Savaş Alanlarına katılın."},
                new Game{Name="The Witcher® 3: Wild Hunt",Price=59,Stock=1000,Description="The Witcher: Wild Hunt, görsel olarak nefes kesici bir evrende geçen, anlamlı tercihlerle ve etkili sonuçlarla dolu öykü tabanlı açık dünya RPG oyunudur. The Witcher'da ticaret şehirleri, korsan adaları, tehlikeli dağ geçitleri ve keşfedilmeyi bekleyen unutulmuş büyük mağaralarla dolu geniş bir açık dünyada bir kehanetin çocuğunu bulma görevi verilmiş profesyonel bir canavar avcısı olarak Geralt of Rivia olarak oynayın."},
                new Game{Name="Cyberpunk 2077",Price=249,Stock=1000,Description="Cyberpunk 2077, hayatta kalabilmek için ölüm kalım mücadelesi veren bir siberhaydut paralı asker olarak oynadığın, Night City kümekentinde geçen bir açık dünya aksiyon macera RPG'sidir. İyileştirmeler ve yepyeni ücretsiz ek içerikler ile görevlere çıktıkça şöhret kazanıp yeni geliştirmeler açarak karakterini ve oynanış stilini özelleştir. Kurduğun ilişkiler ve aldığın kararlar hikâyeyi ve içinde bulunduğun dünyayı şekillendirecek. Burası, efsanelerin yazıldığı yer. Peki seninki nasıl olacak?"},
                new Game{Name="Hunt: Showdown",Price=49,Stock=1000,Description="Takvimler 1895 yılını gösterirken Louisiana Nehir Kolu'nu doldurup taşan vahşi, ürkütücü canavarları öldürmekle görevlendirilen bir Avcıyı oynuyorsun. İster tek başına oynayabilir ister iki veya üç kişilik takımlar kurabilirsin. Hedefinin izini sürmene yardımcı olacak ve seni aynı ödülü avlayan diğer Avcılardan bir adım ileri taşıyacak ipuçları bulman gerekiyor. Hedefini öldürüp defnet, ödülü topla ve müsabakaya hazırlan! Ödülü kazandığında haritadaki diğer Avcılar ödülü senden almak için peşine düşecek. Kimseye merhamet gösterme. Karanlık ve acımasız bu dünyada dönemden ilham alan dehşet verici silahları kuşanarak Kan Kudretin için mücadele et, seviye atla, yeni ekipmanlar topla, tecrübe ve altın kazan."},
                new Game{Name="The Cycle: Frontier",Price=89,Stock=1000,Description="Yüzeye çıkın ve ceplerinizi hazineler ve kaynaklarla doldurun. Ancak dikkatli olun, yalnızca hayatta kalmayı başaranların ganimetlerini tutmasına izin verilir. Kana susamış canavarlara ve açgözlü oyunculara dikkat edin ya da onları aktif olarak avlamak ve zor kazanılmış ödüllerini kendiniz çalmak için yola çıkın."},
                new Game{Name="Squad",Price=79,Stock=1000,Description="Squad, iletişim ve takım çalışması ile muharebe gerçekçiliğini yakalamayı hedefleyen 50 vs 50 kişilik çok oyunculu birinci şahıs nişancı, taktik ve planlama ile birlikte güçlü manga mekaniklerini büyük ölçekli koordinasyonlarda olsa bile vurgulayan bir oyundur. Özellikleri ise büyük açık haritalar, araç bazlı kombine silah oyunu, balyoz etkisi yaratmak için oyuncu tarafından inşa edilmiş üsler, gerçek dünya ölçeğinde organize taktikler ile birden fazla manganın planlaması ile oynama özelliği sunar."},
                new Game{Name="Call of Duty®: Black Ops III",Price=209,Stock=1000,Description="Call of Duty®: Black Ops III Zombies Chronicles Edition'da temel oyunun tümü ve Zombies Chronicles içerik genişleme paketi yer alıyor. Call of Duty: Black Ops III, üç benzersiz oyun modu sunuyor: Sefer, Çok Oyunculu ve Zombiler. Bu modlar hayranlarına gelmiş geçmiş en derin ve en iddialı Call of Duty tecrübesini sunuyor."},

            };   
            db.Game.AddRange(games);
            db.SaveChanges();

            List<GameCategory> gameCategories = new List<GameCategory>
            {
                new GameCategory{ CategoryID=1,GameID=1},
                new GameCategory{ CategoryID=1,GameID=2},
                new GameCategory{ CategoryID=1,GameID=3},
                new GameCategory{ CategoryID=2,GameID=4},
                new GameCategory{ CategoryID=2,GameID=5},
                new GameCategory{ CategoryID=2,GameID=6},
                new GameCategory{ CategoryID=3,GameID=7},
                new GameCategory{ CategoryID=3,GameID=8},
                new GameCategory{ CategoryID=2,GameID=9},
                new GameCategory{ CategoryID=2,GameID=10},
                new GameCategory{ CategoryID=3,GameID=11},
                new GameCategory{ CategoryID=3,GameID=12},
                new GameCategory{ CategoryID=3,GameID=13},
                new GameCategory{ CategoryID=3,GameID=14},
            };
            db.GameCategory.AddRange(gameCategories);
            db.SaveChanges();

            List<GameImage> gameImages = new List<GameImage>
            {
                new GameImage{ GameID=1, ImageURL="/img/cards/Thief-Simulator.jpg"},
                new GameImage{ GameID=2, ImageURL="/img/cards/farming-simulator-22.jpeg"},
                new GameImage{ GameID=3, ImageURL="/img/cards/internet-cafe-simulator-2.jpeg"},
                new GameImage{ GameID=4, ImageURL="/img/cards/Red-Dead-Redemption-2.jpeg"},
                new GameImage{ GameID=5, ImageURL="/img/cards/Grand-Theft-Auto-V.jpeg"},
                new GameImage{ GameID=6, ImageURL="/img/cards/forza-horizon-5.jpeg"},
                new GameImage{ GameID=7, ImageURL="/img/cards/Counter-Strike-Global-Offensive.jpg"},
                new GameImage{ GameID=8, ImageURL="/img/cards/PUBG-BATTLEGROUNDS.jpeg"},
                new GameImage{ GameID=9, ImageURL="/img/cards/The-Witcher-3-Wild-Hunt.jpg"},
                new GameImage{ GameID=10, ImageURL="/img/cards/Cyberpunk-2077.jpg"},
                new GameImage{ GameID=11, ImageURL="/img/cards/Hunt-Showdown.jpg"},
                new GameImage{ GameID=12, ImageURL="/img/cards/The-Cycle-Frontier.jpeg"},
                new GameImage{ GameID=13, ImageURL="/img/cards/Squad.jpeg"},
                new GameImage{ GameID=14, ImageURL="/img/cards/Call-of-Duty-Black-Ops-III.jpg"},
                
            };
            db.GameImage.AddRange(gameImages);
            db.SaveChanges();

            List<SecondhandGame> secondhandGames = new List<SecondhandGame>()
            {
                
                new SecondhandGame{GameName="Escape Simulator",AddUserID=1,Price=20,Stock=1000,Description="Escape Simulator, tek başına veya online eşli modda oynayabileceğin birinci şahıs bir bulmaca oyunu. Olabildiğince yoğun etkileşimli bir sürü kaçış odasını keşfet. Eşyaları yerinden oynat, kaldır; çanağı çömleği parçala; kilitleri aç ve her şeyi incele! Seviye düzenleyici aracılığıyla topluluk yapımı odaları oynamak da mümkün."},
                new SecondhandGame{GameName="Ranch Simulator",AddUserID=1,Price=32,Stock=1000,Description="Aile çiftliğiniz bir zamanlar büyükbabanın gurur ve mutluluk kaynağıydı ancak burası zor zamanlardan geçti ve şimdi durumu tersine çevirmek senin elinde. İzbe ve ormanlık bir vadide bulunan bu viran olmuş çiftlik evi, onu bölgedeki en başarılı çiftliğe dönüştürmeye çalışırken senin tüm becerilerini sınayacak. Yalnız başına veya en fazla dört kişilik ortaklaşa çok oyunculu modda da oynanabilir."},
                new SecondhandGame{GameName="Mount & Blade II: Bannerlord",AddUserID=2,Price=149,Stock=1000,Description="Savaş boruları çalar, kuzgunlar toplanır. İç savaş koca bir krallığı yıpratır. Sınırların ötesinde yeni krallıklar yükselir. Kılıcını kuşan, zırhını giy, adamlarını topla ve şan kazanmak için Kalradya savaş alanlarına atıl. Egemenliğini kur ve eskisinin küllerinden yeni bir dünya yarat."},
                new SecondhandGame{GameName="Ready or Not",AddUserID=3,Price=99,Stock=1000,Description="Ready or Not, düşmanca ve zorlu durumları çözmek için SWAT polis birimlerinin çağrıldığı, günümüz dünyasını tasvir eden son derece yoğun, taktiksel bir birinci şahıs nişancı oyunudur."},

            };
            db.SecondhandGame.AddRange(secondhandGames);
            db.SaveChanges();

            List<SecondhandGameCategory> secondhandGameCategories = new List<SecondhandGameCategory>
            {
                new SecondhandGameCategory{ CategoryID=1,SecondhandGameID=1},
                new SecondhandGameCategory{ CategoryID=1,SecondhandGameID=2},
                new SecondhandGameCategory{ CategoryID=2,SecondhandGameID=3},
                new SecondhandGameCategory{ CategoryID=3,SecondhandGameID=4},
               
            };
            db.SecondhandGameCategory.AddRange(secondhandGameCategories);
            db.SaveChanges();

            List<SecondhandGameImage> secondhandGameImages = new List<SecondhandGameImage>
            {
                new SecondhandGameImage{ SecondhandGameID=1, ImageURL="/img/cards/escape-simulator.jpeg"},
                new SecondhandGameImage{ SecondhandGameID=2, ImageURL="/img/cards/Ranch-Simulator.jpeg"},
                new SecondhandGameImage{ SecondhandGameID=3, ImageURL="/img/cards/mount-and-blade-bannerlord-2.jpg"},
                new SecondhandGameImage{ SecondhandGameID=4, ImageURL="/img/cards/Ready-or-Not.jpeg"},

            };
            db.SecondhandGameImage.AddRange(secondhandGameImages);
            db.SaveChanges();
        }
    }
}
