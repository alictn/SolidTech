namespace SolidTech.Data.Configuration
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Projects");
            builder.HasKey(x => x.ProjectId);
            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(x => x.Image)
                   .HasMaxLength(int.MaxValue);


            builder.Property(x => x.Order)
                   .IsRequired();

            builder.Property(x => x.CreaDate)
                   .IsRequired();

            //Bir project tek bir Category'ye sahiptir,Bir categorinin sonsuz tane projesi olabilir
            builder.HasOne(x => x.ProjectCategory)
                   .WithMany()
                   .HasForeignKey(x => x.ProjectCategoryId);


            builder.HasOne(ip => ip.ProjectImagePath)
                .WithOne(p => p.Project)
                .HasForeignKey<ProjectImagePath>(p => p.ProjectId);


            //1)HasOne WithMany
            //2)HasMany WithOne
            //----------------
            //EntityX HasOne EntityY WithMany EntityX
            //Project HasOne ProjectCategory WithMany Project 
        }
    }
}
