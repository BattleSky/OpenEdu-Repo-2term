using System;
using System.Collections.Generic;

namespace Clones
{
	public class CloneVersionSystem : ICloneVersionSystem
    {

        public class CloneClass
        {
            public string Index;
            public string CurrentProgram;
            public LinkedList<string> ProgramToRollback;
            public LinkedList<string> ProgramToRelearn;
        }

        private List<CloneClass> Clones = new List<CloneClass>() 
        {new CloneClass() 
            {
                Index = "1", 
                CurrentProgram = "basic", 
                ProgramToRelearn = new LinkedList<string>(), 
                ProgramToRollback = new LinkedList<string>()
            }
        };

        public string Execute(string query)
        {
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
                    return Check(clone);
            }
            return null;
        }
        
        private CloneClass FindCloneByIndex(string index)
        {
            var clone = Clones[Convert.ToInt32(index) - 1];
            return clone;
        }

        private void Learn(CloneClass clone, string program)
        {
            clone.ProgramToRollback.AddLast(clone.CurrentProgram);
            clone.CurrentProgram = program;
            clone.ProgramToRelearn.Clear();;
        }
        private void Rollback(CloneClass clone)
        {
            clone.ProgramToRelearn.AddLast(clone.CurrentProgram);
            clone.CurrentProgram = clone.ProgramToRollback.Last.Value;
            clone.ProgramToRollback.RemoveLast();
        }
        private void Relearn(CloneClass clone)
        {
            clone.CurrentProgram = clone.ProgramToRelearn.Last.Value;
        }
        private void Clone(CloneClass oldClone)
        {
            //Не ковертируй стринг в инт без проверки . . . . .
            //но тут можно потому что все команды корректны по условию задачи
            //ВСЕДОЗВОЛЕННОСТЬ, АНАРХИЯ, МУХАХАХАХАХА
            var newIndex = Convert.ToInt32(Clones.Count) + 1;
            var newClone = new CloneClass()
            {
                Index = newIndex.ToString(),
                CurrentProgram = oldClone.CurrentProgram,
                ProgramToRelearn = new LinkedList<string>(),
                ProgramToRollback = new LinkedList<string>()
            };
            if (oldClone.ProgramToRelearn.First != null)
                newClone.ProgramToRelearn.AddFirst(oldClone.ProgramToRelearn.First);
            if (oldClone.ProgramToRollback.First != null)
                newClone.ProgramToRollback.AddFirst(oldClone.ProgramToRollback.First);
            Clones.Add(newClone);
        }
        private string Check(CloneClass clone)
        {
            return clone.CurrentProgram;
        }
    }
}
