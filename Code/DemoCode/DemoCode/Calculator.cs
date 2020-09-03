using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DemoCode
{
    public class Calculator
    {
        public decimal DecimalCalculator(string operation, decimal value1, decimal value2)
        {
            decimal result;
          
            if (!string.IsNullOrEmpty(operation))
            {
               
                
                switch (operation)
                {
                    case "Add":
                        result = value1 + value2;
                        break;
                    case "Multiple":
                        result = value1 * value2;
                        break;
                    case "Subtract":
                        result = value1 - value2;
                        break;
                    case "Divide":
                        result = value1 / value2;
                        break;
                    default:
                        var message = "Not valid opertion provided";
                        throw new ArgumentException(message);

                
                }
            }
            else
            {
                throw new ArgumentNullException("No Operation Provided");
            }
            return result;
        }
    }
}
