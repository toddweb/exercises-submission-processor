using Submissions.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Submissions.Models
{
	public class SubmissionModel
	{
		public SubmissionModel(string filename, DateTime dateSubmitted, IEnumerable<SubmissionEntryModel> entries)
		{
			Filename = filename;
			DateSubmitted = dateSubmitted;
			Entries = entries;
		}

		public SubmissionModel(Guid id, string filename, DateTime dateSubmitted, IEnumerable<SubmissionEntryModel> entries) : this(filename, dateSubmitted, entries)
		{
			Id = id;
		}

		public DateTime DateSubmitted { get; private set; }

		public string Filename { get; private set; }

		public Guid Id { get; private set; }

		public IEnumerable<SubmissionEntryModel> Entries { get; private set; }

		// TODO: these builder methods could benefit from something like Automapper
		public Submission BuildSubmission()
		{
			var submission = new Submission(Filename, DateSubmitted);

			Entries.ToList().ForEach(x => submission.AddEntry(x.BuildSubmissionEntry()));

			return submission;
		}

		public static SubmissionModel BuildFromSubmission(Submission submission)
		{
			return new SubmissionModel(submission.Id, submission.Filename, submission.DateSubmitted, submission.Entries.Select(x => SubmissionEntryModel.BuildFromSubmissionEntry(x)));
		}
	}
}