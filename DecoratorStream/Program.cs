using System.Text;

namespace TestDome;

public class DecoratorStream : Stream
{
    private readonly string _prefix;
    private readonly Stream _stream;
    private bool _prefixWritten;

    public DecoratorStream(Stream stream, string prefix)
    {
        _stream = stream ?? throw new ArgumentNullException(nameof(stream));
        _prefix = prefix ?? "";
    }

    public override bool CanSeek => false;
    public override bool CanWrite => true;
    public override bool CanRead => false;
    public override long Length => throw new NotSupportedException();

    public override long Position
    {
        get => throw new NotSupportedException();
        set => throw new NotSupportedException();
    }

    public override void SetLength(long length)
    {
        throw new NotSupportedException();
    }

    public override void Write(byte[] bytes, int offset, int count)
    {
        if (!_prefixWritten)
        {
            var prefixBytes = Encoding.UTF8.GetBytes(_prefix);
            _stream.Write(prefixBytes, 0, prefixBytes.Length);
            _prefixWritten = true;
        }

        _stream.Write(bytes, offset, count);
    }

    public override int Read(byte[] buffer, int offset, int count)
    {
        throw new NotSupportedException();
    }

    public override long Seek(long offset, SeekOrigin origin)
    {
        throw new NotSupportedException();
    }

    public override void Flush()
    {
        _stream.Flush();
    }

    public static void Main(string[] args)
    {
        var message = "Hello, world!"u8.ToArray();

        using var stream = new MemoryStream();
        using var decoratorStream = new DecoratorStream(stream, "First line: ");
        decoratorStream.Write(message, 0, message.Length);
        stream.Position = 0;
        Console.WriteLine(new StreamReader(stream).ReadLine()); // should print "First line: Hello, world!"
    }
}

/*

 --- not done, but time is too short for now

Implement methods and properties in the `DecoratorStream` class:

- `Write` method should write the prefix into the underlying `stream` member **only** on the first `Write` invocation.
    It should always write the bytes it receives to the underlying stream.
- The `prefix` should be written in UTF-8 encoding.

For example, if the `DecoratorStream` is instantiated with `"First line: "` as the prefix parameter and `Write` method is
called with UTF-8 byte representation of `"Hello, world!"`, it should write `"First line: Hello, world!"`
into the underlying stream.

*/
