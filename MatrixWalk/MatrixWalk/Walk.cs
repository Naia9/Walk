namespace MatrixWalk
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Walk
    {
        private static Position[] directionIncrements = new Position[]
        {
            new Position(1,1),
            new Position(1,0),
            new Position(1,-1),
            new Position(0,-1),
            new Position(-1,-1),
            new Position(-1,0),
            new Position(-1,1),
            new Position(0,1)
        };

        private int directionChangeIndex = 0;

        private Matrix field;

        public Matrix Field
        {
            get
            {
                return this.field;
            }
            private set
            {
                this.field = value;
            }
        }

        public Walk(Matrix matrix)
        {
            if (matrix==null)
            {
               throw new ArgumentException("Can't make a walk in a null matrix.");
            }

            this.Field = matrix;
        }

        public void StartWalk()
        {
            Position currentPosition = new Position(0, 0);

            this.Field.UpdateSeparateValue(currentPosition, 1);

            double maximalValue = Math.Pow(this.Field.RowCount, 2)+1;

            for (int nextValue = 2; nextValue < maximalValue; nextValue++)
            {
                currentPosition = ComputeNextPosition(currentPosition, 0);

                this.Field.UpdateSeparateValue(currentPosition, nextValue);
            }

            PrintOutMatrix();
        }

        private Position ComputeNextPosition(Position currentPosition,int turnCounter)
        {
            Position nextPosition = new Position(-5, -5);

            int rowIncrement = directionIncrements[directionChangeIndex].RowNumber;
            int colIncrement = directionIncrements[directionChangeIndex].ColNumber;
            int nextRow = currentPosition.RowNumber+rowIncrement;
            int nextCol = currentPosition.ColNumber+colIncrement;

            bool positionIsValid = CheckIfPositionIsValid(nextRow, nextCol);

            if (positionIsValid)
            {
                nextPosition = new Position(nextRow, nextCol);
            }
            else
            {
                if (turnCounter <= 8)
                {
                    ChangeDirection();

                    turnCounter++;

                    nextPosition = ComputeNextPosition(currentPosition, turnCounter);
                }
                else
                {
                    nextPosition = FindNextFreePosition();
                }
            }
            return nextPosition;
        }

        private void ChangeDirection()
        {
            directionChangeIndex++;

            if (directionChangeIndex == 8)
            {
                directionChangeIndex = 0;
            }
        }

        private bool CheckIfPositionIsValid(int nextRow, int nextCol)
        {
            bool positionIsInRange = CheckIfPositionIsInRange(nextRow, nextCol);
            bool positionIsAvailable = false;

            if (positionIsInRange)
            {
                positionIsAvailable = CheckIfPositionIsAvailable(nextRow, nextCol);
            }

            bool result = positionIsInRange && positionIsAvailable;
            return result;
        }

        private bool CheckIfPositionIsInRange(int row, int col)
        {
            bool rowIsInRange = (row >= 0) && (row < this.Field.RowCount);
            bool colIsInRange = (col >= 0) && (col < this.Field.ColCount);

            return rowIsInRange && colIsInRange;
        }


        private bool CheckIfPositionIsAvailable(int row, int col)
        {
            if (this.Field.MatrixValues[row, col] == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private Position FindNextFreePosition()
        {
            for (int row = 0; row < this.Field.RowCount; row++)
            {
                for (int col = 0; col < this.Field.ColCount; col++)
                {
                    if (this.Field.MatrixValues[row, col] ==0)
                    {
                        Position nextFreePosition = new Position(row, col);
                        return nextFreePosition;
                    }
                }
            }

            return new Position(-5, -5);
        }

        private void PrintOutMatrix()
        {
            for (int row = 0; row < this.Field.RowCount; row++)
            {
                for (int col = 0; col < this.Field.ColCount; col++)
                {
                    Console.Write( "{0,4}",this.Field.MatrixValues[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
