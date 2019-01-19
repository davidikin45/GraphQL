using GraphQL.Types;
using GraphQLNetCore.Data;
using GraphQLNetCore.Models.GraphQL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLNetCore.Query
{
    public class EatMoreQuery : ObjectGraphType
    {
        public EatMoreQuery(AppDbContext db)
        {
            Field<RestaurantType>(
                "restaurant",
                arguments: new QueryArguments(
                    new QueryArgument<IdGraphType> { Name = "id", Description = "The ID of the restaurant." }),
                resolve: context =>
                {
                    var id = context.GetArgument<Guid?>("id");
                    var restaurant = db
                        .Restaurants
                        .Include("Menus.MenuItems")
                        .FirstOrDefault(i => i.Id == id);
                    return restaurant;
                });

            Field<ListGraphType<RestaurantType>>(
                "restaurants",
                resolve: context =>
                {
                    var restaurants = db.Restaurants.Include("Menus.MenuItems");
                    return restaurants;
                });
        }
    }
}
