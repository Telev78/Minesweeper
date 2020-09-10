namespace minesweeper
{
 public struct Difficulty
    {
        public static Difficulty Beginner { get; } = new Difficulty(9, 9, 10);
        public static Difficulty Intermediate { get; } = new Difficulty(16, 16, 40);
        public static Difficulty Expert { get; } = new Difficulty(30, 16, 99);

        private Difficulty(int colonnes, int rows, int mines)
        {
            Colonnes = colonnes;
            Rows = rows;
            Mines = mines;
        }

        public int Colonnes { get; set; }
        public int Rows { get; set; }
        public int Mines { get; set; }
    };

}