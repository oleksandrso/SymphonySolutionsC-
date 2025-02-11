using Microsoft.Playwright;
using System.Threading.Tasks;

namespace SymphonySolutionsC_.Pages
{
    public class VacancyDetailsPage : BasePage
    {
        private readonly string VacancyTitleSelector = "//h1[contains(@class,'vacancy-title')]";

        public VacancyDetailsPage(IPage page) : base(page) { }

        public async Task<string> GetVacancyTitle()
        {
            await Page.WaitForSelectorAsync(VacancyTitleSelector);
            return await Page.InnerTextAsync(VacancyTitleSelector);
        }
    }
}
