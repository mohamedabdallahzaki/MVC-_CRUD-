

using Project.DataAcessLayer.Models.Shared.Enums;

namespace Project.DataAcessLayer.Data.Configruations
{
    public class EmployeeConfigruation: BaseEntityConfigruations<Employee>, IEntityTypeConfiguration<Employee>
    {
        public new void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(e => e.Name).HasColumnType("varchar(50)");
            builder.Property(e => e.Address).HasColumnType("varchar(100)");
    
            builder.Property(e => e.Salary).HasColumnType("decimal(10,2)");
            builder.Property(e => e.Gender).HasConversion((Gender) => Gender.ToString() , _gender => (Gender)Enum.Parse(typeof(Gender), _gender));
            builder.Property(e => e.EmployeeType).HasConversion((Gender) => Gender.ToString(), _Type => (EmployeeType)Enum.Parse(typeof(EmployeeType), _Type));
            base.Configure(builder);
        }
    }
}
