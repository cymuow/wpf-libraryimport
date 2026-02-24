using System.Text;

namespace WpfLibraryImport.Models.Marshaling.Modern;

public static class StringMarshaller
{
    public static string GetString(ReadOnlySpan<byte> span)
    {
        // Null 문자를 찾아 그 전까지만 읽음
        int nullIndex = span.IndexOf((byte)0);
        return Encoding.UTF8.GetString(nullIndex < 0 ? span : span[..nullIndex]);
    }

    public static void SetString(string inputString, Span<byte> dest)
    {
        if (string.IsNullOrEmpty(inputString))
        {
            dest.Clear();
            return;
        }

        // 문자열을 바이트로 변환하여 복사
        int bytesWritten = Encoding.UTF8.GetBytes(inputString, dest);

        // 나머지 공간 초기화
        if (bytesWritten < dest.Length)
        {
            dest[bytesWritten..].Clear();
        }
    }
}
