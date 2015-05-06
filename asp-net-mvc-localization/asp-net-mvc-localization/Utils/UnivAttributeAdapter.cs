using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace asp_net_mvc_localization.Utils
{
    public class UnivAttributeAdapter
    {
        /// <summary>
        /// Universal Adapter for each ValidationAttribute
        /// Does not support client validation :(
        /// </summary>
        public class ValidationAttributeAdapter : DataAnnotationsModelValidator<ValidationAttribute>
        {
            public ValidationAttributeAdapter(ModelMetadata metadata,
                ControllerContext context,
                ValidationAttribute attribute)
                : base(metadata, context, attribute)
            {
                attribute.ErrorMessageResourceType = typeof(Resources.AttributeResources);
                Type attributeType = attribute.GetType();
                attribute.ErrorMessageResourceName = attributeType.Name;
            }
        }
    }
}