namespace Logic
{
    public class PublicKey
    {
        public int E { get; set; }

        public int N { get; set; }

        public PublicKey(int e, int n)
        {
            E = e;
            N = n;
        }
    }

    public class PrivateKey
    {
        public int D { get; set; }

        public int N { get; set; }

        public PrivateKey(int d, int n)
        {
            D = d;
            N = n;
        }
    }
}
