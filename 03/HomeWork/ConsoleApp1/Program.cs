using System;
using static System.Console;

namespace ConsoleApp1
{
    class Program
	{
		static void OutputWithPaddingRight(string outputCell, int outputCellMaxLength)
		{
			//метод выводит ячейку таблицы, выровняв значение по правому краю
			int outputCellCurrentLength;
			outputCellCurrentLength = outputCell.Length;
			if (outputCell.Length < outputCellMaxLength)
			{
				for (int i = 0; i < outputCellMaxLength - outputCellCurrentLength; i++)
					outputCell = " " + outputCell;
			}
			Write(outputCell + " ");
		}

		static void ArrayFormation(int[] array, int length, int start, int stepRow)
		{
			//метод банально формирует массивы строки и столбца
			for (int i = 0; i < length; i++)
			{
				array[i] = start + i * stepRow;
			}
		}

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
			ArrayFormation(multiplicatorRow, rowLength, rowStart, stepRowColumn);
			int[] multiplicatorColumn = new int[columnLength];
			ArrayFormation(multiplicatorColumn, columnLength, columnStart, stepRowColumn);
			
			int[,] resultTable = new int[rowLength, columnLength];
			int outputCellMaxLength = 0;
			for (int i = 0; i < rowLength; i++) //для красивого вывода при формировании таблицы проверяем, сколько символов займет самый длинный элемент массива - будем выравнивать по последнему символу
			{
				for (int j = 0; j < columnLength; j++)
				{
					resultTable[i, j] = multiplicatorRow[i] * multiplicatorColumn[j];
					if (resultTable[i, j].ToString().Length > outputCellMaxLength)
						outputCellMaxLength = resultTable[i, j].ToString().Length;
				}
			}

			OutputWithPaddingRight("*", outputCellMaxLength);
			for (int i = 0; i < rowLength; i++) //цикл, формирующий первую строку (она отличается по принципу формирования от всех остальных строк)
			{
				OutputWithPaddingRight(multiplicatorRow[i].ToString(), outputCellMaxLength);
			}
			WriteLine();

			for (int i = 0; i< columnLength; i++) //ну и вывод всей таблицы
			{
				OutputWithPaddingRight(multiplicatorColumn[i].ToString(), outputCellMaxLength);
				for (int j = 0; j<rowLength; j++)
				{
					OutputWithPaddingRight(resultTable[j, i].ToString(), outputCellMaxLength);
				}
				WriteLine();
			}
			ReadKey();
		}

    }
}
