using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MerkezBankasıRestApi.Kurlar;
using MerkezBankasıRestApi.Data;
using System.Text;
using System.Xml;
using System.Data;

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
        public async Task<ActionResult<List<ResponseDataKur>>> Run(RequestData request)
        {
            string tcmblink = string.Format("https://www.tcmb.gov.tr/kurlar/{0}.xml", (request.IsBugun) ? ("today") : string.Format("{2}{1}/{0}{1}{2}"
                    , request.Gun.ToString().PadLeft(2, '0'), request.Ay.ToString().PadLeft(2, '0'), request.Yil.ToString()));
            XmlDocument doc = new XmlDocument();
            doc.Load(tcmblink);
            if (doc.SelectNodes("Tarih_Date").Count < 1)
            {
                return null;
            }
            foreach (XmlNode node in doc.SelectNodes("Tarih_Date")[0].ChildNodes)
            {
                ResponseDataKur kur = new ResponseDataKur();
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
                _context.Response.Add(kur);
            }
            await _context.SaveChangesAsync();
            return await _context.Response.ToListAsync();
            

        }
    }
}
