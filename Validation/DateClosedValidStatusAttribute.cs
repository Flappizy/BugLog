using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Buglog.Model;

namespace Buglog.Validation
{
    //This class is used to validate if a user chooses chooses a date for closing an issue and has also made sure to choose
    //the status closed option
    public class DateClosedValidStatusAttribute : ValidationAttribute
    {
        public long StatusId { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Issue issue = value as Issue;
            if (issue.DateClosed != null && issue.StatusId != StatusId)
            {
                return new ValidationResult($"Issue {issue.Title} date closed, can not be chosen because " +
                    $"status is not closed");
            }
            return ValidationResult.Success;
        }
    }
}
