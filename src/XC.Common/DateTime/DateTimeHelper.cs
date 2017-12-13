using System;

namespace XC.Common.DateTime
{
    public class DateTimeHelper
    {
        /// <summary>
        /// 获取时间戳 Unix时间戳格式 毫秒级 13位
        /// </summary>
        /// <returns></returns>
        public static string GetUnixTimeStampML(System.DateTime time)
        {
            long ts = ConvertDateTimeToUnixTimeStamp(time);
            return ts.ToString();
        }

        /// <summary>
        /// 获取时间戳 Unix时间戳格式 秒级 10位
        /// </summary>
        /// <returns></returns>
        public static string GetUnixTimeStampSL(System.DateTime time)
        {
            long ts = ConvertDateTimeToUnixTimeStamp(time);
            long res = ts / 1000;//除1000调整为10位
            return res.ToString();
        }

        /// <summary>  
        /// 将DateTime时间格式转换为Unix时间戳格式  毫秒级 13位
        /// </summary>  
        /// <param name="time">时间</param>  
        /// <returns>long</returns>  
        public static long ConvertDateTimeToUnixTimeStamp(System.DateTime time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1, 0, 0, 0, 0));
            long t = (time.Ticks - startTime.Ticks) / 10000;   //除10000调整为13位      
            return t;
        }

        /// <summary>
        /// 时间戳转为C#格式时间
        /// </summary>
        /// <param name="timeStamp"></param>
        /// <returns></returns>
        
        public static System.DateTime ConvertStringToDateTime(string timeStamp)
        {
            System.DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));

            long lTime;
            if (timeStamp.Length == 10)//秒级
            {
                lTime = long.Parse(timeStamp) * 10000000;
            }
            else if (timeStamp.Length == 13) //毫秒级
            {
                lTime = long.Parse(timeStamp) * 10000;
            }
            else
            {
                throw new Exception("Convert String To DateTime Exception.This string is invalid timestamp");
            }
            
            TimeSpan toNow = new TimeSpan(lTime);
            return dtStart.Add(toNow);
        }
    }
}