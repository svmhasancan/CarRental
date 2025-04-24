using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constanse
{
    public static class Messages
    {
        public static string AuthorizationDenied = "Yetkiniz Yok!";
        public static string UserAdded = "Kullanıcı Eklendi!";
        public static string UserDeleted = "Kullanıcı Silindi!";
        public static string UserUpdated = "Kullanıcı Güncellendi!";
        public static string UserNotFound = "Kullanıcı Bulunamadı!";
        public static string PasswordError = "Hatalı Şifre Girdiniz!";
        public static string SuccessfulLogin = "Giriş Başarılı!"; 
        public static string UserAlreadyExists = "Kullanıcı Zaten Mevcut!";
        public static string AccessTokenCreated = "Access Token Oluşturuldu!";
        public static string CarAdded = "Araç Eklendi";
    }
}