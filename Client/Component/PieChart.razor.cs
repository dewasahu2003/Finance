using Finance.Client.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Finance.Client.Component
{
    public partial class PieChart
    {
        [Parameter]
        public ICollection<string> Colors { get; set; }

        [Parameter]
        public MonthlyData Data { get; set; }

        [Parameter]
        public string Label { get; set; }
    }
}
