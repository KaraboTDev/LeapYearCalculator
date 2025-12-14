using System;
using Microsoft.AspNetCore.Mvc;
using LeapYearCalculator.Models;

namespace LeapYearCalculator.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/LeapYear
        [HttpGet]
        public IActionResult LeapYear()
        {
            // Create a new ViewModel instance
            var model = new LeapYearViewModel();

            // Optional enhancement: auto-fill with current year
            model.Year = DateTime.Now.Year;

            // We have not checked anything yet, so IsLeapYear and Message stay null.
            return View(model);
        }

        // POST: /Home/LeapYear
        [HttpPost]
        public IActionResult LeapYear(LeapYearViewModel model)
        {
            // First, check if the input is valid according to our attributes (Required, Range).
            if (!ModelState.IsValid)
            {
                // If invalid, we just return the same view with validation messages.
                return View(model);
            }

            // At this point, Year has a value because validation passed.
            int year = model.Year!.Value;

            // Use our helper method to determine if it's a leap year
            bool isLeap = LeapYearCalculatorHelper.IsLeapYear(year);

            // Store the result
            model.IsLeapYear = isLeap;

            // Build a user-friendly message
            if (isLeap)
            {
                model.Message = $"{year} is a leap year (366 days).";
            }
            else
            {
                model.Message = $"{year} is NOT a leap year (365 days).";
            }

            // Optional enhancement: Add to history
            // We add a short description of this check
            string historyEntry = $"{DateTime.Now:HH:mm:ss} - Checked {year}: " +
                                  (isLeap ? "Leap year" : "Not a leap year");

            model.History.Add(historyEntry);

            // Return the same view with the updated model
            return View(model);
        }
    }
}