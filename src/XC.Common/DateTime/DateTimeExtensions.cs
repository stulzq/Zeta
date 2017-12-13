namespace XC.Common.DateTime
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// 将DateTime转换为10位秒级Unix时间戳
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static string ToUnixTimeStampSL(this System.DateTime val)
        {
            return DateTimeHelper.GetUnixTimeStampSL(val);
        }

        /// <summary>
        /// 将DateTime转换为13毫位秒级Unix时间戳
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static string ToUnixTimeStampML(this System.DateTime val)
        {
            return DateTimeHelper.GetUnixTimeStampML(val);
        }

        /// <summary>
        /// 将字符串转换为时间 支持10、13位
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static System.DateTime ToDateTime(this string val)
        {
            return DateTimeHelper.ConvertStringToDateTime(val);
        }
    }
}