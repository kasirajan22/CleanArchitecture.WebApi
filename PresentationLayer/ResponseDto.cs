using System.ComponentModel;

namespace PresentationLayer;

public class ResponseOk<T>
{
    [DefaultValue(true)]
    public bool Ok => true;

    [DefaultValue(Constants.Success)]
    public string Message => Constants.Success;

    public T? Data { get; set; }
}

public class ResponseFailure
{
    [DefaultValue(false)]
    public bool Ok => false;

    [DefaultValue(Constants.SomethingWentWrong)]
    public string Message => Constants.SomethingWentWrong;
}
