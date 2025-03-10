using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/files")]
public class FileController: ControllerBase
{
    [HttpGet("{fileId}")]
    public ActionResult GetFile(string fileId)
    {
        var pathToFile = "konradcv.jpg";

        if (!System.IO.File.Exists(pathToFile))
        {
            return NotFound();
        }
        
        var fileBytes = System.IO.File.ReadAllBytes(pathToFile);
        return File(fileBytes, "application/jpg", Path.GetFileName(pathToFile));
    }
}