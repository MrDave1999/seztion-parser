namespace SeztionParser;

internal class ThrowHelper
{
    /// <summary>
    /// Throws an <see cref="ArgumentNullException"/> if <c>argument</c> is <c>null</c>.
    /// </summary>
    /// <param name="argument">
    /// The reference type argument to validate as non-null.
    /// </param>
    /// <param name="paramName">
    /// The name of the parameter with which argument corresponds.
    /// </param>
    /// <exception cref="ArgumentNullException"></exception>
    public static void ThrowIfNull(object argument, string paramName)
    {
        if (argument is null)
            throw new ArgumentNullException(paramName);
    }
}
