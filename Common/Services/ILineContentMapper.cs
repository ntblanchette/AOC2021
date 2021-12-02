namespace Common.Services
{
    public interface ILineContentMapper<T> where T : class, new()
    {
        T Map(string[] array);
    }
}
