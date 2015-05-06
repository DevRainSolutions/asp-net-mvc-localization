using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace asp_net_mvc_localization.Utils
{
    public class AttributeAdapters2
    {
        /// <summary>
        /// Adapters that provide localization for Validation Attributes
        /// Second variant
        /// </summary>
        public class MySecRequiredAttributeAdapter : RequiredAttributeAdapter
        {
            public MySecRequiredAttributeAdapter(
                ModelMetadata metadata,
                ControllerContext context,
                RequiredAttribute attribute)
                : base(metadata, context, attribute)
            {
                Helper.ChangeMessages(attribute);
            }
        }

        public class MySecMinLengthAttributeAdapter : MinLengthAttributeAdapter
        {
            public MySecMinLengthAttributeAdapter(
                ModelMetadata metadata,
                ControllerContext context,
                MinLengthAttribute attribute)
                : base(metadata, context, attribute)
            {
                Helper.ChangeMessages(attribute);
            }
        }

        public class MySecMaxLengthAttributeAdapter : MaxLengthAttributeAdapter
        {
            public MySecMaxLengthAttributeAdapter(
                ModelMetadata metadata,
                ControllerContext context,
                MaxLengthAttribute attribute)
                : base(metadata, context, attribute)
            {
                Helper.ChangeMessages(attribute);
            }
        }

        public class MySecRangeAttributeAdapter : RangeAttributeAdapter
        {
            public MySecRangeAttributeAdapter(
                ModelMetadata metadata,
                ControllerContext context,
                RangeAttribute attribute)
                : base(metadata, context, attribute)
            {
                Helper.ChangeMessages(attribute);
            }
        }

        public class MySecRegularExpressionAttributeAdapter : RegularExpressionAttributeAdapter
        {
            public MySecRegularExpressionAttributeAdapter(
                ModelMetadata metadata,
                ControllerContext context,
                RegularExpressionAttribute attribute)
                : base(metadata, context, attribute)
            {
                Helper.ChangeMessages(attribute);
            }
        }

        private static class Helper
        {
            public static void ChangeMessages(ValidationAttribute attribute)
            {
                attribute.ErrorMessageResourceType = typeof(Resources.AttributeResources);
                Type attributeType = attribute.GetType();
                attribute.ErrorMessageResourceName = attributeType.Name;
            }
        }
    }
}