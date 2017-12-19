
namespace Utils.BitMath
{
    public class BitMathUtil
    {
        public static BitFloat PI
        {
            get
            {
                return (BitFloat.One * 355) / 113;
            }
        }
        
        public static BitFloat Sqrt(BitFloat number)
        {
            long value = number.value;
            if (value == 0)
            {
                return new BitFloat(0);
            }
            
            long n = (value >> 1) + 1;
            long m = (n + (value / n)) >> 1;
            while (m < n)
            {
                n = m;
                m = (n + (value / n)) >> 1;
            }
            return new BitFloat(n << (BitFloat.BIT / 2));
        }

        public static BitFloat Abs(BitFloat number)
        {
            if (number.value >= 0)
            {
                return new BitFloat(number.value);
            }
            else
            {
                return new BitFloat(-number.value);
            }
        }

        public static BitFloat Floor(BitFloat number)
        {
            return new BitFloat((number.value >> BitFloat.BIT) << BitFloat.BIT);
        }

        public static BitFloat Round(BitFloat number)
        {
            return Floor(number + BitFloat.Half);
        }

        public static BitFloat Ceil(BitFloat number)
        {
            long value = number.value + BitFloat.One.value - 1;
            return new BitFloat((value >> BitFloat.BIT) << BitFloat.BIT);
        }

        public static BitFloat Min(BitFloat a, BitFloat b)
        {
            return a <= b ? a : b;
        }

        public static BitFloat Max(BitFloat a, BitFloat b)
        {
            return a >= b ? a : b;
        }

        public static BitFloat Rad2Deg(BitFloat number)
        {
            return number * 180 / PI;
        }

        public static BitFloat Deg2Rad(BitFloat number)
        {
            return number * PI / 180;
        }
        
        //泰勒公式 sinx=x-x^3/3!+x^5/5!-x^7/7!+x^9/9!
        public static BitFloat Sin(BitFloat angle)
        {
            BitFloat twicePI = PI * 2;
            BitFloat halfPI = PI / 2;
            BitFloat rad = Deg2Rad(angle) % twicePI;
            if (rad < 0)
            {
                rad = rad + twicePI;
            }

            int quadrant = (rad / halfPI).IntValue;
            bool mirror = quadrant == 1 || quadrant == 3;
            bool flip = quadrant == 2 || quadrant == 3;

            rad = rad % halfPI;
            if (mirror)
            {
                rad = halfPI - rad;
            }

            BitFloat square = rad * rad;
            BitFloat cube = square * rad;
            
            BitFloat result = rad - (cube / 6) + (cube * square / 120);
            if (flip)
            {
                result *= -1;
            }
            return result;
        }

        //泰勒公式 cos x = 1-x^2/2!+x^4/4!
        public static BitFloat Cos(BitFloat angle)
        {
            BitFloat twicePI = PI * 2;
            BitFloat halfPI = PI / 2;
            BitFloat rad = Deg2Rad(angle) % twicePI;
            if (rad < 0)
            {
                rad = rad + twicePI;
            }

            int quadrant = (rad / halfPI).IntValue;
            bool mirror = quadrant == 1 || quadrant == 3;
            bool flip = quadrant == 1 || quadrant == 2;

            rad = rad % halfPI;
            if (mirror)
            {
                rad = halfPI - rad;
            }
            
            BitFloat square = rad * rad;
            BitFloat result = BitFloat.One - (square / 2) + (square * square / 24);
            if (flip)
            {
                result *= -1;
            }
            return result;
        }

        public static BitFloat Tan(BitFloat angle)
        {
            return Sin(angle) / Cos(angle);
        }
    }
}