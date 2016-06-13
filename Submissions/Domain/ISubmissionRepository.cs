using System;
using System.Collections.Generic;

namespace Submissions.Domain
{
	public interface ISubmissionRepository
	{
		void Add(Submission submission);

		IEnumerable<Submission> All();

		Submission Get(Guid id);
	}
}