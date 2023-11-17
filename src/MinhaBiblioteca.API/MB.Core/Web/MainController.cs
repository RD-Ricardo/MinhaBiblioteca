using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Web.Mvc;

namespace MB.Core.Web
{
    [ApiController]
    public abstract class MainController : Controller
    {
        ICollection<string> Erros = new List<string>();

        public MainController()
        {

        }
      
        //protected System.Web.Mvc.ActionResult CustomResponse(object result = null)
        //{
        //    if (OperacaoValida())
        //    {
        //        return ;
        //    }

        //    return BadRequest(new Por)
        //}

        //protected System.Web.Mvc.ActionResult CustomResponse(ValidationResult validationResult)
        //{
        //    if (validationResult.Errors.Any())
        //    {
        //        foreach (var error in validationResult.Errors) 
        //        {
        //            AdicionarErro(error.ErrorMessage);
        //        }
        //    }

        //    return CustomResponse();
        //}

        protected void AdicionarErro(string message)
        {
            Erros.Add(message);
        }

        public bool OperacaoValida()
        {
            return !Erros.Any();
        }
    }
}
