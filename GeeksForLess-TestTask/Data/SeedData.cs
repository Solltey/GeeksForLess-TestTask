using GeeksForLess_TestTask.Models;

namespace GeeksForLess_TestTask.Data
{
    public class SeedData
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                if (!context.Catalogs.Any())
                {
                    var folders = new List<Catalog>
                    {
                        new Catalog
                        {
                            Id = 2,
                            Name = "Creating Digital images",
                            FolderId = 1,
                            Path = ""
                        },
                        new Catalog
                        {
                            Id = 3,
                            Name = "Resources",
                            FolderId = 2,
                            Path = "Creating Digital images"
                        },
                        new Catalog
                        {
                            Id = 4,
                            Name = "Evidence",
                            FolderId = 2,
                            Path = "Creating Digital images"
                        },
                        new Catalog
                        {
                            Id = 5,
                            Name = "Graphic Product",
                            FolderId = 2,
                            Path = "Creating Digital images"
                        },
                        new Catalog
                        {
                            Id = 6,
                            Name = "Primary Sources",
                            FolderId = 3,
                            Path = "Creating Digital images%Resources"
                        },
                        new Catalog
                        {
                            Id = 7,
                            Name = "Secondary Sources",
                            FolderId = 3,
                            Path = "Creating Digital images%Resources"
                        },
                        new Catalog
                        {
                            Id = 8,
                            Name = "Process",
                            FolderId = 5,
                            Path = "Creating Digital images%Graphic Product"
                        },
                        new Catalog
                        {
                            Id = 9,
                            Name = "Final Product",
                            FolderId = 5,
                            Path = "Creating Digital images%Graphic Product"
                        }
                    };

                    context.Catalogs.AddRange(folders);
                    context.SaveChanges();
                }
            }
        }
    }
}