using System;
using System.Collections.Generic;
using System.Text;


namespace conn4_client
{

    /* desk.cs
     * Masa nesnesidir. Bir masada 2 oyuncu bulunmaktadýr.
     * 3 farklý oyuncu masada oynayabilir, yapay zeka, að üzerinden yapay zeka, insan oyuncu
    */

    #region oturak
    /* oturak;
     * boþ olabilir (EMPTY)
     * yapa zeka oyuncusu oturabilir (AI)
     * að üzerinden yapay zeka oyuncusu oturabilir (AI_OVER_NET)
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
     * baþlamamýþ olabilir (NOT_STARTED)
     * sýra oyuncu-1 de olabilir (PLAYER_1)
     * sýra oyuncu-2 de olabilir (PLAYER_2)
     * oyun bitmiþ olabilir (FINISHED)
    */
    public enum state
    {
        NOT_STARTED=0,
        PLAYER1=1,
        PLAYER2=2,
        FINISHED=3
    }
    #endregion

    public static class desk // oyun masasý
    {
        #region masa_sýnýf_üyeleri
        public static seat seat1=seat.EMPTY;    // oturak 1 öntanýmlý olarak boþ
        public static seat seat2 = seat.EMPTY;  // oturak 2 öntanýmlý olarak boþ
        public static int seat1_look_ahead=6;   // oturak 1'e gelebilecek bir yapay zeka oyuncusunun öntanýmlý arama derinliði=6
        public static int seat2_look_ahead = 6; // oturak 2'e gelebilecek bir yapay zeka oyuncusunun öntanýmlý arama derinliði=6
        public static state game_state= state.NOT_STARTED; // oyun durumu = henüz baþlamamýþ
        public static board b; // masa üzerindeki tahta 
        public static move_type last_ai; // son AI oyuncusunun hamlesi - thread ile arka planda çalýþan AI'nin seçtiði hareketi belirtmesini saðlar
        public static int last_move; // masa üzerinde son hamle - að üzerinden oyunlarda masa üzerindeki son hamlenin karþý tarafa iletilmesini saðlar

