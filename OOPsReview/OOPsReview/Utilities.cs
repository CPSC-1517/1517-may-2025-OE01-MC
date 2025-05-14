using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    public static class Utilities
    {
        /// <summary>
        /// Checks if our value is positive.
        /// 0.0 is assumed positive.
        /// </summary>
        /// <param name="value">The double value to check.</param>
        /// <returns>True if the value is positive, false otherwise.</returns>
        public static bool IsPositive(double value)
        {

            //if(value >= 0.0)
            //{
            //    return true;
            //}

            //return false;


            //bool valid = false;

            //if (value >= 0.0)
            //{
            //    valid = true;
            //}

            //return valid;


            return value >= 0.0;
        }

        /// <summary>
        /// Checks if our value is positive.
        /// 0 is assumed positive.
        /// </summary>
        /// <param name="value">The int value to check.</param>
        /// <returns>True if the value is positive, false otherwise.</returns>
        public static bool IsPositive(int value) => value >= 0;

        /// <summary>
        /// Checks if our value is positive.
        /// 0 is assumed positive.
        /// </summary>
        /// <param name="value">The decimal value to check.</param>
        /// <returns>True if the value is positive, false otherwise.</returns>
        public static bool IsPositive(decimal value) => value >= 0.0m;

    }
}