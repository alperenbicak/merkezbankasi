using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MerkezBankasıRestApi.Kurlar;
using MerkezBankasıRestApi.Data;
using System.Text;
using System.Xml;
using System.Data;
using Azure.Core;

namespace MerkezBankasıRestApi.Services 
{
    public class MerkezBankasiServisi : IMerkezBankasi
    {
        private readonly DataContext _context;
        int i = 0;

        public MerkezBankasiServisi(DataContext context)
        {
            _context = context;
        }

		public async Task<ActionResult<List<OtoKur>>> AutoRun()
		{
            string tcmblink ="https://www.tcmb.gov.tr/kurlar/today.xml";
			XmlDocument doc = new XmlDocument();
			doc.Load(tcmblink);
            foreach(OtoKur kur in _context.OtoKurlar)
            {
				_context.OtoKurlar.Remove(kur);
			}
			foreach (XmlNode node in doc.SelectNodes("Tarih_Date")[0].ChildNodes)
			{
				OtoKur kur = new OtoKur();
				kur.id = i;
				kur.Kodu = node.Attributes["Kod"].Value;
				kur.Adi = node["Isim"].InnerText;
				kur.Birimi = int.Parse(node["Unit"].InnerText);
				kur.AlisKuru = Convert.ToDecimal("0" + node["ForexBuying"].InnerText.Replace(".", ","));
				kur.SatisKuru = Convert.ToDecimal("0" + node["ForexSelling"].InnerText.Replace(".", ","));
				kur.EfektifAlisKuru = Convert.ToDecimal("0" + node["BanknoteBuying"].InnerText.Replace(".", ","));
				kur.EfektifSatisKuru = Convert.ToDecimal("0" + node["BanknoteSelling"].InnerText.Replace(".", ","));
				_context.OtoKurlar.Add(kur);
                await Console.Out.WriteLineAsync("Database Updated");
            }
			await _context.SaveChangesAsync();
			return await _context.OtoKurlar.ToListAsync();
		}

		public async Task<ActionResult<List<EskiKur>>> Run(RequestData request)
        {
            string tcmblink = string.Format("https://www.tcmb.gov.tr/kurlar/{0}.xml", (request.IsBugun) ? ("today") : string.Format("{2}{1}/{0}{1}{2}"
                    , request.Gun.ToString().PadLeft(2, '0'), request.Ay.ToString().PadLeft(2, '0'), request.Yil.ToString()));
            XmlDocument doc = new XmlDocument();
            doc.Load(tcmblink);
            if (doc.SelectNodes("Tarih_Date").Count < 1)
            {
                return null;
            }
			foreach (EskiKur kur in _context.EskiKurlar)
			{
				_context.EskiKurlar.Remove(kur);
			}
			foreach (XmlNode node in doc.SelectNodes("Tarih_Date")[0].ChildNodes)
            {
                EskiKur kur = new EskiKur();
                kur.id = i;
                kur.Tarih = (request.IsBugun) ? ("bugun") : string.Format("{0}/{1}/{2}"
                    , request.Gun.ToString().PadLeft(2, '0'), request.Ay.ToString().PadLeft(2, '0'), request.Yil.ToString());
                kur.Kodu = node.Attributes["Kod"].Value;
                kur.Adi = node["Isim"].InnerText;
                kur.Birimi = int.Parse(node["Unit"].InnerText);
                kur.AlisKuru = Convert.ToDecimal("0" + node["ForexBuying"].InnerText.Replace(".", ","));
                kur.SatisKuru = Convert.ToDecimal("0" + node["ForexSelling"].InnerText.Replace(".", ","));
                kur.EfektifAlisKuru = Convert.ToDecimal("0" + node["BanknoteBuying"].InnerText.Replace(".", ","));
                kur.EfektifSatisKuru = Convert.ToDecimal("0" + node["BanknoteSelling"].InnerText.Replace(".", ","));
                _context.EskiKurlar.Add(kur);
            }
            await _context.SaveChangesAsync();
            return await _context.EskiKurlar.ToListAsync();
            

        }
    }
}
