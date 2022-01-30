using Finance.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;


namespace Finance.Client.Pages
{
    public partial class Expenses
    {
        private Expense[] expenses;

        private Expense _expenseToDelete;
        public bool DeleteDialogOpen { get; set; }

        private async Task OnDeleteDialogClose(bool accepted)
        {
            if (accepted)
            {
                await Http.DeleteAsync($"Expenses/{_expenseToDelete.Id}");
                await LoadData();
               _expenseToDelete =null;
            }

            DeleteDialogOpen = false;
            StateHasChanged();
        }

        private void OpenDeleteDialog(Expense expense)
        {
            DeleteDialogOpen = true;
            _expenseToDelete = expense;
            StateHasChanged();
        }

        protected async override Task OnInitializedAsync()
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            expenses = await Http.GetFromJsonAsync<Expense[]>("Expenses");
            StateHasChanged();
        }

        public async void Refresh()
        {
            await LoadData();
        }
    }
}
