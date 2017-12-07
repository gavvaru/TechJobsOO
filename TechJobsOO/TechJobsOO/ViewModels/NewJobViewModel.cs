﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TechJobsOO.Data;
using TechJobsOO.Models;

namespace TechJobsOO.ViewModels
{
    public class NewJobViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Employer")]
        public int EmployerID { get; set; }

        // TODO #3 - Included other fields needed to create a job,
        // with correct validation attributes and display names.
     //   [Display(Name = "Employer")]
        public List<SelectListItem> Employers { get; set; } = new List<SelectListItem>();
        [Required]
        [Display(Name = "Location")]
        public int LocationID { get; set; }
        public List<SelectListItem> Locations { get; set; } = new List<SelectListItem>();
        public int CoreCompetencyID { get; set; }
        [Required]
        [Display(Name = "Skills")]
        public List<SelectListItem> CoreCompetencies { get; set; } = new List<SelectListItem>();
        public int PositionTypeID { get; set; }
        [Required]
        [Display(Name = "Job Type")]
        public List<SelectListItem> PositionTypes { get; set; } = new List<SelectListItem>();

        public NewJobViewModel()
        {

            JobData jobData = JobData.GetInstance();

            foreach (Employer field in jobData.Employers.ToList())
            {
                Employers.Add(new SelectListItem {
                    Value = field.ID.ToString(),
                    Text = field.Value
                });
            }
            foreach(Location field in jobData.Locations.ToList())
            {
                Locations.Add(new SelectListItem
                {
                    Value = field.ID.ToString(),
                    Text = field.Value
                });
            }

            foreach (CoreCompetency field in jobData.CoreCompetencies.ToList()) 
            {
                CoreCompetencies.Add(new SelectListItem
                {
                    Value = field.ID.ToString(),
                    Text = field.Value
                });
            }

            foreach (PositionType field  in jobData.PositionTypes.ToList())
            {
                PositionTypes.Add(new SelectListItem
                {
                    Value = field.ID.ToString(),
                    Text = field.Value
                });
            }

            // TODO #4 - populate the other List<SelectListItem> 
            // collections needed in the view

        }
    }
}