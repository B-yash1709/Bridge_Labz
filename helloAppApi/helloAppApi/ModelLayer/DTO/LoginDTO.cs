namespace ModelLayer.DTO
{
    public class LoginDTO
    {
        public string Email { get; set; }  
        public string Password { get; set; } 

        public override string ToString()
        {
            return $"Username = {Email}, Password = {Password}";  
        }
    }
}
