using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    public record ResidentAddress(int Number, string Street, string City, string Province, string PostalCode)
    {
        public override string ToString()
        {
            return $"{Number},{Street},{City},{Province},{PostalCode}";
        }
    }
}
