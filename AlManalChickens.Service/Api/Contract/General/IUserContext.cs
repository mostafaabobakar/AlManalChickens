namespace AlManalChickens.Services.Api.Contract.General
{
    public interface IUserContext
    {
        public string WebUserId { get; }
        public string WebLang { get; }


        public string APIUserId { get; }
        public string APILang { get; }

    }
}
