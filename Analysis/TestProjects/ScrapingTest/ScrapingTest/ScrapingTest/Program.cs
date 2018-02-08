using HtmlAgilityPack;
using ScrapySharp.Extensions;
using ScrapySharp.Html;
using ScrapySharp.Html.Forms;
using ScrapySharp.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrapingTest
{
    class Program
    {
        
        static void Main(string[] args)
        {
            
            ScrapingBrowser browser = new ScrapingBrowser();
            browser.AllowAutoRedirect = true;
            WebPage homePage = browser.NavigateToPage(new Uri("https://www.canada.ca/en/revenue-agency/services/e-services/e-services-businesses/confirming-a-gst-hst-account-number.html"));
            WebPage blogPage = homePage.FindLinks(By.Text("Search now")).Single().Click();
            HtmlNode termsForm = blogPage.Html.CssSelect("form").ElementAt(1);

            Console.WriteLine(termsForm.OuterHtml);
            Console.Read();
        }
    }
}
