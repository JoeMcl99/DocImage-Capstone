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

        public Dictionary<string, bool> scrapeTest(string hstNumber, string legalName)
        {
            Dictionary<string, bool> returnDictionary = new Dictionary<string, bool>();
            bool error = false;
            int throwaway;
            bool isNumeric = int.TryParse(legalName, out throwaway);
            //Validate input here
            if (hstNumber == "")
            {
                returnDictionary.Add("NoHstNumberError", true);
                error = true;
            }
            else if (!isNumeric)
            {
                returnDictionary.Add("HstNotNumericError", true);
                error = true;
            }
            if (legalName == "")
            {
                returnDictionary.Add("NoLegalNameError", true);
                error = true;
            }
            if (error)
            {
                return returnDictionary;
            }



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


            //Proper Name and Number for testing
            //"130502719"
            //"Morrison Hershfield Limited"

            registryForm.FormFields[0].Value = hstNumber;
            registryForm.FormFields[1].Value = legalName;
            registryForm.FormFields[2].Value = "2018-03-29";
            WebPage submittedPage = registryForm.Submit();


            IEnumerable<HtmlNode> resultNode = submittedPage.Html.CssSelect("main div");
            if (resultNode.Count() != 10)
            {
                HtmlNode correctNode = resultNode.ElementAt(10);
                returnDictionary.Add("NumberNotRegisteredError", true);
            }


            return returnDictionary;
        }
    }
}
