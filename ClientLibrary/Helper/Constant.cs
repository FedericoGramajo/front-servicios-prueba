using ClientLibrary.Models.Cart;

namespace ClientLibrary.Helper
{
    public static class Constant
    {
        public static class Product
        {
            public const string GetAll  = "product/all";
            public const string Get     = "product/single";
            public const string Add     = "product/add";
            public const string Update  = "product/update";
            public const string Delete  = "product/delete";
        }
        public static class ServiceOffering
        {
            public const string GetAll = "serviceoffering/all";
            public const string Get = "serviceoffering/single";
            public const string Add = "serviceoffering/add";
            public const string Update = "serviceoffering/update";
            public const string Delete = "serviceoffering/delete";
        }
        public static class Category
        {
            public const string GetAll                  = "category/all";
            public const string Get                     = "category/single";
            public const string Add                     = "category/add";
            public const string Update                  = "category/update";
            public const string Delete                  = "category/delete";
            public const string GetServiceByCategory    = "category/service-by-category";
        }
        public static class Authentication
        {
            public const string Type                    = "Bearer";
            public const string Register                = "authentication/create";
            public const string Login                   = "authentication/login";
            public const string ReviveToken             = "authentication/refreshToken";
            public const string RequestPasswordReset    = "authentication/request-password-reset";
            public const string VerifyToken             = "authentication/verifyToken";
            public const string ChangePassword          = "authentication/change-password";
        }
        public static class ApiCallType
        {
            public const string Get     = "get";
            public const string Post    = "post";
            public const string Update  = "put";
            public const string Delete  = "delete";
        }
        public static class Cookie
        {
            public const string Name = "token";
            public const string Path = "/";
            public const int Days = 1; 
        }
        public static class ApiClient
        {
            public const string Name = "Blazor-Client";
        }
        public static class Payment
        {
            public const string GetAll = "payment/methods";
        }

        public static class Cart
        {
            public const string Checkout = "cart/checkout";
            public const string SaveCart = "cart/save-checkout";
            public const string Name = "my-cart";
            public const string GetAchieve = "cart/get-achieves";
        }
        public static class Administration
        {
            public const string AdminRole = "Admin";
            public const string ProfessionalRole = "Professional";
            public const string CustomerRole = "Customer";
        }
        public static class UserProfile
        {
            public const string Get = "userprofile/get";
            public const string Update = "userprofile/update";
            public const string AddAddress = "userprofile/address/add";
            public const string DeleteAddress = "userprofile/address/delete";
            public const string GetAddresses = "userprofile/address/get";
        }
        public static class ServiceHistory
        {
            public const string GetHistory = "servicehistory/get";
        }
        public static class Professional
        {
            public const string GetMetrics              = "professional/metrics";
            public const string GetServiceGroups        = "professional/service-groups";
            public const string GetTransactions         = "professional/transactions";
            public const string AddService              = "professional/service/add";
            public const string UpdateService           = "professional/service/update";
            public const string DeleteService           = "professional/service/delete";
            
            public const string GetAvailableCategories  = "professional/categories/available";
            public const string GetMyCategories         = "professional/categories/mine";
            public const string AddMyCategory           = "professional/categories/add";
            public const string RemoveMyCategory        = "professional/categories/remove";

            public const string GetAvailability         = "availability/professional";
            public const string AddAvailability         = "availability/add";
            public const string RemoveAvailability      = "availability/delete";

            public const string GetCertifications       = "professional/certifications/get";
            public const string AddCertification        = "professional/certifications/add"; // Multipart usually
            public const string RemoveCertification     = "professional/certifications/remove";
        }
        public static class Admin
        {
            public const string GetMetrics              = "admin/metrics";
            public const string GetCategoryReport       = "admin/reports/categories";
            public const string GetStatusReport         = "admin/reports/status";
            public const string GetProfessionals        = "Professional/all";
            public const string UpdateProfessional      = "Professional/update";
        }
    }
}
