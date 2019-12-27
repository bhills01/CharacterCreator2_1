using Microsoft.VisualStudio.TestTools.UnitTesting;
using CharacterCreator2_1.Providers.Security;
using System;
using System.Collections.Generic;
using System.Text;

namespace CharacterCreator2_1.Tests.Providers.Security
{
    [TestClass]
    public class PasswordHasherTests
    {
        [TestMethod]
        public void HashProvider_ReturnsHashedPassword()
        {
            PasswordHasher hashProvider = new PasswordHasher();

            var hashedPassword = hashProvider.ComputeHash("password123");

            Assert.IsNotNull(hashedPassword.Salt);
            Assert.AreNotEqual(hashedPassword.Password, "password123");
        }

        [DataTestMethod]
        [DataRow("password123", "rsD3TaOu0XQ=", "OZpnzNCj1mcK3lvPKxhh89ikT0w=")]
        public void HashProvider_ReturnsPasswordMatch(string password, string salt, string hashedPassword)
        {
            PasswordHasher hashProvider = new PasswordHasher();

            Assert.IsTrue(hashProvider.VerifyHashMatch(hashedPassword, password, salt));
        }
    }

}
