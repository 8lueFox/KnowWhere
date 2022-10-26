using KW.Domain.Common;
using KW.FS.Application;
using KW.Shared.Extensions;
using System.Text.RegularExpressions;

namespace KW.FS.Infrastructure;

public class LocalFileStorageService : IFileStorageService
{ 
    public async Task<string> UploadAsync<T>(FileUploadRequest? request, FileType supportedFileType, CancellationToken cancellationToken = default) where T : class
    {
        if (request == null)
            return string.Empty;

        if (!supportedFileType.GetDescriptionList().Contains(request.Extension.ToLower()))
            throw new InvalidOperationException("File Format Not Supported.");
        if (request.Name is null)
            throw new InvalidOperationException("Name is required.");

        string base64Data = Regex.Match(request.Data, "data:image/(?<type>.+?),(?<data>.+)").Groups["data"].Value;

        return null;
    }

    public void Remove(string? path)
    {
        throw new NotImplementedException();
    }
}
