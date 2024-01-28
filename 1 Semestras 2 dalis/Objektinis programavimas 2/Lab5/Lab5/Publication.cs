using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab5
{
    /// <summary>
    /// Class of publication data
    /// </summary>
    public class Publication
    {
        /// <summary>
        /// Publication code
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Name of the publication
        /// </summary>
        public string PublicationName { get; set; }

        /// <summary>
        /// Publisher's name
        /// </summary>
        public string PublichersName { get; set; }

        /// <summary>
        /// Publication's one month price
        /// </summary>
        public decimal OneMonthPrice { get; set; }

        /// <summary>
        /// Publications income
        /// </summary>
        public decimal Income = 0;

        /// <summary>
        /// Publication constructor
        /// </summary>
        /// <param name="code">Publication code</param>
        /// <param name="publicationName">Name of the publication</param>
        /// <param name="publichersName">Publisher's name</param>
        /// <param name="oneMonthPrice">Publication's one month price</param>
        /// <param name="income">Publications income</param>
        public Publication(string code, string publicationName, string publichersName, decimal oneMonthPrice, decimal income)
        {
            this.Code = code;
            this.PublicationName = publicationName;
            this.PublichersName = publichersName;
            this.OneMonthPrice = oneMonthPrice;
            this.Income = income;
        }

        /// <summary>
        /// Overriden ToString method
        /// </summary>
        /// <returns>Formated line of text</returns>
        public override string ToString()
        {
            return string.Format("| {0, -20} | {1, -20} | {2, -20} | {3, 20} |", Code, PublicationName, PublichersName, OneMonthPrice);
        }
    }
}