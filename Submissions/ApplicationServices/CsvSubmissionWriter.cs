using CsvHelper;
using Submissions.Domain;
using System.IO;

namespace Submissions.ApplicationServices
{
	public class CsvSubmissionWriter : ICsvSubmissionWriter
	{
		public byte[] Write(Submission submission)
		{
			byte[] contents;

			using (var memoryStream = new MemoryStream())
			using (var streamWriter = new StreamWriter(memoryStream))
			using (var csvWriter = new CsvWriter(streamWriter))
			{
				csvWriter.WriteRecords(submission.Entries);
				streamWriter.Flush();
				contents = memoryStream.ToArray();
			}

			return contents;
		}
	}
}