using System.Collections.Generic;
namespace App.WebStore.Models
{
    public static class ModelStateExtension
    {
        public static void AddModelError(this System.Web.Mvc.ModelStateDictionary modelStateDictionary, IDictionary<string, string> items)
        {
            if (items?.Count > 0)
            {
                foreach (var item in items)
                {
                    modelStateDictionary.AddModelError(item.Key, item.Value);
                }
            }
        }
    }
}