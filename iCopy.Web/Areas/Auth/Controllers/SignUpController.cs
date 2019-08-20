using iCopy.ExternalServices.Mail;
using iCopy.ExternalServices.Model;
using iCopy.SERVICES.Attributes;
using iCopy.SERVICES.IServices;
using iCopy.Web.Options;
using iCopy.Web.Resources;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;
using iCopy.Web.Helper;

namespace iCopy.Web.Areas.Auth.Controllers
{
    [Area(Helper.Strings.Area.Auth)]
    public class SignUpController : Controller
    {
        private readonly IClientService ClientService;
        private readonly SharedResource _localizer;
        private readonly IMailService MailService;
        private readonly EmailServerNoReplyOptions ServerNoReplyOptions;
        private readonly IUserService UserService;
        private readonly Constants Constants;

        public SignUpController(IClientService ClientService, 
            SharedResource _localizer, 
            IMailService MailService, 
            EmailServerNoReplyOptions ServerNoReplyOptions, 
            IUserService UserService,
            Constants Constants)
        {
            this.ClientService = ClientService;
            this._localizer = _localizer;
            this.MailService = MailService;
            this.ServerNoReplyOptions = ServerNoReplyOptions;
            this.UserService = UserService;
            this.Constants = Constants;
        }
        [HttpGet]
        public Task<ViewResult> Index() => Task.FromResult(View(new Model.Request.Client()));
        [HttpPost, Transaction, AutoValidateModelState]
        public async Task<IActionResult> Index([FromForm] Model.Request.Client client)
        {
            try
            {
                Model.Response.Client addedClient = await ClientService.InsertAsync(client);
                var token = UserService.GenerateAccountActivationToken(addedClient.ApplicationUserId);
                await MailService.SendMailAsync(new MailMessage
                {
                    To = addedClient.ApplicationUser.Email,
                    Subject = Constants.EmailActivationAccountSubject(),
                    Body = Constants.EmailActivationAccountBody($"{HttpContext.Request.Scheme}/{HttpContext.Request.Host}{Settings.Routes.SignUp.ActivateAcount}?ApplicationUserId={addedClient.ApplicationUserId}&ActivationEmailToken={token}"),
                });
                return Json(new {success = true, message = _localizer.SuccRegister});
            }
            catch (Exception e)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError);
            }
        }

        public async Task<string> ActivateAccount(int id)
        {
            var token = UserService.GenerateAccountActivationToken(id);
            await MailService.SendMailAsync(new MailMessage
            {
                To = "emir.veledar@edu.fit.ba",
                Subject = Constants.EmailActivationAccountSubject(),
                Body = Constants.EmailActivationAccountBody($"{HttpContext.Request.Scheme}/{HttpContext.Request.Host}{Settings.Routes.SignUp.ActivateAcount}?ApplicationUserId={id}&ActivationEmailToken={token}"),
                MailServer = new MailServer()
                {
                    Url =  ServerNoReplyOptions.Domain,
                    Name = ServerNoReplyOptions.Name,
                    Email = ServerNoReplyOptions.Email,
                    Username = ServerNoReplyOptions.Username,
                    Password = ServerNoReplyOptions.Password,
                    Port = ServerNoReplyOptions.Port
                }
            });
            return "Dobar";
        }
    }
}
