﻿using System;
#if !NETSTANDARD
using System.Web;
#else
using System.Net;
#endif

namespace DotnetSpider.Extraction.Model.Formatter
{
	/// <summary>
	/// Converts a text string into a URL-encoded string.
	/// </summary>
	[AttributeUsage(AttributeTargets.Property)]
	public class UrlEncodeFormater : Formatter
	{
		/// <summary>
		/// 编码的名称
		/// </summary>
		public string Encoding;
		
		/// <summary>
		/// 实现数值的转化
		/// </summary>
		/// <param name="value">数值</param>
		/// <returns>被格式化后的数值</returns>
		protected override object FormateValue(object value)
		{
			string tmp = value.ToString();
#if !NETSTANDARD
			return HttpUtility.UrlEncode(tmp, System.Text.Encoding.GetEncoding(Encoding));
#else
			return WebUtility.UrlEncode(tmp);
#endif
		}

		/// <summary>
		/// 校验参数是否设置正确
		/// </summary>
		protected override void CheckArguments()
		{
			var encoding = System.Text.Encoding.GetEncoding(Encoding);
			if (encoding == null)
			{
				throw new ArgumentException($"Can't get encoding: {Encoding}");
			}
		}
	}
}
