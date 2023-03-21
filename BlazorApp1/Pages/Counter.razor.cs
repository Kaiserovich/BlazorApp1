using Microsoft.AspNetCore.Components;
using System;

namespace BlazorApp1.Pages
{
    public partial class Counter
    {
        [Inject] SingletonServices singleton { get; set; }
        [Inject] TransientServices transient { get; set; }

        private int currentCount = 0;

        private void IncrementCount()
        {

            currentCount++;

            singleton.Value = currentCount;
            transient.Value = currentCount;
        }
    }
}
