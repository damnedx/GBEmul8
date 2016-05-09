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
        private Stack<ushort> _SP;

        public Chip8()
        {
            _V = new byte[Constantes.SIZE_V_REGISTERS];
            _memory = new byte[Constantes.SIZE_RAM_MEMORY];

            // le PC doit demarre a l'instruction 0x200
            _PC = Constantes.OFFSET_PC;

            _SP = new Stack<ushort>();
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
            while (_PC < _memory.Length)
            {
                // Fetch
                ushort _opcode = (ushort)((_memory[_PC] << 8) + _memory[_PC + 1]);        
                // Decode 
                byte _code = (byte)((_opcode & 0xF000) >> 12);
                ushort _NNN = (ushort)(_opcode & 0x0FFF);
                byte _KK = (byte)(_opcode & 0x00FF);
                byte _X = (byte)((_opcode & 0x0F00) >> 8);
                byte _Y = (byte)((_opcode & 0x00F0) >> 4);
                byte _K = (byte)(_opcode & 0x000F);
                _PC += 2;
                SystInstructions instr = new SystInstructions(_opcode);
                // Execute
                switch(_code)
                {           
                    case (byte)InstructionsEnum.OPCodeHeaderEnum.SYS:
                        instr.executeSyst(ref _PC, ref _SP);
                        break;
                    case (byte)InstructionsEnum.OPCodeHeaderEnum.JUMP:
                        instr.JUMPTO(_NNN, ref _PC);
                        break;
                    case (byte)InstructionsEnum.OPCodeHeaderEnum.CALL:
                        instr.CALL(_NNN, ref _PC, ref _SP);
                        break;
                    case (byte)InstructionsEnum.OPCodeHeaderEnum.SE_CONST:
                        instr.SE(_V[_X], _KK, ref _PC);
                        break;
                    case (byte)InstructionsEnum.OPCodeHeaderEnum.SNE_CONST:
                        instr.SNE(_V[_X], _KK, ref _PC);
                        break;
                    case (byte)InstructionsEnum.OPCodeHeaderEnum.SE_XY:
                        instr.SE_XY(_V[_X], _V[_Y], ref _PC);
                        break;
                    case (byte)InstructionsEnum.OPCodeHeaderEnum.LD_CONST:
                        instr.LD_CONST(ref _V[_X], _KK);
                        break;
                    case (byte)InstructionsEnum.OPCodeHeaderEnum.ADD_CONST:
                        instr.ADD_CONST(ref _V[_X], _KK);
                        break;
                    case (byte)InstructionsEnum.OPCodeHeaderEnum.LD_XY:
                        switch(_K)
                        {                          
                            case 0x1:
                                instr.OR(ref _V[_X], ref _V[_Y]);
                                break;
                            case 0x2:                             
                                instr.AND(ref _V[_X], ref _V[_Y]);
                                break;
                            case 0x3:
                                instr.XOR(ref _V[_X], ref _V[_Y]);
                                break;
                            case 0x4:
                                instr.ADD_XY(ref _V[_X], ref _V[_Y], ref _V[0xF]);
                                break;
                            case 0x5:
                                instr.SUB_XY(ref _V[_X], ref _V[_Y], ref _V[0xF]);
                                break;
                            case 0x6:
                                instr.SHR(ref _V[_X], ref _V[0xF]);
                                break;
                            case 0x7:
                                instr.SUB_N(ref _V[_X], ref _V[_Y], ref _V[0xF]);
                                break;
                            case 0xE:
                                instr.SHL(ref _V[_X], ref _V[0xF]);
                                break;

                        }               
                        break;
                    case (byte)InstructionsEnum.OPCodeHeaderEnum.SNE_XY:
                        instr.SNE_XY(_V[_X], _V[_Y], ref _PC);
                        break;
                    case (byte)InstructionsEnum.OPCodeHeaderEnum.LD_ADDR:
                        instr.LD_ADDR(ref _I, ref _NNN);
                        break;
                    case (byte)InstructionsEnum.OPCodeHeaderEnum.JUMP_ADDR:
                        instr.JUMP_ADDR(ref _V[0x0],ref  _NNN, ref _PC);
                        break;
                    case (byte)InstructionsEnum.OPCodeHeaderEnum.RND:
                        instr.RND(ref _V[_X], ref _KK);
                        break;
                    case (byte)InstructionsEnum.OPCodeHeaderEnum.DRAW:
                        
                        break;
                    case (byte)InstructionsEnum.OPCodeHeaderEnum.SKIP:
                        
                        break;
                    
                }

            
                // Update
                Console.WriteLine(_PC.ToString());
                
            }
        }
        // GETTERS
        public byte[] V() { return _V;  }

        public byte[] memory() { return _memory; }

        public ushort I() { return _I; }

        public ushort PC() { return _PC; }

        public Stack<ushort> SP() { return _SP; }

  

        


    }
}
