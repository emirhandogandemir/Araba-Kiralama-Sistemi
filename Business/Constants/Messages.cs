using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public class Messages
    {
        public static string CarAdded = "araba eklendi";
        public static string CarNameInValid = "Ürün ismi geçersiz";
        public static string MaintenanceTime = "sistem bakımda";
        public static string CarUpdated = "ürün güncellendi";
        public static string CarsListed = "ürünler lsitelendi";
        public static string CarDeleted = " araba silindi ";
        public static string CarPriceInValid =  " Geçersiz fiyat";
        
        
        public static string BrandAdded = "marka eklendi";
        public static string BrandNameInValid = "marka ismi geçersiz";
        public static string BrandDeleted = "marka başarılı ile silindi";
        
        
        public static string ColorAdded = " renk eklendi";
        public static string ColorUpdated = "renk güncellendi";
        public static string ColorDeleted = " renk silindi";

        public static string UserAdded = "Kullanıcı başarılı şekilde eklendi";
        public static string UserUpdated = "Kullanıcı başarılı şekilde güncellendi";
        public static string UserDeleted = " kullanıcı başarılı şekilde silindi";

        public static string AddedCustomer = "Müşteri başarıyla eklendi.";
        public static string DeletedCustomer = "Müşteri başarıyla silindi.";
        public static string UpdatedCustomer = "Müşteri başarıyla güncellendi.";

        public static string RentalAdded = "Araba Kiralama işlemi baraşıyla gerçekleşti.";
        public static string RentalDeleted = "Araba Kiralama işlemi iptal edildi.";
        public static string RentalUpdated = "Araba Kiralama işlemi güncellendi.";
        public static string FailedRentalAddOrUpdate = "Bu araba henüz teslim edilmediği için kiralayamazsınız.";
        public static string RentalReturned = "Kiraladığınız araç teslim edildi.";


        public static string CarImageAdded = "Araba Resmi başarı ile eklendi";
        public static string CarImageUpdated = "Araba resmi başarı ile güncellendi";
        public static string CarImageDeleted = "Araba resmi başarı ile silindi";
        public static string CarImageListed = "Araba resimlerinin hepsi listelendi";
        
        
        internal static object MaximumImageInCar;
       public static string AuthorizationDenied = "Yetkiniz yok";
    }
}
