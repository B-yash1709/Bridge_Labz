using System;

class Solution {
    // Create a random matrix with specified rows and columns
    public static double[,] CreateRandomMatrix(int rows, int cols) {
        Random rand = new Random();
        double[,] matrix = new double[rows, cols];
        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < cols; j++) {
                matrix[i, j] = rand.Next(1, 10); 
			}
		}
        return matrix;
    }

    // Add two matrices
    public static double[,] AddMatrices(double[,] A, double[,] B, int rows, int cols) {
        double[,] result = new double[rows, cols];
        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < cols; j++) {
                result[i, j] = A[i, j] + B[i, j];
			}
		}
        return result;
    }

    // Subtract two matrices
    public static double[,] SubtractMatrices(double[,] A, double[,] B, int rows, int cols) {
        double[,] result = new double[rows, cols];
        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < cols; j++) {
                result[i, j] = A[i, j] - B[i, j];
			}
		}
        return result;
    }

    // Multiply two matrices
    public static double[,] MultiplyMatrices(double[,] A, double[,] B, int rows, int colsA, int colsB) {
        double[,] result = new double[rows, colsB];
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < colsB; j++)
                for (int k = 0; k < colsA; k++)
                    result[i, j] += A[i, k] * B[k, j];
        return result;
    }

    // Transpose a matrix
    public static double[,] TransposeMatrix(double[,] matrix, int rows, int cols) {
        double[,] result = new double[cols, rows];
        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < cols; j++) {
                result[j, i] = matrix[i, j];
			}
		}
        return result;
    }

    // Determinant of a 2x2 matrix
    public static double Determinant2x2(double[,] matrix) {
        return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
    }

    // Determinant of a 3x3 matrix
    public static double Determinant3x3(double[,] matrix) {
        double a = matrix[0, 0], b = matrix[0, 1], c = matrix[0, 2];
        double d = matrix[1, 0], e = matrix[1, 1], f = matrix[1, 2];
        double g = matrix[2, 0], h = matrix[2, 1], i = matrix[2, 2];

        return a * (e * i - f * h) - b * (d * i - f * g) + c * (d * h - e * g);
    }

    // Inverse of a 2x2 matrix
    public static double[,] Inverse2x2(double[,] matrix) {
        double det = Determinant2x2(matrix);
        if (det == 0) return null; 
        double[,] result = new double[2, 2];
        result[0, 0] = matrix[1, 1] / det;
        result[0, 1] = -matrix[0, 1] / det;
        result[1, 0] = -matrix[1, 0] / det;
        result[1, 1] = matrix[0, 0] / det;
        return result;
    }

    // Inverse of a 3x3 matrix
    public static double[,] Inverse3x3(double[,] matrix) {
        double det = Determinant3x3(matrix);
        if (det == 0) return null; 
        double[,] result = new double[3, 3];

        result[0, 0] = (matrix[1, 1] * matrix[2, 2] - matrix[1, 2] * matrix[2, 1]) / det;
        result[0, 1] = (matrix[0, 2] * matrix[2, 1] - matrix[0, 1] * matrix[2, 2]) / det;
        result[0, 2] = (matrix[0, 1] * matrix[1, 2] - matrix[0, 2] * matrix[1, 1]) / det;

        result[1, 0] = (matrix[1, 2] * matrix[2, 0] - matrix[1, 0] * matrix[2, 2]) / det;
        result[1, 1] = (matrix[0, 0] * matrix[2, 2] - matrix[0, 2] * matrix[2, 0]) / det;
        result[1, 2] = (matrix[0, 2] * matrix[1, 0] - matrix[0, 0] * matrix[1, 2]) / det;

        result[2, 0] = (matrix[1, 0] * matrix[2, 1] - matrix[1, 1] * matrix[2, 0]) / det;
        result[2, 1] = (matrix[0, 1] * matrix[2, 0] - matrix[0, 0] * matrix[2, 1]) / det;
        result[2, 2] = (matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0]) / det;

        return result;
    }

    // Display matrix
    public static void DisplayMatrix(double[,] matrix, int rows, int cols, string label = "Matrix") {
        Console.WriteLine(label);
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
                Console.Write(matrix[i, j] + "\t");
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    public static void Main() {
        // Define matrix dimensions
        int rows = 3;
        int cols = 3;

        // Create random 3x3 matrices
        double[,] matrixA = CreateRandomMatrix(rows, cols);
        double[,] matrixB = CreateRandomMatrix(rows, cols);

        // Display matrices
        Console.WriteLine("Matrix A:");
        DisplayMatrix(matrixA, rows, cols);

        Console.WriteLine("Matrix B:");
        DisplayMatrix(matrixB, rows, cols);

        // Perform operations and display results
        DisplayMatrix(AddMatrices(matrixA, matrixB, rows, cols), rows, cols, "A + B");
        DisplayMatrix(SubtractMatrices(matrixA, matrixB, rows, cols), rows, cols, "A - B");
        DisplayMatrix(MultiplyMatrices(matrixA, matrixB, rows, cols, cols), rows, cols, "A * B");
        DisplayMatrix(TransposeMatrix(matrixA, rows, cols), rows, cols, "Transpose of A");

        // For 3x3 matrices, calculate determinant and inverse
        Console.WriteLine("Determinant of A: " + Determinant3x3(matrixA));
        DisplayMatrix(Inverse3x3(matrixA), 3, 3, "Inverse of A");
    }
}
