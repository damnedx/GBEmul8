using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBEmul8.Instructions
{
    interface IInstructions
    {
        // Retour de fonction
        void ret(ref ushort _PC, ref Stack<ushort> SP);

        // Saute a l'addresse N
        void JUMPTO(ushort N, ref ushort PC);
        
        // appel l'instruction a l'addresse N
        void CALL(ushort N, ref ushort PC, ref Stack<ushort> SP);


        // ARITHMETIQUE

        // Test si V == Const
        void SE(byte V, byte Const, ref ushort PC);

        // Test si V != Const
        void SNE(byte V, byte Const, ref ushort PC);

        // Test si V == Y
        void SE_XY(byte V, byte Y, ref ushort PC);

        // Affecte KK à V
        void LD_CONST(ref byte V, byte Const);

        // Affecte V = V + KK
        void ADD_CONST(ref byte V, byte Const);

        // V = Y
        void LD_XY(ref byte V, ref byte Y);

        // V = V OR Y
        void OR(ref byte V, ref byte Y);

        // V = V & Y
        void AND(ref byte V, ref byte Y);

        // V = V ^ Y
        void XOR(ref byte V, ref byte Y);

        void ADD_XY(ref byte V, ref byte Y, ref byte F);

        void SUB_XY(ref byte V, ref byte Y, ref byte F);

        void SHR(ref byte V, ref byte F);

        void SUB_N(ref byte V, ref byte Y, ref byte F);

        void LD_ADDR(ref ushort I, ref ushort N);

        void JUMP_ADDR(ref byte V, ref ushort N, ref ushort PC);

        void RND(ref byte V, ref byte Const);



    }
}
