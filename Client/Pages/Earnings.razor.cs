using System;
using System.Globalization;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Finance.Shared;



namespace Finance.Client.Pages
{
    public partial class Earnings
    {
        private Earning[] earnings;

        private Earning _earningToDelete;
        public bool DeleteDialogOpen { get; set; }

        private async Task OnDeleteDialogClose(bool accepted)
        {
            if (accepted)
            {
                await Http.DeleteAsync($"Earnings/{_earningToDelete.Id}");
                await LoadData();
                _earningToDelete = null;
            }

            DeleteDialogOpen = false;
            StateHasChanged();
        }

        private void OpenDeleteDialog(Earning earning)
        {
            DeleteDialogOpen = true;
            _earningToDelete = earning;
            StateHasChanged();
        }

        protected async override Task OnInitializedAsync()
        {
            await LoadData();
        }

        private async Task LoadData()
        {
            earnings = await Http.GetFromJsonAsync<Earning[]>("Earnings");
            StateHasChanged();
        }

        public async void Refresh()
        {
            await LoadData();
        }
    }
}
