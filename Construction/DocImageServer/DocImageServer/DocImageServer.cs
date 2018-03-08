using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HtmlAgilityPack;
using ScrapySharp.Extensions;
using ScrapySharp.Html;
using ScrapySharp.Html.Forms;
using ScrapySharp.Network;

namespace DocImageServer
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class DocImageServer : IDocImageServer
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public string scrapeTest()
        {
            ScrapingBrowser browser = new ScrapingBrowser();
            browser.AllowAutoRedirect = true;
            WebPage homePage = browser.NavigateToPage(new Uri("https://www.canada.ca/en/revenue-agency/services/e-services/e-services-businesses/confirming-a-gst-hst-account-number.html"));
            WebPage blogPage = homePage.FindLinks(By.Text("Search now")).Single().Click();
            HtmlNode termsForm = blogPage.Html.CssSelect("form").ElementAt(1);
            return termsForm.OuterHtml;
        }
    }
}
