namespace MatrixWalk
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Position
    {
        private int rowNumber;
        private int colNumber;

        public int RowNumber
        {
            get
            {
                return this.rowNumber;
            }
            private set
            {
                this.rowNumber = value;
            }
        }

        public int ColNumber
        {
            get
            {
                return this.colNumber;
            }
            private set
            {
                this.colNumber = value;
            }
        }

        public Position(int numberOfRows,int numberOfCols)
        {
            this.rowNumber = numberOfRows;
            this.colNumber = numberOfCols;
        }
    }
}
