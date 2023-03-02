using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeymenCase.Core.Keys
{
    public static class ValidationKey
    {
        public const string IdNotNull = "Id boş geçilemez";
        public const string UserIdNotNull = "User Id boş geçilemez";
        public const string ParentIdNotNull = "Parent Id boş geçilemez";
        public const string TaxNumberNotNull = "Vergi numarası boş geçilemez";
        public const string EmailNotNull = "Email boş geçilemez";
        public const string UserTypeNotNull = "Kullanıcı tipi boş geçilemez";
        public const string UserStatusNotNull = "Kullanıcı durumu boş geçilemez";
        public const string UserPhotoNotNull = "Kullanıcı resmi boş geçilemez";
        public const string EnglishLevelNotNull = "İngilizce seviyesi boş geçilemez";
        public const string WorkingTypeNotNull = "Çalışma tipi boş geçilemez";
        public const string SprintNoNotNull = "Sprint no boş geçilemez";
        public const string NameNotNull = "İsim boş geçilemez";
        public const string CurrentPasswordNotNull = "Mevcut şifre boş geçilemez";
        public const string NewPasswordNotNull = "Yeni şifre boş geçilemez";
        public const string PasswordNotNull = "Şifre boş geçilemez";
        public const string CodeNotNull = "Kod boş geçilemez";
        public const string SprintIdNotNull = "Sprint Id boş geçilemez";
        public const string TitleNotNull = "Başlık boş geçilemez";
        public const string ConfirmPasswordRequired = "Doğrulama şifresi zorunlu";
        public const string TokenRequired = "Token zorunlu";
        public const string PasswordNotEqual = "Şifreler birbirine eşit değil";
        public const string DescriptionNotNull = "Açıklama boş geçilemez";
        public const string EmailCharValid = "Geçerli bir Email adresi giriniz";
        public const string IdnumberValid = "TC kimlik numarasını kontrol ediniz";
        public const string PhoneNumberValid = "Telefon numarasını kontrol ediniz";

    }
}