using System;


namespace nwn2_ai_2da_editor
{
	static class util
	{
		#region Utilities (static)
		/// <summary>
		/// Value of <c>epsilon</c>.
		/// </summary>
		const float epsilon = 0.0001f;

		/// <summary>
		/// Checks if two <c>floats</c> are within <c><see cref="epsilon"/></c>.
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns>true if equal enough</returns>
		/// <remarks>Does not handle NaNs, infinities or whathaveya.</remarks>
		internal static bool FloatsEqual(float a, float b)
		{
			return Math.Abs(b - a) < epsilon;
		}

		/// <summary>
		/// Formats a <c>float</c> to a <c>string</c> that is consistent with a
		/// 2da-field.
		/// </summary>
		/// <param name="f"></param>
		/// <returns><c>string</c> of a <c>float</c></returns>
		internal static string Float2daFormat(float f)
		{
			string val = f.ToString();

			if (val.IndexOf('.') == -1)
				return val + ".0";

			return val;
		}
		#endregion Utilities (static)
	}
}
