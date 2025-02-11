using Microsoft.Playwright;
using System.Threading.Tasks;

namespace SymphonySolutionsC_.Pages
{
    public class MainPage : BasePage
    {
        private readonly string CareerMenuSelector = "nav a:has-text('Career')";
        private readonly string VacanciesSubMenuSelector = "nav a:has-text('Vacancies')";

        public MainPage(IPage page) : base(page) { }

        public async Task OpenMainPage()
        {
            await Page.GotoAsync("https://com.symphonysolutions.info/");
            await DismissCookieBanner();
            await DismissPromoPopup();
        }

        public async Task GoToVacancies()
        {
            await Page.HoverAsync(CareerMenuSelector);
            await Page.ClickAsync(VacanciesSubMenuSelector);
            await Page.WaitForURLAsync("https://com.symphonysolutions.info/vacancies");
            await DismissPromoPopup();
        }
    }
}
