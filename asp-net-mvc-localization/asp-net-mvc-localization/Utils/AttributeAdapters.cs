using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Linq;
using System.Web;

namespace asp_net_mvc_localization.Utils
{
    /// <summary>
    /// Base abstract class that contains settings of ErrorMessage fields.
    /// </summary>
    /// <typeparam name="T">Type of Attribute that adapts</typeparam>
    public abstract class BaseDataAnnotationsModelValidator<T>
        : DataAnnotationsModelValidator<T> where T : ValidationAttribute
    {
        protected BaseDataAnnotationsModelValidator(
            ModelMetadata metadata,
            ControllerContext context,
            T attribute)
            : base(metadata, context, attribute)
        {
            attribute.ErrorMessageResourceType = typeof(Resources.AttributeResources);
            Type attributeType = attribute.GetType();
            attribute.ErrorMessageResourceName = attributeType.Name;
        }
    }

    /// <summary>
    /// Adapters that provide localization for Validation Attributes
    /// </summary>
    #region ValidationAttribute Adapters
    public class MyRequiredAttributeAdapter : BaseDataAnnotationsModelValidator<RequiredAttribute>
    {
        public MyRequiredAttributeAdapter(
            ModelMetadata metadata,
            ControllerContext context,
            RequiredAttribute attribute)
            :base(metadata, context, attribute)
        {
        }
    }

    public class MyMinLengthAttributeAdapter : BaseDataAnnotationsModelValidator<MinLengthAttribute>
    {
        public MyMinLengthAttributeAdapter(
            ModelMetadata metadata,
            ControllerContext context,
            MinLengthAttribute attribute)
            : base(metadata, context, attribute)
        {
        }
    }

    public class MyMaxLengthAttributeAdapter : BaseDataAnnotationsModelValidator<MaxLengthAttribute>
    {
        public MyMaxLengthAttributeAdapter(
            ModelMetadata metadata,
            ControllerContext context,
            MaxLengthAttribute attribute)
            : base(metadata, context, attribute)
        {
        }
    }

    public class MyRangeAttributeAdapter : BaseDataAnnotationsModelValidator<RangeAttribute>
    {
        public MyRangeAttributeAdapter(
            ModelMetadata metadata,
            ControllerContext context,
            RangeAttribute attribute)
            : base(metadata, context, attribute)
        {
        }
    }

    public class MyRegularExpressionAttributeAdapter : BaseDataAnnotationsModelValidator<RegularExpressionAttribute>
    {
        public MyRegularExpressionAttributeAdapter(
            ModelMetadata metadata,
            ControllerContext context,
            RegularExpressionAttribute attribute)
            : base(metadata, context, attribute)
        {
        }
    }

    #endregion
}