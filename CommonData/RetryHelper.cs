using System;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;

namespace CommonData
{
    public class RetryHelper
    {
        public static async Task<T> Retry<T>(Func<T> valueFactory, int retryCount = 1, int retryWait = 100)
        {
            if (valueFactory == null) throw new ArgumentNullException(nameof(valueFactory));
            if (retryCount < 0) throw new ArgumentOutOfRangeException(nameof(retryCount), "must be greater than or equal to zero");
            if (retryWait < 0) throw new ArgumentOutOfRangeException(nameof(retryWait), "must be greater than or equal to zero");

            do
            {
                ExceptionDispatchInfo capturedException;
                try
                {
                    return valueFactory();
                }
                catch (Exception ex)
                {
                    capturedException = ExceptionDispatchInfo.Capture(ex);
                }

                if (capturedException != null)
                {
                    if (retryCount == 0) capturedException.Throw();

                    //if (logger != null) logger(capturedException.SourceException);

                    if (retryWait > 0) await Task.Delay(retryWait);
                }
            }
            while (retryCount-- > 0);

            return default(T);
        }

        public static async Task<T> Retry<TInput, T>(
            Func<TInput, T> valueFactory,
            TInput parameter,
            int retryCount = 1,
            int retryWait = 100)
        {
            if (valueFactory == null) throw new ArgumentNullException(nameof(valueFactory));
            if (retryCount < 0) throw new ArgumentOutOfRangeException(nameof(retryCount), "must be greater than or equal to zero");
            if (retryWait < 0) throw new ArgumentOutOfRangeException(nameof(retryWait), "must be greater than or equal to zero");

            do
            {
                ExceptionDispatchInfo capturedException;
                try
                {
                    return valueFactory(parameter);
                }
                catch (Exception ex)
                {
                    capturedException = ExceptionDispatchInfo.Capture(ex);
                }

                if (capturedException != null)
                {
                    if (retryCount == 0) capturedException.Throw();

                    //if (logger != null) logger(capturedException.SourceException);

                    if (retryWait > 0) await Task.Delay(retryWait);
                }
            }
            while (retryCount-- > 0);

            return default(T);
        }
    }
}
