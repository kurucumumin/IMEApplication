namespace MyLibrary
{
    using System.Data;

    public sealed class TransacsionArgumanlari_
    {

        public CommandType KomtTipi { get; set; }

        public string Komut { get; set; }

        public KomutArgumanlari_[] KomutArgumanDizisi { get; set; }
    }
}

