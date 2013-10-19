using System;
using System.Collections.Generic;
using System.Text;

namespace conn4_client
{
    /*
     * board.cs
     * Oyun tahtas�n� tan�mlamaktad�r
     * Oyun tahtas�; tahta_genisligi(width), tahta_yuksekligi(height) bilgilerini i�erir
     * board_cells, oyun tahtas� b�y�kl���nde cell s�n�f�ndan 2 boyutlu bir dizidir.
    */

    #region hamle_t�r�
    public enum move_type : int 
    {
        PLAYER_1=1,PLAYER_2=2
    } // hamle t�r�
    #endregion

    public class Board
    {
        #region tahta_sinif_uyeleri
        public static int width = 7; // s�tun say�s�
        public static int height = 6; // sat�r say�s�

        public Cell[,] board_cells = new Cell[width, height];  // oyun tahtas� b�y�kl���nde cell s�n�f�ndan 2 boyutlu dizi
        public static int winning_places=69; // tahta boyutlar� i�in toplam kazanabilme durumu say�s�
        public static int max_pieces=42; // tahta boyutlar� i�in toplam h�cre say�s�
        public static Boolean [,,] win_map; // tahta i�in kazanma durumlar� haritas�
        public int[,] score = new int[2,winning_places]; // mevcut tahta i�in skor dizisi
        public int curr_pieces; // tahtada mevcut bulunan ta�lar�n toplam say�s�
        #endregion

        #region board()_ontanimli_kurucu
        public Board() // �ntan�ml� kurucu
        {
            // kazanma haritas�n� haz�rla
            int i, j, k, count = 0;
            if (win_map == null) // harita hen�z olu�turulmam��sa
            {
                win_map=new Boolean[width,height,winning_places];
                // kazanma pozisyonlar� tablosunu s�f�rla
                for (i = 0; i < width; i++)
                    for (j = 0; j < height; j++)
                        for (k = 0; k < winning_places; k++)
                            win_map[i, j, k] = false;

                // yatay kazanma pozisyonlar�n� hesapla
                for(i=0;i<height;i++) 
                    for (j = 0; j < 4; j++)
                    {
                        for (k = 0; k < 4; k++)  // ard���k yatay kazanma posizyonlar�                   
                            win_map[j + k,i,count] = true;
                        count++;
                    }

                // dikey kazanma pozisyonlar�
                for (i = 0; i < width; i++)
                    for (j = 0; j < 3; j++)
                    {
                        for (k = 0; k < 4; k++) // ard���k dikey kazanma posizyonlar�
                            win_map[i, j + k, count] = true;
                        count++;
                    }

                // forward-diagonal
                for (i = 0; i < 3; i++)
                    for (j = 0; j < 4; j++)
                    {
                        for (k = 0; k < 4; k++) // ard���k diagonal kazanma pozisyonlar�
                            win_map[j+k, i + k, count] = true;
                        count++;
                    }

                // backward-diagonal
                for (i = 0; i < 3; i++)
                    for (j = 6; j >= 3; j--)
                    {
                        for (k = 0; k < 4; k++) // ard���k ters-diagonal kazanma pozisyonlar�
                            win_map[j - k, i + k, count] = true;
                        count++;
                    }
            }


            // tahta h�crelerini ve pozisyonlar�n� haz�rla
            for (i = 0; i < width; i++)
                for (j = 0; j < height; j++)
                {
                    board_cells[i, j] = new Cell();
                    board_cells[i, j].x = i; // x-kordinat�
                    board_cells[i, j].y = j; // y-kordinat�
                    board_cells[i, j].status = cell_status.EMPTY; // h�cre �ntan�ml� olarak bo�tur
                }

            // skor tablosunu haz�rla
            // skor tablosu her iki oyuncu i�inde kazanma durumlar�ndaki ta� say�s�n� tutan 2-boyutlu bir dizidir
            for(i=0;i<2;i++)
                for (j = 0; j < winning_places; j++)
                    score[i, j] = 1; // Bo� pozisyonlar her iki oyuncu i�inde bir puand�r

            curr_pieces = 0; // tahtaki toplam ta� say�s�
        }
        #endregion

