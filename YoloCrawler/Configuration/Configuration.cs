namespace YoloCrawler.Configuration
{
    using Newtonsoft.Json;

    public interface Configuration<out T> where T : Configuration<T>
    {
        [JsonIgnore]
        T Default { get; }
    }
}