using System;
using System.Collections.Generic;
using System.Text;

namespace conn4_client
{
    /*
     * board.cs
     * Oyun tahtasýný tanýmlamaktadýr
     * Oyun tahtasý; tahta_genisligi(width), tahta_yuksekligi(height) bilgilerini içerir
     * board_cells, oyun tahtasý büyüklüðünde cell sýnýfýndan 2 boyutlu bir dizidir.
    */

    #region hamle_türü
    public enum move_type : int 
    {
        PLAYER_1=1,PLAYER_2=2
    } // hamle türü
    #endregion

    public class Board
    {
        #region tahta_sinif_uyeleri
        public static int width = 7; // sütun sayýsý
        public static int height = 6; // satýr sayýsý

        public Cell[,] board_cells = new Cell[width, height];  // oyun tahtasý büyüklüðünde cell sýnýfýndan 2 boyutlu dizi
        public static int winning_places=69; // tahta boyutlarý için toplam kazanabilme durumu sayýsý
        public static int max_pieces=42; // tahta boyutlarý için toplam hücre sayýsý
        public static Boolean [,,] win_map; // tahta için kazanma durumlarý haritasý
        public int[,] score = new int[2,winning_places]; // mevcut tahta için skor dizisi
        public int curr_pieces; // tahtada mevcut bulunan taþlarýn toplam sayýsý
        #endregion

        #region board()_ontanimli_kurucu
        public Board() // öntanýmlý kurucu
        {
            // kazanma haritasýný hazýrla
            int i, j, k, count = 0;
            if (win_map == null) // harita henüz oluþturulmamýþsa
            {
                win_map=new Boolean[width,height,winning_places];
                // kazanma pozisyonlarý tablosunu sýfýrla
                for (i = 0; i < width; i++)
                    for (j = 0; j < height; j++)
                        for (k = 0; k < winning_places; k++)
                            win_map[i, j, k] = false;

                // yatay kazanma pozisyonlarýný hesapla
                for(i=0;i<height;i++) 
                    for (j = 0; j < 4; j++)
                    {
                        for (k = 0; k < 4; k++)  // ardýþýk yatay kazanma posizyonlarý                   
                            win_map[j + k,i,count] = true;
                        count++;
                    }

                // dikey kazanma pozisyonlarý
                for (i = 0; i < width; i++)
                    for (j = 0; j < 3; j++)
                    {
                        for (k = 0; k < 4; k++) // ardýþýk dikey kazanma posizyonlarý
                            win_map[i, j + k, count] = true;
                        count++;
                    }

                // forward-diagonal
                for (i = 0; i < 3; i++)
                    for (j = 0; j < 4; j++)
                    {
                        for (k = 0; k < 4; k++) // ardýþýk diagonal kazanma pozisyonlarý
                            win_map[j+k, i + k, count] = true;
                        count++;
                    }

                // backward-diagonal
                for (i = 0; i < 3; i++)
                    for (j = 6; j >= 3; j--)
                    {
                        for (k = 0; k < 4; k++) // ardýþýk ters-diagonal kazanma pozisyonlarý
                            win_map[j - k, i + k, count] = true;
                        count++;
                    }
            }


            // tahta hücrelerini ve pozisyonlarýný hazýrla
            for (i = 0; i < width; i++)
                for (j = 0; j < height; j++)
                {
                    board_cells[i, j] = new Cell();
                    board_cells[i, j].x = i; // x-kordinatý
                    board_cells[i, j].y = j; // y-kordinatý
                    board_cells[i, j].status = cell_status.EMPTY; // hücre öntanýmlý olarak boþtur
                }

            // skor tablosunu hazýrla
            // skor tablosu her iki oyuncu içinde kazanma durumlarýndaki taþ sayýsýný tutan 2-boyutlu bir dizidir
            for(i=0;i<2;i++)
                for (j = 0; j < winning_places; j++)
                    score[i, j] = 1; // Boþ pozisyonlar her iki oyuncu içinde bir puandýr

            curr_pieces = 0; // tahtaki toplam taþ sayýsý
        }
        #endregion

