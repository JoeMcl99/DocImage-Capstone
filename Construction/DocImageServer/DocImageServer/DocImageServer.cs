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
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            ScrapingBrowser browser = new ScrapingBrowser();
            browser.IgnoreCookies = true;
            browser.AllowAutoRedirect = true;
            WebPage homePage = browser.NavigateToPage(new Uri("https://www.canada.ca/en/revenue-agency/services/e-services/e-services-businesses/confirming-a-gst-hst-account-number.html"));
            WebPage blogPage = homePage.FindLinks(By.Text("Search now")).Single().Click();

            HtmlNode termsForm = blogPage.Html.CssSelect("form").ElementAt(1);
            PageWebForm acceptForm = new PageWebForm(termsForm, browser);

            WebPage registryPage = acceptForm.Submit();

            //"Morrison Hershfield Limited"
            PageWebForm registryForm = registryPage.FindFormById("registryPromptSubmit");
            HtmlNode ha = registryPage.Html.CssSelect("textarea").Single();
            registryForm.FormFields[0].Value = "130502719";
            registryForm.FormFields[1].Value = "2018-03-21";
            WebPage submittedPage = registryForm.Submit();

            return "kfk";
        }
    }
}
