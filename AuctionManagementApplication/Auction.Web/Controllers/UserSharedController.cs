﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Auction.Web.Controllers
{
    public class UserSharedController : Controller
    {
        public JsonResult UploadImage()
        {
            JsonResult result = new JsonResult();
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            try
            {
                var file = Request.Files[0];

                var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);//string.Format("/content/images/{0}", fileName)

                //var path = Path.Combine(Server.MapPath("/Contents/Images/Category/"), fileName);
                var path = Path.Combine(Server.MapPath("/Contents/Images/PostedProduct/"), fileName);

                file.SaveAs(path);

                result.Data = new { Success = true, ImageURL = string.Format("/Contents/Images/PostedProduct/{0}", fileName) };

                //var newImage = new Image() { Name = fileName };

                //if (ImagesService.Instance.SaveNewImage(newImage))
                //{
                //    result.Data = new { Success = true, Image = fileName, File = newImage.ID, ImageURL = string.Format("{0}{1}", Variables.ImageFolderPath, fileName) };
                //}
                //else
                //{
                //    result.Data = new { success = false, Message = new HttpStatusCodeResult(500) };
                //}
            }
            catch (Exception ex)
            {
                result.Data = new { Success = false, Message = ex.Message };
            }
            return result;
        }
    }
}