

using System;
using System.Linq;

namespace SettlersOfValgardGame.util.random
{
    public static class Noise
    {
        public static uint GetDimensionalNoise(uint seed, int x, int y = 0, int z = 0, int t = 00)
        {
            const uint prime1 = 4033;
            const uint prime2 = 103387;
            const uint prime3 = 261104399;
            return GetNoise(Convert.ToInt32(x + prime1 * y + prime2 * z + prime3 * t), seed);
        }
        
        public static uint GetNoise(int position, uint seed)
        {
            const uint bitNoise1 = 0x85297a4d;
            const uint bitNoise2 = 0x68e31da4;
            const uint bitNoise3 = 0x1859c4e9;
            
            var mangled = Convert.ToUInt32(Convert.ToInt64(position) + int.MaxValue);
            mangled *= bitNoise1;
            mangled += seed;
            mangled ^= (mangled >> 8);
            mangled += bitNoise2;
            mangled ^= (mangled << 8);
            mangled *= bitNoise3;
            mangled ^= (mangled >> 8);
            return mangled;
        }

        public static uint GetRecursiveNoise(uint seed, params int[] positions)
        {
            return positions.Aggregate(seed, (current, position) => GetNoise(position, current));
        }
    }
}