using PersonalExpenses.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalExpenses.Model
{
    public class Category
    {

        public static List<string> GetCategories()
        {
            List<string> categories = new List<string>();
            categories.Add(AppResources.transportCategory);
            categories.Add(AppResources.personalCategory);
            categories.Add(AppResources.healthCategory);
            categories.Add(AppResources.miscellaneousCategory);
            categories.Add(AppResources.homeCategory);
            categories.Add(AppResources.otherCategory);

            return categories;
        }
    }
}
