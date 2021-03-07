using System;

namespace ErrorHandlingExec
{
    public class MemberService
    {
        private readonly string displayName;
        public MemberService()
        {
            this.displayName = "會員";
        }
        
        public ValidationResult ValidateLogin(string account, string password)
        {
            if (string.IsNullOrEmpty(account) || string.IsNullOrEmpty(password))
            {
                return ValidationResult.Fail(UserLoginError.MissingLoginInfo);
            }

            if (account != "allen")
            {
                return ValidationResult.Fail(UserLoginError.ErrorLoginInfo);
            }
            
            return ValidationResult.Success();
        }

        public void Create(string account, string password)
        {
            CrudError currentError = CrudError.Create;
            
            if (string.IsNullOrEmpty(account)) ThrowException(this.displayName, "帳號必填", currentError);
            if (string.IsNullOrEmpty(password)) ThrowException(this.displayName, "密碼必填", currentError);

            // create record
        }
        
        private void ThrowException(string displayName, string errorMessge, Enum value)
        {
            int errorCode = value.GetValue();
            string errorTemplate = value.GetDescription();
            string errorMessage = errorTemplate
                .Replace("{displayName}", displayName)
                .Replace("{msg}", errorMessge);
            
            string message = errorMessage + $" / ErrorCode = {errorCode}";
            
            throw new BizException(message);
        } 
    }
}