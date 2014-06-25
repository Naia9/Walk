namespace MatrixWalk
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Matrix
    {
        private int[,] matrixValues;
        private int rowCount;
        private int colCount;

        public int[,] MatrixValues
        {
            get
            {
                int[,] copyOfValues = MakeDeepCopyOfValues(this.matrixValues);

                return copyOfValues;
            }
            private set
            {
                this.matrixValues = value;
            }
        }

        public int RowCount
        {
            get
            {
                return this.rowCount;
            }
            private set
            {
                if (value<=0)
                {
                    throw new ArgumentException(String.Format("Invalid size of matrix - {0}. It must be positive.",value));
                }
                this.rowCount = value;
            }
        }

        public int ColCount
        {
            get
            {
                return this.colCount;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(String.Format("Invalid size of matrix - {0}. It must be positive.", value));
                }
                this.colCount = value;
            }
        }

        public Matrix(int countOfRows)
        {
            this.RowCount = countOfRows;
            this.ColCount = countOfRows;
            this.MatrixValues = new int[countOfRows, countOfRows];
        }

        public void UpdateSeparateValue(Position currentPosition, int currentValue)
        {
            int currentRow;
            int currentCol;

            try
            {
                currentRow = currentPosition.RowNumber;
                currentCol = currentPosition.ColNumber;
            }
            catch (NullReferenceException)
            {

                throw new ArgumentException("The position to set a value to is null.");
            }


            if (currentRow < 0 || currentRow >= this.RowCount)
            {
                throw new ArgumentException(String.Format("Row of the given position ({0}), is outside of the matrix range- 0 to {1}", currentRow, this.RowCount));
            }
            else if (currentCol < 0 || currentCol >= this.ColCount)
            {
                throw new ArgumentException(String.Format("Col of the given position ({0}), is outside of the matrix range- 0 to {1}", currentCol, this.ColCount));
            }
            else if (currentValue<0||currentValue>Math.Pow(this.RowCount,2))
            {
                throw new ArgumentException(String.Format("The given value ({0}), is outside of the range of values for this matrix- 1 to {1}", currentValue, Math.Pow(this.RowCount,2)));
            }

            this.matrixValues[currentRow, currentCol] = currentValue;
        }

        private int[,] MakeDeepCopyOfValues(int[,] valuesOfMatrix)
        {
            int[,] copyOfValues = new int[this.RowCount, this.ColCount];

            for (int row = 0; row < this.RowCount; row++)
            {
                for (int col = 0; col < this.ColCount; col++)
                {
                    copyOfValues[row, col] = valuesOfMatrix[row, col];
                }
            }

            return copyOfValues;
        }
    }
}
