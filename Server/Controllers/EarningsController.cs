using Finance.Server.Storage;
using Finance.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Finance.Server.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class EarningsController : ControllerBase
    {
        private readonly IRepository<Earning> _earningRepository;

        public EarningsController(IRepository<Earning> earningRepository)
        {
            _earningRepository = earningRepository;
        }

        [HttpGet]
        public IEnumerable<Earning> Get()
        {
            return _earningRepository.GetAll()
                .OrderBy(earning => earning.Date);
        }

        [HttpPost]
        public void Post(Earning earning)
        {
            _earningRepository.Add(earning);
        }


        [HttpDelete("{id?}")]
        public void Delete(Guid id)
        {
            var entity = _earningRepository.GetAll()
                .Single(item => item.Id == id);
            _earningRepository.Remove(entity);
        }



    }
}