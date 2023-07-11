

public class Program
{
    UInt64 seed = 0x1234567890ABCDEF;
    private UInt32 NextBit()
    {
        UInt64 x = seed;
        UInt64 next = (x << 1) ^ (x >> 63) ^ ((x >> 53) & 1) ^ ((x >> 38) & 1) ^ ((x >> 23) & 1) ^ ((x >> 8) & 1) ^ 1;
        seed = next;
        return (UInt32)next & 1;
    }

    private UInt32 NextUInt32()
    {
        UInt32 result = 0;
        for (int i = 0; i < 32; i++)
        {
            result = (result << 1) | NextBit();
        }
        return result;
    }

    private static void Main(string[] args)
    {
        var prog = new Program();
        for (int i = 0; i < 1000000; ++i)
        {
            Console.WriteLine($"{prog.NextUInt32()}");
        }
    }
}
