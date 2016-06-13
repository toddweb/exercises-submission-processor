using System;
using System.Collections.Generic;

namespace Submissions.Domain
{
	public class Submission
	{
		public Submission(string filename, DateTime dateSubmitted)
		{
			Id = Guid.NewGuid();
			DateSubmitted = dateSubmitted;
			Filename = filename;
			Entries = new List<SubmissionEntry>();
		}

		public DateTime DateSubmitted { get; private set; }

		public string Filename { get; private set; }

		public Guid Id { get; private set; }

		public IList<SubmissionEntry> Entries { get; private set; }

		public void AddEntry(SubmissionEntry entry)
		{
			Entries.Add(entry);
		}
	}
}