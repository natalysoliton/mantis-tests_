﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace mantis_tests
{
    public class ProjectHelper : HelperBase
    {
        public ProjectHelper(ApplicationManager manager) : base(manager) { } 

        public void Create(ProjectData newProject)
        {
            OpenProjectsTab();
            //Thread.Sleep(3000);
            SubmitCreateNewProject();
            //Thread.Sleep(3000);
            FillProjectForm(newProject);
            //Thread.Sleep(3000);
            SubmitAddProject();
        }

            public void OpenProjectsTab()
            {
                driver.Url = "http://localhost/mantisbt-2.27.1/manage_proj_page.php";
            }

            public void SubmitCreateNewProject()
            {
                driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            }

            public void FillProjectForm(ProjectData project)
            {
                Type(By.Name("name"), project.ProjectName);
            }

            public void SubmitAddProject()
            {
                driver.FindElement(By.XPath("//div[3]/input")).Click();
            }

        public List<ProjectData> GetProjectList()
        {
            List<ProjectData> projects = new List<ProjectData>();
            OpenProjectsTab();

            ICollection<IWebElement> projectLinks = driver.FindElements(
                By.CssSelector("table.table-bordered tbody tr td:first-child a")
            );

            foreach (IWebElement link in projectLinks)
            {
                string projectName = link.Text.Trim();
                projects.Add(new ProjectData(projectName));
            }

            return projects;
        }

        public void Remove(ProjectData projectToRemove)
        {
            OpenProjectsTab();
            SelectFirstProject();
            SubmitDeleteProjectButton();
            SubmitDeleteProjectButton2();
        }

            public void SelectFirstProject()
            {
                driver.FindElement(By.XPath("//div[@id='main-container']/div[2]/div[2]/div/div/div[2]/div[2]/div/div[2]/table/tbody/tr/td/a")).Click();
            }

            public void SubmitDeleteProjectButton()
            {
                driver.FindElement(By.XPath("//form[@id='manage-proj-update-form']/div/div[3]/button[2]")).Click();
            }

            public void SubmitDeleteProjectButton2()
            {
                driver.FindElement(By.XPath("//div[@id='main-container']/div[2]/div[2]/div/div/div[2]/form/input[10]")).Click();
            }
    }
}
