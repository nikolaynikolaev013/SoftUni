using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ValidationAttributes.Attributes;

namespace ValidationAttributes
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            Type type = obj.GetType();

            PropertyInfo[] properties = type.GetProperties();

            foreach (var property in properties)
            {
                List<MyValidationAttribute> myAttributes = property.GetCustomAttributes<MyValidationAttribute>().ToList();

                object propObj = property.GetValue(obj);

                foreach (var MyValidationAttribute in myAttributes)
                {
                    bool res = MyValidationAttribute.isValid(propObj);

                    if (!res)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
