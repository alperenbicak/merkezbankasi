global using MerkezBankasıRestApi.Kurlar;
using Microsoft.AspNetCore.Mvc;

namespace MerkezBankasıRestApi.Services
{
    public interface IMerkezBankasi
    {
        public Task<ActionResult<List<ResponseDataKur>>> Run(RequestData request);
    }
}
