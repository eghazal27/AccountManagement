namespace AccountManagement.Infrastructure.dbcontext
{
    /// <summary>
    /// This class can be transformed into dbContext used By Entity Framework.
    /// Instead Dapper is being used, and this class contains the queries, procedures to be called.
    /// </summary>
    public static class AccountManagemetDbContext
    {
        public static string GETALLACCOUNTS = "select * from public.\"Account\"";
        public static string GETALLCUSTOMERS = "SELECT * FROM public.\"Customer\"";
        public static string GETALLTRANSACTIONS = "SELECT * FROM public.\"Transaction\"";
    }
}
