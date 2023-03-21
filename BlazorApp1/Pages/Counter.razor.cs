using BlazorApp1.Models;
using Microsoft.AspNetCore.Components;
using System;
using static BlazorApp1.Shared.MainLayout;

namespace BlazorApp1.Pages
{
    public partial class Counter
    {
        [Inject] SingletonServices singleton { get; set; }
        [Inject] TransientServices transient { get; set; }
        [CascadingParameter] public AppStyle styles { get; set; }

        private int currentCount = 0;

        private void IncrementCount()
        {

            currentCount++;

            singleton.Value = currentCount;
            transient.Value = currentCount;
        }
    }
}
