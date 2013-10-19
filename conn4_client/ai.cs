using System;
using System.Collections.Generic;
using System.Text;

namespace conn4_client
{
    /* ai.cs
     * Yapay zeka
     * alpha-beta iyileþtirmeli minmax fonksiyonu
    */

    public class ai
    {
        #region compute_move() - Yapay Zeka, en iyi hamleyi hesapla
        public static int compute_move(board b,move_type player, int level,System.ComponentModel.BackgroundWorker bw)
        {
            board t; // hesaplama yapýlacak yeni tahta
            int best_move_pos = 0; // en iyi oynama pozisyonu
            int score;

            bw.ReportProgress(0); // Hesapla durumunu bildir - Form1 üzerindeki Progress bar bu deðere göre bir hesaplama durumu gösterir
            t = new board(b); // hesaplama yapýlacak tahtayý, mevcut oyun tahtasýnýn o anki halinden kopyala
            score = max(t, player, level,ref best_move_pos,bw); // t tahtasý üzerinde, player oyuncusu için, level arama derinlikli
                                                                // en iyi hamleyi bul
                                                                // best_move deðiþkeni, olasý en iyi hamleyi ifade etmektedir
                                                                // 'ref' olarak tanýmlandýðý için, pointer gibi çalýþarak, fonksiyondan
                                                                // deðer okunmasýný saðlamaktadýr
            bw.ReportProgress(7); // Hesaplama bitti

            return best_move_pos; // Bulunan en yüksek puanlý hamleyi geri döndür
        }
        #endregion

        #region max - Maksimum kazanç
        private static int max(board b, move_type player, int depth,ref int pos,System.ComponentModel.BackgroundWorker bw)
        {
            int alpha = -30000; // alpha - en iyi hamle puaný
            int i;
            board t; // sonraki hamlenin hesaplanacaðý tahta kopyasý
            int score; // hamle skoru

            if (depth != 0 & b.curr_pieces!=board.max_pieces ) // Eðer boardda hala oynanabilecek alan varsa
            {                                                  // veya arama derinliði 0'a inmemiþse devam et
                for (i = 0; i < 7; i++) // 7 farklý sütun için hamle hazýrla
                {
                    t = new board(b); // hesaplama yapýlacak tahta kopyasýný hazýrla
                    if (t.move(player, i)) // mevcut sütuna yapýlan hamle baþarýlýysa
                    {
                        if (t.is_winner(player)) // ve oyunu kazandýysak (alpha-beta pruning)
                        {
                            pos = i; // hamle pozisyonunu kaydet
                            return 20000; // Bu hamleyle oyunu kazanabildiðimiz için kalan hamleleri hesaplamadan
                                          // direkt hamleyi ve en iyi hamle skorunu geri döndür.
                        }
                        score = min(t, get_other_player(player), depth - 1); // rakip oyuncunun bir sonraki hamlesini hesapla
                        if (score > alpha) // eðer dönen skor alphadan büyükse
                        {
                            alpha = score; // yeni alphayi ayarla
                            pos = i; // mevcut en iyi hamle olarak iþaretle
                        }
                        else if (score == alpha) // eðer skor alphaya eþitse, ayný skora sahip 2 eþit hamle var demektir
                        {
                            // Bu durumda eþit skora sahip hamleler arasýndan rasgele birini seç
                            Random rnd = new Random(DateTime.Now.Millisecond);
                            if (rnd.Next(100) > 50)
                            {
                                alpha = score;
                                pos = i;
                            }
                        }
                    }
                    if(bw!=null)                // En üst seviyede isek (AI'nin ilk hamlesi), hesaplama durumunu background-worker vasýtasýyla
                        bw.ReportProgress(i);   // progress bara geri döndür
                }
            }
            else // eðer arama derinliði 0 ise veyada tahtadaki son hamle bu ise
            {
                return b.calculate_score(player) - b.calculate_score(get_other_player(player)); // tahtanýn mevcut skorunu hesapla
                // AI açýsýndan skor= AI_skoru - rakip_skoru
            }

            return alpha; // mevcut en iyi skoru döndür
                          // ayrýca mevcut en iyi hamle deðiþkeni pos, 'ref' tanýmlanmýþ bir deðiþken olduðu için
                          // pointer gibi çalýþacak ve en iyi hamleyi bir üste döndürecektir
        }
        #endregion

        #region min - Minumum kazanç
        private static int min(board b, move_type player, int depth)
        {
            int beta = 30000; // beta - AI açýsýndan rakibin en iyi hamle puaný
            int i;
            board t; // sonraki hamlenin hesaplanacaðý tahta puaný
            int score;
            int foo=0; // dummy deðiþken

            if (depth != 0)// Eðer arama derinliði 0'a inmemiþse
            {              
                for (i = 0; i < 7; i++) // 7 farklý sütun için hamle hazýrla
                {
                    t = new board(b); // hesaplama yapýlacak tahta kopyasýný hazýrla
                    if (t.move(player, i)) // mevcut sütuna yapýlan hamle baþarýlýysa
                    {
                        if (t.is_winner(player)) // hamle oyunu kazandýrýyorsa, rakip oyuncu oyunu kazanacaktýr demektir.
                        {
                            return -20000; // rakip oyuncu oyunu kazanýyorsa, bu AI açýsýndan oldukça kötü bir durumdur
                                           // bu durumda AI açýsýndan, rakip oyunucun hamleleri arasýnda olabilecek en düþük skoru almalýdýr                                           
                        }
                        
                        score = max(t, get_other_player(player), depth - 1, ref foo, null); // bir sonraki hamleyi hesapla
                        if (score < beta) // hamle betadan daha az bir deðere sahpise
                        {
                            beta = score; // betayý yeni skora eþitle
                        }
                    }
                }
            }
            else // eðer arama derinliði 0 ise veyada tahtadaki son hamle bu ise
            {   
                return b.calculate_score(player) - b.calculate_score(get_other_player(player));
                // skor = mevcut_oyuncu_skoru - diðer_oyuncunun_skoru
            }

            return beta; // skoru döndür
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
