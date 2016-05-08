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
        void Jump_Address(ushort N, ref ushort PC);
        
        // appel l'instruction a l'addresse N
        void Call(ushort N, ref ushort PC, ref Stack<ushort> SP);

        // Test si V == Const
        void SE(byte V, byte Const, ref ushort PC);

        // Test si V != Const
        void SNE(byte V, byte Const, ref ushort PC);

        // Test si V == Y
        void SE_XY(byte V, byte Y, ref ushort PC);

        // Affecte KK à V
        void LD_CONST(ref byte V, byte Const);

    }
}
