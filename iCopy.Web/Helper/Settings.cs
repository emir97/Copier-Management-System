namespace iCopy.Web.Helper
{
    public class Settings
    {
        public static class Routes
        {

            public static class City
            {
                public static string Index => "/location/city/index";
                public static string Insert => "/location/city/insert";
                public static string Update => "/location/city/update";
                public static string Delete => "/location/city/delete";
                public static string GetData => "/location/city/getdata";
                public static string ChangeActiveStatus => "/location/city/changeactivestatus";
            }
            public static class Country
            {
                public static string Index => "/location/country/index";
                public static string Insert => "/location/country/insert";
                public static string Update => "/location/country/update";
                public static string Delete => "/location/country/delete";
                public static string GetData => "/location/country/getdata";
                public static string ChangeActiveStatus => "/location/country/changeactivestatus";
            }
            public static class Company
            {
                public static string Index => "/administration/company/index";
                public static string Insert => "/administration/company/insert";
                public static string Update => "/administration/company/update";
                public static string Delete => "/administration/company/delete";
                public static string GetData => "/administration/company/getdata";
                public static string ChangeActiveStatus => "/administration/company/changeactivestatus";
                public static string Details => "/administration/company/details";
            }
            public static class Copier
            {
                public static string Index => "/administration/copier/index";
                public static string Insert => "/administration/copier/insert";
                public static string Update => "/administration/copier/update";
                public static string Delete => "/administration/copier/delete";
                public static string GetData => "/administration/copier/getdata";
                public static string ChangeActiveStatus => "/administration/copier/changeactivestatus";
                public static string Details => "/administration/copier/details";
            }
            public static class Employee
            {
                public static string Index => "/administration/employee/index";
                public static string Insert => "/administration/employee/insert";
                public static string Update => "/administration/employee/update";
                public static string Delete => "/administration/employee/delete";
                public static string GetData => "/administration/employee/getdata";
                public static string ChangeActiveStatus => "/administration/employee/changeactivestatus";
                public static string Details => "/administration/employee/details";
            }
            public static class User
            {
                public static string Index => "/administration/user/index";
                public static string ChangeActiveStatus => "/administration/user/changeactivestatus";
                public static string GetData => "/administration/user/getdata";
                public static string Update => "/administration/user/update";
                public static string UpdatePassword => "/administration/user/updatepassword";
                public static string Details => "/administration/user/details";
            }
            public static class PrintRequest
            {
                public static string Index => "/administration/printrequest/index";
                public static string Insert => "/administration/printrequest/insert";
                public static string Update => "/administration/printrequest/update";
                public static string Delete => "/administration/printrequest/delete";
                public static string GetData => "/administration/printrequest/getdata";
                public static string ChangeActiveStatus => "/administration/printrequest/changeactivestatus";
                public static string Details => "/administration/printrequest/details";
            }
            public static class SelectList
            {
                public static string Cities => "/selectlist/cities";
                public static string CitiesByCountry => "/selectlist/CitiesByCountry";
                public static string CopiersByCompanyId => "/selectlist/copiersbycompanyid";
            }
            public static class Upload
            {
                public static string UploadProfileImage => "/upload/UploadProfileImage";
                public static string RemoveUploadedProfileImage => "/upload/RemoveUploadedProfileImage";
            }
            public static class SignUp
            {
                public static string Index => "/auth/signup/index";
            }
            public static class Login
            {
                public static string Index => "/auth/login/";
                public static string Logout => "/auth/login/logout";
                public static string ActivateAcount => "/auth/login/activate";
            }
            public static class Dashboard
            {
                public static string Index => "/administration/dashboard/";
            }
        }
        public static class Defaults
        {
            public static class Photo
            {
                public static string ProfilePhoto => "assets/media/users/default_user.png";
            }
        }
    }
}
