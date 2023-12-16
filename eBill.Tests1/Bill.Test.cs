using Xunit;
using eBill;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace eBill.Tests
{
    public class BillTest: IDisposable
    {
    private IWebDriver driver;
    private const string Url = "http://localhost:7282/";

       
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
        public void CheckIfAllBillsShowRightTitle()
    {
        // Navigate to the web page
         driver.Navigate().GoToUrl("http://localhost:5000/Home/AllBills");
        IWebElement element =  driver.FindElement(By.TagName ("h6"));

        // Assert that the element is not null, indicating that it exists
        Assert.NotNull(element);
        Assert.Equal("Showing all bills", element.Text);

    }

        [Fact]
        public void ShouldNavigateToAllBillsOnSubmit()
    {
        driver.Navigate().GoToUrl(Url);
        IWebElement name =  driver.FindElement(By.Id("Name"));
        name.SendKeys("Dinner with friends");

        IWebElement amount =  driver.FindElement(By.Id("Amount"));
        amount.SendKeys("200");

         IWebElement DueDate =  driver.FindElement(By.Id("DueDate"));
        DueDate.SendKeys(DateTime.Now.ToString("yyyy-MM-ddTHH:mm"));
 
        IWebElement submitButton =  driver.FindElement(By.ClassName("btn-primary"));
        submitButton.Click();
        // Wait for the page to load (you might need to adjust the wait time based on your application)
        System.Threading.Thread.Sleep(5000);
        string urlAfterButtonClick = driver.Url;
        // Assert that the element is not null, indicating that it exists
        Assert.Equal("http://localhost:5000/Home/AllBills", urlAfterButtonClick);

    }

    [Fact]
        public void ShouldNotNavigateOnEmptyInput()
    {
         driver.Navigate().GoToUrl(Url);
        IWebElement element =  driver.FindElement(By.ClassName ("btn-primary"));
        element.Click();
        // Wait for the page to load (you might need to adjust the wait time based on your application)
        System.Threading.Thread.Sleep(2000);
        string urlAfterButtonClick = driver.Url;
        // Assert that the element is not null, indicating that it exists
        Assert.Equal(Url, urlAfterButtonClick);

    }


        [Fact]
        public void Dispose()
    {
        // Close the WebDriver when the test is finished
        driver.Quit();
    }
    }
}
