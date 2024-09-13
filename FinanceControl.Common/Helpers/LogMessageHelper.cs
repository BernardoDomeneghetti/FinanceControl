

using FinanceControl.Common.Resources;

namespace FinanceControl.Helpers
{
    public static class LogMessageHelper
    {
        private static TimeProvider? _timeProvider;

        public static void SetTimeProvider(TimeProvider timeProvider)
        {
            if (_timeProvider != null)
            {
                throw new InvalidOperationException(ErrorMessages.SingletonViolated);
            }

            _timeProvider = timeProvider;
        }

        public static string GetRawExceptionTreatedFormattedMessage<TCaller>()
        {
            ArgumentNullException.ThrowIfNull(_timeProvider);

            var currentDate = _timeProvider.GetUtcNow();

            var formattedMessage = string.Format(ErrorMessages.RawException, typeof(TCaller).Name, currentDate);

            return formattedMessage;
        }
    }
}