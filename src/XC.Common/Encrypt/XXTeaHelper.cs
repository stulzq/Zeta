using System;

namespace XC.Common.Encrypt
{
	/// <summary>
	/// XTEA 跟 TEA 使用了相同的简单运算，但它采用了截然不同的顺序，为了阻止密钥表攻击，
	/// 四个子密钥（在加密过程中，原 128 位的密钥被拆分为 4 个 32 位的子密钥）采用了一种
	/// 不太正规的方式进行混合，但速度更慢了。
	/// Copy from http://www.cnblogs.com/linzheng/archive/2011/09/14/2176767.html
	/// </summary>
	public class XXTeaHelper
	{
		/// <summary>
		/// Encrypt
		/// </summary>
		/// <param name="data">data</param>
		/// <param name="key">key  1-16 character</param>
		/// <returns></returns>
		public static byte[] Encrypt(byte[] data, byte[] key)
		{
			if (data.Length == 0)
			{
				return data;
			}
			return ToByteArray(Encrypt(ToUInt32Array(data, true), ToUInt32Array(key, false)), false);
		}

		/// <summary>
		/// Decrypt
		/// </summary>
		/// <param name="data">encrypt data</param>
		/// <param name="key">key</param>
		/// <returns></returns>
		public static byte[] Decrypt(byte[] data, byte[] key)
		{
			if (data.Length == 0)
			{
				return data;
			}
			return ToByteArray(Decrypt(ToUInt32Array(data, false), ToUInt32Array(key, false)), true);
		}

		/// <summary>
		/// Encrypt
		/// </summary>
		/// <param name="v">vector</param>
		/// <param name="k">key</param>
		/// <returns></returns>
		public static uint[] Encrypt(UInt32[] v, UInt32[] k)
		{
			Int32 n = v.Length - 1;
			if (n < 1)
			{
				return v;
			}
			if (k.Length < 4)
			{
				UInt32[] Key = new UInt32[4];
				k.CopyTo(Key, 0);
				k = Key;
			}
			UInt32 z = v[n], y = v[0], delta = 0x9E3779B9, sum = 0, e;
			Int32 p, q = 6 + 52 / (n + 1);
			while (q-- > 0)
			{
				sum = unchecked(sum + delta);
				e = sum >> 2 & 3;
				for (p = 0; p < n; p++)
				{
					y = v[p + 1];
					z = unchecked(v[p] += (z >> 5 ^ y << 2) + (y >> 3 ^ z << 4) ^ (sum ^ y) + (k[p & 3 ^ e] ^ z));
				}
				y = v[0];
				z = unchecked(v[n] += (z >> 5 ^ y << 2) + (y >> 3 ^ z << 4) ^ (sum ^ y) + (k[p & 3 ^ e] ^ z));
			}
			return v;
		}

		/// <summary>
		/// Decrypt
		/// </summary>
		/// <param name="v">vector</param>
		/// <param name="k">key</param>
		/// <returns></returns>
		public static uint[] Decrypt(UInt32[] v, UInt32[] k)
		{
			Int32 n = v.Length - 1;
			if (n < 1)
			{
				return v;
			}
			if (k.Length < 4)
			{
				UInt32[] Key = new UInt32[4];
				k.CopyTo(Key, 0);
				k = Key;
			}
			UInt32 z = v[n], y = v[0], delta = 0x9E3779B9, sum, e;
			Int32 p, q = 6 + 52 / (n + 1);
			sum = unchecked((UInt32)(q * delta));
			while (sum != 0)
			{
				e = sum >> 2 & 3;
				for (p = n; p > 0; p--)
				{
					z = v[p - 1];
					y = unchecked(v[p] -= (z >> 5 ^ y << 2) + (y >> 3 ^ z << 4) ^ (sum ^ y) + (k[p & 3 ^ e] ^ z));
				}
				z = v[n];
				y = unchecked(v[0] -= (z >> 5 ^ y << 2) + (y >> 3 ^ z << 4) ^ (sum ^ y) + (k[p & 3 ^ e] ^ z));
				sum = unchecked(sum - delta);
			}
			return v;
		}
		private static uint[] ToUInt32Array(byte[] data, Boolean includeLength)
		{
			Int32 n = (((data.Length & 3) == 0) ? (data.Length >> 2) : ((data.Length >> 2) + 1));
			UInt32[] Result;
			if (includeLength)
			{
				Result = new UInt32[n + 1];
				Result[n] = (UInt32)data.Length;
			}
			else
			{
				Result = new UInt32[n];
			}
			n = data.Length;
			for (Int32 i = 0; i < n; i++)
			{
				Result[i >> 2] |= (UInt32)data[i] << ((i & 3) << 3);
			}
			return Result;
		}
		private static byte[] ToByteArray(UInt32[] data, Boolean includeLength)
		{
			Int32 n;
			if (includeLength)
			{
				n = (Int32)data[data.Length - 1];
			}
			else
			{
				n = data.Length << 2;
			}
			byte[] Result = new byte[n];
			for (Int32 i = 0; i < n; i++)
			{
				Result[i] = (byte)(data[i >> 2] >> ((i & 3) << 3));
			}
			return Result;
		}
	}
}