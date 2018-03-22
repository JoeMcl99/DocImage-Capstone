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
            //Setting up the Browser
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            ScrapingBrowser browser = new ScrapingBrowser();
            browser.IgnoreCookies = true;
            browser.AllowAutoRedirect = true;

            //Goes to the Canada Revenue Agency Website and presses the Search Now button
            WebPage homePage = browser.NavigateToPage(new Uri("https://www.canada.ca/en/revenue-agency/services/e-services/e-services-businesses/confirming-a-gst-hst-account-number.html"));
            WebPage blogPage = homePage.FindLinks(By.Text("Search now")).Single().Click();
            
            
            //Finds the form for the terms and conditions, and submits it 
            HtmlNode termsForm = blogPage.Html.CssSelect("form").ElementAt(1);
            PageWebForm acceptForm = new PageWebForm(termsForm, browser);
            WebPage registryPage = acceptForm.Submit();

                        
           //Changing the Business name element from a textarea to a text input so that it can be filled and submitted
            HtmlNode newbusinessName = registryPage.Html.CssSelect("#businessName").Single();
            newbusinessName.Name = "input";
            newbusinessName.SetAttributeValue("type", "text");

            //Finding the HST Form
            PageWebForm registryForm = registryPage.FindFormById("registryPromptSubmit");
            
            //Inputting the values into the HST Form
            registryForm.FormFields[0].Value = "130502719";
            registryForm.FormFields[1].Value = "Morrison Hershfield Limited";
            registryForm.FormFields[2].Value = "2018-03-21";
            WebPage submittedPage = registryForm.Submit();

            HtmlNode resultNode = submittedPage.Html.CssSelect("main div").ElementAt(10);
            bool hstResult = resultNode.InnerHtml.Contains("GST/HST number registered on this transaction date.");
            if (hstResult)
            {
                return "GST / HST number registered on this transaction date";
            }
            else return "Was not Successful";
        }
    }
}
