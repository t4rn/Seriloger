namespace Seriloger.Core.Services
{
    public interface IKrisLogger
    {
        void LogDebug(string messageTemplate, params object[] propertyValues);
        void LogError(string messageTemplate, params object[] propertyValues);
    }
}
