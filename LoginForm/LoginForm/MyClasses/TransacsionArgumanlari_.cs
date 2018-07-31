using LoginForm.MyClasses;
using System.Data;


namespace LoginForm.MyClasses
{

    public sealed class TransacsionArgumanlari_
    {

        public CommandType KomtTipi { get; set; }

        public string Komut { get; set; }

        public KomutArgumanlari_[] KomutArgumanDizisi { get; set; }
    }
}

