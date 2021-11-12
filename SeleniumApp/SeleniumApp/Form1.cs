using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeleniumApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            ChromeDriver chromeDriver = new ChromeDriver();
             chromeDriver.Navigate().GoToUrl("");
            */
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.BinaryLocation= @"D:\\TAI KHOAN\\ADS FACEBOOK 1  NGUYEN HOAI\\GoogleChromePortable.exe";
            
            //chromeOptions.BinaryLocation = @"C:\\Program Files (x86)\\Google\Chrome\\Application\\chrome.exe";
            chromeOptions.AddArgument("--app=https://google.com");
            //chromeOptions.AddArgument("--window-size=500,750");
            chromeOptions.AddArgument("--user-agent=Mozilla/5.0 (iPhone; CPU iPhone OS 14_1 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/14.0 Mobile/15E148 Safari/604.1");
            chromeOptions.AddExcludedArgument("enable-automation");
            chromeOptions.AddArgument("no-sandbox");
            //chromeOptions.AddArgument("start-maximized");
            //chromeOptions.AddArgument("--disable-gpu");
            //chromeOptions.AddArgument("--disable-dev-shm-usage");
            //chromeOptions.AddAdditionalCapability("useAutomationExtension", false);
            chromeOptions.AddUserProfilePreference("credentials_enable_service", false);
            chromeOptions.AddUserProfilePreference("profile.password_manager_enabled", false);
            ChromeDriverService chromeDriverService = ChromeDriverService.CreateDefaultService();
            chromeDriverService.HideCommandPromptWindow = true;
            ChromeDriver driver = new ChromeDriver(chromeDriverService, chromeOptions);
            Thread.Sleep(5000);
            var status = driver.FindElement(By.XPath("//*[@id='tsf']/div[1]/div[1]/div[1]/div[1]/div/input"));
            status.SendKeys("hehehehe");
            
        }
    }
}
