using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Security
{
    [Table("Login")]
    [HasSelfValidation]
    public class Login:BaseEntity
    {
        private const string tagValidation = "Login";

        public string UserName { get; set; }
        public string Password { get; set; }
        [NotMapped]
        public string TokenAcess { get; set; }

        //implementar selfvalidation
        public static implicit operator bool(Login login)
        {
            if (login != null)
                return true;
            else
                return false;
        }

        [SelfValidation]
        public void Validate(ValidationResults results)
        {
            if (string.IsNullOrEmpty(this.UserName))
                results.AddResult(new ValidationResult(message: "UserName is null, empty or invalid", target: this, key: "UserName", tag: tagValidation, validator: null));
            if (string.IsNullOrEmpty(this.Password))
                results.AddResult(new ValidationResult(message: "Password is null, empty or invalid", target: this, key: "Password", tag: tagValidation, validator: null));
        }
    }
}
