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
        [LocalizedRange(2, 100, Constants.Entities.UserEmailRangeValidationMsg)]
        [LocalizedRequired(Constants.Entities.UserEmailRequiredValidationMsg)]
        [Remote("CheckEmail", "Account", ErrorMessage = "Пользователь с такой почтой уже зарегистрирован")]
        [LocalizedRegularExpression(@"^(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\-+)|([A-Za-z0-9]+\.+)|([A-Za-z0-9]+\++))*[A-Za-z0-9]+@((\w+\-+)|(\w+\.))*\w{1,63}\.[a-zA-Z]{2,6}$", Constants.Entities.UserEmailRegularExpressionValidationMsg)]
        public string Email { get; set; }

        [LocalizedRequired(Constants.Entities.UserPasswordRequiredValidationMsg)]
        [LocalizedRange(6, 100, Constants.Entities.UserPasswordRangeValidationMsg)]
        public string Password { get; set; }

        [LocalizedCompare("Password", Constants.Entities.UserConfirmPasswordCompareValidationMsg)]
        public string ConfirmPassword { get; set; }
    }
}