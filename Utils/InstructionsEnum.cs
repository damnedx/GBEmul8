using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBEmul8.Utils
{
    class InstructionsEnum
    {
        public enum OPCodeHeaderEnum
        {
            // OP header
            SYS = 0x0,
            JUMP = 0x1,
            CALL = 0x2,
            SE_CONST = 0x3,
            SNE_CONST = 0x4,
            SE_XY = 0x5,
            LD_CONST = 0x6,
            ADD_CONST = 0x7,
            LD_XY = 0x8,
            SNE_XY = 0x9



        }

        public enum OPCodeInstructionsEnum
        {
            CLS = 0x00E0,
            RET = 0x00EE,
        }
    }
}
