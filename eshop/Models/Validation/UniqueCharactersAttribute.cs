using eshop.Models.Validation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using eshop.Models;


namespace eshop.Models
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Parameter, AllowMultiple = false)]        // these attributes could be used only once
    public class UniqueCharactersAttribute : ValidationAttribute, IClientModelValidator
    {

        private readonly int diffChars;

        public UniqueCharactersAttribute(int diffChars)
        {
            this.diffChars = diffChars;
        }


        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var counter = value.ToString().Distinct().Count();

            if (counter >= diffChars)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(GetErrorMessage(diffChars), new List<string> { validationContext.MemberName });
            }

        }


        protected string GetErrorMessage(int diffChars)
        {
            return $"Password must have at least {diffChars} different characters.";
        }


        public void AddValidation(ClientModelValidationContext context)
        {
            ClientSideAttributeHelper.MergeAttribute(context.Attributes, "data-val", "true");       // allow data validation
            ClientSideAttributeHelper.MergeAttribute(context.Attributes, "data-val-uniqueChars", GetErrorMessage(diffChars));
            ClientSideAttributeHelper.MergeAttribute(context.Attributes, "data-val-uniqueChars-count", diffChars.ToString());        // parameter for JS
        }

    }
}