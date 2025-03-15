namespace Shared
{
    public static class Constants
    {
        public enum EResponse
        {
            OK,
            ERRORE,
            NOT_FOUND,
            EXISTS_EMAIL,
            EXISTS_RECORD,
            REQUEST_ERROR,
            REQUIRED_FIELD_NOT_FOUND,
            USERNAME_NOT_VALID,
            EMAIL_NOT_VALID,
            PASSWORD_NOT_VALID,
            EXISTS_USERNAME,
            USER_NOT_FOUND
        }

        public enum ParametersType
        {
            PATH,
            QUERY,
            HEADERS
        }
    }
}