        #region board(board t)_kopyalama_kurucusu
        public Board(Board t) // kopyalama kurucusu - verilen bir board türündeki t tahtasýnýn mevcut tahtaya kopyalar
        {
            int i,j;
            // hücreleri kopyala
            for (i = 0; i < width; i++)
                for (j = 0; j < height; j++)
                {
                    board_cells[i, j] = new Cell();
                    board_cells[i, j].x = i;
                    board_cells[i, j].y = j;
                    board_cells[i, j].status = t.board_cells[i, j].status; 
                }

            // skorlarý kopyala
            for(i=0;i<2;i++)
                for(j=0;j<winning_places;j++)
                    score[i,j]=t.score[i,j];

            // toplam taþ sayýsýný kopyala
            curr_pieces = t.curr_pieces;
        }
        #endregion

        #region is_tie()
        public Boolean is_tie() // Oyun berabere mi?
        {
            if (curr_pieces == max_pieces) return true; // Eðer mevcut taþ sayýsý tahtada ki toplam hücre sayýsýna 
                                                        // eþitse oyun berabere bitmiþ demektir
            else return false;
        }
        #endregion

        #region is_winner()
        public Boolean is_winner(move_type player) // Oyuncu kazandýmý?
        {
            int p;
            // verilen player oyuncusu için oyunu kazanýp kazanmadýðýný kontrol eder
            if (player == move_type.PLAYER_1) p = 0;
            else p = 1;


            for (int i = 0; i < winning_places; i++) //skor tablosunu kontrol et
                if (score[p,i] == 16) // eðer skor tablosunda herhangi bir alan 16 puana sahipse, 4 taþ yanyana, dik veya diagonal
                    return true;      // bir þekilde yerleþmiþ demektir ki, verilen oyuncu oyunu kazanmýþtýr
            return false;
        }
        #endregion

        #region skoru_hesapla
        public int calculate_score(move_type player) // skoru hesapla
        {
            // verilen player oyuncusu için skoru hesaplar
            int i,p; 
            int s = 0;

            if (player == move_type.PLAYER_1) p = 0;
            else p = 1;

            for(i=0;i<winning_places;i++) // skor tablosu boyunca verilen oyuncunun toplam skorunu hesapla
                s+=score[p,i];

            return s;
        }
        #endregion

        #region skoru_güncelle
        public void update_score(move_type player,int x,int y) // skoru güncelle
        {
            // verilen player oyuncusu için x,y kordinatlarý için skoru günceller
            int i,p,other;

            if (player == move_type.PLAYER_1)
            {
                p = 0;
                other = 1;
            }
            else
            {
                p = 1;
                other = 0;
            }

            for (i = 0; i < winning_places; i++)
            {
                if(win_map[x,y,i] == true) // x,y kordinatlarýnda ki taþýn bulunduðu kazanma posizyonlarýnda verilen oyuncu için
                                           // mevcut puaný 2 ile çarp.
                                           // Kazanma posizyonunda hiç taþ yoksa; 1 puan
                                           // Kazanma posizyonunda 0 taþ (rakip oyuncunun taþý var demektir); 0 puan
                                           // Kazanma posizyonunda 1 taþ; 2 puan
                                           // Kazanma posizyonunda 2 taþ; 4 puan
                                           // Kazanma posizyonunda 3 taþ; 8 puan
                                           // Kazanma posizyonunda 0 taþ; 16 puan = Oyun kazanma durumu
                {
                    score[p,i] *= 2;
                    score[other,i] = 0;   // rakip oyuncu için x,y kordinatlarýnda ki taþýn bulunduðu kazanma posizyonlarýný 0'a eþitle
                                          // Herhangi bir kazanma pozisyonu için skorun 0 olmasý, o kazanma pozisyonunda mevcut oyununcun 
                                          // oyuncu kazanamayacaðýný belirtir
                }
            }
        }
        #endregion

        #region move()_taþ_hamlesi
        public Boolean move(move_type m, int x) // verilen m oyuncusu için, x sütundan taþý at
        {
            int y;
            for (y = 5; y > -1; y--) // taþýn düþeceði y kordinatýný bul
            {
                if (board_cells[x, y].status == cell_status.EMPTY) // eðer hücre boþsa
                {
                    this.board_cells[x, y].status = (cell_status)m; // mevcut pozisyona taþý yerleþtir
                    curr_pieces++; // tahtadaki toplam taþ sayýsýný arttýr
                    update_score(m, x, y); // taþýn atýldýðý kordinattaki kazanma posiyonlarý için skoru güncelle
                    return true; // taþ hareketi baþarýlý
                }
            }
            return false; // taþ hareketi verilen sütunda boþ bir yer bulamadýðý için baþarýz - HATALI HAREKET anlamýna gelmektedir
        }
        #endregion

    }

    }
