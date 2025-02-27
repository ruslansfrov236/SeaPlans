using System.Security.Cryptography;
using System.Text;

public static class SecurityHelper
{
    private static readonly string secretKey = GenerateRandomKey();

    private static string GenerateRandomKey()
    {
        using (var rng = new RNGCryptoServiceProvider())
        {
            var keyBytes = new byte[32];
            rng.GetBytes(keyBytes);
            return Convert.ToBase64String(keyBytes).Substring(0, 32);
        }
    }

    public static string HashCode(string code)
    {
        using (var sha256 = SHA256.Create())
        {
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(code));
            return Convert.ToBase64String(bytes);
        }
    }


    public static string Encrypt(string text)
    {
        using (var aes = Aes.Create())
        {
            aes.Key = Encoding.UTF8.GetBytes(secretKey);
            aes.IV = new byte[16];

            var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
            var encrypted = encryptor.TransformFinalBlock(
                Encoding.UTF8.GetBytes(text), 0, text.Length);
            return Convert.ToBase64String(encrypted);
        }
    }


    public static string Decrypt(string encryptedText)
    {
        using (var aes = Aes.Create())
        {
            aes.Key = Encoding.UTF8.GetBytes(secretKey);
            aes.IV = new byte[16];

            var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
            var bytes = Convert.FromBase64String(encryptedText);
            var decrypted = decryptor.TransformFinalBlock(bytes, 0, bytes.Length);
            return Encoding.UTF8.GetString(decrypted);
        }
    }


    public static string GenerateHMAC(string data)
    {
        using (var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secretKey)))
        {
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(data));
            return Convert.ToBase64String(hash);
        }
    }
}