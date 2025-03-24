
namespace SolidTech.Data
{
    public class SolidTechContext : DbContext
    {
        public SolidTechContext()
        {

        }
        public SolidTechContext(DbContextOptions<SolidTechContext> options) : base(options)
        {

        }

        //C# tarafındaki Enittylerin Database objesi olarak kabul edildiği yer 
        public DbSet<ProjectCategory> ProjectCategories { get; set; }
        public DbSet<Project> Projects { get; set; }//Crud 
        public DbSet<Solution> Solutions { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<CustomerComment> CustomerComments { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<MessageType> MessageTypes { get; set; }
        public DbSet<ProjectImagePath> ProjectImagePaths { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        //Db Model oluşturma aşamasında çağrılan bir metottur 
        //Model Yapılandırılması:Tablo ve sutun adları,veri türleri,özelliklerinin belirlenmesi
        //İlişkiler : Entityler arası ilişkilerin,birebir,bire çok,çokaçok..ilşiklerin ayarlanması 
        //Seeding   : Veri tabanı tablolarına default değerler atama işlemleri burda yapılır 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new ProjectCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectConfiguration());
            modelBuilder.ApplyConfiguration(new SolutionConfiguration());
            modelBuilder.ApplyConfiguration(new TeamMemberConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerCommentConfiguration());
            modelBuilder.ApplyConfiguration(new MessageConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectImagePathConfiguration());


            modelBuilder.SeedDataCreate();

            base.OnModelCreating(modelBuilder);
        }

        //Configurasyon yapıldığında çalıştırılamsını istediğin kodlar buraya yazılır
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //MsSql
            optionsBuilder.UseSqlServer("Server=ALI\\MSSQLSERVER01;Database=SolidTechDb;Trusted_Connection=True;Encrypt=False");
            //Not schema adı küçük olamk durumda ve schema adı Search Path ten sonra belirtilmek zorunda 

            //optionsBuilder.UseNpgsql(@"Host=localhost;Database=test2;Username=postgres;Password=123456;Search Path=public");
        }
    }
}
