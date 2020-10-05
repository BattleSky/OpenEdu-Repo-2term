using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace hashes
{
    public class ReadonlyBytes : IEnumerable<byte>
    {
        private byte[] Query { get; }
        public int Length { get; }
        private int Hash { get; }

        // конструктор
        public ReadonlyBytes(params byte[] query) 
        {
            /*  Следующая строка это аналог вот этого. Учись делать так!!
             *  if (Query == null)
             *  throw new ArgumentNullException();
             *  this.Query = Query;
             */
            Query = query ?? throw new ArgumentNullException();
            Length = query.Length;
            Hash = CalculateHash();
        }
        public byte this[int index]
        {
            get
            {
                if (index < 0 || index >= Length) throw new IndexOutOfRangeException();
                return Query[index];
            }
        }

        public IEnumerator<byte> GetEnumerator()
        {
            foreach (var b in Query) yield return b;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override int GetHashCode()
        {
            return Hash;
        }

        private int CalculateHash()
        {
            var hashValue = 1;
            // создаем простое число 
            // (это то, которое делится только на себя и на 1)
            // https://ru.wikipedia.org/wiki/%D0%A1%D0%BF%D0%B8%D1%81%D0%BE%D0%BA_%D0%BF%D1%80%D0%BE%D1%81%D1%82%D1%8B%D1%85_%D1%87%D0%B8%D1%81%D0%B5%D0%BB
            const int simpleNumber = 2357;

            unchecked
            {
                foreach (var elem in Query)
                {
                    hashValue *= simpleNumber;
                    hashValue ^= elem.GetHashCode();
                }

                return hashValue;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj.GetType() == typeof(ReadonlyBytes)) )
                return false;
            /*
             * С помощью AS программа пытается преобразовать выражение к определенному
             * типу, при этом не выбрасывает исключение.
             * В случае неудачного преобразования выражение будет содержать значение null
             */
            var array = obj as ReadonlyBytes;
            return array.GetHashCode() == Hash;
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append("[");
            for (var i = 0; i < Query.Length; i++)
            {
                result.Append(Query[i]);
                if (!(Query.Length <= 1 || i == Query.Length - 1))
                    // условие при котором не должен добавляться разрыв между элементами
                    result.Append(", ");
            }
            result.Append("]");
            return result.ToString();
        }
    }
}