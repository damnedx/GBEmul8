using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GBEmul8.Utils
{
    class InstructionsEnum
    {
        public enum OPCodeEnum
        {
            SYS = 0x0,
            CLS = 0x00E0,
            RET = 0x00EE,
            JUMP = 0x1,
            CALL = 0x2,
            SE_KK = 0x3,
            SNE = 0x4,
            SE_XY = 0x5,
            LD_KK = 0x6,
            ADD_KK = 0x7,
            LD_XY = 0x8


        }
    }
}
