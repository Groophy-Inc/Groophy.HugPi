using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace hugging_api
{
    public class HugPi
    {
        ChromeDriver chromeDriver;

        IWebElement InputBox;
        IWebElement SendBox;
        int TimePerAsk = 2;
        public HugPi(string DriverPATH,string api = "facebook/blenderbot-400M-distill")
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--headless");
            options.AddArguments("--log-level=3");

            chromeDriver = new ChromeDriver(DriverPATH, options);

            chromeDriver.Navigate().GoToUrl("https://huggingface.co/" + api);

            for (int i = 0; i < 50; i++)
            {
                if (chromeDriver.PageSource.IndexOf("twitter:card") == -1)
                {
                    Thread.Sleep(100);
                }
                else
                {
                    break;
                }
            }

            InputBox = chromeDriver.FindElement(By.CssSelector(@"body > div > main > div > section.pt-8.border-gray-100.md\:col-span-5.pt-6.md\:pb-24.md\:pl-6.md\:border-l.order-first.md\:order-none > div.bg-white.pb-1 > div > div > form > div > input"));

            SendBox = chromeDriver.FindElement(By.CssSelector("div > button[type=\"submit\"]"));
        }

        public string Ask(string input, int timeout = 11)
        {
            InputBox.Clear();
            InputBox.SendKeys(input);
            SendBox.Click();

            string output = "Timeout!";

            for (int i = 0; i < timeout; i++)
            {
                try
                {
                    var getbox = chromeDriver.FindElement(By.CssSelector("div.flex.flex-col.items-end.space-y-4.p-3 > div:nth-child(" + TimePerAsk.ToString() + ")"));

                    output = getbox.Text;
                    TimePerAsk += 2;
                    break;
                }
                catch
                {
                    Thread.Sleep(1000);
                }
            }

            return output;
        }

        public void Kill()
        {
            chromeDriver.Quit();
        }

        public static void KillAllProcess()
        {
            foreach (System.Diagnostics.Process proc in System.Diagnostics.Process.GetProcessesByName("Chrome"))
            {
                proc.Kill();
            }
        }
    }
}