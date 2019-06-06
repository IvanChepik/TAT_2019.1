namespace Writers
{
    /// <summary>
    /// Class Writer
    /// Base class for other writers
    /// </summary>
    public abstract class Writer
    {
        public abstract void WriteInFile<T>(string filename, T list);
    }
}