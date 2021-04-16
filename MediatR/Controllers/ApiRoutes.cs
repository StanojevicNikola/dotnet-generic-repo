using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Generic.Repo.API.Controllers
{
    public static class ApiRoutes
    {
        public const string Root = "api";

        public static class Get 
        {
            public const string GetAllUsers = Root + "/users";
            public const string GetUser = Root + "/users/{id}";
            public const string GetAllOrders = Root + "/orders";
            public const string GetOrder = Root + "/orders/{id}";
        }
        public static class Post 
        {
            public const string CreateUser = Root + "/users";
            public const string CreateOrder = Root + "/orders";
        }
        public static class Put
        {
            public const string UpdateUser = Root + "/users/{id}";
            public const string UpdateOrder = Root + "/orders/{id}";
        }
        public static class Delete
        {
            public const string DeleteUser = Root + "/users/{id}";
            public const string DeleteOrder = Root + "/orders/{id}";
        }
    }
}
