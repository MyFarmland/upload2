using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace WebAppTest
{
    public partial class upload2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpFileCollection file = Request.Files;
            if (file.Count != 0)
            {
                
                for (var i=0; i<Request.Files.Count;i++) {
                    var avatarFile = Request.Files[i];
                    var name = Request.Form["name"];
                    var avatarExt = Path.GetExtension(avatarFile.FileName);
                    var filename = DateTime.Now.ToString("yyyyMMddHHmmss")+"_"+i + avatarExt;
                    avatarFile.SaveAs(Path.Combine(Server.MapPath("/upload"), filename));
                }
                
                Response.Write("{\"file\":\"ok\"}");//返回信息
            }
            else {
                Response.Write("Error");
            }
        }
    }
}