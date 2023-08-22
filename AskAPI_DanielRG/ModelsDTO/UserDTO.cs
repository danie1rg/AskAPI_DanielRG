namespace AskAPI_DanielRG.ModelsDTO
{
    public class UserDTO
    {
        public int UserIdx { get; set; }
        public string UserNamex { get; set; } = null!;
        public string FirstNamex { get; set; } = null!;
        public string LastNamex { get; set; } = null!;
        public string? PhoneNumberx { get; set; }
        public string UserPasswordx { get; set; } = null!;
        public int StrikeCountx { get; set; }
        public string BackUpEmailx { get; set; } = null!;
        public string? JobDescriptionx { get; set; }
        public int UserStatusIdx { get; set; }
        public int CountryIdx { get; set; }
        public int UserRoleIdx { get; set; }

    }
}
