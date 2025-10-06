﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace mantis_tests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager) { }

        public void Login(AccountData account)
        {
            OpenLoginPage();
            FillUsernamefield(account);
            Submit();
            FillPasswordfield(account);
            Submit();
        }

        public void OpenLoginPage()
        {
            manager.Driver.Url = "http://localhost/mantisbt-2.27.1/login_page.php";
        }

        public void FillUsernamefield(AccountData account)
        {
            driver.FindElement(By.Name("username")).SendKeys(account.Name);
        }

        public void FillPasswordfield(AccountData account)
        {
            driver.FindElement(By.Name("password")).SendKeys(account.Password);
        }

        public void Submit()
        {
            driver.FindElement(By.CssSelector("input[value='Login']")).Click();

        }
    }
}
