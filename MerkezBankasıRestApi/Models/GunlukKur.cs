using System.ComponentModel.DataAnnotations;

namespace MerkezBankasıRestApi.Kurlar
{
    public class RequestData

    {
        public int Gun { get; set; }
        public int Ay { get; set; }
        public int Yil { get; set; }

    }
    public class EskiKur
    {
        public int id { get; set; }
		public string Tarih { get; set; }
		public string Kodu { get; set; }
        public string Adi { get; set; }
        public int Birimi { get; set; }
        public decimal AlisKuru { get; set; }
        public decimal SatisKuru { get; set; }
        public decimal EfektifAlisKuru { get; set; }
        public decimal EfektifSatisKuru { get; set; }
    }
	public class OtoKur
	{
		public int id { get; set; }
		public string Kodu { get; set; }
		public string Adi { get; set; }
		public int Birimi { get; set; }
		public decimal AlisKuru { get; set; }
		public decimal SatisKuru { get; set; }
		public decimal EfektifAlisKuru { get; set; }
		public decimal EfektifSatisKuru { get; set; }
	}

}
