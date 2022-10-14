using KW.Domain.Common;

namespace KW.FS.Application;

public interface IFileStorageService
{
    public Task<string> UploadAsync<T>(FileUploadRequest? request, FileType supportedFileType, CancellationToken cancellationToken = default)
        where T : class;

    public void Remove(string? path);
}
