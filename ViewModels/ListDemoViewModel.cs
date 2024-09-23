using Microsoft.AspNetCore.Mvc.Rendering;

namespace WT_Lab.ViewModels
{
    public class ListDemoViewModel
    {
        public int SelectedId { get; set; }
        public SelectList Items { get; set; }
    }
}
