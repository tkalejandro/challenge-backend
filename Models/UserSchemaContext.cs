using Microsoft.EntityFrameworkCore;


namespace authapp_react_net.Models

{
    public class UserSchemaContext : DbContext
    {
        public UserSchemaContext(DbContextOptions<UserSchemaContext> options)
            : base(options)
        {
        }

        public DbSet<UserSchema> Users { get; set; } = null!;
    }
}
