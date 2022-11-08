using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace UppyDemo
{
	[Route("api/upload/[action]")]
	[ApiController]
	public class UploadController : ControllerBase
	{

		[HttpPost]
		public async Task<IActionResult> UploadFile1(IFormFile file)
		{
			Debug.WriteLine($"Begin {file.FileName}.");
			string output = $"{file.FileName} - {file.Length}";
			Debug.WriteLine($"End {file.FileName}.");
			return Ok(output);
		}


		[HttpPost]
		public async Task<IActionResult> UploadFile2(IFormFile file, [FromForm]int idPackage)
		{
			Debug.WriteLine($"Begin {file.FileName} with idPackage {idPackage}.");
			string output = $"{file.FileName} - {file.Length} - {idPackage}";
			Debug.WriteLine($"End {file.FileName} with idPackage {idPackage}.");
			return Ok(output);
		}

	}
}