        #region board(board t)_kopyalama_kurucusu
        public Board(Board t) // kopyalama kurucusu - verilen bir board t�r�ndeki t tahtas�n�n mevcut tahtaya kopyalar
        {
            int i,j;
            // h�creleri kopyala
            for (i = 0; i < width; i++)
                for (j = 0; j < height; j++)
                {
                    board_cells[i, j] = new Cell();
                    board_cells[i, j].x = i;
                    board_cells[i, j].y = j;
                    board_cells[i, j].status = t.board_cells[i, j].status; 
                }

            // skorlar� kopyala
            for(i=0;i<2;i++)
                for(j=0;j<winning_places;j++)
                    score[i,j]=t.score[i,j];

            // toplam ta� say�s�n� kopyala
            curr_pieces = t.curr_pieces;
        }
        #endregion

        #region is_tie()
        public Boolean is_tie() // Oyun berabere mi?
        {
            if (curr_pieces == max_pieces) return true; // E�er mevcut ta� say�s� tahtada ki toplam h�cre say�s�na 
                                                        // e�itse oyun berabere bitmi� demektir
            else return false;
        }
        #endregion

        #region is_winner()
        public Boolean is_winner(move_type player) // Oyuncu kazand�m�?
        {
            int p;
            // verilen player oyuncusu i�in oyunu kazan�p kazanmad���n� kontrol eder
            if (player == move_type.PLAYER_1) p = 0;
            else p = 1;


            for (int i = 0; i < winning_places; i++) //skor tablosunu kontrol et
                if (score[p,i] == 16) // e�er skor tablosunda herhangi bir alan 16 puana sahipse, 4 ta� yanyana, dik veya diagonal
                    return true;      // bir �ekilde yerle�mi� demektir ki, verilen oyuncu oyunu kazanm��t�r
            return false;
        }
        #endregion

        #region skoru_hesapla
        public int calculate_score(move_type player) // skoru hesapla
        {
            // verilen player oyuncusu i�in skoru hesaplar
            int i,p; 
            int s = 0;

            if (player == move_type.PLAYER_1) p = 0;
            else p = 1;

            for(i=0;i<winning_places;i++) // skor tablosu boyunca verilen oyuncunun toplam skorunu hesapla
                s+=score[p,i];

            return s;
        }
        #endregion

        #region skoru_g�ncelle
        public void update_score(move_type player,int x,int y) // skoru g�ncelle
        {
            // verilen player oyuncusu i�in x,y kordinatlar� i�in skoru g�nceller
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
                if(win_map[x,y,i] == true) // x,y kordinatlar�nda ki ta��n bulundu�u kazanma posizyonlar�nda verilen oyuncu i�in
                                           // mevcut puan� 2 ile �arp.
                                           // Kazanma posizyonunda hi� ta� yoksa; 1 puan
                                           // Kazanma posizyonunda 0 ta� (rakip oyuncunun ta�� var demektir); 0 puan
                                           // Kazanma posizyonunda 1 ta�; 2 puan
                                           // Kazanma posizyonunda 2 ta�; 4 puan
                                           // Kazanma posizyonunda 3 ta�; 8 puan
                                           // Kazanma posizyonunda 0 ta�; 16 puan = Oyun kazanma durumu
                {
                    score[p,i] *= 2;
                    score[other,i] = 0;   // rakip oyuncu i�in x,y kordinatlar�nda ki ta��n bulundu�u kazanma posizyonlar�n� 0'a e�itle
                                          // Herhangi bir kazanma pozisyonu i�in skorun 0 olmas�, o kazanma pozisyonunda mevcut oyununcun 
                                          // oyuncu kazanamayaca��n� belirtir
                }
            }
        }
        #endregion

        #region move()_ta�_hamlesi
        public Boolean move(move_type m, int x) // verilen m oyuncusu i�in, x s�tundan ta�� at
        {
            int y;
            for (y = 5; y > -1; y--) // ta��n d��ece�i y kordinat�n� bul
            {
                if (board_cells[x, y].status == cell_status.EMPTY) // e�er h�cre bo�sa
                {
                    this.board_cells[x, y].status = (cell_status)m; // mevcut pozisyona ta�� yerle�tir
                    curr_pieces++; // tahtadaki toplam ta� say�s�n� artt�r
                    update_score(m, x, y); // ta��n at�ld��� kordinattaki kazanma posiyonlar� i�in skoru g�ncelle
                    return true; // ta� hareketi ba�ar�l�
                }
            }
            return false; // ta� hareketi verilen s�tunda bo� bir yer bulamad��� i�in ba�ar�z - HATALI HAREKET anlam�na gelmektedir
        }
        #endregion

    }

    }
