using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupManagement.BlazorUI.Static
{
    public static class EndPoints
    {
        public static string BaseUrl = "https://localhost:44358/";
        public static string CountriesEndPoint = $"{BaseUrl}api/master/countries/";
        public static string CitiesEndPoint = $"{BaseUrl}api/master/cities/";
        public static string LoginEndPoint = $"{BaseUrl}api/users/login/";
        public static string RegisterEndPoint = $"{BaseUrl}api/users/register/";
    }
}
