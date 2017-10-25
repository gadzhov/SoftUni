namespace SimpleMvc.App.Dto
{
    using System.Collections.Generic;
 
    public class UserProfileDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<NoteDto> Notes { get; set; }
    }
}
