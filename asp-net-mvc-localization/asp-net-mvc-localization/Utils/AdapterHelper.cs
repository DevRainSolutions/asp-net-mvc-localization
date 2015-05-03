using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace asp_net_mvc_localization.Utils
{
    public static class AdapterHelper
    {
        public static void ChangeAttribute(ValidationAttribute attribute)
        {
            attribute.ErrorMessageResourceType = typeof(Resources.ValidationResources);
            Type attributeType = attribute.GetType();
            string resName = attributeType.Name;
            resName = resName.Remove(resName.LastIndexOf("A"));
            attribute.ErrorMessageResourceName = resName;
        }
    }
}