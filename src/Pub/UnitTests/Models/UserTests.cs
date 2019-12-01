using Xunit;
using Common.Models;

namespace UnitTests
{
    public class UserTests
    {
        private readonly User _user;

        public UserTests()
        {
            _user = new User();
        }

        [Fact]
        public void ValidUsernameMinLength_0Chars_ReturnsFalse()
        {
            bool valid = _user.ValidUsernameMinLength("");
            Assert.False(valid);
        }

        [Fact]
        public void ValidUsernameMinLength_1Char_ReturnsTrue()
        {
            bool valid = _user.ValidUsernameMinLength("a");
            Assert.True(valid);
        }

        [Fact]
        public void ValidUsernameMaxLength_20Chars_ReturnsFalse()
        {
            bool valid = _user.ValidUsernameMaxLength("morethan15characters");
            Assert.False(valid);
        }

        [Fact]
        public void ValidUsernameCharacters_ValidCharactersLettersNumbersAndUnderscore_ReturnsTrue()
        {
            bool valid = _user.ValidUsernameCharacters("unicorn123_s");
            Assert.True(valid);
        }

        [Fact]
        public void ValidUsernameCharacters_InValidCharactersSpecialChars_ReturnsFalse()
        {
            bool valid = _user.ValidUsernameCharacters("unic{orn123_");
            Assert.False(valid);
        }
    }
}
