using FormSettings.Shared;
using Microsoft.AspNetCore.Components;

namespace FormSettings.Client.Components
{
    public partial class AccountForm
    {
        private List<SortableFormSectionModel> sortableSections = new();
        private SortableFormSectionModel? draggingSection;

        protected override async Task OnInitializedAsync()
        {
            sortableSections.Add(new SortableFormSectionModel { Index = 1, ElementId = "accountNumber", Required = true, InputType = "text", Label = "Account Number:" });
            sortableSections.Add(new SortableFormSectionModel { Index = 2, ElementId = "accountDescription", InputType = "text", Label = "Account Description:" });
            sortableSections.Add(new SortableFormSectionModel { Index = 3, ElementId = "customerNumber", InputType = "text", Label = "Customer Number:" });
            sortableSections.Add(new SortableFormSectionModel { Index = 4, ElementId = "customerName", InputType = "text", Label = "Customer Name:" });
            sortableSections.Add(new SortableFormSectionModel { Index = 5, ElementId = "transactionDate", Required = true, InputType = "date", Label = "Transaction Date:" });
            sortableSections.Add(new SortableFormSectionModel { Index = 5, ElementId = "dueDate", Required = true, InputType = "date", Label = "Due Date:" });
            sortableSections.Add(new SortableFormSectionModel { Index = 5, ElementId = "referenceNumber", InputType = "text", Label = "Reference Number:" });
            sortableSections.Add(new SortableFormSectionModel { Index = 5, ElementId = "accountBalance", InputType = "text", Label = "Account Balance:" });
            sortableSections.Add(new SortableFormSectionModel { Index = 5, ElementId = "outstandingCredits", InputType = "text", Label = "Outstanding Credits:" });

            await base.OnInitializedAsync();
        }

        private void HandleDrop(SortableFormSectionModel landingSection)
        {
            int count = sortableSections.Count;
            int landingIndex = landingSection.Index;

            if (landingIndex < draggingSection.Index)
                landingSection.Index++;
            else
                landingSection.Index--;

            // Replace landing section with dragged section
            draggingSection.Index = landingIndex;

            // Increment all items larger than or equal to the landing spot index
            List<SortableFormSectionModel> reorderSections = sortableSections.Where(x => x.Index > landingIndex).ToList();
            foreach(SortableFormSectionModel section in reorderSections)
            {
                section.Index++;
            }

            // Reset the indexes so they start from 1
            int i = 1;
            foreach (var model in sortableSections.OrderBy(x => x.Index).ToList())
            {
                model.Index = i++;
            }
        }

        private void ShowHidden()
        {
            foreach(SortableFormSectionModel model in sortableSections)
            {
                model.Visible = true;
            }
        }
    }
}