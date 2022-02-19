﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace _01_framework.Application
{
    public class MaxFileSize: ValidationAttribute, IClientModelValidator
    {
        private readonly int _maxFileSize;

        public MaxFileSize(int maxFileSize)
        {
            _maxFileSize = maxFileSize;
        }

      

        public override bool IsValid(object value)
        {
            var file=value as IFormFile;
            if (file == null) return true;

            return file.Length <= _maxFileSize;
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            context.Attributes.Add("data-val", "true");
            context.Attributes.Add("data-val-MaxFileSize", ErrorMessage);
        }
    }
}
