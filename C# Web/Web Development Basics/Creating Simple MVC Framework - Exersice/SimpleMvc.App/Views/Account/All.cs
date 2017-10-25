namespace SimpleMvc.App.Views.Account
{
    using System.Text;
    using SimpleMvc.App.Dto;
    using SimpleMvc.Framework.Contracts.Generic;

    public class All : IRenderable<AllUsernamesDto>
    {
        public string Render()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<h3>All users</h3>")
                .AppendLine("<ul>");
            foreach (UserDto user in this.Model.Users)
            {
                sb.AppendLine($@"<li><a href=""\account\profile?id={user.Id}"">{user.Username}</a></li>");
            }
            sb.AppendLine("</ul>");

            return sb.ToString();
        }

        public AllUsernamesDto Model { get; set; }
    }
}
