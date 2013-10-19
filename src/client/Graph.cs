using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace conn4_client
{
    /* graph.cs
     * Grafiksel tahta, h�cre ve insan oyuncu i�in ta� atma fonksiyonlar�
    */

    class Graph
    {
        #region tahtayi_grafiksel_olarak_boya
        public static void paint_board(System.Windows.Forms.PictureBox pb, System.Windows.Forms.PaintEventArgs e, Board b)
        {
            int board_width;
            int board_height;
            float per_x;
            float per_y;
            float curr_x;
            float curr_y;
            int margin = 8;
            int i, j;
            Color c;

            
            // oyun tahtasi grafi�ini haz�rla
            board_width = pb.Width;
            board_height = pb.Height;
            per_x = board_width / 7;
            per_y = board_height / 6;
            curr_x = 0;
            curr_y = 0;

            pb.Image = null; // oyun tahtasini temizle
            e.Graphics.FillRectangle(new SolidBrush(Color.RoyalBlue), 0, 0, board_width, board_height);

            for (i = 0; i < Board.height ; i++)
            {
                for (j = 0; j < Board.width; j++)
                {
                    // oyun tahtas�ndaki h�creleri, durumunu ifade eden renklerle �iz
                    if (b.board_cells[j,i].status == cell_status.PLAYER_2) { c = Color.Red; }
                    else if (b.board_cells[j,i].status == cell_status.PLAYER_1) { c = Color.Yellow; }
                    else { c = Color.White; }

                    e.Graphics.FillEllipse(new SolidBrush(c), curr_x + margin, curr_y + margin, per_x - (2 * margin), per_y - (2 * margin));
                    if(b.board_cells[j,i].winning_cell)
                        e.Graphics.FillEllipse(new SolidBrush(Color.Black), curr_x + margin+25, curr_y + margin+25, per_x - (2 * (margin+25)), per_y - (2 * (margin+25)));
                    b.board_cells[j,i].graph_x1 = curr_x + margin;
                    b.board_cells[j,i].graph_x2 = curr_x + per_x - margin;
                    b.board_cells[j,i].graph_y1 = curr_y + margin;
                    b.board_cells[j,i].graph_y2 = curr_y + per_y - margin;
                    curr_x += per_x;
                }
                curr_x = 0;
                curr_y += per_y;
            }
        }
        #endregion

        #region insan_oyunucun_hamlesini_oku
        public static void board_mouse_down(System.Windows.Forms.MouseEventArgs e,Board b,move_type m)
        {
            // mouse kordinatlar�ndan yola ��karak ta��n at�laca�� s�tunu bul
            int i, j;

            if ((Desk.game_state!= state.FINISHED) & (Desk.game_state!=state.NOT_STARTED)) // oyun halen devam ediyorsa
            { 
                if (Desk.get_seat(m) == seat.HUMAN) // mevcut oyuncu bir insan oyuncuysa
                {
                    // kordinatlardan yola ��karak ta��n at�ld��� s�tunu bul
                    for (i = 0; i < Board.width; i++)
                        for (j = 0; j < Board.height; j++)
                        {
                            // mevcut mouse kordinatlar� i�in, ta��n at�labilece�i uygun s�tun sat�r� bul
                            if ((b.board_cells[i, j].graph_x1 < e.X) & (b.board_cells[i, j].graph_x2 > e.X))
                                if ((b.board_cells[i, j].graph_y1 < e.Y) & (b.board_cells[i, j].graph_y2 > e.Y))
                                {
                                    if (b.board_cells[i, j].status == cell_status.EMPTY)
                                    {
                                        b.move(m, i); // insan oyuncu hamlesi
                                        Desk.turn_complete(); // hamle biti�i
                                    }
                                    break;
                                }
                        }

                }
            }
        }
        #endregion
    }
}
