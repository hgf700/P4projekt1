using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace p4_projekt
{
    public class UserRegister
    {
        [Key]
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Nickname { get; set; }
        public virtual UserDataWhileLogged UserDataWhileLogged { get; set; }
    }

    public class UserDataWhileLogged
    {
        [Key]
        [ForeignKey("UserRegister")]
        public int UserDataWhileLoggedID { get; set; }
        public int UserID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Restaurant> LikedRestaurants { get; set; }
        public virtual UserRegister UserRegister { get; set; }
    }

    public class Restaurant
    {
        [Key]
        public int RestaurantID { get; set; }
        public string Nameofrestaurant { get; set; }
        public string Adressofrestaurant { get; set; }
    }

    public class BloggingContext : DbContext
    {
        public DbSet<UserRegister> UserRegisters { get; set; }
        public DbSet<UserDataWhileLogged> UserDataWhileLoggeds { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
