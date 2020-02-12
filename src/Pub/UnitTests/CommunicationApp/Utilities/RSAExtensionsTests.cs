using System;
using System.Security.Cryptography;
using CommunicationAppDomain.Utilities;
using Microsoft.IdentityModel.Tokens;
using Xunit;

namespace UnitTests
{
    public class RSAExtensionsTests
    {
        [Fact]
        public void FromXmlString_ValidRsaFormat_Pass()
        {
            // Arrange
            string rsaSample = "<RSAKeyValue><Modulus>AKoYq6Q7UN7vOFmPr4fSq2NORXHBMKm8p7h4JnQU+quLRxvYll9cn8OBhIXq9SnCYkbzBVBkqN4ZyMM4vlSWy66wWdwLNYFDtEo1RJ6yZBExIaRVvX/eP6yRnpS1b7m7T2Uc2yPq1DnWzVI+sIGR51s1/ROnQZswkPJHh71PThln</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
            // Act
            RsaSecurityKey privateKey;
            RSA privateRsa = RSA.Create();
            RSAKeyExtensions.FromXmlString(privateRsa, rsaSample);
            privateKey = new RsaSecurityKey(privateRsa);
            // Assert
            Assert.NotNull(privateKey);
        }
        
        [Fact]
        public void FromXmlString_InvalidRsaFromat_Throws()
        {
            // Arrange
            string rsaSample = "-----BEGIN PUBLIC KEY-----MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQCnGH3GRAqzF0byJjN1RLLJsiwaDp4VuYTxSfibhj0u8xk87TzqRpFg0EDjmMkHoBx8yU1MHPRFzAFzyqLVLHbmvOA+/XvOCLESGto3jeUabd2/j4e873n01bzFovU207olSgvDaN5e6yq7OWnU4Xzp0xYSNetwUGvEgQr/s9JaFwIDAQAB-----END PUBLIC KEY-----";
            // Act
            RSA privateRsa = RSA.Create();
            // Assert
            Assert.Throws<System.Xml.XmlException>(() => RSAKeyExtensions.FromXmlString(privateRsa, rsaSample));
        }
    }
}