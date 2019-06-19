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
        }
    }
}
