using Submissions.Domain;

namespace Submissions.Models
{
	public class SubmissionEntryModel
	{
		private SubmissionEntryModel()
		{
		}

		public SubmissionEntryModel(string name, string details) : this()
		{
			Name = name;
			Details = details;
		}

		public string Details { get; set; }

		public string Name { get; set; }

		public SubmissionEntry BuildSubmissionEntry()
		{
			return new SubmissionEntry(Name, Details);
		}

		public static SubmissionEntryModel BuildFromSubmissionEntry(SubmissionEntry entry)
		{
			return new SubmissionEntryModel(entry.Name, entry.Details);
		}
	}
}