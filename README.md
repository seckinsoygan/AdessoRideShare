# AdessoRideShare

#Projeye ait bilgileri aşağıda bulabilirsiniz.

-Projeyi yaparken çok katmanlı mimariden faydalandım. Proje Entities, Data Access , Business ve WebAPI katmanlarından oluşmaktadır.
-Program cs. tarafında daha clean bir görüntü için IoC container injectionlarını autofac kullanarak başka bir klasöre taşıdım ve IoC containera ait işlemlerimi orda gerçekleştirdim.
-ORM aracı olarak Entity Frameworkten faydalandım.Db connection işlemlerini ve connection stringe ait bilgileri Data Access katmanı altındaki shared klasörünün içinde AppDbContext.cs te bulabilirsiniz.
-İsteğe yönelik response ve requestler için Dtolar oluşturdum ve bunların mappping işlemlerinde AutoMapperdan faydalandım.
-Post requestlerindeki validation işlemleri için FluentValidationdan faydalandım.

Projede 2 farklı entity(Travel,Passenger) bulunmaktadır. Ekleme ve silme işlemleri , tüm travelları getirme işlemleri ve nereden nereye bilgilerini girerek filtrelemeye yönelik verileri alabilmekteyiz.FromWheretoWhere endpointinde verinin gelebilmesi için travelStatus propertysi true olmalıdır.Bu property toplam koltuk sayısı ve yolcu sayısına göre değer almaktadır. Tüm koltuklar doldurulmuşsa status değeri false olacaktır ve responseda görünmeyecektir. GetAll endpointinde entitye ait tüm veriler dönmektedir.

Passenger işlemlerinde yolcu oluşturup silinebilmekte ve aynı zamanda yolcuyu oluştururken yolculuk bilgilerini kişiden isteyerek yolcuya ait yolculuk bilgileri atanmatadır. Yolcu bilgilerini getirirken kişiye ait yolculuk bilgilerini de response içinde dönmektedir.
