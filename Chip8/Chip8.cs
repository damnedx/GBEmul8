using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GBEmul8.Utils;
using System.Windows.Forms;
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
            bool _romLoaded = true;
            for (int i = 0; i < rom.Length && _romLoaded; i++)
            {
                if ((i + _PC) > 0xFFF)
                    _romLoaded = false;
                else
                    _memory[i + _PC] = rom[i];
            }
            return _romLoaded;
        }

        public void Start()
        {
            bool end = false;
            while (!end)
            {
                // Fetch
                ushort opcode = (ushort)((_memory[_PC] << 8) + _memory[_PC + 1]);        
                // Decode 
                byte _code = (byte)((opcode & 0xF000) >> 12);
                ushort _NNN = (ushort)(opcode & 0x0FFF);
                byte _KK = (byte)(opcode & 0x00FF);
                byte _X = (byte)((opcode & 0x0F00) >> 8);
                byte _Y = (byte)((opcode & 0x00F0) >> 4);              
                _PC += 2;
                // Execute
                switch(_code)
                {


                }


                // Update

                // on passe a l'instruction suivante
                
            }
        }
        // GETTERS
        public byte[] V() { return _V;  }

        public byte[] memory() { return _memory; }

        public ushort I() { return _I; }

        public ushort PC() { return _PC; }

        public ushort SP() { return _SP; }

        


    }
}
