using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoGallery.Attributes
{
    public class MaxFileSizeAttribute : ValidationAttribute, IClientValidatable
    {
        private readonly int _maxFileSize;
        public MaxFileSizeAttribute(int maxFileSize)
        {
            _maxFileSize = maxFileSize;
        }

        public override bool IsValid(object value)
        {
            var file = value as HttpPostedFileBase;
            if (file == null)
            {
                return false;
            }

            bool isFileSizeValid = file.ContentLength <= _maxFileSize;

            bool isMimeTypeValid = false;

            if (file.ContentType.Contains("image"))
            {
                string[] formats = new string[] { ".jpg", ".jpeg" };
                isMimeTypeValid = formats.Any(item => file.FileName.EndsWith(item, StringComparison.OrdinalIgnoreCase));
            }

            return isFileSizeValid && isMimeTypeValid;
        }

        public override string FormatErrorMessage(string name)
        {
            return base.FormatErrorMessage(_maxFileSize.ToString());
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule
            {
                ErrorMessage = FormatErrorMessage(_maxFileSize.ToString()),
                ValidationType = "filesize"
            };
            rule.ValidationParameters["maxsize"] = _maxFileSize;
            yield return rule;
        }
    }
}