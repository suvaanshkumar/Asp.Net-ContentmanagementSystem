using System.Web;

namespace ContenManagementSystem.Models
{
    /// <summary>
    /// Supported HTML elements. Open for extension, closed for modification.
    /// </summary>
    public class HTMLElement
    {
        public string ElementId { get; set; }
    }

    public class TextView : HTMLElement
    {
        public string Text { get; set; }
        public TextView(string id, string value)
        {
            this.ElementId = id;
            this.Text = value;
        }
    }
    public class ImageView : HTMLElement
    {
        public string Src { get; set; }
        public ImageView(string id, string value)
        {
            this.ElementId = id;
            this.Src = value;
        }
    }
    public class UserDefinedView : HTMLElement
    {
        public HtmlString SanitizedHTML { get; set; }
        public UserDefinedView(string id, HtmlString value)
        {
            this.ElementId = id;
            this.SanitizedHTML = value;
        }
    }
}