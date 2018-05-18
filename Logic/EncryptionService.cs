using System.Linq;

namespace Logic
{
    public class EncryptionService
    {
        private PrivateKey PrivateKey { get; set; }
        private PublicKey PublicKey { get; set; }

        public PublicKey FormKeys(int p, int q)
        {
            int n = p * q;
            int fi = (p - 1) * (q - 1);
            int e = GetOpenExponent(fi);
            int d = GetD(e, fi);

            PrivateKey = new PrivateKey(d, n);
            PublicKey = new PublicKey(e, n);

            return PublicKey;
        }

        public int Encrypt(int message)
        {
            int encrypted = SmartExponentiation(message, PublicKey.E, PublicKey.N);

            return encrypted;
        }

        public int Decrypt(int decryptedMessage)
        {
            int decrypted = SmartExponentiation(decryptedMessage, PrivateKey.D, PrivateKey.N);

            return decrypted;
        }

        private int SmartExponentiation(int message, int power, int module)
        {
            int nextPower = 2;
            int currentValue = message;
            while (nextPower <= power)
            {
                currentValue = (currentValue * message) % module;
                nextPower++;
            }

            return currentValue;
        }

        private int GetOpenExponent(int fi)
        {
            int e = 2;
            while (true)
            {
                if (e < fi && IsPrime(e) && RelativelyPrime(e, fi))
                {
                    return e;
                }

                e++;
            }
        }

        private bool IsPrime(int e)
        {
            if (e > 1)
            {
                bool isPrime = Enumerable.Range(1, e).Where(n => e % n == 0).SequenceEqual(new int[] { 1, e });

                return isPrime;
            }

            return false;
        }

        private bool RelativelyPrime(int e, int fi)
        {
            int i = 2;
            while (i < e)
            {
                if (e % i == 0 && fi % i == 0)
                {
                    return false;
                }

                i++;
            }

            return fi % i != 0;
        }

        private int GetD(int e, int fi)
        {
            int d = 1;
            while (true)
            {
                if (e * d % fi == 1)
                {
                    return d;
                }

                d++;
            }
        }
    }
}
