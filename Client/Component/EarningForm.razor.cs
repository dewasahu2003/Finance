using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;



namespace Finance.Client.Component
{
    public partial class EarningForm
    {
        private EarningModel earning = new EarningModel { Date = DateTime.Today };

        [Parameter]
        public EventCallback OnSubmitCallback { get; set; }


        public async Task HandleValidSubmit()
        {
            await Http.PostAsJsonAsync<EarningModel>("Earnings",earning);// to send form data to Earning page
            await OnSubmitCallback.InvokeAsync();

        }
    }
}
