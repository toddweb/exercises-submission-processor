using Submissions.Models;
using System.Collections.Generic;
using System.IO;

namespace Submissions.ApplicationServices
{
	public interface ISubmissionFileParser
	{
		IEnumerable<SubmissionModel> Parse(Stream stream, string filename);
	}
}
