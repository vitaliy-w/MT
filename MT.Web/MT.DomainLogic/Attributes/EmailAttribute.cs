using System.ComponentModel.DataAnnotations;

namespace MT.DomainLogic.Attributes
{
    /// <summary>
    /// Validates if the input is an email
    /// </summary>
    public class EmailAttribute : RegularExpressionAttribute
    {
        public EmailAttribute() :
            base(@"^(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\-+)|([A-Za-z0-9]+\.+)|([A-Za-z0-9]+\++))*[A-Za-z0-9]+@((\w+\-+)|(\w+\.))*\w{1,63}\.[a-zA-Z]{2,6}$")
        {
            ErrorMessage = "Please enter a valid email address";
        }
    }
}
