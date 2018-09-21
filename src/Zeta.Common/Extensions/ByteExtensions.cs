using System;
using System.Text;

namespace Zeta.Common.Extensions
{
	/// <summary>
	/// byte & byte array type's extension methods
	///Author:stulzq
	/// CreatedTime:2017-12-12 21:06:09
	/// </summary>
	public static class ByteExtensions
	{
		/// <summary>
		/// byte[] to Base64 string
		/// </summary>
		/// <param name="val"></param>
		/// <returns></returns>
		public static string ToBase64String(this byte[] val)
		{
			return Convert.ToBase64String(val);
		}

		/// <summary>
		/// byte[] to string use utf8 encoding
		/// </summary>
		/// <param name="val"></param>
		/// <returns></returns>
		public static string ToUtf8String(this byte[] val)
		{
			return Encoding.UTF8.GetString(val);
		}

		/// <summary>
		/// byte[] to string use ASCII encoding
		/// </summary>
		/// <param name="val"></param>
		/// <returns></returns>
		public static string ToAsciiString(this byte[] val)
		{
			return Encoding.ASCII.GetString(val);
		}

		/// <summary>
		/// byte[] to string use custom encoding
		/// </summary>
		/// <param name="val"></param>
		/// <param name="encoding"></param>
		/// <returns></returns>
		public static string ToString(this byte[] val,Encoding encoding)
		{
			return encoding.GetString(val);
		}
	}
}