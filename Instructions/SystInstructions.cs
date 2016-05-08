using GBEmul8.Instructions;
using GBEmul8.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GBEmul8.Chip8
{

    class SystInstructions : IInstructions
    {
        ushort _opcode;
        public SystInstructions(ushort opcode)
        {
            this._opcode = opcode;
        }

        // Instructions liées au système "interne"
        public void executeSyst(ref ushort _PC, ref Stack<ushort> SP)
        {
            if(_opcode == (ushort)InstructionsEnum.OPCodeInstructionsEnum.CLS)
            {
                // Clear the Display
 
            }
            else if(_opcode == (ushort)InstructionsEnum.OPCodeInstructionsEnum.RET)
            {
                ret(ref _PC, ref SP);           
            }
        }
        public void ret(ref ushort _PC, ref Stack<ushort> SP)
        {
            _PC = SP.Pop();
        }
        public void Jump_Address(ushort N, ref ushort PC)
        {
            PC = N;
        }

        public void Call(ushort N, ref ushort PC, ref Stack<ushort> SP)
        {
            // On enregistre l'instruction actuelle dans la pile
            SP.Push(PC);

            // on se place à l'instruction N
            PC = N;
        }
        public void SE(byte V, byte Const, ref ushort PC)
        {
            if(V == Const)
                PC +=2; // on passe a l'instruction suivante
        }

        public void SNE(byte V, byte Const, ref ushort PC)
        {
            if (V != Const)
                PC += 2; // on passe a l'instruction suivante
        }

        public void SE_XY(byte V, byte Y, ref ushort PC)
        {
            if (V == Y)
                PC += 2;
        }

        public void LD_CONST(ref byte V, byte Const)
        {
            V = Const;
        }
    }
}
