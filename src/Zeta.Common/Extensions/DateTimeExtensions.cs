using Zeta.Common.Utils;

namespace Zeta.Common.DateTime
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
            return DateTimeUtil.GetUnixTimeStampSL(val);
        }

        /// <summary>
        /// 将DateTime转换为13毫位秒级Unix时间戳
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static string ToUnixTimeStampML(this System.DateTime val)
        {
            return DateTimeUtil.GetUnixTimeStampML(val);
        }
    }
}