using System;
using System.Security.Cryptography;
using System.Xml;

namespace CommunicationAppDomain.Utilities
{
  // Rsa ToXmlString is not supported on .NET Core 2.0
  // https://github.com/dotnet/core/issues/874
  // On track to be supported for .NET Core 3.0 
  // https://github.com/dotnet/corefx/issues/23686
  // until then we use the code provided in issue #874
  // to parse the private RSA xml string 
  public static class RSAKeyExtensions
  {
    public static void FromXmlString(this RSA rsa, string xmlString)
    {
      RSAParameters parameters = new RSAParameters();

      XmlDocument xmlDoc = new XmlDocument();
      xmlDoc.LoadXml(xmlString);

      if (xmlDoc.DocumentElement.Name.Equals("RSAKeyValue"))
      {
        foreach (XmlNode node in xmlDoc.DocumentElement.ChildNodes)
        {
          switch (node.Name)
          {
            case "Modulus": parameters.Modulus = (string.IsNullOrEmpty(node.InnerText) ? null : Convert.FromBase64String(node.InnerText)); break;
            case "Exponent": parameters.Exponent = (string.IsNullOrEmpty(node.InnerText) ? null : Convert.FromBase64String(node.InnerText)); break;
            case "P": parameters.P = (string.IsNullOrEmpty(node.InnerText) ? null : Convert.FromBase64String(node.InnerText)); break;
            case "Q": parameters.Q = (string.IsNullOrEmpty(node.InnerText) ? null : Convert.FromBase64String(node.InnerText)); break;
            case "DP": parameters.DP = (string.IsNullOrEmpty(node.InnerText) ? null : Convert.FromBase64String(node.InnerText)); break;
            case "DQ": parameters.DQ = (string.IsNullOrEmpty(node.InnerText) ? null : Convert.FromBase64String(node.InnerText)); break;
            case "InverseQ": parameters.InverseQ = (string.IsNullOrEmpty(node.InnerText) ? null : Convert.FromBase64String(node.InnerText)); break;
            case "D": parameters.D = (string.IsNullOrEmpty(node.InnerText) ? null : Convert.FromBase64String(node.InnerText)); break;
          }
        }
      }
      else
      {
        throw new Exception("Invalid XML RSA key.");
      }

      rsa.ImportParameters(parameters);
    }
  }
}