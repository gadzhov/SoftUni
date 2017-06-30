namespace Problem_15.Drawing_tool
{
    public class CorDraw
    {
        public CorDraw(Rectangle rectangle)
        {
            this.Rectangle = rectangle;
        }

        public CorDraw(Square square)
        {
            this.Square = square;
        }

        public Rectangle Rectangle { get; set; }

        public Square Square { get; set; }
    }
}
