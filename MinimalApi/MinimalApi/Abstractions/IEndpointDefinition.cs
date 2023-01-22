namespace MinimalApi.Abstractions
{
    public interface IEndpointDefinition
    {
        void RegisterEndpoints(WebApplication app);
    }
}
