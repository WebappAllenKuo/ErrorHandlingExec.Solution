using NUnit.Framework;

namespace ErrorHandlingExec
{
    public class MemberServiceTests
    {
        private MemberService memberService;

        [SetUp]
        public void Init()
        {
            memberService = new MemberService();
        }
        
        [Test]
        public void ValidateLogin_WhenCalled()
        {
            var actual = memberService.ValidateLogin("allen", "dummy");
            
            Assert.IsTrue(actual.IsSuccess);
        }
        
        [Test]
        public void ValidateLogin_帳號錯誤_傳回失敗訊息()
        {
            var actual = memberService.ValidateLogin("wrong account", "dummy");
            
            Assert.IsTrue(actual.IsFail);
            Assert.AreEqual((int)UserLoginError.ErrorLoginInfo, actual.ErrorCode);
        }
        
        [TestCase(null,null)]
        [TestCase("","")]
        [TestCase("account",null)]
        [TestCase("","password")]
        public void ValidateLogin_帳密缺少_傳回失敗訊息(string account, string password)
        {
            var actual = memberService.ValidateLogin(account, password);
            
            Assert.IsTrue(actual.IsFail);
            Assert.AreEqual((int)UserLoginError.MissingLoginInfo, actual.ErrorCode);
        }

        [Test]
        public void Create_帳號未填_傳回例外()
        {
            TestDelegate action = ()=> memberService.Create(null,"password");

            var ex = Assert.Throws<BizException>(action);
            
            Assert.IsTrue(ex.Message.StartsWith("新增 會員 記錄失敗"));
            Assert.IsTrue(ex.Message.Contains("帳號必填"));
        }
    }
}