        // Desk'in, Form1'ün aktif kopyasýndaki bileþenlere ulaþabilmesi için referanslar
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
            // masa üzerindeki oyuncular arasýnda ki sýrayý belirleyip, oyunun oynanmasýný saðlayan fonksiyon
            if (game_state == state.NOT_STARTED) // eðer oyun henüz baþlamamýþ durumdaysa ve play() çaðrýlmýþsa ilk sýra 
            {                                    // oyuncu-1'dedir (Sadece yerel oyunlar için geçerli. 
                game_state = state.PLAYER1;      // Að üzerinden oyuncuda ilk sýrayý sunucu belirler)
                pic_turn1.Visible = true;        // Grafiksel olarak oyuncu-1 üzerinde ok iþaretiyle sýrasýný göster
                pic_turn2.Visible = false;
            }
            if (game_state == state.PLAYER1)    // sýra oyuncu-1'de ise
            {
                if (seat1 == seat.HUMAN)        // oyuncu-1 sýrasýnda insan oturuyorsa, insanýn hamle yapmasýný bekle
                {
                    // do nothing
                }
                else if (seat1 == seat.AI)      // sýrada yapay zeka oturuyorsa yapay zekanýn sonraki hamlesini hesaplamasýný iste
                {
                    bw.RunWorkerAsync(move_type.PLAYER_1); // yapay zeka background-worker aracýlýðýyla geri planda thread olarak çalýþýr
                }
                else if (seat1 == seat.AI_OVER_NET) // sýrada að üzerinden yapay zeka oturuyorsa
                {
                    String msg;
                    pb.Refresh(); // grafikleri yenile
                    msg = sr.ReadLine(); // socket üzerinden karþý tarafýn hamlesini oku
                    b.move((move_type)game_state, Int32.Parse(msg)); // gelen hamleyi tahta üzerinde oyna
                    desk.turn_complete(); // hamle bitiþi ardýndan, gerekli iþlemleri yap ve sýranýn diðer oyuncuya geçmesini saðla
                    
                }


            }
            else if (game_state == state.PLAYER2) // sýra oyuncu-2'de ise
            {
                if (seat2 == seat.HUMAN) // insan
                {
                    // do nothing
                }
                else if (seat2 == seat.AI) // yapay zeka
                {
                    bw.RunWorkerAsync(move_type.PLAYER_2);
                }
                else if (seat2 == seat.AI_OVER_NET) // að üzerinden yapay zeka
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
        public static void turn_complete() // hamle bitiþi
        {
            if (game_state != state.FINISHED) // eðer oyun bitmemiþse
            {
                pic_turn1.Visible = false; // grafiksel sýra belirten oku görünmez yap
                pic_turn2.Visible = false;

                // karþý oyuncu að üzerinden bir oyuncu ise, lokal oyuncunun son hamlesini herzaman karþý tarafa ilet
                if (game_state == state.PLAYER1 & seat2 == seat.AI_OVER_NET)
                {
                    sw.WriteLine(last_move); // son hamleyi sockete yaz
                    sw.Flush(); // soketin veriyi göndermesini saðla
                }
                else if (game_state == state.PLAYER2 & seat1 == seat.AI_OVER_NET)
                {
                    sw.WriteLine(last_move);
                    sw.Flush();
                }

                // oyunun bitip bitmediðini kontrol et
                if (b.is_winner(move_type.PLAYER_1)) // oyuncu-1 oyunu kazandý mý?
                {
                    game_state = state.FINISHED; 
                    mark_winning_places(move_type.PLAYER_1); // kazanmasýný saðlayan taþlarý grafiksel olarak iþaretle
                    lbl_status.Text = "Sarý oyuncu kazandý!"; // Oyun sonucunu ekranda göster
                }
                else if (b.is_winner(move_type.PLAYER_2)) // oyuncu-2 oyunu kazandý mý?
                {
                    game_state = state.FINISHED;
                    mark_winning_places(move_type.PLAYER_2);
                    lbl_status.Text = "Kýrmýzý oyuncu kazandý!";
                }
                else if (b.is_tie()) // oyun berabere mi bitti?
                {
                    game_state = state.FINISHED;
                    lbl_status.Text = "Oyun berabere bitti!";
                }
                else // kontrol buraya gelirse oyun henüz bitmemiþ demektir
                {
                    if (game_state == state.PLAYER1) // son hamleyi oyuncu-1 yapmýþsa
                    {
                        game_state = state.PLAYER2; // sýradaki hamle oyuncu-2'nin
                        pic_turn1.Visible = false;
                        pic_turn2.Visible = true;
                    }
                    else
                    {
                        game_state = state.PLAYER1;
                        pic_turn1.Visible = true;
                        pic_turn2.Visible = false;
                    }

                    lbl_status.Text = "Oyun sürüyor...";

                    play(); // sýradaki oyuncunun oynamasýný saðla
                }
            }
        }
        #endregion

        #region siradaki_oyunucu_bul
        public static move_type get_current_player() // tahtanýn mevcut durumundan sýradaki oyuncuyu move_type türünde geri döndür
        {
            if (game_state == state.PLAYER1)
                return move_type.PLAYER_1;
            else
                return move_type.PLAYER_2;
        }
        #endregion

        #region oyuncun_oturagini_bul
        public static seat get_seat(move_type player) // verilen player oyuncusunun oturduðu oturaðý bul
        {
            if (player == move_type.PLAYER_1)
                return seat1;
            else
                return seat2;
        }
        #endregion

        #region oyun_kazanan_taþlarý_grafiksel_olarak_iþaretle
        public static void mark_winning_places(move_type player) // kazanan oyunucunun, kazanmasýný saðladýðý taþlarý
        {                                                        // grafiksel olarak iþaretle
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
