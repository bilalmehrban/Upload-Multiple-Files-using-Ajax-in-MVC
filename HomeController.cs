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
