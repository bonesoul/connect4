using System;
using System.Collections.Generic;
using System.Text;


namespace conn4_client
{

    /* desk.cs
     * Masa nesnesidir. Bir masada 2 oyuncu bulunmaktad�r.
     * 3 farkl� oyuncu masada oynayabilir, yapay zeka, a� �zerinden yapay zeka, insan oyuncu
    */

    #region oturak
    /* oturak;
     * bo� olabilir (EMPTY)
     * yapa zeka oyuncusu oturabilir (AI)
     * a� �zerinden yapay zeka oyuncusu oturabilir (AI_OVER_NET)
     * insan oyuncu oturabilir (HUMAN)
    */
    public enum seat
    {
        EMPTY=-1,
        AI=0,
        AI_OVER_NET=1,
        HUMAN=2
    }
    #endregion

    #region masa_durumu
    /* 
     * masa durumu;
     * ba�lamam�� olabilir (NOT_STARTED)
     * s�ra oyuncu-1 de olabilir (PLAYER_1)
     * s�ra oyuncu-2 de olabilir (PLAYER_2)
     * oyun bitmi� olabilir (FINISHED)
    */
    public enum state
    {
        NOT_STARTED=0,
        PLAYER1=1,
        PLAYER2=2,
        FINISHED=3
    }
    #endregion

    public static class desk // oyun masas�
    {
        #region masa_s�n�f_�yeleri
        public static seat seat1=seat.EMPTY;    // oturak 1 �ntan�ml� olarak bo�
        public static seat seat2 = seat.EMPTY;  // oturak 2 �ntan�ml� olarak bo�
        public static int seat1_look_ahead=6;   // oturak 1'e gelebilecek bir yapay zeka oyuncusunun �ntan�ml� arama derinli�i=6
        public static int seat2_look_ahead = 6; // oturak 2'e gelebilecek bir yapay zeka oyuncusunun �ntan�ml� arama derinli�i=6
        public static state game_state= state.NOT_STARTED; // oyun durumu = hen�z ba�lamam��
        public static board b; // masa �zerindeki tahta 
        public static move_type last_ai; // son AI oyuncusunun hamlesi - thread ile arka planda �al��an AI'nin se�ti�i hareketi belirtmesini sa�lar
        public static int last_move; // masa �zerinde son hamle - a� �zerinden oyunlarda masa �zerindeki son hamlenin kar�� tarafa iletilmesini sa�lar

        // Desk'in, Form1'�n aktif kopyas�ndaki bile�enlere ula�abilmesi i�in referanslar
        public static System.Windows.Forms.PictureBox pic_turn1;
        public static System.Windows.Forms.PictureBox pic_turn2;
        public static System.ComponentModel.BackgroundWorker bw;
        public static System.Windows.Forms.Cursor cursor;
        public static System.Windows.Forms.Label lbl_status;
        public static System.IO.StreamReader sr;
        public static System.IO.StreamWriter sw;
        public static System.Windows.Forms.PictureBox pb;
        #endregion

        #region oyun_motoru
        public static void play() // oyun motoru
        {
            // masa �zerindeki oyuncular aras�nda ki s�ray� belirleyip, oyunun oynanmas�n� sa�layan fonksiyon
            if (game_state == state.NOT_STARTED) // e�er oyun hen�z ba�lamam�� durumdaysa ve play() �a�r�lm��sa ilk s�ra 
            {                                    // oyuncu-1'dedir (Sadece yerel oyunlar i�in ge�erli. 
                game_state = state.PLAYER1;      // A� �zerinden oyuncuda ilk s�ray� sunucu belirler)
                pic_turn1.Visible = true;        // Grafiksel olarak oyuncu-1 �zerinde ok i�aretiyle s�ras�n� g�ster
                pic_turn2.Visible = false;
            }
            if (game_state == state.PLAYER1)    // s�ra oyuncu-1'de ise
            {
                if (seat1 == seat.HUMAN)        // oyuncu-1 s�ras�nda insan oturuyorsa, insan�n hamle yapmas�n� bekle
                {
                    // do nothing
                }
                else if (seat1 == seat.AI)      // s�rada yapay zeka oturuyorsa yapay zekan�n sonraki hamlesini hesaplamas�n� iste
                {
                    bw.RunWorkerAsync(move_type.PLAYER_1); // yapay zeka background-worker arac�l���yla geri planda thread olarak �al���r
                }
                else if (seat1 == seat.AI_OVER_NET) // s�rada a� �zerinden yapay zeka oturuyorsa
                {
                    String msg;
                    pb.Refresh(); // grafikleri yenile
                    msg = sr.ReadLine(); // socket �zerinden kar�� taraf�n hamlesini oku
                    b.move((move_type)game_state, Int32.Parse(msg)); // gelen hamleyi tahta �zerinde oyna
                    desk.turn_complete(); // hamle biti�i ard�ndan, gerekli i�lemleri yap ve s�ran�n di�er oyuncuya ge�mesini sa�la
                    
                }


            }
            else if (game_state == state.PLAYER2) // s�ra oyuncu-2'de ise
            {
                if (seat2 == seat.HUMAN) // insan
                {
                    // do nothing
                }
                else if (seat2 == seat.AI) // yapay zeka
                {
                    bw.RunWorkerAsync(move_type.PLAYER_2);
                }
                else if (seat2 == seat.AI_OVER_NET) // a� �zerinden yapay zeka
                {
                    String msg;
                    pb.Refresh(); // grafikleri yenile
                    msg = sr.ReadLine();
                    b.move((move_type)game_state, Int32.Parse(msg));
                    desk.turn_complete();
                }

            }


        }
        #endregion

