using iCopy.Model.Options;
using iCopy.Web.Helper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace iCopy.Web.Controllers
{
    public class UploadController : Controller
    {
        private readonly ProfilePhotoOptions profilePhotoOptions;
        private readonly IHostingEnvironment hostingEnvironment;

        public Model.Request.ProfilePhoto FileSession
        {
            get => HttpContext.Session.Get<Model.Request.ProfilePhoto>(Session.Keys.Upload.ProfileImage);
            set => HttpContext.Session.Set<Model.Request.ProfilePhoto>(Session.Keys.Upload.ProfileImage, value);
        }

        public UploadController(ProfilePhotoOptions profilePhotoOptions, IHostingEnvironment hostingEnvironment)
        {
            this.profilePhotoOptions = profilePhotoOptions;
            this.hostingEnvironment = hostingEnvironment;
        }

        [HttpPost]
        public async Task<IActionResult> UploadProfileImage(IFormFile file)
        {
            if(FileSession != null && System.IO.File.Exists(FileSession.Path))
                System.IO.File.Delete(FileSession.Path);
            if(file != null)
            {
                string filename = Guid.NewGuid().ToString();
                while (System.IO.File.Exists(Path.Combine(hostingEnvironment.WebRootPath, "Uploads", profilePhotoOptions.Path, filename, Path.GetExtension(file.FileName))))
                    filename = Guid.NewGuid().ToString();
                string url = Path.Combine("Uploads", profilePhotoOptions.Path, filename, Path.GetExtension(file.FileName));
                string path = Path.Combine(hostingEnvironment.WebRootPath, "Uploads", profilePhotoOptions.Path, filename + Path.GetExtension(file.FileName));
                if (file.Length > profilePhotoOptions.MaxSize)
                    return StatusCode(StatusCodes.Status413RequestEntityTooLarge);
                if (!profilePhotoOptions.SupportedContentTypes.Contains(file.ContentType))
                    return StatusCode(StatusCodes.Status415UnsupportedMediaType);
                
                MemoryStream stream = new MemoryStream();
                await file.CopyToAsync(stream);

                System.Drawing.Image image = System.Drawing.Image.FromStream(stream);

                if (image.Width > profilePhotoOptions.MaxWidth || image.Height > profilePhotoOptions.MaxHeight)
                    image = Helper.Graphics.Image.Resize(image, profilePhotoOptions.MaxWidth, profilePhotoOptions.MaxHeight);

                FileSession = new Model.Request.ProfilePhoto()
                {
                    Path = url,
                    FileSystemPath = path,
                    Extension = Path.GetExtension(file.FileName),
                    Name = filename,
                    XResolution = image.HorizontalResolution,
                    YResolution = image.VerticalResolution,
                    Height = image.Height,
                    Width = image.Width,
                    SizeInBytes = stream.Length,
                    Format = image.PixelFormat.ToString(),
                };

                try
                {
                    using (var filesystemstream = new FileStream(path, FileMode.Create))
                    {
                        stream.Position = 0;
                        await stream.CopyToAsync(filesystemstream);
                    }
                } catch(Exception e)
                {
                    // TODO: Dodati log operaciju
                    return StatusCode((int)HttpStatusCode.InternalServerError);
                }
            }
            return Ok();
        }

        [HttpGet]
        public Task<OkResult> RemoveUploadedProfileImage()
        {
            if (FileSession != null && System.IO.File.Exists(FileSession.Path))
                System.IO.File.Delete(FileSession.Path);
            return Task.FromResult(Ok());
        }
    }
}
