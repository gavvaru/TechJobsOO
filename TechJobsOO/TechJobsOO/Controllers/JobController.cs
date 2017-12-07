﻿using Microsoft.AspNetCore.Mvc;
using TechJobsOO.Data;
using TechJobsOO.ViewModels;
using TechJobsOO.Models;

namespace TechJobsOO.Controllers
{
    public class JobController : Controller
    {

        // Our reference to the data store
        private static JobData jobData;

        static JobController()
        {
            jobData = JobData.GetInstance();
        }

        // The detail display for a given Job at URLs like /Job?id=17
        public IActionResult Index(int id)
        { 
            Job data = jobData.Find(id);

            // TODO #1 - get the Job with the given ID and pass it into the view

            return View(data);
        }

        public IActionResult New()
        {
            NewJobViewModel newJobViewModel = new NewJobViewModel();
            return View(newJobViewModel);
        }

        [HttpPost]
        public IActionResult New(NewJobViewModel newJobViewModel)
        {
            if (ModelState.IsValid)
            { 
                Job newJob = new Job {
                    Name = newJobViewModel.Name,
                    Employer = jobData.Employers.Find(newJobViewModel.EmployerID),
                    Location = jobData.Locations.Find(newJobViewModel.LocationID),
                    CoreCompetency = jobData.CoreCompetencies.Find(newJobViewModel.CoreCompetencyID),
                    PositionType = jobData.PositionTypes.Find(newJobViewModel.PositionTypeID)
                };
                jobData.Jobs.Add(newJob);

                //successful adding to jobdata
                //redirecting to view the job in index
                return Redirect("/Job?id=" + newJob.ID);
            }

            //failed viewmodel state
            //returning back to the form
            return View(newJobViewModel);
        }

    }
}