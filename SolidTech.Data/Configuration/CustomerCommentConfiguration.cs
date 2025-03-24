namespace SolidTech.Data.Configuration
{
    public class CustomerCommentConfiguration : IEntityTypeConfiguration<CustomerComment>
    {
        public void Configure(EntityTypeBuilder<CustomerComment> builder)
        {
            //Tablo adından sonra Schema adı da verilebilir
            //builder.ToTable("CustomerComments", "solidtechdb");
            builder.ToTable("CustomerComments");

            builder.HasKey(x => x.CustomerCommentId);

            builder.Property(x => x.CustomerName)
                   .IsRequired()
                   .HasMaxLength(25);

            builder.Property(x => x.Comment)
                   .HasMaxLength(250)
                   .IsRequired();

            builder.Property(x => x.Title)
                   .HasMaxLength(30);

            builder.Property(x => x.Image)
                   .HasMaxLength(int.MaxValue)
                   .IsRequired();

            builder.Property(x => x.Order)
                   .IsRequired();

            builder.Property(x => x.CreaDate)
                   .IsRequired();

        }
    }
}
