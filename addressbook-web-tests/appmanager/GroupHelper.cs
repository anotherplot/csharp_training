using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using WebAddressBookTests;

namespace addressbook_web_tests.appmanager
{
    public class GroupHelper : HelperBase
    {
        private List<GroupData> _groupCache;

        public GroupHelper(ApplicationManager manager) : base(manager)
        {
        }

        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper Modify(GroupData newData, int index)
        {
            SelectGroup(index);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            ReturnToGroupsPage();
            return this;
        }
        
        public GroupHelper Modify(GroupData newData, GroupData group)
        {
            SelectGroup(group.Id);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper Remove(int index)
        {
            SelectGroup(index);
            RemoveGroup();
            ReturnToGroupsPage();
            return this;
        }
        public GroupHelper Remove(GroupData group)
        {
            SelectGroup(group.Id);
            RemoveGroup();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }

        private GroupHelper SelectGroup(String id)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value='"+id+"'])")).Click();
            return this;
        }
        
        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index + 1) + "]")).Click();
            return this;
        }

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            _groupCache = null;
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            _groupCache = null;
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            _groupCache = null;
            return this;
        }

        public GroupHelper FillGroupForm(GroupData groupData)
        {
            Type(By.Name("group_name"), groupData.Name);
            Type(By.Name("group_header"), groupData.Header);
            Type(By.Name("group_footer"), groupData.Footer);
            return this;
        }

        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public bool IsAnyGroupExist()
        {
            manager.Navigator.GoToGroupsPage();
            return IsElementPresent(By.Name("selected[]"));
        }

        public List<GroupData> GetGroupList()
        {
            if (_groupCache == null)
            {
                _groupCache = new List<GroupData>();
                manager.Navigator.GoToGroupsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (var webElement in elements)
                {
                    _groupCache.Add(new GroupData(webElement.Text)
                    {
                        Id = webElement.FindElement(By.TagName("input")).GetAttribute("value")
                    });
                }
            }

            return new List<GroupData>(_groupCache);
        }

        public int GetGroupCount()
        {
            return driver.FindElements(By.CssSelector("span.group")).Count;
        }
        
    }
}