using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Linq;
using System.Text.RegularExpressions;
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

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public sealed class MyEmailAddressAttribute : DataTypeAttribute
    {
        private readonly static Regex _regex = new Regex(@"^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^{\\|}~]|
                                                            [\\u00A0-\\uD7FF\\uF900-\\uFDCF\\uFDF0-\\
                                                            uFFEF])+(\\.([a-z]|\\d|[!#\\$%&'\\*\\+\\-\\
                                                            /=\\?\\^_{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\
                                                            uFDF0-\uFFEF])+))|((\x22)((((\x20|\x09)(\x0d\
                                                            x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\
                                                            x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\
                                                            uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09
                                                            \x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))
                (((\x20|\x09)(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.||~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.||~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$", RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture | RegexOptions.Compiled);
        public MyEmailAddressAttribute()
            : base(DataType.EmailAddress)
        {
            base.ErrorMessage = Resources.AttributeResources.EmailAttribute;
        }
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }
            string text = value as string;
            return text != null && MyEmailAddressAttribute._regex.Match(text).Length > 0;
        }
}

    #endregion
}