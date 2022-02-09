namespace Special_Offer_Hunter.Models
{
    public class UserImageFileNameViewModel
    {
        public UserImageFileNameViewModel(string name)
        {
            FileName = name;
            Message = "";
        }
        public string FileName { get; set; }
        public string Message { get; set; }
    }
}
