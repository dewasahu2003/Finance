using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Finance.Client.Pages;


namespace Finance.Client.Component
{
    public partial class ModelDialog
    {
        
        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public string Text { get; set; }

        [Parameter]
        public EventCallback<bool> OnClose { get; set; }

        [Parameter]
        public ModelDialogType DialogType { get; set; }

        private Task ModelCancel()
        {
            return OnClose.InvokeAsync(false);
        }

        private Task ModelOk()
        {
            return OnClose.InvokeAsync(true);
        }

        public enum ModelDialogType
        {
            Ok,
            OkCancel,
            DeleteCancel

        }
    }
}

