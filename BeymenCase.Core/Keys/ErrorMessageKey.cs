using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeymenCase.Core.Keys
{
    public class ErrorMessageKey
    {
        public const string BillingPlanNotFound = "Billing Plan Bulunamadı";
        public const string BillingPlanItemNotFound = "BillingPlanItem Bulunamadı";
        public const string AgreementNotFound = "Agreement bulunamadı";
        public const string CommnetDuplicate = "Bu tipte yorum var";
        public const string RetroDuplicate = "Etkinlik reto raporu zaten mevcut";
        public const string CommnetNotFound = "Yorum bulunamadı";
        public const string UserNotFound = "Kullanıcı bulunamadı";
        public const string CompanyNotFound = "Şirket bulunamadı";
        public const string SettingNotFound = "Title bulunamadı";
        public const string TaskNotFound = "Task bulunamadı";
        public const string RoleNotFound = "Rol bulunamadı";
        public const string ProjectNotFound = "Proje bulunamadı";
        public const string SprintNotFound = "Sprint bulunamadı";
        public const string TeamNotFound = "Team bulunamadı";
        public const string TeamUserNotFound = "Team içerisinde personel bulunamadı";
        public const string PasswordNotExits = "Email ya da şifre yanlış";
        public const string UserAlreadyExits = "Kullanıcı zaten mevcut";
        public const string CustomerAlreadyExits = "Müşteri zaten mevcut";
        public const string RoleAlreadyExits = "Rol zaten mevcut";
        public const string TeamNameAlreadyExits = "Takım ismi zaten mevcut";
        public const string Unauthorized = "Login değilsiniz";
        public const string MailExists = "Mail adresi zaten mevcut";
        public const string UserNotRegister = "Kullanıcı kaydedilirken bir hata oluştu";
        public const string AuthorityNotRegister = "Yetki kaydedilirken bir hata oluştu";
        public const string AuthorityNotFound = "Yetki bulunamadı";
        public const string RetroNotFound = "Retro bulunamadı";
        public const string GoogleCaptchaInvalid = "Google Captcha Geçersiz";
        public const string GoogleError = "Google Hata";
        public const string PasswordUpperCase = "Şifre büyük harf içermeli";
        public const string PasswordLowerCase = "Şifre küçük harf içermeli";
        public const string PasswordNumber = "Şifre rakam içermeli";
        public const string PasswordEightCharacter = "Şifre 8 karakterden az olamaz";
        public const string TokenInvalid = "Token tanımlı değil";
        public const string EnumError = "enumType should describe enum";
        public const string ProjectDuplicateError = "Seçilen projenin bir sözleşmesi mevcut. Başka bir proje seçiniz.";
    }
}