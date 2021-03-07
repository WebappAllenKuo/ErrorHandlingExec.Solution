using System.ComponentModel;

namespace ErrorHandlingExec
{
    public enum UserLoginError
    {
        [Description("缺少帳號密碼")]
        MissingLoginInfo = 1,

        [Description("帳號或密碼錯誤")]
        ErrorLoginInfo = 2,
        
        [Description("未知錯誤")]
        UnknowError = 3
    }

    public enum CrudError
    {
        [Description("新增 {displayName} 記錄失敗：{msg}")]
        Create = 1,
        
        [Description("更新 {displayName} 記錄失敗：{msg}")]
        Update = 2,
        
        [Description("刪除 {displayName} 記錄失敗：{msg}")]
        Delete = 3,
        
    }
}