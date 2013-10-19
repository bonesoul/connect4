using System;
using System.Collections.Generic;
using System.Text;

namespace conn4_client
{
    /* ai.cs
     * Yapay zeka
     * alpha-beta iyile�tirmeli minmax fonksiyonu
    */

    public class ai
    {
        #region compute_move() - Yapay Zeka, en iyi hamleyi hesapla
        public static int compute_move(board b,move_type player, int level,System.ComponentModel.BackgroundWorker bw)
        {
            board t; // hesaplama yap�lacak yeni tahta
            int best_move_pos = 0; // en iyi oynama pozisyonu
            int score;

            bw.ReportProgress(0); // Hesapla durumunu bildir - Form1 �zerindeki Progress bar bu de�ere g�re bir hesaplama durumu g�sterir
            t = new board(b); // hesaplama yap�lacak tahtay�, mevcut oyun tahtas�n�n o anki halinden kopyala
            score = max(t, player, level,ref best_move_pos,bw); // t tahtas� �zerinde, player oyuncusu i�in, level arama derinlikli
                                                                // en iyi hamleyi bul
                                                                // best_move de�i�keni, olas� en iyi hamleyi ifade etmektedir
                                                                // 'ref' olarak tan�mland��� i�in, pointer gibi �al��arak, fonksiyondan
                                                                // de�er okunmas�n� sa�lamaktad�r
            bw.ReportProgress(7); // Hesaplama bitti

            return best_move_pos; // Bulunan en y�ksek puanl� hamleyi geri d�nd�r
        }
        #endregion

        #region max - Maksimum kazan�
        private static int max(board b, move_type player, int depth,ref int pos,System.ComponentModel.BackgroundWorker bw)
        {
            int alpha = -30000; // alpha - en iyi hamle puan�
            int i;
            board t; // sonraki hamlenin hesaplanaca�� tahta kopyas�
            int score; // hamle skoru

            if (depth != 0 & b.curr_pieces!=board.max_pieces ) // E�er boardda hala oynanabilecek alan varsa
            {                                                  // veya arama derinli�i 0'a inmemi�se devam et
                for (i = 0; i < 7; i++) // 7 farkl� s�tun i�in hamle haz�rla
                {
                    t = new board(b); // hesaplama yap�lacak tahta kopyas�n� haz�rla
                    if (t.move(player, i)) // mevcut s�tuna yap�lan hamle ba�ar�l�ysa
                    {
                        if (t.is_winner(player)) // ve oyunu kazand�ysak (alpha-beta pruning)
                        {
                            pos = i; // hamle pozisyonunu kaydet
                            return 20000; // Bu hamleyle oyunu kazanabildi�imiz i�in kalan hamleleri hesaplamadan
                                          // direkt hamleyi ve en iyi hamle skorunu geri d�nd�r.
                        }
                        score = min(t, get_other_player(player), depth - 1); // rakip oyuncunun bir sonraki hamlesini hesapla
                        if (score > alpha) // e�er d�nen skor alphadan b�y�kse
                        {
                            alpha = score; // yeni alphayi ayarla
                            pos = i; // mevcut en iyi hamle olarak i�aretle
                        }
                        else if (score == alpha) // e�er skor alphaya e�itse, ayn� skora sahip 2 e�it hamle var demektir
                        {
                            // Bu durumda e�it skora sahip hamleler aras�ndan rasgele birini se�
                            Random rnd = new Random(DateTime.Now.Millisecond);
                            if (rnd.Next(100) > 50)
                            {
                                alpha = score;
                                pos = i;
                            }
                        }
                    }
                    if(bw!=null)                // En �st seviyede isek (AI'nin ilk hamlesi), hesaplama durumunu background-worker vas�tas�yla
                        bw.ReportProgress(i);   // progress bara geri d�nd�r
                }
            }
            else // e�er arama derinli�i 0 ise veyada tahtadaki son hamle bu ise
            {
                return b.calculate_score(player) - b.calculate_score(get_other_player(player)); // tahtan�n mevcut skorunu hesapla
                // AI a��s�ndan skor= AI_skoru - rakip_skoru
            }

            return alpha; // mevcut en iyi skoru d�nd�r
                          // ayr�ca mevcut en iyi hamle de�i�keni pos, 'ref' tan�mlanm�� bir de�i�ken oldu�u i�in
                          // pointer gibi �al��acak ve en iyi hamleyi bir �ste d�nd�recektir
        }
        #endregion

        #region min - Minumum kazan�
        private static int min(board b, move_type player, int depth)
        {
            int beta = 30000; // beta - AI a��s�ndan rakibin en iyi hamle puan�
            int i;
            board t; // sonraki hamlenin hesaplanaca�� tahta puan�
            int score;
            int foo=0; // dummy de�i�ken

            if (depth != 0)// E�er arama derinli�i 0'a inmemi�se
            {              
                for (i = 0; i < 7; i++) // 7 farkl� s�tun i�in hamle haz�rla
                {
                    t = new board(b); // hesaplama yap�lacak tahta kopyas�n� haz�rla
                    if (t.move(player, i)) // mevcut s�tuna yap�lan hamle ba�ar�l�ysa
                    {
                        if (t.is_winner(player)) // hamle oyunu kazand�r�yorsa, rakip oyuncu oyunu kazanacakt�r demektir.
                        {
                            return -20000; // rakip oyuncu oyunu kazan�yorsa, bu AI a��s�ndan olduk�a k�t� bir durumdur
                                           // bu durumda AI a��s�ndan, rakip oyunucun hamleleri aras�nda olabilecek en d���k skoru almal�d�r                                           
                        }
                        
                        score = max(t, get_other_player(player), depth - 1, ref foo, null); // bir sonraki hamleyi hesapla
                        if (score < beta) // hamle betadan daha az bir de�ere sahpise
                        {
                            beta = score; // betay� yeni skora e�itle
                        }
                    }
                }
            }
            else // e�er arama derinli�i 0 ise veyada tahtadaki son hamle bu ise
            {   
                return b.calculate_score(player) - b.calculate_score(get_other_player(player));
                // skor = mevcut_oyuncu_skoru - di�er_oyuncunun_skoru
            }

            return beta; // skoru d�nd�r
        }
        #endregion

        #region get_other_player - Rakip oyuncuyu bul
        public static move_type get_other_player(move_type player)
        {
            if (player == move_type.PLAYER_1) return move_type.PLAYER_2;
            else return move_type.PLAYER_1;
        }
        #endregion

    }
}
