namespace HR.LeaveManagement.Application.Exceptions;
using FluentValidation.Results;


public class ValidationException : ApplicationException{
        public List<string> Errors {get; set;} = new List<string>();

        public ValidationException(ValidationResult validationResult)
        {
            foreach(var errors in validationResult.Errors){
                Errors.Add(errors.ErrorMessage);
            }
        }
    }
