using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace func.brainfuck
{
    public class VirtualMachine : IVirtualMachine
	{
        private Dictionary<char, Action<IVirtualMachine>> Commands;

        public VirtualMachine(string program, int memorySize)
        {
            MemoryPointer = 0;
            InstructionPointer = 0;
            Instructions = program;
            Memory = new byte[memorySize];
            Commands = new Dictionary<char, Action<IVirtualMachine>>();
        }

        public void RegisterCommand(char symbol, Action<IVirtualMachine> execute)
        {
            Commands.Add(symbol, execute);
        }


        public string Instructions { get; }
		public int InstructionPointer { get; set; }
		public byte[] Memory { get; }
		public int MemoryPointer { get; set; }
		public void Run()
        {
            for (; InstructionPointer < Instructions.Length; InstructionPointer++)
            {
                var command = Instructions[InstructionPointer];
                if (Commands.ContainsKey(command))
                    Commands[command](this);
            }
        }
	}
}