using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Interfaces;

namespace hashes
{
    public class ReadonlyBytes : IEnumerable<byte>
    {
        public byte[] query;
        
        // конструктор
        public ReadonlyBytes(params byte[] query)
        {
            this.query = query;
        }

        public IEnumerator<byte> GetEnumerator()
        {
            foreach (var b in query)
            {
                yield return b;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public int Length(params byte[] query)
        {
            var count = 0;
            foreach (byte b in query)
            {
                count++;
            }

            return count;
        }
    }
}