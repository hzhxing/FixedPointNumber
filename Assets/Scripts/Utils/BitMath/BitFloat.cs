namespace Utils.BitMath
{
    public struct BitFloat
    {
        public long value;

        public BitFloat(long value)
        {
            this.value = value;
        }

        public int IntValue
        {
            get {return (int)(value >> BIT); }
        }

        public float FloatValue
        {
            get { return (float) ((double) value / (double) One.value); }
        }
        
        public override bool Equals(object obj)
        {
            if (obj is BitFloat)
            {
                return this == (BitFloat)obj;
            }
            else if (obj is int)
            {
                return this == (int) obj;
            }
            
            return false;
        }

        public override int GetHashCode()
        {
            return (int)value;
        }
        
        
        public static int BIT = 10;

        public static BitFloat Zero
        {
            get {return new BitFloat(0);}
        }
        
        public static BitFloat One
        {
            get {return new BitFloat(1 << BIT);}
        }

        public static BitFloat Half
        {
            get {return new BitFloat(1 << (BIT - 1));}
        }
        
        public static BitFloat Create(int value)
        {
            return new BitFloat((long)value << BIT);
        }

        public static BitFloat Create(float value)
        {
            return new BitFloat((long)(One.value * (double)value));
        }

        public static BitFloat operator +(BitFloat a,BitFloat b)
        {
            return new BitFloat(a.value + b.value);
        }
        
        public static BitFloat operator +(BitFloat a,int b)
        {
            return new BitFloat(a.value + b << BIT);
        }
        
        public static BitFloat operator -(BitFloat a,BitFloat b)
        {
            return new BitFloat(a.value - b.value);
        }
        
        public static BitFloat operator -(BitFloat a,int b)
        {
            return new BitFloat(a.value - b << BIT);
        }
        
        public static BitFloat operator *(BitFloat a,BitFloat b)
        {
            return new BitFloat((a.value * b.value) >> BIT);
        }
        
        public static BitFloat operator *(BitFloat a,int b)
        {
            return new BitFloat(a.value * b);
        }
        
        public static BitFloat operator /(BitFloat a,BitFloat b)
        {
            return new BitFloat((a.value << BIT) / b.value);
        }
        
        public static BitFloat operator /(BitFloat a,int b)
        {
            return new BitFloat(a.value / b);
        }
        
        public static BitFloat operator %(BitFloat a,BitFloat b)
        {
            return new BitFloat(a.value % b.value);
        }
        
        public static BitFloat operator %(BitFloat a,int b)
        {
            return new BitFloat(a.value % (b << BIT));
        }
        
        public static bool operator ==(BitFloat a,BitFloat b)
        {
            return a.value == b.value;
        }
        
        public static bool operator ==(BitFloat a,int b)
        {
            return a.value == (b << BIT);
        }
        
        public static bool operator !=(BitFloat a,BitFloat b)
        {
            return a.value != b.value;
        }
        
        public static bool operator !=(BitFloat a,int b)
        {
            return a.value != (b << BIT);
        }
        
        public static bool operator >(BitFloat a,BitFloat b)
        {
            return a.value > b.value;
        }
        
        public static bool operator >(BitFloat a,int b)
        {
            return a.value > (b << BIT);
        }
        
        public static bool operator >=(BitFloat a,BitFloat b)
        {
            return a.value >= b.value;
        }
        
        public static bool operator >=(BitFloat a,int b)
        {
            return a.value >= (b << BIT);
        }
        
        public static bool operator <(BitFloat a,BitFloat b)
        {
            return a.value < b.value;
        }
        
        public static bool operator <(BitFloat a,int b)
        {
            return a.value < (b << BIT);
        }
        
        public static bool operator <=(BitFloat a,BitFloat b)
        {
            return a.value <= b.value;
        }
        
        public static bool operator <=(BitFloat a,int b)
        {
            return a.value <= (b << BIT);
        }
    }
}