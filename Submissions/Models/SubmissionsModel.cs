using System.Collections.Generic;

namespace Submissions.Models
{
	public class SubmissionsModel
	{
		public SubmissionsModel()
		{
			Submissions = new List<SubmissionModel>();
			ValidationMessages = new List<string>();
		}

		public SubmissionsModel(IEnumerable<SubmissionModel> submissions)
		{
			Submissions = submissions;
		}
		
		public IEnumerable<SubmissionModel> Submissions { get; private set; }

		public IEnumerable<string> ValidationMessages { get; set; }
	}
}