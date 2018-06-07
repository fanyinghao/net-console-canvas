using System;

namespace FYH.Quiz
{
    public class Canvas
    {
        private int _width;
        private int _height;
        public char[][] Pixels;

        public Canvas(int width, int height)
        {
            Init(width, height);
        }

        public void Init(int width, int height)
        {
            _width = width;
            _height = height;

            if (_width > 0 && _height > 0) 
            {
                Pixels = new char[_height + 2][];
                for (var i = 0; i < _height + 2; i++) 
                {
                    Pixels[i] = new char[_width + 2];
                    for (var j = 0; j < _width + 2; j++) 
                    {
                        if (i == 0 || i == _height + 1) 
                        {
                            Pixels[i][j] = '-';
                        } 
                        else if (j == 0 || j == _width + 1) 
                        {
                            Pixels[i][j] = '|';
                        } 
                        else 
                        {
                            Pixels[i][j] = ' ';
                        }
                    }
                }
            }
        }

        public bool CanDraw 
        {
            get
            {
                return _width > 0 && _height > 0;
            }
        }

        public void DrawLine(int x1, int y1, int x2, int y2) 
        {
            if (!CanDraw) return;
            if (x1 <= 0 || x1 >= _width + 1 || 
                x2 <= 0 || x2 >= _width + 1 || 
                y1 <= 0 || y2 >= _height + 1 ||
                y2 <= 0 || y2 >= _height + 1) 
            {
                throw new Exception("input exceeds range.");
            }
            if (x1 == x2) {
                var min = y1;
                var max = y2;
                if(y1 > y2) 
                {
                    min = y2;
                    max = y1;
                }
                for (var i = min; i <= max; i++) 
                {
                    Pixels[i][x1] = 'x';
                }
            } 
            else if (y1 == y2) 
            {
                var min = x1;
                var max = x2;
                if (x1 > x2) {
                    min = x2;
                    max = x1;
                }
                for (var i = min; i <= max; i++) 
                {
                    Pixels[y1][i] = 'x';
                }
            }
            else
                throw new Exception("Currently only horizontal or vertical lines are supported.");
        }

        public void DrawRectangle(int x1, int y1, int x2, int y2)
        {
            DrawLine(x1, y1, x1, y2);
            DrawLine(x1, y1, x2, y1);
            DrawLine(x2, y1, x2, y2);
            DrawLine(x1, y2, x2, y2);
        }

        public void Fill(int x, int y, char colour)
        {
            if (!CanDraw) return;
            if (x <= 0 || x >= _width + 1 || y <= 0 || y >= _height + 1) {
                return;
            }
            if (Pixels[y][x] != ' ')
                return;
            Pixels[y][x] = colour;
            Fill(x - 1, y, colour);
            Fill(x, y - 1, colour);
            Fill(x + 1, y, colour);
            Fill(x, y + 1, colour);
        }
    }
}