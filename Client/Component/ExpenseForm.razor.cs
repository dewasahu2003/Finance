using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;



namespace Finance.Client.Component
{
    public partial class ExpenseForm
    {
        private ExpenseModel expense = new ExpenseModel { Date = DateTime.Today };

        [Parameter]
        public EventCallback OnSubmitCallback { get; set; }


        public async Task HandleValidSubmit()
        {
            await Http.PostAsJsonAsync<ExpenseModel>("Expenses", expense);// to send form data to Earning page
            await OnSubmitCallback.InvokeAsync();

        }
    }
}
