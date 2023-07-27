global using MerkezBankasıRestApi.Kurlar;
using Microsoft.AspNetCore.Mvc;

namespace MerkezBankasıRestApi.Services
{
    public interface IMerkezBankasi
    {
        public Task<ActionResult<List<EskiKur>>> Run(RequestData request);
        public Task<ActionResult<List<OtoKur>>> AutoRun();
    }
}
