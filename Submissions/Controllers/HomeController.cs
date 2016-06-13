using ClosedXML.Excel;
using Submissions.ApplicationServices;
using Submissions.Domain;
using Submissions.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Submissions.Controllers
{
	public class HomeController : Controller
	{
		private ISubmissionRepository repository;
		private ISubmissionFileParser fileParser;
		private ICsvSubmissionWriter submissionWriter;

		public HomeController()
		{
			repository = new InMemorySubmissionRepository(); // TODO: Dependency injection
			fileParser = new SubmissionExcelParser();
			submissionWriter = new CsvSubmissionWriter();
		}

		public ActionResult Index()
		{
			return View(GetSubmissionsModel());
		}
		
		[HttpPost]
		public ActionResult Index(HttpPostedFileBase file)
		{
			if (file == null) return View(GetSubmissionsModel()); // TODO: address in js and server-side validation generated messages, as well as server-side file type validation

			IEnumerable<SubmissionModel> models = null;
			var validationMessages = new List<string>();

			try
			{
				models = fileParser.Parse(file.InputStream, file.FileName);
			}
			catch (Exception)
			{
				validationMessages.Add("The file was not in the correct format.");
				return View(GetSubmissionsModel(validationMessages));
			}

			models.ForEach(x => repository.Add(x.BuildSubmission()));

			return View(GetSubmissionsModel());
		}

		public ActionResult DownloadCsv(Guid submissionId)
		{
			var submission = repository.Get(submissionId);
			if (submission == null) return new HttpStatusCodeResult(404);

			return new FileStreamResult(new MemoryStream(submissionWriter.Write(submission)), "text/csv") { FileDownloadName = string.Format(".csv", Path.GetFileNameWithoutExtension(submission.Filename)) };
		}

		private SubmissionsModel GetSubmissionsModel(IEnumerable<string> validationMessages = null)
		{
			return new SubmissionsModel(repository.All().Select(x => SubmissionModel.BuildFromSubmission(x))) { ValidationMessages = validationMessages };
		}
	} 
}