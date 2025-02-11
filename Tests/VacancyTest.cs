using NUnit.Framework;
using System.Threading.Tasks;
using SymphonySolutionsC_.Pages;

namespace SymphonySolutionsC_.Tests
{
    [TestFixture]
    public class VacancyTest : BaseTest
    {
        [Test]
        public async Task VerifyVacancyTitleConsistency()
        {
            var mainPage = new MainPage(Page);
            await mainPage.OpenMainPage();
            await mainPage.GoToVacancies();

            var vacanciesPage = new VacanciesPage(Page);
            var (expectedTitle, vacancyUrl) = await vacanciesPage.GetFirstVacancyDetails();

            await vacanciesPage.OpenVacancy(vacancyUrl);

            var vacancyDetailsPage = new VacancyDetailsPage(Page);
            var actualTitle = await vacancyDetailsPage.GetVacancyTitle();

            Assert.That(actualTitle, Is.EqualTo(expectedTitle), "Vacancy title does not match.");
        }
    }
}
