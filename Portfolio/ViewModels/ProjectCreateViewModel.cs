using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Portfolio.ViewModels
{
    public class ProjectCreateViewModel : ProjectViewModel
    {
        [Required]
        public HttpPostedFileBase Image { get; set; }
    }
}
