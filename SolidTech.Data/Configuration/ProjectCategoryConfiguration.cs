namespace SolidTech.Data.Configuration
{
    public class ProjectCategoryConfiguration : IEntityTypeConfiguration<ProjectCategory>
    {
        public void Configure(EntityTypeBuilder<ProjectCategory> builder)
        {
            builder.ToTable("ProjectCategories");
            builder.HasKey(x => x.ProjectCategoryId);
            builder.Property(x => x.CategoryName)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.Property(x => x.Order)
                   .IsRequired();

            builder.Property(x => x.CreaDate)
                   .IsRequired();
        }
    }
}
