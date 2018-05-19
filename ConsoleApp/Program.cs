using Logic;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var encryptionService = new EncryptionService();

            PublicKey publicKey = encryptionService.FormKeys(13, 17);

            int number = 111;
            int encrypted = encryptionService.Encrypt(number);
            int decrypted = encryptionService.Decrypt(encrypted);

            PrivateKey privateKey = encryptionService.TryGetPrivateKeyUsingPublic(number, encrypted);

            Console.WriteLine($"number: {number}, encrypted: {encrypted}, decrypted: {decrypted}" +
                $"\nprivate key: {privateKey.ToString()}");
        }
    }
}
