namespace Marketplace.Domain.Models.Response
{
    public class ResultModel<T>
    {
        public T Result { get; set; }
        public string Error { get; set; }
        public bool Success => string.IsNullOrWhiteSpace(Error);

        public ResultModel()
        { }

        public ResultModel(T result)
            => Result = result;

        public ResultModel(string error)
            => Error = error;

        public ResultModel<T> AddResult(T result)
            => new(result);

        public ResultModel<T> AddError(string error)
            => new(error);
    }
}
