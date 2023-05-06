namespace CityInformations.Api.Quartz
{
    public class JobSchedule
    {
        #region CronExpressionOptions

        /// <summary>
        /// Task odpalany co 15 minut
        /// </summary>
        public const string CronExpressionEveryFifteenMinutes = "0 0/15 * ? * *";

        /// <summary>
        /// Task odpalany co minutę
        /// </summary>
        public const string CronExpressionEveryMinute = "0 * * ? * *";

        /// <summary>
        /// Task odpalany co 5 minut
        /// </summary>
        public const string CronExpressionEveryFiveMinutes = "0 0/5 * ? * *";

        #endregion

        public JobSchedule(Type jobType, string cronExpression)
        {
            JobType = jobType;
            CronExpression = cronExpression;
        }

        public Type JobType { get; }
        public string CronExpression { get; }
    }
}
