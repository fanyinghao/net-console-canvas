using System;

namespace FYH.Quiz
{
    class Program
    {
        static void Main(string[] args)
        {
            Canvas canvas = null;

            while(true)
            {
                Console.Write("enter command: ");
                var input = Console.ReadLine();

                try
                {
                    var cmd = input.Substring(0, 1);
                    var val = input.Length > 1 ? input.Substring(2) : string.Empty;
                    switch(cmd)
                    {
                        case "C":
                            var width = int.Parse(val.Split(" ")[0]);
                            var height = int.Parse(val.Split(" ")[1]);
                            canvas = new Canvas(width, height);
                            Print(canvas.Pixels);
                            
                            break;

                        case "L":
                            var x1 = int.Parse(val.Split(" ")[0]);
                            var y1 = int.Parse(val.Split(" ")[1]);
                            var x2 = int.Parse(val.Split(" ")[2]);
                            var y2 = int.Parse(val.Split(" ")[3]);

                            if(null == canvas)
                            {
                                Console.WriteLine("please create canvas first.");
                            }
                            else
                            {
                                canvas.DrawLine(x1, y1, x2, y2);
                                Print(canvas.Pixels);
                            }
                            
                            break;

                        case "R":
                            var xx1 = int.Parse(val.Split(" ")[0]);
                            var yy1 = int.Parse(val.Split(" ")[1]);
                            var xx2 = int.Parse(val.Split(" ")[2]);
                            var yy2 = int.Parse(val.Split(" ")[3]);
                            
                            if(null == canvas)
                            {
                                Console.WriteLine("please create canvas first.");
                            }
                            else
                            {
                                canvas.DrawRectangle(xx1, yy1, xx2, yy2);
                                Print(canvas.Pixels);
                            }
                            
                            break;

                        case "B":
                            var x = int.Parse(val.Split(" ")[0]);
                            var y = int.Parse(val.Split(" ")[1]);
                            var colour = val.Split(" ")[2].Substring(0, 1);
                            
                            if(null == canvas)
                            {
                                Console.WriteLine("please create canvas first.");
                            }
                            else
                            {
                                canvas.Fill(x, y, colour[0]);
                                Print(canvas.Pixels);
                            }
                            
                            break;

                        case "Q":
                            Console.WriteLine("see you.");
                            return;

                        default:
                            Console.WriteLine("command is not correct." + instructionStr);
                            break;
                    }
                }
                catch(IndexOutOfRangeException)
                {
                    Console.WriteLine("parameters are not correct." + instructionStr);                    
                }
                catch(Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }

        static void Print(char[][] data)
        {
            foreach (var row in data)
            {
                foreach (var item in row)
                {
                    Console.Write(item);
                }
                Console.WriteLine();
            }
        }

        const string instructionStr = @"
C w h           Should create a new canvas of width w and height h.
L x1 y1 x2 y2   Should create a new line from (x1,y1) to (x2,y2). Currently only
                horizontal or vertical lines are supported.
R x1 y1 x2 y2   Should create a new rectangle, whose upper left corner is (x1,y1) and
                lower right corner is (x2,y2).
B x y c         Should fill the entire area connected to (x,y) with 'colour' c. The
                behaviour of this is the same as that of the 'bucket fill' tool in paint
                programs.
Q               Should quit the program.";
    }
}
