Imagine that you're working on the C# submission processing code at companyobfuscated. Let's say that our current parser only supports CSV files, but due to popular demand we want to support Excel files.

Please write code that will convert a user's uploaded Excel submission file to a CSV formatted submission file that our existing parser will understand. You can use any NuGet package that has a permissive license for use in a commercial project.

For reliability, security, and performance reasons, your solution must work without accessing the file system in any way (e.g. writing temporary files, using Excel COM, OLE DB, etc).

Write your code in the current style you currently write production code. Try to make reasonable assumptions for any issues that come up along the way.

Your code will be evaluated based on a combination of functionality, completeness, style, and how well you follow engineering best practices.

You should add a small ASP.NET MVC app to the project where you can submit an Excel file and download the converted CSV file.