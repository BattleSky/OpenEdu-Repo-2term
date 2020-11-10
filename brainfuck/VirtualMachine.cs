using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace func.brainfuck
{
    public class VirtualMachine : IVirtualMachine
	{
        private Action<IVirtualMachine> _execute;
        private Dictionary<char, Action<IVirtualMachine>> Commands { get; set; }

        public delegate Action<IVirtualMachine> TheExecution();

        public VirtualMachine(string program, int memorySize)
        {
            MemoryPointer = 0;
            InstructionPointer = 0;
            Instructions = program;
            Memory = new byte[memorySize];
        }

        public void RegisterCommand(char symbol, Action<IVirtualMachine> execute)
        {

            Commands.Add(symbol, execute);
        }

        public static void MakeThisExecution(IVirtualMachine someVirtualMachine)
        {

        }


		public string Instructions { get; }
		public int InstructionPointer { get; set; }
		public byte[] Memory { get; }
		public int MemoryPointer { get; set; }
		public void Run()
		{
            for (int i = 0; i < Instructions.Length; i++)
            {
                if (Commands.ContainsKey(Instructions[i]))
                {
                    Commands[Instructions[i]](this);
                }
            }
		}
	}
}