using ClosedXML.Excel;
using CsvHelper;
using CsvHelper.Excel;
using Submissions.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Submissions.ApplicationServices
{
	public class SubmissionExcelParser : ISubmissionFileParser
	{
		public IEnumerable<SubmissionModel> Parse(Stream stream, string filename)
		{
			var models = new List<SubmissionModel>();

			using (var workbook = new XLWorkbook(stream, XLEventTracking.Disabled))
			using (var reader = new CsvReader(new ExcelParser(workbook, new CsvHelper.Configuration.CsvConfiguration { HasHeaderRecord = true, IsHeaderCaseSensitive = false })))
				models.Add(new SubmissionModel(filename, DateTime.Now, reader.GetRecords<SubmissionEntryModel>().ToList()));

			return models;
		}
	}
}