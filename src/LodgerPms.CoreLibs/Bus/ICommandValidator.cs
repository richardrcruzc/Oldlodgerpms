using LodgerPms.CoreLibs.Domain;

namespace LodgerPms.CoreLibs.Bus
{
    /// <summary>
    ///     This is a supertype for register all command validators
    /// </summary>
    public interface ICommandValidator<T>
        where T : Command
    {
    }
}