using Microsoft.Playwright;
using System;
using System.Threading.Tasks;

namespace SymphonySolutionsC_.Pages
{
    public class BasePage
    {
        protected IPage Page;

        public BasePage(IPage page)
        {
            Page = page;
        }

        public async Task DismissCookieBanner()
        {
            try
            {
                var cookieCloseSelector = "button.cky-banner-btn-close";
                var acceptAllSelector = "button.cky-btn-accept";

                if (await Page.QuerySelectorAsync(cookieCloseSelector) != null)
                {
                    await Page.ClickAsync(cookieCloseSelector);
                    Console.WriteLine("Cookie banner closed.");
                }
                else if (await Page.QuerySelectorAsync(acceptAllSelector) != null)
                {
                    await Page.ClickAsync(acceptAllSelector);
                    Console.WriteLine("Accepted all cookies.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"No cookie banner found or error occurred: {ex.Message}");
            }
        }

        public async Task DismissPromoPopup()
        {
            try
            {
                var popupCloseSelector = "a.promo-popup--close";

                if (await Page.QuerySelectorAsync(popupCloseSelector) != null)
                {
                    await Page.ClickAsync(popupCloseSelector);
                    Console.WriteLine("Promo popup closed.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"No promo popup found or error occurred: {ex.Message}");
            }
        }
    }
}
