namespace FirstAPI
{
    public class ResultObject<T> where T : class,new()
    {
        public string? Message { get; set; }
        public int StatusCode { get; set; }
        public string? Error { get; set; }
        public T? Value { get; set; }
        public List<T>? Values { get; set; }
    }
}
