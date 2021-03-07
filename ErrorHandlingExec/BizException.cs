using System;

namespace ErrorHandlingExec
{
    public class BizException : Exception
    {
        public BizException(string message) : base(message)
        { }
    
    }
}