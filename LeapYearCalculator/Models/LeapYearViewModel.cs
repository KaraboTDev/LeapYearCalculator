using System.ComponentModel.DataAnnotations;

namespace LeapYearCalculator.Models
{
    // ViewModel: holds input and output for the view
    public class LeapYearViewModel
    {
        // Year entered by the user
        [Required(ErrorMessage = "Please enter a year.")]
        [Range(1, 9999, ErrorMessage = "Year must be a positive number between 1 and 9999.")]
        public int? Year { get; set; }

        // Result: is it a leap year?
        public bool? IsLeapYear { get; set; }

        // A message shown to the user (friendly text)
        public string? Message { get; set; }

        // Optional enhancement: history (list of checked years)
        public List<string> History { get; set; } = new List<string>();
    }
}

/*
  Explanation of choices:
- int? Year is nullable so the model can be created without a year yet.
- [Required] and [Range] handle basic input validation for us.
- bool? IsLeapYear is nullable: before checking, it can be null.
- Message will hold user-friendly text like “2024 is a leap year.”
- History will store strings describing all years checked so far (in one session).
*/