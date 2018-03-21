namespace Seriloger.Core.Services
{
    public interface IKrisLogger
    {
        void LogDebug(string msg);
        void LogError(string msg);
    }
}
