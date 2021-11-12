using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumBai1_Gioithieu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
           
        }
        public ChromeDriver driver = new ChromeDriver();
       
        private void button1_Click(object sender, EventArgs e)
        {
            driver.Navigate().GoToUrl("https://gocchiase.info");
            //driver.Navigate().GoToUrl("https://google.com");
            textBox1.Text = driver.Url;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            driver.Navigate().Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Screenshot screenshot = driver.GetScreenshot();
            screenshot.SaveAsFile("manhinh.PNG");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var cookies = this.driver.Manage().Cookies.AllCookies;
            textBox2.AppendText(cookies.ToString());
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            driver.SwitchTo().NewWindow(WindowType.Tab);
            driver.Navigate().GoToUrl("https://gocchiase.info/gioi-thieu-ve-selenium/");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            driver.SwitchTo().NewWindow(WindowType.Window);
            driver.Navigate().GoToUrl("https://gocchiase.info/gioi-thieu-ve-selenium/");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            driver.Quit();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            driver.Manage().Window.Minimize();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            driver.Manage().Window.Maximize();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            driver.Manage().Window.Size= new Size(1000, 1000);
        }
    }
}
