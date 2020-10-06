using System;
using System.CodeDom;
using System.Reflection;
using System.Text;

namespace hashes
{
	public class GhostsTask : 
		IFactory<Document>, IFactory<Vector>, IFactory<Segment>, IFactory<Cat>, IFactory<Robot>, 
		IMagic
    {
        private static byte[] massiveBytes = {1, 2, 3};
        private static int justANumber = 27;
        private Document document = new Document("firstDoc", Encoding.UTF8, massiveBytes);
        private Vector vector = new Vector(5, 6);
        private Segment segment = new Segment(new Vector(1, 1), new Vector(2, 2));
        private Cat blackCat = new Cat("Flawless", "Black", DateTime.Today);
        private Robot robot = new Robot("5", 59.9);


        /*
         * Для числа justANumber был рандомайзер, но он создает псевдослучайные числа, отсюда возникли коллизии
         * когда два числа были одинаковые (притом часто такое встречалось)
         * Видоизменил на статическое поле с суммированием
         */
        public void DoMagic()
        {
            vector.Add(new Vector(10, 10));
            segment.Start.Add(new Vector(20, 20));
            blackCat.Rename("Kitty");
            Robot.BatteryCapacity = justANumber;
            massiveBytes[2] = Convert.ToByte(justANumber);
            justANumber += 3;
        }
        // Чтобы класс одновременно реализовывал интерфейсы IFactory<A> и IFactory<B> 
		// придется воспользоваться так называемой явной реализацией интерфейса.
		// Чтобы отличать методы создания A и B у каждого метода Create нужно явно указать, к какому интерфейсу он относится.
		// На самом деле такое вы уже видели, когда реализовывали IEnumerable<T>.

		Document IFactory<Document>.Create()
        {
            return document;
        }

		Vector IFactory<Vector>.Create()
        {
            return vector;
        }

        Segment IFactory<Segment>.Create()
        {
            return segment;
        }

        Cat IFactory<Cat>.Create()
        {
            return blackCat;
        }

        Robot IFactory<Robot>.Create()
        {
            return robot;
        }
    }
}