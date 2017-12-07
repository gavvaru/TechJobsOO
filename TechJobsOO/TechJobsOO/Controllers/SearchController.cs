﻿using Microsoft.AspNetCore.Mvc;
using TechJobsOO.Models;
using TechJobsOO.Data;
using TechJobsOO.ViewModels;

namespace TechJobsOO.Controllers
{
    public class SearchController : Controller
    {

        // Our reference to the data store
        private static JobData jobData;

        static SearchController()
        {
            jobData = JobData.GetInstance();
        }

        // Display the search form
        public IActionResult Index()
        {
            SearchJobsViewModel jobsViewModel = new SearchJobsViewModel();
            jobsViewModel.Title = "Search";
            return View(jobsViewModel);
        }

        // Process search submission and display search results
        public IActionResult Results(SearchJobsViewModel jobsViewModel)
        {

            if (jobsViewModel.Column.Equals(JobFieldType.All) || jobsViewModel.Value.Equals(""))
            {
                jobsViewModel.Jobs = jobData.FindByValue(jobsViewModel.Value);
            }
            else
            {
                jobsViewModel.Jobs = jobData.FindByColumnAndValue(jobsViewModel.Column, jobsViewModel.Value);
            }
            
            jobsViewModel.Title = "Search";

            return View("Index", jobsViewModel);
        }
    }
}
