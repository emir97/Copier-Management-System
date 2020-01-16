using iCopy.SERVICES.Attributes;
using iCopy.SERVICES.Exceptions;
using iCopy.SERVICES.Extensions;
using iCopy.SERVICES.IServices;
using iCopy.Web.Helper;
using iCopy.Web.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using iCopy.Web.Options;
using Microsoft.Extensions.Options;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace iCopy.Web.Areas.User.Controllers
{
    [Area(Strings.Area.User)]
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IUserService UserService;
        private readonly SharedResource _localizer;
        private readonly ValidationErrors _validationErrors;
        private readonly IOptionsMonitor<TwillioClientOptions> _twillioClient;

        public ProfileController(IOptionsMonitor<TwillioClientOptions> twillioClient, IUserService UserService, SharedResource localizer, ValidationErrors validationErrors)
        {
            this.UserService = UserService;
            this._localizer = localizer;
            this._validationErrors = validationErrors;
            this._twillioClient = twillioClient;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await UserService.GetByIdAsync(User.GetUserId());
            return View(user);
        }

        [HttpPost, Transaction, AutoValidateModelState]
        public async Task<IActionResult> Update(Model.Request.ApplicationUserUpdate model)
        {
            try
            {
                await UserService.UpdateAsync(User.GetUserId(), model);
                return Json(new { success = true, message = _localizer.SuccUserUpdate });
            }
            catch (ModelStateException e)
            {
                ModelState.AddModelError(e.Key, _validationErrors.LocalizedString(e.Message));
            }
            catch (Exception e)
            {
                ModelState.AddModelError("Error", _localizer.ErrUserUpdate);
            }

            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json(ModelState.Where(x => x.Value.Errors.Count > 0).ToDictionary(x => x.Key, x => x.Value.Errors.Select(y => y.ErrorMessage)));
        }

        [HttpPost, Transaction, AutoValidateModelState]
        public async Task<IActionResult> UpdatePassword([FromForm] Model.Request.ChangePassword model)
        {
            try
            {
                await UserService.UpdatePassword(User.GetUserId(), model);
                return Json(new { success = true, message = _localizer.SuccPasswordUpdated });
            }
            catch (ModelStateException e)
            {
                ModelState.AddModelError(e.Key, _localizer.LocalizedString(e.Message));
            }
            catch (Exception e)
            {
                ModelState.AddModelError("Error", _localizer.ErrUpdatePassword);
            }

            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json(ModelState.Where(x => x.Value.Errors.Count > 0).ToDictionary(x => x.Key, x => x.Value.Errors.Select(y => y.ErrorMessage)));
        }

        [HttpGet]
        public async Task<IActionResult> VerifyPhoneNumber()
        {
            var phoneNumber = await UserService.GetByIdAsync(User.GetUserId());
            var verificationCode = new Random().Next(100000, 1000000);
            TwilioClient.Init(_twillioClient.CurrentValue.Sid, _twillioClient.CurrentValue.AuthToken);
            var message = await MessageResource.CreateAsync(body: string.Format(_localizer.VerifyPhoneNumberFormat, verificationCode), from: new PhoneNumber("+13343264225"), to: new PhoneNumber("+38761589885"));
            
            return View("_VerifyPhoneNumber");
        }
    }
}
