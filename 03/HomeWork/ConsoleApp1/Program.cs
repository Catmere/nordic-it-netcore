using System;
using static System.Console;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowLength, rowStart, columnLength, columnStart, stepRowColumn;
			Write("Введите первое число строки: ");
			rowStart = int.Parse(ReadLine());
			Write("Введите первое число колонки: ");
			columnStart= int.Parse(ReadLine());
			Write("Введите количество чисел в строке: ");
			rowLength = int.Parse(ReadLine()); 
			Write("Введите количество чисел в колонке: ");
			columnLength = int.Parse(ReadLine());
			Write("Введите шаг сетки: ");
			stepRowColumn = int.Parse(ReadLine());
			int[] multiplicatorRow = new int[rowLength];
			int[] multiplicatorColumn = new int[columnLength];
			for (int i = 0; i< rowLength; i++)
			{
				multiplicatorRow[i] = rowStart + i*stepRowColumn;
			}
			for (int i = 0; i < columnLength; i++)
			{
				multiplicatorColumn[i] = columnStart + i*stepRowColumn;
			}
			int[,] resultTable = new int[rowLength, columnLength];
			int outputCellMaxLength = 0;
			for (int i = 0; i < rowLength; i++) //для красивого вывода, проверяем, сколько символов займет самый длинный элемент массива
			{
				for (int j = 0; j < columnLength; j++)
				{
					resultTable[i, j] = multiplicatorRow[i] * multiplicatorColumn[j];
					if (resultTable[i, j].ToString().Length > outputCellMaxLength)
						outputCellMaxLength = resultTable[i, j].ToString().Length;
				}
			}
			int outputCellCurrentLength;			
			string outputCell = "*"; 
			outputCellCurrentLength = outputCell.Length;//выводим красиво первый элемент
			if (outputCell.Length < outputCellMaxLength)
			{
				for (int i = 0; i < outputCellMaxLength - outputCellCurrentLength; i++)
					outputCell = " " + outputCell;
			}
			Write(outputCell + " "); 
			for (int i = 0; i < rowLength; i++) //цикл, формирующий первую строку (она отличается по принципу формирования от всех остальных строк
			{
				outputCell = multiplicatorRow[i].ToString();
				outputCellCurrentLength = outputCell.Length;
				if (outputCell.Length < outputCellMaxLength)
				{
					for (int j = 0; j < (outputCellMaxLength - outputCellCurrentLength); j++)
						outputCell = " " + outputCell;
				}
				Write(outputCell + " ");
			}
			WriteLine();
			for (int i = 0; i< columnLength; i++) //ну и вывод всей таблицы
			{
				outputCell = multiplicatorColumn[i].ToString();
				outputCellCurrentLength = outputCell.Length;
				if (outputCell.Length < outputCellMaxLength)
				{
					for (int j = 0; j < outputCellMaxLength - outputCellCurrentLength; j++)
						outputCell = " " + outputCell;
				}
				Write(outputCell + " ");
				for (int j = 0; j<rowLength; j++)
				{
					outputCell = resultTable[j,i].ToString();
					outputCellCurrentLength = outputCell.Length;
					if (outputCell.Length < outputCellMaxLength)
					{
						for (int k = 0; k < (outputCellMaxLength - outputCellCurrentLength); k++)
							outputCell = " " + outputCell;
					}
					Write(outputCell + " ");
				}
				WriteLine();
			}
			ReadKey();
		}

    }
}
