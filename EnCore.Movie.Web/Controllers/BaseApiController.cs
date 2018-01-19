using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EnCore.Movie.Web.Controllers
{
    public class BaseApiController : Controller
    {
        protected IActionResult GetHttpResponse(Func<IActionResult> codeToExecute)
        {
            try
            {
                return codeToExecute.Invoke();
            }
            catch (System.ArgumentException ex)
            {
                ModelState.AddModelError("", ex.Message);

                return BadRequest(ModelState);
            } catch (EnCore.Core.BusinessException ex)
            {                
                return BadRequest(ex.Message);
            }
            catch (System.Security.SecurityException ex)
            {
                return Unauthorized();
            }           
            catch (Exception ex)
            {
                 throw new Exception(ex.Message);
            }
        }

    }
}
