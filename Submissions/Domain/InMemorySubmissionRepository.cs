using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Submissions.Domain
{
	public class InMemorySubmissionRepository : ISubmissionRepository
	{
		private static readonly ConcurrentBag<Submission> submissions;

		static InMemorySubmissionRepository()
		{
			submissions = new ConcurrentBag<Submission>();
		}

		public void Add(Submission submission)
		{
			submissions.Add(submission);
		}

		public IEnumerable<Submission> All()
		{
			return submissions.OrderByDescending(x => x.DateSubmitted);
		}

		public Submission Get(Guid id)
		{
			return submissions.FirstOrDefault(x => x.Id == id);
		}
	}
}