using System;
using System.Collections.Generic;

namespace func.brainfuck
{
	public class VirtualMachine : IVirtualMachine
	{
		public VirtualMachine(string program, int memorySize)
        {
            MemoryPointer = 0;    
            InstructionPointer = 0;
            Instructions = program;
            Memory = new byte[memorySize];
        }

		public void RegisterCommand(char symbol, Action<IVirtualMachine> execute)
		{
			
		}

		public string Instructions { get; }
		public int InstructionPointer { get; set; }
		public byte[] Memory { get; }
		public int MemoryPointer { get; set; }
		public void Run()
		{
			throw new NotImplementedException();
		}
	}
}