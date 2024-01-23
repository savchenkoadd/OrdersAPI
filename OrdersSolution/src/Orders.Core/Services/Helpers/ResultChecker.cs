namespace Orders.Core.Services.Helpers
{
	internal static class ResultChecker
	{
		private const int MAX_EXPECTED_AFFECTED_ROWS = 1;

		internal static void CheckAffectedAndThrowIfNeeded(int affectedRows)
		{
			if (affectedRows > MAX_EXPECTED_AFFECTED_ROWS)
			{
				throw new Exception("Affected rows did not match expected ones.");
			}
		}
	}
}
