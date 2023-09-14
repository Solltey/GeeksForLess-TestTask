using GeeksForLess_TestTask.Data;
using GeeksForLess_TestTask.Interfaces;
using GeeksForLess_TestTask.Models;
using static NuGet.Packaging.PackagingConstants;

namespace GeeksForLess_TestTask.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly int count;
        private readonly ApplicationDbContext _context;
        private List<Catalog> _myFolders = new List<Catalog>();
        private int _iterator;
        private string _currentPath;

        public CatalogService(ApplicationDbContext context)
        {
            _context = context;
            _iterator = _context.Catalogs.Count() + 2;
            count = _context.Catalogs.Count() + 1;
        }

        public void GetCatalogTree(string directory, int lvl, string[] excludedFolders = null, string lvlSeperator = "")
        {
            excludedFolders = excludedFolders ?? new string[0];
            foreach (string d in Directory.GetDirectories(directory))
            {
                if (_iterator != _context.Catalogs.Count() + 1)
                {
                    int a = _iterator - 1;

                    _myFolders.Add(new Catalog()
                    {
                        Id = _iterator,
                        Name = Path.GetFileName(d),
                        Path = Path.GetDirectoryName(d),
                        FolderId = (Path.GetDirectoryName(d) == "C:\\Users\\Admin\\Desktop\\fo") ? count
                        : _myFolders.FirstOrDefault(x => x.Path == Path.GetDirectoryName(d)) != null ? _myFolders.FirstOrDefault(x => x.Path == Path.GetDirectoryName(d)).FolderId : a
                    });
                    _iterator++;
                    _currentPath = Path.GetDirectoryName(d);
                }
                else
                {
                    _myFolders.Add(new Catalog() { Id = _iterator, Name = Path.GetFileName(d), FolderId = count, Path = Path.GetDirectoryName(d) });
                    _iterator++;
                    _currentPath = Path.GetDirectoryName(d);
                }

                if (lvl > 0 && Array.IndexOf(excludedFolders, Path.GetFileName(d)) < 0)
                {
                    GetCatalogTree(d, lvl - 1, excludedFolders, lvlSeperator + "  ");
                }
            }
        }
    }
}
