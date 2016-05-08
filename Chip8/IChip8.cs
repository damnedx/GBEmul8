using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBEmul8.Chip8
{
    // Corp du CPU Chip8
    interface IChip8
    {
        // registres
        byte[] V();
        // registre pour les instructions
        ushort I();

        // mémoire 
        byte[] memory();

        // Program Counter
        ushort PC();

        // Stack Pointer
        Stack<ushort> SP();

        // Charge la ROM en mémoire
        bool LoadRom(byte[] rom);

        // Execution de la ROM
        void Start();
        

    }
}
