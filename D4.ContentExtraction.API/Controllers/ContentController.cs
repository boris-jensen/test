using NBoilerpipe.Extractors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace D4.ContentExtraction.API.Controllers
{
    // see the following links: https://github.com/oganix/NBoilerpipe, http://videolectures.net/wsdm2010_kohlschutter_bdu/, https://code.google.com/p/boilerpipe/
    public class ContentController : ApiController
    {
        // POST api/<controller>  with body: htmlSource=some x-www-form-urlencoded string
        public string Post([FromBody]RequestHolder requestParams)
        {
            return DefaultExtractor.INSTANCE.GetText(requestParams.HtmlSource);
        }
    }

    // workaround. If the Post method accepted a simple type of string, then the name portion of the name/value pair in the post
    // request would have to be empty, like "=value", and PostMan application in Google store doesn't support that.
    // See: http://www.asp.net/web-api/overview/working-with-http/sending-html-form-data,-part-1#sending_simple_types
    public class RequestHolder
    {
        public string HtmlSource { get; set; }
    }
}