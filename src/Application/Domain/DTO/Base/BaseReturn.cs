using api_cadastro.Application.Domain.Dto.Base;
using api_cadastro.Application.Domain.Enums;

public struct BaseReturn<TSuccess>
{
    public EnumState State { get; set; }
    public TSuccess? SucessObject { get; set; }
    public BaseError? ErrorObject { get; set; }

    public BaseReturn()
    {
        State = EnumState.SUCCESS;
        SucessObject = default;
        ErrorObject = null;
    }

    public BaseReturn<TSuccess> Success(TSuccess success)
    {
        State = EnumState.SUCCESS;
        SucessObject = success;

        return this;
    }

    public BaseReturn<TSuccess> Error(EnumState status, BaseError error)
    {
        State = status;
        ErrorObject = error;

        return this;
    }
}
