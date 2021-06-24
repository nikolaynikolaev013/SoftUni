using System;
namespace ValidationAttributes.Attributes
{
    public class MyRequiredAttribute : MyValidationAttribute
    {
        public MyRequiredAttribute()
        {
        }

        public override bool isValid(object objProperty)
        {
            return objProperty != null; 
        }
    }
}
