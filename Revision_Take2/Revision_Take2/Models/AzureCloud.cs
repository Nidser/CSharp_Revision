using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Revision_Take2.Models
{

    public enum InstanceSize
    {
        [Display(Name="Very Small")] verySmall,
        Small, Medium, Large,
        [Display(Name = "Very Large")] veryLarge,
        A6, A7
    }
    public class AzureCloud
    {

        public static double[] prices = {.02, .08, .16, .32, .64, .90, 1.80 };

        [Display(Name = "Instance Type ")]
        [Required]
        public InstanceSize InstanceType { get; set; }

        //NUMERIC
        [Display(Name = "Storage Amount")]
        [Range(2, Int32.MaxValue, ErrorMessage = "must be at least 1")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Must be numeric")]
        [Required]
        public int NumInstances { get; set; }


        [Display(Name = "Total Cost")]
        [DataType(DataType.Currency)]
        public double Cost
        {
            get
            {
                double total = 0;
                int index = 0;
                double dailyTotal = 0;

                foreach (var item in Enum.GetValues(typeof(InstanceSize) ) )
                {
                    if(item.Equals(InstanceType))
                    {
                        dailyTotal = prices[index] * 24;
                    }
                    index++;
                }

                if(DateTime.IsLeapYear(DateTime.Now.Year))
                {
                    total = dailyTotal * 366;
                }
                else
                {
                    total = dailyTotal * 355;
                }

                total *= NumInstances;

             return total;
            }
        }
    }
}