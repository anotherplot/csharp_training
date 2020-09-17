using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace WebAddressBookTests
{
    public class ContactHelper : HelperBase
    {
        private List<ContactData> _contactCache = null;

        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ContactHelper Create(ContactData contact)
        {
            FillContactForm(contact);
            SubmitContactCreation();
            manager.Navigator.ReturnToHomePage();
            return this;
        }

        public ContactHelper Modify(ContactData contact, int index)
        {
            InitContactModification(index);
            FillContactForm(contact);
            SubmitContactModification();
            manager.Navigator.ReturnToHomePage();
            return this;
        }
        
        public ContactHelper Modify(ContactData newData, ContactData oldData)
        {
            InitContactModification(oldData.Id);
            FillContactForm(newData);
            SubmitContactModification();
            manager.Navigator.ReturnToHomePage();
            return this;
        }

        public ContactHelper Remove(int index)
        {
            SelectContact(index);
            RemoveContact();
            return this;
        }
        
        
        public ContactHelper Remove(ContactData contact)
        {
            SelectContact(contact.Id);
            RemoveContact();
            manager.Navigator.GoToHomePage();
            return this;
        }
        

        private ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            _contactCache = null;
            return this;
        }

        private ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index + 1) + "]")).Click();
            return this;
        }
        
        private ContactHelper SelectContact(String contactId)
        {
            driver.FindElement(By.Id(contactId)).Click();
            return this;
        }

        private void InitContactModification(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[7]
                .FindElement(By.TagName("a"))
                .Click();
        }

        private void InitContactModification(String id)
        {
            var index = int.Parse(id);
            driver.FindElement(By.XPath($"//a[@href='edit.php?id={id}']"))
                .Click();
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            _contactCache = null;
            return this;
        }

        public void SubmitContactCreation()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
            _contactCache = null;
        }

        public void FillContactForm(ContactData contactData)
        {
            Type(By.Name("firstname"), contactData.FirstName);
            Type(By.Name("middlename"), contactData.MiddleName);
            Type(By.Name("lastname"), contactData.LastName);
            Type(By.Name("nickname"), contactData.NickName);
            Type(By.Name("title"), contactData.Title);
            Type(By.Name("company"), contactData.Company);
            Type(By.Name("address"), contactData.Address);
            Type(By.Name("home"), contactData.Home);
            Type(By.Name("mobile"), contactData.Mobile);
            Type(By.Name("work"), contactData.Work);
            Type(By.Name("email"), contactData.Email);
            Type(By.Name("email2"), contactData.Email2);
            Type(By.Name("email3"), contactData.Email3);
            Type(By.Name("fax"), contactData.Fax);
            Type(By.Name("homepage"), contactData.Homepage);

            SelectOption(By.Name("bday"), contactData.Birthday.Day.ToString());
            SelectOption(By.Name("bmonth"), contactData.Birthday.ToString("MMMM"));
            Type(By.Name("byear"), contactData.Birthday.Year.ToString());
            SelectOption(By.Name("aday"), contactData.Anniversary.Day.ToString());
            SelectOption(By.Name("amonth"), contactData.Anniversary.ToString("MMMM"));
            Type(By.Name("ayear"), contactData.Anniversary.Year.ToString());

            Type(By.Name("address2"), contactData.SecondAddress);
            Type(By.Name("phone2"), contactData.SecondHomePhone);
            Type(By.Name("notes"), contactData.Notes);
        }

        public void InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }

        public bool IsAnyContactExist()
        {
            return IsElementPresent(By.XPath("//img[@title='Edit']"));
        }

        public List<ContactData> GetContactList()
        {
            if (_contactCache == null)
            {
                _contactCache = new List<ContactData>();
                manager.Navigator.GoToHomePage();
                ICollection<IWebElement> contactLastNames =
                    driver.FindElements(By.XPath("//*[@id='maintable']//td[2]"));
                ICollection<IWebElement> contactFirstNames =
                    driver.FindElements(By.XPath("//*[@id='maintable']//td[3]"));

                var fullContactNames = contactLastNames
                    .Zip(contactFirstNames, (f, l)
                        => new {LastName = l, FirstName = f});

                foreach (var contact in fullContactNames)
                {
                    _contactCache.Add(new ContactData(contact.LastName.Text, contact.FirstName.Text)
                    {
                        Id = contact.LastName.FindElement(By.XPath("..//td[1]//input")).GetAttribute("id")
                    });
                }
            }

            return new List<ContactData>(_contactCache);
        }

        public int GetContactCount()
        {
            return (driver.FindElements(By.CssSelector("tr")).Count - 1);
        }

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text; 
         

            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones,
                AllEmails = allEmails
            };
        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(0);

            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string middleName = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string nickName = driver.FindElement(By.Name("nickname")).GetAttribute("value");
            string company = driver.FindElement(By.Name("company")).GetAttribute("value");
            string title = driver.FindElement(By.Name("title")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string fax = driver.FindElement(By.Name("fax")).GetAttribute("value");
            
            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");
            
            string homePage = driver.FindElement(By.Name("homepage")).GetAttribute("value");
            string birthDay = driver.FindElement(By.XPath("//select[@name='bday']/option[@selected='selected']")).Text;
            string birthMonth = driver.FindElement(By.XPath("//select[@name='bmonth']/option[@selected='selected']")).Text;
            string birthYear = driver.FindElement(By.Name("byear")).GetAttribute("value");
            
            string anniversaryDay = driver.FindElement(By.XPath("//select[@name='aday']/option[@selected='selected']")).Text;
            string anniversaryMonth = driver.FindElement(By.XPath("//select[@name='amonth']/option[@selected='selected']")).Text;
            string anniversaryYear = driver.FindElement(By.Name("ayear")).GetAttribute("value");
            
            string secondAddress = driver.FindElement(By.Name("address2")).GetAttribute("value");
            string secondHomePhone =  driver.FindElement(By.Name("phone2")).GetAttribute("value");
            string notes =  driver.FindElement(By.Name("notes")).GetAttribute("value");

            return new ContactData(firstName, lastName)
            {
                MiddleName = middleName,
                NickName = nickName,
                Company = company,
                Title = title,
                Address = address,
                Home = homePhone,
                Mobile = mobilePhone,
                Work = workPhone,
                Fax = fax,
                Email = email,
                Email2 = email2,
                Email3 = email3,
                Homepage = homePage,
                Birthday = new DateTime(Int32.Parse(birthYear),DateTime.ParseExact(birthMonth, "MMMM", CultureInfo.CurrentCulture ).Month,Int32.Parse(birthDay)),
                Anniversary = new DateTime(Int32.Parse(anniversaryYear),DateTime.ParseExact(anniversaryMonth, "MMMM", CultureInfo.CurrentCulture ).Month,Int32.Parse(anniversaryDay)),
                SecondAddress = secondAddress,
                SecondHomePhone = secondHomePhone,
                Notes = notes
            };
        }

        public int GetNumberOfResults()
        {
            manager.Navigator.GoToHomePage();
            string text = driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);
        }

        public string GetContactInformationFromView(int i)
        {
            manager.Navigator.GoToHomePage();
            OpenContactDetails(0);
            string contactInformation = driver.FindElement(By.Id("content")).Text;
            return contactInformation;

        }

        private void OpenContactDetails(int i)
        {
            driver.FindElements(By.Name("entry"))[i]
                .FindElements(By.TagName("td"))[6]
                .FindElement(By.TagName("a"))
                .Click();
        }

        public void AddContactDataToGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.GoToHomePage();
            ClearGroupFilter();
            SelectContact(contact.Id);
            SelectGroupToAdd(group.Name);
            CommitAddingContactToGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count() > 0);
        }

        private void CommitAddingContactToGroup()
        {
            driver.FindElement(By.Name("add")).Click();
        }

        private void SelectGroupToAdd(string groupName)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(groupName);
        }

        private void ClearGroupFilter()
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[all]");
        }
    }
}