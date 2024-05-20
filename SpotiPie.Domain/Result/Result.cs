namespace SpotiPie.Domain.Result;

public abstract class Result
{
    public Error? Error { get; set; }
    public bool IsSuccess => Error is null;
    public bool IsFailure => Error is not null;

    public static Result<TValue> Ok<TValue>() => new Result<TValue>();
    public static Result<TValue> Ok<TValue>(TValue value) => new Result<TValue>(value);
    public static Result<TValue> Fail<TValue>(Error error) => new Result<TValue>(error);
    public static Result<TValue> Fail<TValue>(string errorCode, string? message = null) =>
        new Result<TValue>(new Error(errorCode, message));
}

public class Result<TValue> : Result
{
    public TValue? Value { get; set; }

    internal Result()
    {
        Value = default;
    }

    internal Result(TValue value)
    {
        Value = value;
    }

    internal Result(Error error)
    {
        Value = default;
        Error = error;
    }

    public static implicit operator Result<TValue>(TValue value) => new Result<TValue>(value);
    public static implicit operator Result<TValue>(Error error) => new Result<TValue>(error);
}