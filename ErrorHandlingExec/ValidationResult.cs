using System;

namespace ErrorHandlingExec
{
    public class ValidationResult
    {
        public bool IsSuccess { get; private set; }
        public bool IsFail => !IsSuccess;
        
        public int ErrorCode { get; private set; }
        public string ErrorMessage { get; private set; }

        public static ValidationResult Success() => new ValidationResult {IsSuccess = true};

        public static ValidationResult Fail(Enum userLoginError)
            => new ValidationResult
            {
                IsSuccess = false,
                ErrorCode = userLoginError.GetValue(),
                ErrorMessage = userLoginError.GetDescription()
            };
    }
}