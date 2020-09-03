using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCode
{
    public class TypeJoiner<T> : ITypeJoiner<T>
    {

        public T Joined { get; set; }



        public void Join(dynamic value1, dynamic value2)
        {

            if (value1.GetType() == typeof(string))
            {
                T item;
                item = value1.ToString() + " " + value2.ToString();
                this.Joined = item;
            }
            else if (IsNumeric(value1) || IsNumeric(value2))
            {

                T item;
                item = value1.ToString() + " " + value2.ToString();
                this.Joined = item;

            }

        }

        public bool IsNumeric(object value)
        {
            Type type = value.GetType();
            if (type == null)
                return false;

            TypeCode typeCode = Type.GetTypeCode(type);

            switch (typeCode)
            {
                case TypeCode.Byte:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.SByte:
                case TypeCode.Single:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                    return true;
            }
            return false;
        }

    }
}

