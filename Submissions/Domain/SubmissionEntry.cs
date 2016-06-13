namespace Submissions.Domain
{
	public class SubmissionEntry
	{
		public SubmissionEntry(string name, string details)
		{
			Name = name;
			Details = details;
		}

		public string Name { get; private set; }

		public string Details { get; private set; }
	}
}