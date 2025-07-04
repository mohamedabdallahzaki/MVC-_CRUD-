
namespace Project.DataAcessLayer.Data.Configruations
{
    public  class BaseEntityConfigruations<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(d => d.CreatedAt).HasDefaultValueSql("getdate()");
            builder.Property(d => d.UpdatedAt).HasDefaultValueSql("getdate()");
        }
    }
}
