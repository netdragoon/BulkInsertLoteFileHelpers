using System.Collections.Generic;
using Castle.Components.Validator;
namespace App.WebStore.Models.ValidatorExtension
{
    public static class GetErrorValidatorRunner
    {
        public static IDictionary<string, string> GetErrors<T>(this IValidatorRunner runner, T model)
        {
            IDictionary<string, string> errors = null;
            if (runner.HasErrors(model))
            {
                errors = new Dictionary<string, string>();
                ErrorSummary sumary = runner.GetErrorSummary(model);
                for (int i = 0; i < sumary.ErrorsCount; i++)
                {
                    errors.Add(sumary.InvalidProperties[i], sumary.ErrorMessages[i]);
                }
            }
            return errors;
        }
        
    }
}