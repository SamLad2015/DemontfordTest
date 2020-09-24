﻿using System;
using DemontfordTest.Entities;
using DemontfordTest.Enums;
using DemontfordTest.Interfaces;


namespace DemontfordTest.Implementations
{
    public class Attacker : IAttacker
    {
        public AttackStatus Attack(Board board, int row, int column)
        {
            Validate(board, row, column);
            
            if (board.BoardCellStatuses[row, column] == BoardCellStatus.Occupied ||
                board.BoardCellStatuses[row, column] == BoardCellStatus.Hit
                )
            {
                board.BoardCellStatuses[row, column] = BoardCellStatus.Hit;
                
                board.HitCount++;
                
                return AttackStatus.Hit;
            }

            board.BoardCellStatuses[row, column] = BoardCellStatus.Miss;
            return AttackStatus.Miss;
        }

        private void Validate(Board board, int row, int column)
        {
            var errorMessage = "Attack position is out of bounds";
            
            if (row > board.Rows)
            {
                throw new IndexOutOfRangeException(errorMessage);
            }

            if (column > board.Columns)
            {
                throw new IndexOutOfRangeException(errorMessage);
            }
        }
    }
}