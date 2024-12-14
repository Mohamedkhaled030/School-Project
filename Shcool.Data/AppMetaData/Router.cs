namespace Shcool.Data.AppMetaData
{
    public static class Router
    {
        public const string SingleRoute = "/{id}";

        public const string Root = "Api";
        public const string Version = "V1";
        public const string Rule = Root + "/" + Version + "/";

        public static class Student
        {
            public const string prefix = Rule + "Students";
            public const string List = prefix + "/List";
            public const string GetById = prefix + SingleRoute;
            public const string Create = prefix + "/Create";
            public const string Update = prefix + "/Update";
            public const string Delete = prefix + "/{id}";
            public const string Paginated = prefix + "/paginated";

        }
        public static class InstructorRouter
        {
            public const string prefix = Rule + "Instructor";
            public const string GetInstructorList = prefix + "/List";
            public const string AddInstructor = prefix + "/Create";
            public const string GetSalarySummitionInstractour = prefix + "/Salary-Summition-Instractour";
        }
        public static class Department
        {
            public const string prefix = Rule + "Department";
            public const string List = prefix + "/List";
            public const string GetById = prefix + "/Id";
            public const string GetViewDepartmentStudentCount = prefix + "/Department-Student-Count";
            public const string GetProcDepartmentStudentById = prefix + "GetView-Department-Student-ById/{id}";
        }
        public static class ApplicationUserRouter
        {
            public const string prefix = Rule + "User";
            public const string Create = prefix + "/Create";
            public const string Paginated = prefix + "/paginated";
            public const string GetById = prefix + SingleRoute;
            public const string Update = prefix + "/Update";
            public const string Delete = prefix + "/{id}";
            public const string ChangePassword = prefix + "/Change-Password";






        }
        public static class Authentication
        {
            public const string prefix = Rule + "Authentication";
            public const string SignIn = prefix + "/SignIn";
            public const string RefreshToken = prefix + "/Refresh-Token";
            public const string ValidateToken = prefix + "/Validate-Token";
            public const string ConfirmEmail = "/Api/Authentication/ConfirmEmail";
            public const string SendReastPassword = prefix + "/SendReastPassword";
            public const string ConfirmReastPassword = prefix + "/ConfirmReastPassword";
            public const string ReastPassword = prefix + "/ReastPassword";

        }
        public static class AuthorizationRout
        {
            public const string prefix = Rule + "AuthorizationRout";
            public const string Roles = prefix + "/Role";
            public const string Claims = prefix + "Claims";
            public const string Create = Roles + "/Create";
            public const string Edite = Roles + "/Edite";
            public const string GetListRoles = prefix + "/Role/GetListRoles";
            public const string Delete = Roles + "/Delete/{id}";
            public const string GetRolesById = Roles + "/Role-By-Id/{id}";
            public const string MangeUserRoles = Roles + "/Mange-User-Roles/{userId}";
            public const string MangeUserCliams = Claims + "/Mange-User-Claims/{userId}";
            public const string UpdateUserRole = Roles + "/Update-User-Roles";
            public const string UpdateUserClaim = Roles + "/Update-User-Claims";
        }
        public static class Email
        {
            public const string prefix = Rule + "EmailsRoute";
            public const string SendEmails = prefix + "/SendEmails";
        }
    }
}
