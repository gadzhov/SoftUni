namespace SimpleMvc.App.Views.Account
{
    using System.Text;
    using App.Dto;
    using Framework.Contracts.Generic;

    public class Profile : IRenderable<UserProfileDto>
    {
        public string Render()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"<h1>User: {this.Model.Name}</h1>")
                .AppendLine("<form method=\"POST\">")
                .AppendLine("Title: <input type=\"text\" name=\"Title\" />")
                .AppendLine("Content: <input type=\"text\" name=\"Content\" />")
                .AppendLine("</br>")
                .AppendLine($"<input type=\"text\" name=\"OwnerId\" value=\"{this.Model.Id}\"  hidden/>")
                .AppendLine("</br>")
                .AppendLine("<input type=\"submit\" value=\"Add Note\"/>")
                .AppendLine("</form>")
                .AppendLine("</br>")
                .AppendLine("List of notes")
                .AppendLine("<ul>");
            foreach (NoteDto note in this.Model.Notes)
            {
                sb.AppendLine($"<li>{note.Title} {note.Content}</li>");
            }

            sb.AppendLine("</ul");

            return sb.ToString();
        }

        public UserProfileDto Model { get; set; }
    }
}
