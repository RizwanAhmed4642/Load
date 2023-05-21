using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace SAS.GeneralLayer
{
	public class SecurityLayer
	{
		//Here key is of 128 bit  
		//Key should be either of 128 bit or of 192 bit  
		//Example:      able-2en6-pqry34
		public static string Encrypt(string input, string key = "able-2en6-pqry34")
		{
			byte[] inputArray = UTF8Encoding.UTF8.GetBytes(input);
			TripleDES tripleDES = TripleDES.Create();
			tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
			tripleDES.Mode = CipherMode.ECB;
			tripleDES.Padding = PaddingMode.PKCS7;
			ICryptoTransform cTransform = tripleDES.CreateEncryptor();
			byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
			tripleDES.Clear();
			return Convert.ToBase64String(resultArray, 0, resultArray.Length);
		}
		public static string Decrypt(string input, string key = "able-2en6-pqry34")
		{
			byte[] inputArray = Convert.FromBase64String(input);
			TripleDES tripleDES = TripleDES.Create();
			tripleDES.Key = UTF8Encoding.UTF8.GetBytes(key);
			tripleDES.Mode = CipherMode.ECB;
			tripleDES.Padding = PaddingMode.PKCS7;
			ICryptoTransform cTransform = tripleDES.CreateDecryptor();
			byte[] resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
			tripleDES.Clear();
			return UTF8Encoding.UTF8.GetString(resultArray);
		}
		public static bool ValidateEmailAddress(string emailAddress)
		{
			try
			{
				string email = emailAddress;
				Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
				Match match = regex.Match(email);
				//Email is not correct
				if (!match.Success)
					return false;
				else
					return true;
			}
			catch (Exception)
			{
				return false;
			}
		}
	}
}
