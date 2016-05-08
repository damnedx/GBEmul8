using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GBEmul8.Utils;
namespace GBEmul8.Chip8
{
    class Chip8 : IChip8
    {
        private byte[] _V;
        private byte[] _memory;
        private ushort _PC;
        private ushort _I;
        private ushort _SP;

        public Chip8()
        {
            _V = new byte[Constantes.SIZE_V_REGISTERS];
            _memory = new byte[Constantes.SIZE_RAM_MEMORY];

            // le PC doit demarre a l'instruction 0x200
            _PC = Constantes.OFFSET_PC;
        }

        /*
         * mémoire utilisable de 0x200 à 0xFFF
         */
        public bool LoadRom(byte[] rom)
        {
            bool romLoaded = true;
            for (int i = 0; i < rom.Length && romLoaded; i++)
            {
                if ((i + _PC) > 0xFFF)
                    romLoaded = false;
                else
                    _memory[i + _PC] = rom[i];
            }
            return romLoaded;
        }


        // GETTERS
        public byte[] V() { return _V;  }

        public byte[] memory() { return _memory; }

        public ushort I() { return _I; }

        public ushort PC() { return _PC; }

        public ushort SP() { return _SP; }

        


    }
}
