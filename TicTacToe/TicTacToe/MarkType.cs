using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public enum MarkType
    {
        /// <summary>
        /// The cell hasn´t been clicked yet
        /// </summary>
        Free,
        /// <summary>
        /// The cell is O
        /// </summary>
        Nought,
        /// <summary>
        /// The cell is X
        /// </summary>
        Cross
    }
}
