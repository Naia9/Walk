namespace MatrixWalk
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class WalkInMatrix
    {
        static void Main()
        {
            Matrix matrix = new Matrix(6);
            Walk walkInTheMatrix = new Walk(matrix);
            walkInTheMatrix.StartWalk();
        }
    }
}
