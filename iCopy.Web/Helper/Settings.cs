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
            public static class User
            {
                public static string Update => "/administration/user/update";
                public static string UpdatePassword => "/administration/user/updatepassword";
            }
            public static class SelectList
            {
                public static string Cities => "/selectlist/cities";
                public static string CitiesByCountry => "/selectlist/CitiesByCountry";
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
                public static string Index => "/auth/login/index";
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
