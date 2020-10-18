using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using System;
using CountingCalories.Shared.ViewModels;
using CountingCalories.UI.Services;
using System.Linq;

namespace CountingCalories.UI.Pages
{
    public class FoodOverviewBase : ComponentBase
    {
        protected bool IsLoadingData;

        [Inject]
        public FoodService FoodService { get; set; }

        public List<FoodView> allFood = new List<FoodView>();

        protected override async Task OnInitializedAsync()
        {
            ShowSpinner();
            allFood = await FoodService.GetAllFood();
            HideSpinner();
            await base.OnInitializedAsync();
        }

        public void SaveChanges()
        {
            FoodService.Update(allFood);
            StateHasChanged();
        }

        public async void DeleteFood(FoodView food)
        {
            try
            {
                await FoodService.Delete(food);
                
                allFood.Remove(food);
                StateHasChanged();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ShowSpinner()
        {
            IsLoadingData = true;
            StateHasChanged();
        }

        private void HideSpinner()
        {
            if (allFood.Any())
            {
                IsLoadingData = false;
                StateHasChanged();
            }
        }
    }
}
