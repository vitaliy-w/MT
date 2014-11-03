using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MT.ModelEntities;
using MT.Utility.Localization.Attributes;

namespace MT.Web.ViewModels
{
    public class RegisterViewModel
    {
        [LocalizedStringLengthAttribute(5, Constants.Entities.UserEmailRangeValidationMsg)]
        //[LocalizedRequired(Constants.Entities.UserEmailRequiredValidationMsg)]
        //[Remote("CheckEmail", "Account", ErrorMessage = "Пользователь с такой почтой уже зарегистрирован")]
        //[LocalizedRegularExpression(@"^(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\-+)|([A-Za-z0-9]+\.+)|([A-Za-z0-9]+\++))*[A-Za-z0-9]+@((\w+\-+)|(\w+\.))*\w{1,63}\.[a-zA-Z]{2,6}$", Constants.Entities.UserEmailRegularExpressionValidationMsg)]
        //[MaxLength(50, ErrorMessage = "Максимальное количество символов в поле Email пользователя - 50")]
        //[Required(ErrorMessage = "Поле Email обязательно для заполнения")]
        //[Remote("CheckEmail", "Account", ErrorMessage = "Пользователь с такой почтой уже зарегистрирован")]
        //[RegularExpression(@"^(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\-+)|([A-Za-z0-9]+\.+)|([A-Za-z0-9]+\++))*[A-Za-z0-9]+@((\w+\-+)|(\w+\.))*\w{1,63}\.[a-zA-Z]{2,6}$", ErrorMessage = "Некорректный адрес")]
        public string Email { get; set; }

        //[LocalizedRequired(Constants.Entities.UserPasswordRequiredValidationMsg)]
        //[LocalizedRange(6, 100, Constants.Entities.UserPasswordRangeValidationMsg)]
        [Required(ErrorMessage = "Поле пароль обязательно для заполнения")]
        [StringLength(5, ErrorMessage = "Пароль должен быть минимум 6 символов")]
        public string Password { get; set; }

       // [LocalizedCompare("Password", Constants.Entities.UserConfirmPasswordCompareValidationMsg)]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
    }
}