using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace API.Controllers;

[ApiController]
[Route("api/files")]
public class FilesController: ControllerBase
{
    
    private readonly FileExtensionContentTypeProvider _fileExtensionContentTypeProvider;

    public FilesController(FileExtensionContentTypeProvider fileExtensionContentTypeProvider)
    {
        _fileExtensionContentTypeProvider = fileExtensionContentTypeProvider ?? throw new ArgumentNullException(nameof(fileExtensionContentTypeProvider));
    }
    
    [HttpGet("{fileId}")]
    public ActionResult GetFile(string fileId)
    {
        var pathToFile = "konradcv.jpg";

        if (!System.IO.File.Exists(pathToFile))
        {
            return NotFound();
        }

        if (!_fileExtensionContentTypeProvider.TryGetContentType( pathToFile, out var contentType ))
        {
            contentType = "application/octet-stream";
        }
        
        var fileBytes = System.IO.File.ReadAllBytes(pathToFile);
        return File(fileBytes, contentType, Path.GetFileName(pathToFile));
    }
}