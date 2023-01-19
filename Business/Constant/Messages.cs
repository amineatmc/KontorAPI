using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constant
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün Eklendi.";
        public static string ProductNameInvalid = "Ürün ismi geçersiz.";
        public static string MaintenanceTime = "Sistem bakımda.";
        public static string ProductsListed = "Ürünler Listelendi.";
        public static string ProductCountOfCategoryError = "En Fazla 10 adet ürün eklenebilir.";


        public static string UsersError = "Kuulanıcı Adı veya Şifre Hatalı !";
        public static string UsersSuccesLogin = "Giriş Yapıldı.";
        public static string ProductNameAlReadyExists = "aynı isimde ürün eklenemez.";
        public static string CategoryLimitExceded = "Kategoriler sayısı 15!ten fazla ";
        public static string AuthorizationDenied = "yetkiniz yok.";


        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";
        public static string ActivationError = "Hesap Aktivasyonu Gerekli";

        public static string ProductNameAlreadyExists = "Bu isimde ürün mevcut.";
        public static string BalancesAdded;
        public static string Success = "Success";

        public static string InvoicesListed = "Faturalar Listelendi.";
    }
}
