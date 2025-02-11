# **Automated Testing for Symphony Solutions Vacancies Page**

## **Overview**
This project automates the testing of the **Vacancies Page** on the Symphony Solutions website using **C#**, **Playwright**, and the **Page Object Model (POM)**. The automation is integrated into a **CI/CD pipeline on GitHub Actions**, allowing for automated test execution upon each code change.

## **Test Scenario**
The test follows these steps:
1. **Navigate to the Main Page**
   - Open the [Symphony Solutions Website](https://com.symphonysolutions.info/).
   - Close any interfering elements such as **cookie banners** and **promo pop-ups**.

2. **Navigate to the Vacancies Page**
   - Hover over the **Career** menu.
   - Click on the **Vacancies** submenu.
   - Ensure that the **Vacancies Page** is loaded.
   - Close any additional **promo pop-ups**.

3. **Select and Open a Vacancy**
   - Identify the **first available vacancy** in the list.
   - Save the **vacancy title**.
   - Click the vacancy link to navigate to the detailed vacancy page.

4. **Verify Vacancy Title**
   - Compare the **title on the vacancy page** with the saved title from the list.
   - Assert that both titles match.

## **Technologies Used**
- **C#** with **Playwright** for browser automation.
- **NUnit** for test execution.
- **GitHub Actions** for CI/CD automation.
- **TRX Test Reports** for result tracking.

## **Project Structure**
```
SymphonySolutionsC-
│   README.md
│   .gitignore
│   playwright.config.ts
│   Program.cs
│
├── Pages
│   ├── BasePage.cs
│   ├── MainPage.cs
│   ├── VacanciesPage.cs
│   ├── VacancyDetailsPage.cs
│
├── Tests
│   ├── BaseTest.cs
│   ├── VacancyTest.cs
│
├── Utils
│
├── .github
│   ├── workflows
│   │   ├── ci.yml
```

## **Setting Up the Project**
### **1. Install Dependencies**
Ensure you have **.NET SDK** installed, then run:
```sh
dotnet restore
dotnet build
dotnet tool install --global Microsoft.Playwright.CLI
dotnet playwright install
```

### **2. Run Tests Locally**
```sh
dotnet test --logger "trx;LogFileName=test-results.trx"
```

### **3. Running Tests on GitHub Actions**
The **CI/CD pipeline** runs tests automatically on:
- Every push to `main`
- Every pull request to `main`
- Manual execution via **workflow_dispatch**

To trigger tests manually:
1. Navigate to **GitHub Actions**.
2. Select **Run Playwright Tests**.
3. Click **Run workflow**.

### **4. Viewing Test Reports**
- Navigate to GitHub Actions → Workflow run.
- Download **TestResults** from **Artifacts**.
- Open `test-results.trx` using **Visual Studio Test Explorer**.

## **Contributing**
- Follow the **POM structure** for maintainability.
- Use meaningful commit messages.
- Ensure tests pass before pushing changes.