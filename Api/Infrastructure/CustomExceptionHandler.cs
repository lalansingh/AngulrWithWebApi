using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ExceptionHandling;
using log4net;

namespace Api.Infrastructure
{
    public sealed class CustomExceptionHandler : ExceptionHandler
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public override void Handle(ExceptionHandlerContext context)
        {
            Log.Debug(context.Exception.Message);
        }
    }
}