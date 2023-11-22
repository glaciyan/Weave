namespace Weave;

public class Decoder
{
    private readonly byte[] _message;

    public Decoder(byte[] message)
    {
        _message = message;
    }

    public byte[] Decode(byte xorParam)
    {
        var message = new byte[_message.Length];
        var ecx = _message.Length;
        for (var esi = 0; esi < ecx; esi++)
        {
            var al = _message[esi] ^ xorParam;
            unsafe
            {
                // C# forces byte xor byte to be an int result and wont
                // allow a int -> byte cast, so we use an unsafe pointer
                var ptr = (byte*)&al;
                message[esi] = *ptr;
            }
        }

        return message;
    }
}