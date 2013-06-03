using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace WebApiWithGpb
{
    public class CsvFormatter:MediaTypeFormatter
    {
        private static readonly MediaTypeHeaderValue MediaType = new MediaTypeHeaderValue("text/csv");

        public CsvFormatter()
        {
            SupportedMediaTypes.Add(MediaType);
        }

        public override Task WriteToStreamAsync(Type type, object value, Stream stream, HttpContent content, TransportContext transportContext)
        {
            var tcs = new TaskCompletionSource<object>();

            try
            {
                var stringWriter = new StringWriter();
                stringWriter.Write("hallo");
                var streamWriter = new StreamWriter(stream);
                streamWriter.Write(stringWriter.ToString());
                streamWriter.Flush();
                tcs.SetResult(null);
            }
            catch (Exception ex)
            {
                tcs.SetException(ex);
            }

            return tcs.Task;
        }


        public override bool CanReadType(Type type)
        {
            return true;
        }

        public override bool CanWriteType(Type type)
        {
            return true;
        }
    }
}