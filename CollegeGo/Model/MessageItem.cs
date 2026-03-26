namespace CollegeGo.Model
{
    //Model Attribuites
    public class MessageItem
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string MobileNumber { get; set; } = string.Empty;
        public TimeSpan Duration { get; set; }   
        public DateTime Time { get; set; }       
    }
    
}

