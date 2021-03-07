using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {

        public static string Added= "Eklendi.";
        public static string NotAdded = "Eklenemedi.";
        public static string Deleted = "Silindi!";
        public static string Updated = "Güncellendi.";
        public static string MaintenanceTime = "Bakım zamanı, lütfen daha sonra deneyiniz!";
        public static string Details = "Detaylar getirildi";
        public static string Listed= "Ürünler listelendi!";

        public static string CapacityFulled = "Bu araba için resim kapasitesi dolmuştur.";

        public static string NotDeleted = "Silinemedi.";

        public static string AuthorizationDenied = "Yetkiniz yok.";

        public static string UserRegistered = "Kullanıcı kaydedildi.";
        public static string UserNotFound = "Kullanıcı bulunamadı.";
        public static string PasswordError = "Parola yanlış.";
        public static string SuccessfulLogin = "Başarılı giriş.";
        public static string UserAlreadyExists = "Kullanıcı zaten mevcut.";
        public static string AccessTokenCreated = "Token oluşturuldu.";
    }
}
