using System.Text;

namespace Visicom.DataApi.Geocoder.Extensions;
/// <summary>
/// Request builder extensions for StringBuilder
/// </summary>
public static class StringBuilderExtensions
{
    public static StringBuilder AppendEndpoint(this StringBuilder builder, string endpoint)
        => builder.Append(endpoint).Append('/');

    public static StringBuilder AppendParam(this StringBuilder builder, string param, string value,
        bool isFirst = false)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return builder;
        }
        
        if (isFirst)
        {
            builder[^1] = '?';
        }
        else
        {
            builder.Append('&');
        }

        return builder.Append(param)
            .Append('=')
            .Append(value);
    }
}