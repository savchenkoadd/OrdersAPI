﻿namespace Orders.Core.Services.Helpers
{
	internal static class ResultChecker
	{
		private const int EXPECTED_AFFECTED_ROWS = 1;

		internal static void CheckAffectedAndThrowIfNeeded(int affectedRows)
		{
			if (affectedRows)
			{

			}
		}
	}
}
