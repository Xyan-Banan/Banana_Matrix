using System;

namespace ConsoleApp1
{
    class Matrix
    {
        private int[,] values;
        private int rows;
        public int Rows { get { return rows; } }
        private int cols;
        public int Cols { get { return cols; } }
        public int[,] Values { get { return values; } }

        public Matrix(int[,] values)
        {
            this.values = values;
            rows = values.GetLength(0);
            cols = values.GetLength(1);
        }

        public Matrix add(Matrix other)
        {
            if (rows != other.rows || cols != other.cols)
                throw new ApplicationException("Размеры матриц не совпадают");

            int[,] res = new int[rows, cols];

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    res[i, j] = values[i, j] + other.values[i, j];

            return new Matrix(res);
        }

        public Matrix sub(Matrix other)
        {
            if (rows != other.rows || cols != other.cols)
                throw new ApplicationException("Размеры матриц не совпадают");

            int[,] res = new int[rows, cols];

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    res[i, j] = values[i, j] - other.values[i, j];

            return new Matrix(res);
        }

        public Matrix mul(int x)
        {
            int[,] res = new int[rows, cols];

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    res[i, j] = x * values[i, j];

            return new Matrix(res);
        }
        
        public Matrix mul(Matrix other)
        {
            if (cols != other.rows) throw new ApplicationException(
                "Количество столбцов первой матрицы не совпадает с количеством строк второй.");

            int[,] res = new int[rows,other.cols];

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < other.cols; j++) 
                    for (int k = 0; k < cols; k++)
                        res[i, j] += values[i, k] * other.values[k, j];
                                  
            return new Matrix(res);
        }

        public Matrix transpose()
        {
            int[,] res = new int[cols, rows];

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    res[j,i] = values[i,j];

            return new Matrix(res);
        }

        public override string ToString()
        {
            string res = "";
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                    res += Values[i, j] + "\t";
                res += "\n";
            }
            return res;
        }


        public static Matrix operator +(Matrix a) => a;
        public static Matrix operator -(Matrix a) => a.mul(-1);
        public static Matrix operator +(Matrix a, Matrix b) => a.add(b);
        public static Matrix operator -(Matrix a, Matrix b) => a.sub(b);
        public static Matrix operator *(Matrix a, int b) => a.mul(b);
        public static Matrix operator *(int a, Matrix b) => b.mul(a);
        public static Matrix operator *(Matrix a, Matrix b) => a.mul(b);
        
    }
}
