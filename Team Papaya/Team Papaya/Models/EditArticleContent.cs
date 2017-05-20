using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team_Papaya.Models
{
    public class EditArticleContent
    {
        private string title;
        private string content;

        public EditArticleContent(string title, string content)
        {
            this.title = title;
            this.content = content;
        }

        public string Title
        {
            get { return this.title; }
            set { this.title = value; }
        }

        public string Content
        {
            get { return this.content; }
            set { this.content = value; }
        }
    }
}
