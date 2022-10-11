using System;

namespace MyDBConnApp1
{
    public class Board
    {
        public int Board_Id { get; set; }
        public string Board_Title { get; set; }
        public string Board_Writer { get; set; }
        public DateTime Board_Date { get; set; }
        public string Board_Contents { get; set; }
    }
}