using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Portfolio.Models
{
    public class Project
    {
        private string _link;
        private string _imagePath;
        private string _baseDir;

        public Project()
        {
            _baseDir = "~/Images/";
        }

        public int ID { get; set; }
        [StringLength(100, MinimumLength = 2)]
        [Required]
        public string Title { get; set; }
        public string Body { get; set; }

        public string ExternalLink
        {
            get
            {
                return _link;
            }
            set
            {
                // perform URL formatting if value does not start with "http" (this could be http, https, etc... as it checks the first 4 chars)
                if (!UrlHeadHasString("http", value))
                {
                    value = "http://" + value;
                }

                _link = value;
            }
        }

        public string ImagePath
        {
            get
            {
                return _imagePath;
            }
            set
            {
                _imagePath = value;
            }
        }

        public List<Category> Categories { get; set; }

        private bool UrlHeadHasString(string needle, string url)
        {
            int needleLen = needle.Length;

            return url.Substring(0, needleLen).Contains(needle);
        }

        public void SetImagePath(string fileName)
        {
            _imagePath = _baseDir + fileName;
        }
    }
}