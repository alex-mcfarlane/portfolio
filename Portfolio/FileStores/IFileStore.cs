using System.Web;

namespace Portfolio.FileStores
{
    public interface IFileStore
    {
        string Store(HttpPostedFileBase file);
    }
}
