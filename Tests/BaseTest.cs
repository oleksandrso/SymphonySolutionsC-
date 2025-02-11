using Microsoft.Playwright;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace SymphonySolutionsC_.Tests
{
    public class BaseTest
    {
        protected IPlaywright Playwright;
        protected IBrowser Browser;
        protected IBrowserContext Context;
        protected IPage Page;

        [SetUp]
        public async Task Setup()
        {
            Playwright = await Microsoft.Playwright.Playwright.CreateAsync();
            Browser = await Playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
                SlowMo = 1000
            });

            Context = await Browser.NewContextAsync();
            Page = await Context.NewPageAsync();
        }

        [TearDown]
        public async Task Teardown()
        {
            await Browser.CloseAsync();
            Playwright.Dispose();
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
