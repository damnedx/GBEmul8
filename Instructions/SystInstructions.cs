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
        private Random _rnd = new Random();
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
        public void JUMPTO(ushort N, ref ushort PC)
        {
            PC = N;
        }

        public void CALL(ushort N, ref ushort PC, ref Stack<ushort> SP)
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

        public void ADD_CONST(ref byte V, byte Const)
        {
            V += Const;
        }

        public void LD_XY(ref byte V, ref byte Y)
        {
            V = Y;
        }

        public void OR(ref byte V, ref byte Y)
        {
            V |= Y;
        }
        public void AND(ref byte V, ref byte Y)
        {
            V &= Y;
        }
        public void XOR(ref byte V, ref byte Y)
        {
            V ^= Y;
        }

        public void ADD_XY(ref byte V, ref byte Y, ref byte F)
        {
            int tmp = V + Y;
            if (tmp > 0xFF)
                F = 0x1;
            else
                F = 0x0;
            V = (byte)(tmp % 0xFF);
        }

        public void SUB_XY(ref byte V, ref byte Y, ref byte F)
        {
            if (V > Y)
                F = 0x1;
            else
                F = 0x0;
            V -= Y;
        }
        public void SHR(ref byte V, ref byte F)
        {
            F = (byte)(V & 0x1);
            V >>= 1;
        }

        public void SUB_N(ref byte V, ref byte Y, ref byte F)
        {
            if (Y > V)
                F = 0x1;
            else
                F = 0x0;
            V = (byte)(Y - V);
        }

        public void SHL(ref byte V, ref byte F)
        {
            F = (byte)(V >> 7);
            V <<= 1;
          
        }

        public void SNE_XY(byte V, byte Y, ref ushort PC)
        {
            if (V != Y)
                PC += 2; // on passe a l'instruction suivante
        }
        public void LD_ADDR(ref ushort I, ref ushort N)
        {
            I = N;
        }

        public void JUMP_ADDR(ref byte V, ref ushort N, ref ushort PC)
        {
            PC = (ushort)(V + N);
        }
        public void RND(ref byte V, ref byte Const)
        {
            V = (byte)(_rnd.Next(0, 256) & Const);
        }
    }
}
