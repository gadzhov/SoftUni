namespace SocialNetwork.Models.Attributes
{
    using System.ComponentModel.DataAnnotations;
    public class MaxFileSizeAttribute : ValidationAttribute
    {
        private readonly int maxFileSize;

        public MaxFileSizeAttribute(int maxFileSize)
        {
            this.maxFileSize = maxFileSize;
        }

        public override bool IsValid(object value)
        {
            byte[] image = value as byte[];
            return image?.Length <= this.maxFileSize;
        }

        public override string FormatErrorMessage(string name)
        {
            return base.FormatErrorMessage(this.maxFileSize.ToString());
        }
    }
}
