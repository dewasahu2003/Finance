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
    public class ExpensesController : ControllerBase
    {
        private readonly IRepository<Expense> _expenseRepository;

        public ExpensesController(IRepository<Expense> expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        [HttpGet]
        public IEnumerable<Expense> Get()
        {
            return _expenseRepository.GetAll()
                .OrderBy(expense => expense.Date);
        }

        [HttpPost]
        public void Post(Expense expense)
        {
            _expenseRepository.Add(expense);
        }


        [HttpDelete("{id?}")]
        public void Delete(Guid id)
        {
            var entity = _expenseRepository.GetAll()
                .Single(item => item.Id == id);
            _expenseRepository.Remove(entity);
        }



    }

}
