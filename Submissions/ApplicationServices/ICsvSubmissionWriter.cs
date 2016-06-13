using Submissions.Domain;

namespace Submissions.ApplicationServices
{
	public interface ICsvSubmissionWriter
	{
		byte[] Write(Submission submission);
	}
}
