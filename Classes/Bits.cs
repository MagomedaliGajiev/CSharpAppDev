using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace Task1
    {
        class Bits
        {

            // Реализуйте операторы явного и неявного приведения из long, int, byte в Bits
            public byte Value { get; private set; } = 0;

            public Bits(byte b)
            {
                this.Value = b;
            }

            public bool this[int index]
            {
                get
                {
                    if (index > 7 || index < 0)
                    {
                        return false;
                    }
                    return ((Value >> index) & 1) == 1;
                }
                set
                {
                    if (index > 7 || index < 0)
                    {
                        return;
                    }
                    if (value == true)
                    {
                        Value = (byte)(Value | (1 << index));
                    }
                    else
                    {
                        var mask = (byte)(1 << index);
                        mask = (byte)(0xff ^ mask);
                        Value &= (byte)(Value & mask);
                    }
                }
            }

            public static explicit operator Bits(long value)
            {
                byte b = (byte)(value & 0xFF);
                return new Bits(b);
            }

            public static explicit operator Bits(int value)
            {
                byte b = (byte)(value & 0xFF);
                return new Bits(b);
            }

            public static explicit operator Bits(byte value)
            {
                return new Bits(value);
            }

            public static implicit operator byte(Bits b) => b.Value;

        }
    }

}
