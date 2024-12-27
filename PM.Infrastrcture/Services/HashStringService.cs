using System.Security.Cryptography;
using System.Text;
using PM.Application.Common.Interfaces.Services;
namespace PM.Infrastrcture.Services;

public class HashStringService : IHashStringService
{
    private readonly int _keySize = 64;
    private readonly int _iterations = 350000;
    private readonly HashAlgorithmName _hashAlgorithm = HashAlgorithmName.SHA512;

    public string HashPassword(string password, out byte[] salt)
    {
        salt = RandomNumberGenerator.GetBytes(_keySize);
        var hash = Rfc2898DeriveBytes.Pbkdf2(
            Encoding.UTF8.GetBytes(password),
            salt,
            _iterations,
            _hashAlgorithm,
            _keySize);
        return Convert.ToHexString(hash);
    }

    public bool VerifyPassword(string password, string hash, byte[] salt)
    {
        var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(password, salt, _iterations, _hashAlgorithm, _keySize);
        return CryptographicOperations.FixedTimeEquals(hashToCompare, Convert.FromHexString(hash));
    }
    public string HashString(string key)
    {
        StringBuilder sb = new StringBuilder();
        using (HashAlgorithm algorithm = MD5.Create())
            foreach (byte b in algorithm.ComputeHash(Encoding.UTF8.GetBytes(key)))
                sb.Append(b.ToString("X2"));

        return sb.ToString();
    }
}