using System.Net;
using System.Text.Json;

namespace aplication.Exceptions;

public class CustomException : Exception
{
    public HttpStatusCode StatusCode { get; set; }
    public CustomException(HttpStatusCode statusCode, string message) : base(message)
    {
        StatusCode = statusCode;
    }

    public static CustomException BadRequest(object obj) =>
        new CustomException(HttpStatusCode.BadRequest, JsonSerializer.Serialize(obj));

    public static CustomException EntityNotFound(object obj) =>
        new CustomException(HttpStatusCode.NotFound, JsonSerializer.Serialize(obj));

    public static CustomException ErroValidacao(object obj) =>
        new CustomException(HttpStatusCode.UnprocessableEntity, JsonSerializer.Serialize(obj));

    public static CustomException Conflito(object obj) =>
        new CustomException(HttpStatusCode.Conflict, JsonSerializer.Serialize(obj));

}