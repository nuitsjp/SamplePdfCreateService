using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Results;

namespace PdfCreateService.Controllers
{
    public class PdfController : ApiController
    {
        // GET api/pdf/5
        public IHttpActionResult Get(int id)
        {
            // 実際にはここでIDに該当するPDFを作成する
            var pdf = Properties.Resources.Invoice;

            // 出来上がったPDFのバイト列をレスポンスとして返却する
            return ResponseMessage(new HttpResponseMessage
            {
                Content = new StreamContent(new MemoryStream(pdf))
                {
                    Headers =
                    {
                        ContentType = new MediaTypeHeaderValue("application/octet-stream"),
                        ContentDisposition = new ContentDispositionHeaderValue("attatchment")
                        {
                            FileName = "請求書.pdf"
                        }
                    },
                }
            });
        }

    }
}
