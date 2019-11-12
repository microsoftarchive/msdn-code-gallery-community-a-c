using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using WebApiAngularJsUploader.Models;
using WebApiAngularJsUploader.Photo;

namespace WebApiAngularJsUploader.Controllers
{
    [RoutePrefix("api/photo")]
    public class PhotoController : ApiController
    {
        private IPhotoManager photoManager;

        public PhotoController()
            : this(new LocalPhotoManager(HttpRuntime.AppDomainAppPath + @"\Album"))
        {            
        }

        public PhotoController(IPhotoManager photoManager)
        {
            this.photoManager = photoManager;
        }

        // GET: api/Photo
        public async Task<IHttpActionResult> Get()
        {
            var results = await photoManager.Get();
            return Ok(new { photos = results });
        }

        // POST: api/Photo
        public async Task<IHttpActionResult> Post()
        {
            // Check if the request contains multipart/form-data.
            if(!Request.Content.IsMimeMultipartContent("form-data"))
            {
                return BadRequest("Unsupported media type");
            }

            try
            {
                var photos = await photoManager.Add(Request);
                return Ok(new { Message = "Photos uploaded ok", Photos = photos });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.GetBaseException().Message);
            }
            
        }

        // DELETE: api/Photo/5
        [HttpDelete]
        [Route("{fileName}")]
        public async Task<IHttpActionResult> Delete(string fileName)
        {         
            if (!this.photoManager.FileExists(fileName))
            {
                return NotFound();
            }

           var result = await this.photoManager.Delete(fileName);

           if (result.Successful)
           {
               return Ok(new { message = result.Message});
           } else
           {
               return BadRequest(result.Message);
           }
        }
    }
}
