namespace Brightskies.Restaurant.Application.Users.Comands.Dtos
{
    public class LoginOutput 
    {
        public string Name { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public string ErrorMessage { get; set; }
    }
}