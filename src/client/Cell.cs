using System;
using System.Collections.Generic;
using System.Text;

namespace conn4_client
{
    /* cell.cs 
     * H�cre nesnesi.
     * Tahta �zerinde ki her bir yuvarlak bo�luk h�cre olarak kabul edilmektedir.
     * Bir h�cre; bo�(EMPTY), oyuncu-1(PLAYER_1), oyuncu-2(PLAYER_2) taraf�ndan kullanilabilinir.
     * H�cre i�in tahta kordinat bilgileri (x,y) ve grafiksel kordinat bilgileri bulunmaktad�r.
     * Ayr�ca bir h�cre kazanan_h�cre_mi(winning_cell) bilgisi i�ermektedir.(Bak�n�z board.cs)
    */

    #region h�cre_durumu
    public enum cell_status : byte
    {
        EMPTY=0,PLAYER_1=1,PLAYER_2=2
    } // H�cre durumu olas� de�erleri
    #endregion

    public class Cell
    {
        #region h�cre_sinifi_�yeleri
        // tahta �zerinde h�cre kordinatlar�
        public int x; 
        public int y;

        // h�cre durumu - EMPTY, PLAYER_1, PLAYER_2
        public cell_status status;

        // grafiksel kordinatlar ( tahta grafi�inin �izilmesinde kullan�l�r )
        public float graph_x1, graph_x2, graph_y1, graph_y2;

        public Boolean winning_cell = false; // bir oyuncu oyunu kazand���nda, kazand��� pozisyondaki h�crelerin i�aretlenmesini sa�lar
        #endregion

        public Cell()
        {
           // �ntan�ml� kurucu
        }

        
    }
}
