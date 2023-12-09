using Xunit;
using eBill;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace eBill.Tests
{
    public class BillTest: IDisposable
    {
    private IWebDriver driver;
    private const string Url = "http://localhost:5000";

       
        public  BillTest()
    {
        // Set up the WebDriver (in this example, we're using Chrome)
        driver = new ChromeDriver();
    }

        [Fact]
        public void CheckIfHeaderElementExists()
    {
        // Navigate to the web page
        driver.Navigate().GoToUrl(Url);
        IWebElement element =  driver.FindElement(By.TagName ("h4"));

        // Assert that the element is not null, indicating that it exists
        Assert.NotNull(element);
        Assert.Equal("eBill", element.Text);

    }

        [Fact]
        public void CheckIfCreateButtonElementExists()
    {
        // Navigate to the web page
        driver.Navigate().GoToUrl(Url);
        IWebElement element =  driver.FindElement(By.ClassName ("btn-primary"));

        // Assert that the element is not null, indicating that it exists
        Assert.NotNull(element);

    }

        [Fact]
        public void checkIfAllBillsShowRightTitle()
    {
        // Navigate to the web page
         driver.Navigate().GoToUrl("http://localhost:5000/Home/AllBills");
        IWebElement element =  driver.FindElement(By.TagName ("h6"));

        // Assert that the element is not null, indicating that it exists
        Assert.NotNull(element);
        Assert.Equal("Showing all bills", element.Text);

    }

        [Fact]
        public void Dispose()
    {
        // Close the WebDriver when the test is finished
        driver.Quit();
    }
    }
}
