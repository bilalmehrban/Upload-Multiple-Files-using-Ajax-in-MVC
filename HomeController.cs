[HttpPost]
public ActionResult Index(IEnumerable Files)
{
 try
 {
  foreach (var file in Files)
  {
   if (file != null && file.ContentLength > 0)
   {
    file.SaveAs(Path.Combine(Server.MapPath("/uploads/" + file.FileName)));
   }
  }
 }
 catch (Exception ex)
 {
  string Msg = ex.Message;
 }
 return View();
}
//the other multiple file upload 
[HttpPost]
public ActionResult UploadFiles()
{
 if (Request.Files.Count > 0)
 {
  try
  {
   HttpFileCollectionBase files = Request.Files;
   for (int i = 0; i < files.Count; i++)
   {
    string path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/";
    string filename = Path.GetFileName(Request.Files[i].FileName);

    HttpPostedFileBase file = files[i];
    string fname;
    if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
    {
     string[] testfiles = file.FileName.Split(new char[] { '\\' });
     fname = testfiles[testfiles.Length - 1];
    }
    else
    {
     fname = file.FileName;
    }

    fname = Path.Combine(Server.MapPath("~/Uploads/"), fname);
    file.SaveAs(fname);
   }

   return Json("File Uploaded Successfully!");
  }
  catch (Exception ex)
  {
   return Json("Error occurred. Error details: " + ex.Message);
  }
 }
 else
 {
  return Json("No files selected.");
 }
}
