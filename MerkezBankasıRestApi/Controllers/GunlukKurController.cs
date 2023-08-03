using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System;
using System.Xml;
using MerkezBankasıRestApi.Services;
using Hangfire;

namespace merkezbankasi
{
    [Route("api/[controller]")]
    [ApiController]
    public class GunlukKurController : ControllerBase
    {
        private readonly IMerkezBankasi _merkezBankasi;
        public GunlukKurController(IMerkezBankasi merkezBankasi)
        {
            _merkezBankasi = merkezBankasi;
        }
        [HttpPost]
        public async Task<ActionResult<List<EskiKur>>> Run(RequestData request)
        {
            var result = await _merkezBankasi.Run(request);
            if (result is null) { return BadRequest("Belirli tarihteki kurlar bulunamadı."); }
			return result;
            
        }
    }
}
