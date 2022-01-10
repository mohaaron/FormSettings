using FormSettings.Shared;
using Microsoft.AspNetCore.Components;

namespace FormSettings.Client.Components
{
    public partial class SortableFormSection
    {
        [Parameter]
        public SortableFormSectionModel Model { get; set; }

        private void CheckChanged()
        {
            Model.Visible = !Model.Visible;
        }
    }
}