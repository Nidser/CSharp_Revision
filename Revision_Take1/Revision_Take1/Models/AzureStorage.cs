using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Revision_Take1.Models
{

    

    public enum Redundancy
    {
        [Display(Name = "Geographically Redundant")] Geographically,
        [Display(Name = "Locally Redundant")] Locally 
    }
    public class AzureStorage
    {

        public const double GeoStd = 0.125;
        public const double GeoRed = 0.11;
        public const double LocStd = 0.093;
        public const double LocRed = 0.083;


        [Display(Name="Redundncy Type" )]
        public Redundancy Redundancy { get; set; }

        [Display(Name="Storage Amount Required")]
        [Range(1,Int32.MaxValue,ErrorMessage="must be at least 1")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Must be numeric")]
        public int storageAmount { get; set; }

    /*Calculate the storage based on the storageAmount entered by the user
     *              Redundancy	First 1 TB per month	After First 1 TB per month
    Geographically redundant	$0.125 per GB	            $0.11 per GB
    Locally redundant	        $0.093 per GB	            $0.083 per GB

     */

        [DataType(DataType.Currency)]
    public double Cost
        {
            get
            {
                double total = 0.0;

                if(Redundancy.Equals(Redundancy.Geographically))
                {
                    if(storageAmount < 1000)
                    {
                        total = GeoStd * storageAmount;
                    }
                    else
                    {
                        total = (GeoStd * 1000) + ((storageAmount - 1000) * GeoRed);
                    }
                }
                else if(Redundancy.Equals(Redundancy.Locally))
                {
                    if (storageAmount < 1000)
                    {
                        total = LocStd * storageAmount;
                    }
                    else
                    {
                        total = (LocStd * 1000) + ((storageAmount - 1000) * LocRed);
                    }
                }
                else
                {
                    //Do Nothing
                    total = 0;
                }

                return total;
            }
        }


    }
}