namespace GeeksForLess_TestTask.Interfaces
{
    public interface ICatalogService
    {
        public void GetCatalogTree(string directory, int lvl, string[] excludedFolders = null, string lvlSeperator = "");
    }
}
