using DesafioImpar.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.OData.Extensions;
using Microsoft.AspNetCore.OData.Query;

namespace DesafioImpar.Presentation.Configurations
{
    public class ODataQueryAttribute : EnableQueryAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception != null)
                return;

            base.OnActionExecuted(actionExecutedContext);

            var oDataFeature = actionExecutedContext.HttpContext.ODataFeature();
            if (oDataFeature.TotalCount.HasValue && actionExecutedContext.Result is ObjectResult obj && obj.Value is IQueryable queryable)
                actionExecutedContext.Result = new ObjectResult(new ODataViewModel(oDataFeature.TotalCount, queryable));
        }
    }
}