        #region hamle_bitisi
        public static void turn_complete() // hamle biti�i
        {
            if (game_state != state.FINISHED) // e�er oyun bitmemi�se
            {
                pic_turn1.Visible = false; // grafiksel s�ra belirten oku g�r�nmez yap
                pic_turn2.Visible = false;

                // kar�� oyuncu a� �zerinden bir oyuncu ise, lokal oyuncunun son hamlesini herzaman kar�� tarafa ilet
                if (game_state == state.PLAYER1 & seat2 == seat.AI_OVER_NET)
                {
                    sw.WriteLine(last_move); // son hamleyi sockete yaz
                    sw.Flush(); // soketin veriyi g�ndermesini sa�la
                }
                else if (game_state == state.PLAYER2 & seat1 == seat.AI_OVER_NET)
                {
                    sw.WriteLine(last_move);
                    sw.Flush();
                }

                // oyunun bitip bitmedi�ini kontrol et
                if (b.is_winner(move_type.PLAYER_1)) // oyuncu-1 oyunu kazand� m�?
                {
                    game_state = state.FINISHED; 
                    mark_winning_places(move_type.PLAYER_1); // kazanmas�n� sa�layan ta�lar� grafiksel olarak i�aretle
                    lbl_status.Text = "Sar� oyuncu kazand�!"; // Oyun sonucunu ekranda g�ster
                }
                else if (b.is_winner(move_type.PLAYER_2)) // oyuncu-2 oyunu kazand� m�?
                {
                    game_state = state.FINISHED;
                    mark_winning_places(move_type.PLAYER_2);
                    lbl_status.Text = "K�rm�z� oyuncu kazand�!";
                }
                else if (b.is_tie()) // oyun berabere mi bitti?
                {
                    game_state = state.FINISHED;
                    lbl_status.Text = "Oyun berabere bitti!";
                }
                else // kontrol buraya gelirse oyun hen�z bitmemi� demektir
                {
                    if (game_state == state.PLAYER1) // son hamleyi oyuncu-1 yapm��sa
                    {
                        game_state = state.PLAYER2; // s�radaki hamle oyuncu-2'nin
                        pic_turn1.Visible = false;
                        pic_turn2.Visible = true;
                    }
                    else
                    {
                        game_state = state.PLAYER1;
                        pic_turn1.Visible = true;
                        pic_turn2.Visible = false;
                    }

                    lbl_status.Text = "Oyun s�r�yor...";

                    play(); // s�radaki oyuncunun oynamas�n� sa�la
                }
            }
        }
        #endregion

        #region siradaki_oyunucu_bul
        public static move_type get_current_player() // tahtan�n mevcut durumundan s�radaki oyuncuyu move_type t�r�nde geri d�nd�r
        {
            if (game_state == state.PLAYER1)
                return move_type.PLAYER_1;
            else
                return move_type.PLAYER_2;
        }
        #endregion

        #region oyuncun_oturagini_bul
        public static seat get_seat(move_type player) // verilen player oyuncusunun oturdu�u otura�� bul
        {
            if (player == move_type.PLAYER_1)
                return seat1;
            else
                return seat2;
        }
        #endregion

        #region oyun_kazanan_ta�lar�_grafiksel_olarak_i�aretle
        public static void mark_winning_places(move_type player) // kazanan oyunucunun, kazanmas�n� sa�lad��� ta�lar�
        {                                                        // grafiksel olarak i�aretle
            int i, j, k;
            int p;
            if (player == move_type.PLAYER_1) p = 0;
            else p = 1;

            for (k = 0; k < board.winning_places; k++)
                if (b.score[p, k] == 16)
                {
                    for (i = 0; i < board.width; i++)
                        for (j = 0; j < board.height; j++)
                            if (board.win_map[i, j, k] == true)
                                b.board_cells[i, j].winning_cell = true;
                }
        }
        #endregion

    }
   
}
