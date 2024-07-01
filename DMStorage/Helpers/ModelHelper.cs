namespace DMStorage.Helpers
{
    public static class ModelHelper
    {
        public static string GetRoleBadgeClass(string role)
        {
            switch (role)
            {
                case "FiOT":
                    return "badge-primary";
                case "Maintenance":
                    return "badge-success";
                case "Technology":
                    return "badge-danger";
                default:
                    return "badge-secondary";
            }
        }
    }
}
