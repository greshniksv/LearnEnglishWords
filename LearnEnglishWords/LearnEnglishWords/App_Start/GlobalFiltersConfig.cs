using System.Web.Mvc;
using LearnEnglishWords.Attributes;

namespace LearnEnglishWords
{
    public static class GlobalFiltersConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleAllErrorAttribute());
            filters.Add(new AuthorizeAttribute());
        }
    }
}