using System;
using System.ComponentModel.DataAnnotations;
using Resources;

namespace asp_net_mvc_localization.Utils
{
    /// <summary>
    /// Contain additional methods
    /// </summary>
    public static class AdapterHelper
    {
        /// <summary>
        /// Setting ErrorMessageResource fields that provide localization for ValidationAttribute
        /// </summary>
        /// <param name="attribute">attribute that will be setting</param>
        public static void ChangeAttribute(ValidationAttribute attribute)
        {
            attribute.ErrorMessageResourceType = typeof(DataAnnotations);
            Type attributeType = attribute.GetType();
            attribute.ErrorMessageResourceName = attributeType.Name;
        }
    }
}