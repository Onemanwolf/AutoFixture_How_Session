using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCode
{
    public class Product
    {
        public int Id { get; set; }
        private string productCode;

        public string ProductCode
        {
            get => productCode;
            set
            {
                ValidProductCode(value);
                productCode = value;

            }
        }

        private void ValidProductCode(string value)
        {
            var inValidLength = value.Length != 3;
            var inValidCase = value != value.ToUpperInvariant();
            
            if(inValidLength || inValidCase) {   
                throw new Exception(value + "inValid Product Code");
            }
        }
    }
}
