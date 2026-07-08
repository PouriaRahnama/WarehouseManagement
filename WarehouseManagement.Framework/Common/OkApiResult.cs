namespace WarehouseManagement.Framework.Common;

public class OkApiResult<T>
{
    public static OkApiResult<T> Ok(T data)
    {
        return new OkApiResult<T>
        {
            Success = true,
            Data = data,
        };
    }

    public static OkApiResult<T> Fail(string errorMessage, string? message = "")
    {
        return new OkApiResult<T>
        {
            Success = false,
            Data = (T)(object)errorMessage, // چون Data جنریک هست
            Message = message
        };
    }


    public bool Success { get; set; }
    public T Data { get; set; }
    public string? Message { get; set; } = ".عملیات با موفقیت انجام شد";
}