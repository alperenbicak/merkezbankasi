using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System;
using System.Xml;
using MerkezBankasıRestApi.Services;

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
        public Task<ActionResult<List<ResponseDataKur>>> Run(RequestData request)
        {
            var result = _merkezBankasi.Run(request);
            return result;
            
        }
    }
}
