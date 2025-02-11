using Microsoft.Playwright;
using System.Threading.Tasks;

namespace SymphonySolutionsC_.Pages
{
    public class VacanciesPage : BasePage
    {
        private readonly string VacancyTitleSelector = "//div[contains(@class,'listing-grid--item')]//h3";
        private readonly string VacancyLinkSelector = "//div[contains(@class,'listing-grid--item')]//a[contains(@class,'box-vacancy--link')]";

        public VacanciesPage(IPage page) : base(page) { }

        public async Task<(string Title, string Url)> GetFirstVacancyDetails()
        {
            await Page.WaitForSelectorAsync(VacancyTitleSelector);
            var firstVacancyTitleElement = await Page.QuerySelectorAsync(VacancyTitleSelector);
            var title = await firstVacancyTitleElement.InnerTextAsync();

            var firstVacancyLinkElement = await Page.QuerySelectorAsync(VacancyLinkSelector);
            var url = await firstVacancyLinkElement.GetAttributeAsync("href");

            return (title, url);
        }

        public async Task OpenVacancy(string url)
        {
            await Page.GotoAsync(url);
        }
    }
}
