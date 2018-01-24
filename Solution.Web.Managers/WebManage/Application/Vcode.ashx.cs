using System.Web;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web.SessionState;
using DotNet.Utilities;

namespace Solution.Web.Managers.WebManage.Application
{
    /// <summary>
    /// Vcode 的摘要说明
    /// </summary>
    public class Vcode : IHttpHandler, IReadOnlySessionState
    {

        public void ProcessRequest(HttpContext context)
        {

            VerificationCode.CountCode = 5;
            VerificationCode.ImageHeight = 32;
            VerificationCode.ImageWidth = 100;
            VerificationCode.NoiseLine = 50;
            VerificationCode.NoisePoint = 80;
            VerificationCode.FontSize = 23;
            VerificationCode vcode = new VerificationCode();

            //CommonBll.WriteLog("vcode:" + VerificationCode.Code);
            HttpContext.Current.Session["vcode"] = VerificationCode.Code;
            //CommonBll.WriteLog("sessionvcode:" + HttpContext.Current.Session["vcode"]);
            //HttpContext.Current.Session.Add("vcode", VerificationCode.Code);
            //context.Session.Add("vcode", VerificationCode.Code);


            Bitmap bitmap = VerificationCode.CurrentBitmap;

            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = "image/jpeg";
            bitmap.Save(HttpContext.Current.Response.OutputStream, ImageFormat.Jpeg);

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}