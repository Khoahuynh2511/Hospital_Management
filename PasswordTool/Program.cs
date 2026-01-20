using System;
using System.Security.Cryptography;

class Program
{
    private const int SaltSize = 16;
    private const int HashSize = 20;

    public static string Hash(string password, int iterations = 10000)
    {
        byte[] salt;
        new RNGCryptoServiceProvider().GetBytes(salt = new byte[SaltSize]);
        var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations);
        var hash = pbkdf2.GetBytes(HashSize);
        var hashBytes = new byte[SaltSize + HashSize];
        Array.Copy(salt, 0, hashBytes, 0, SaltSize);
        Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);
        var base64Hash = Convert.ToBase64String(hashBytes);
        return string.Format("$MYHASH$V1${0}${1}", iterations, base64Hash);
    }

    static void Main(string[] args)
    {
        string password = args.Length > 0 ? args[0] : "admin123";
        string hashed = Hash(password);
        
        Console.WriteLine($"Password: {password}");
        Console.WriteLine($"Hashed: {hashed}");
        Console.WriteLine();
        Console.WriteLine("SQL Update:");
        Console.WriteLine($"UPDATE TAIKHOAN SET MATKHAU = '{hashed}' WHERE TENDANGNHAP = 'admin';");
    }
}
