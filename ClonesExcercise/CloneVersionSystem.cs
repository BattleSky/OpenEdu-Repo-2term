using System;
using System.Collections.Generic;

namespace Clones
{
    public class CloneVersionSystem : ICloneVersionSystem
    {
        private readonly List<Droid> Clones = new List<Droid>
        {
            new Droid
            {
                CurrentProgram = "basic",
                ProgramToRelearn = new ProgrammStack<string>(),
                ProgramToRollback = new ProgrammStack<string>()
            }
        };

        public string Execute(string query)
        {
            //log.Append("\""+query+"\", ");
            var splitQuery = query.Split(' ');
            // ужасно с точки зрения ошибок,
            // но условия задачи уверяют, что все команды корректны
            var clone = FindCloneByIndex(splitQuery[1]);
            switch (splitQuery[0])
            {
                case "learn":
                    Learn(clone, splitQuery[2]);
                    break;
                case "rollback":
                    Rollback(clone);
                    break;
                case "relearn":
                    Relearn(clone);
                    break;
                case "clone":
                    Clone(clone);
                    break;
                case "check":
                    //  log.Append("Check \n\n");
                    return Check(clone);
            }

            return null;
        }

        private Droid FindCloneByIndex(string index)
        {
            var clone = Clones[Convert.ToInt32(index) - 1];
            //log.Append("Clone " + index + "(sum:" + Clones.Count + " counter:" + Clones.Count + ")" + ":\n");
            return clone;
        }

        private void Learn(Droid clone, string program)
        {
            clone.ProgramToRollback.Push(clone.CurrentProgram);
            //log.Append("Learn from " + clone.CurrentProgram + " to " + program+"\n");
            clone.CurrentProgram = program;
            clone.ProgramToRelearn.Clear();
            //log.Append("Current: " + clone.CurrentProgram + " ProgramToRelearn: " + clone.ProgramToRelearn.Peek() + " ProgramToRollback: " +
            //clone.ProgramToRollback.Peek() + "\n\n");
        }

        private void Rollback(Droid clone)
        {
            //log.Append("* Rollback from " + clone.CurrentProgram + " to " + clone.ProgramToRollback.Peek() + "\n");
            clone.ProgramToRelearn.Push(clone.CurrentProgram);
            clone.CurrentProgram = clone.ProgramToRollback.Pop();
            //log.Append("* Current: " + clone.CurrentProgram + " ProgramToRelearn: " + clone.ProgramToRelearn.Peek() + " ProgramToRollback: " +
            //clone.ProgramToRollback.Peek() + "\n\n");
        }

        private void Relearn(Droid clone)
        {
            //log.Append("** Relearn from " + clone.CurrentProgram + " to " + clone.ProgramToRelearn.Peek() + "\n");
            clone.ProgramToRollback.Push(clone.CurrentProgram);
            clone.CurrentProgram = clone.ProgramToRelearn.Pop();
            //log.Append("** Current: " + clone.CurrentProgram + " ProgramToRelearn: " + clone.ProgramToRelearn.Peek() + " ProgramToRollback: " +
            //           clone.ProgramToRollback.Peek() + "\n\n");
        }

        private void Clone(Droid oldClone)
        {
            //Не ковертируй стринг в инт без проверки . . . . .
            //но тут можно потому что все команды корректны по условию задачи
            //ВСЕДОЗВОЛЕННОСТЬ, АНАРХИЯ, МУХАХАХАХАХА
            var newClone = new Droid
            {
                CurrentProgram = oldClone.CurrentProgram,
                ProgramToRelearn = new ProgrammStack<string>
                    {Last = oldClone.ProgramToRelearn.Last, count = oldClone.ProgramToRelearn.count},
                ProgramToRollback = new ProgrammStack<string>
                    {Last = oldClone.ProgramToRollback.Last, count = oldClone.ProgramToRollback.count}
            };
            //log.Append("*** Clone\n*** old: Current: " + oldClone.CurrentProgram + " ProgramToRelearn: " +oldClone.ProgramToRelearn.Peek() + " ProgramToRollback: " +
            //           oldClone.ProgramToRollback.Peek() + "\n" + "*** new "+ Clones.Count + ": Current: " + newClone.CurrentProgram + " ProgramToRelearn: " + newClone.ProgramToRelearn.Peek() + " ProgramToRollback: " +
            //           newClone.ProgramToRollback.Peek() + "\n\n");
            Clones.Add(newClone);
        }

        private string Check(Droid clone)
        {
            return clone.CurrentProgram;
        }

        //   public static StringBuilder log = new StringBuilder();
        // Элемент хранит значение и ссылку на предыдущий
        // Реализация односвязного списка
        public class Programms<T>
        {
            public Programms<T> PreviousNode { get; set; }
            public T Value { get; set; }
        }


        // Стэк хранит значения последнего и размер себя;
        public class ProgrammStack<T>
        {
            public int count;

            public Programms<T> Last;
            // Last - последний в стеке, первый на выход
            // [[stack]] : [1] <- [2] <- [3]  <= push

            public T Pop()
            {
                var result = Last;
                if (result == null)
                    throw new InvalidOperationException("Last is null with counter=" + count + " log: \n");
                Last = result.PreviousNode;
                count--;
                return result.Value;
            }

            public T Peek()
            {
                try
                {
                    var result = Last;
                    if (result == null)
                        return default;
                }
                catch
                {
                    return default;
                }

                return Last.Value;
            }

            public void Push(T item)
            {
                if (Last == null) //очередь пуста, значит последний -  null
                {
                    Last = new Programms<T> {Value = item};
                }
                else
                {
                    var newItem = new Programms<T> {Value = item, PreviousNode = Last};
                    Last = newItem;
                }

                count++;
                // последний используется, чтобы положить в стек новый элемент
                // и сначала сослаться на старый, а потом переприсвоить first как новый
            }

            // в этом случае Last обнуляет ссылку на последний элемент
            // получается, что ничто не указывает на элементы в стеке
            // сборщик мусора их увезет
            public void Clear()
            {
                Last = null;
                count = 0;
            }
        }

        public class Droid
        {
            public string CurrentProgram;
            public ProgrammStack<string> ProgramToRelearn;
            public ProgrammStack<string> ProgramToRollback;
        }
    }
}