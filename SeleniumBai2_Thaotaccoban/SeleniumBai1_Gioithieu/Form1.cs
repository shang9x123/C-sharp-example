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
            // thu nhỏ
            driver.Manage().Window.Minimize();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            // phóng to
            driver.Manage().Window.Maximize();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            // tùy chỉnh kích thước
            driver.Manage().Window.Size= new Size(1000, 1000);
        }
        private void button11_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = driver.Url;
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            textBox2.Text= driver.PageSource;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox2.Text = "";
            var cookies = this.driver.Manage().Cookies.AllCookies;
            foreach (Cookie cookie in cookies)
            {
                string text = cookie.Name.ToString();
                text = text+"____" + cookie.Value.ToString()+"\n";
                textBox2.AppendText(text);
                
            }
            Thread.Sleep(5000);
            textBox2.Clear();
            var cookies_value = this.driver.Manage().Cookies.GetCookieNamed("__gads").Value;

            textBox2.Text = cookies_value.ToString();
        }
    }
}
