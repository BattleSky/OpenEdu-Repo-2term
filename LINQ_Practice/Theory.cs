using System;
using System.Collections.Generic;

namespace LINQ_Practice
{
    class Theory
    {
        #region Кусочек теории
        /*
        public IEnumerable<int> GetNewLetterIds()
        {
            return letters
                .Where(l => l.IsNew) // Оставили только новые письма
                .Select(l => l.Id);  // Каждое оставшееся письмо превратили в его идентификатор
        }

        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        IEnumerable<int> even = numbers.Where(x => x % 2 == 0); // 2, 4,6, 8
        IEnumerable<int> squares = even.Select(x => x * x); // 4, 16, 36, 64
        IEnumerable<int> squaresWithoutOne = squares.Skip(1); // 16, 36, 64 - пропустить один сначала
        IEnumerable<int> secondAndThirdSquares = squaresWithoutOne.Take(2); // 16, 36 - взять два и отбросить остальное
        int[] result = secondAndThirdSquares.ToArray();

        // `Assert.That` — это метод библиотеки NUnit. Он проверяет истинность некоторого условия. 
        // В данном случае, что result — это массив из двух элементов 16 и 36.
        Assert.That(result, Is.EqualTo(new[] { 16, 36 }));

        // Или так:
        Assert.That(
	    new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }
		    .Where(x => x % 2 == 0)
		    .Select(x => x * x)
		    .Skip(1)
		    .Take(2)
		    .ToArray(),
	    Is.EqualTo(new[] { 16, 36 }));

        // SelectMany:

        В качестве аргумента он принимает функцию, 
        преобразующую каждый элемент исходной последовательности 
        в новую последовательность. 
        А результатом работы является конкатенация 
        всех полученных последовательностей.

        string[] words = {"ab", "", "c", "de"};
        IEnumerable<char> letters = words.SelectMany(w => w.ToCharArray());
        Assert.That(letters, Is.EqualTo(new[] {'a', 'b', 'c', 'd', 'e'}));

        string[] words = {"ab", "", "c", "de"};
        var letters = words.SelectMany(w => w); // <= исчез вызов ToCharArray
        Assert.That(letters, Is.EqualTo(new[] {'a', 'b', 'c', 'd', 'e'}));
        */

        /*
         * Для сортировки последовательности в LINQ имеется четыре метода:
           
           
           IOrderedEnumerable<T> OrderBy<T>(this IEnumerable<T> items, Func<T, K> keySelector)           
           IOrderedEnumerable<T> OrderByDescending<T>(this IEnumerable<T> items, Func<T, K> keySelector)           
           IOrderedEnumerable<T> ThenBy<T>(this IOrderedEnumerable<T> items, Func<T, K> keySelector)           
           IOrderedEnumerable<T> ThenByDescending<T>(this IOrderedEnumerable<T> items, Func<T, K> keySelector)

           Первые два дают на выходе последовательность, упорядоченную по возрастанию/убыванию ключей. А keySelector — это как раз функция, которая каждому элементу последовательности ставит в соответствие некоторый ключ, по которому его будут сравнивать при сортировке.
           
           
           var names = new[] { "Pavel", "Alexander", "Anna" };           
           IOrderedEnumerable<string> sorted = names.OrderBy(n => n.Length);           
           Assert.That(sorted, Is.EqualTo(new[] { "Anna", "Pavel", "Alexander" }));

           Если при равенстве ключей вы хотите отсортировать элементы по другому критерию, на помощь приходит метод ThenBy.
           
           Например, в следующем примере все имена сортируются по убыванию длин, а при равных длинах — лексикографически.
           
           
           var names = new[] { "Pavel", "Alexander", "Irina" };
           var sorted = names
                      .OrderByDescending(name => name.Length)           
                      .ThenBy(n => n);
           Assert.That(sorted, Is.EqualTo(new[] { "Alexander", "Irina", "Pavel" }).AsCollection);

           Чтобы убрать из последовательности все повторяющиеся элементы, можно воспользоваться функцией Distinct.
           
           var numbers = new[] { 1, 2, 3, 3, 1, 1, };
           var uniqueNumbers = numbers.Distinct();
           Assert.That(uniqueNumbers.Count(), Is.EqualTo(3));
         */

        #endregion

    }
}
