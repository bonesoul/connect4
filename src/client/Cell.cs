using System;
using System.Collections.Generic;
using System.Text;

namespace conn4_client
{
    /* cell.cs 
     * Hücre nesnesi.
     * Tahta üzerinde ki her bir yuvarlak boþluk hücre olarak kabul edilmektedir.
     * Bir hücre; boþ(EMPTY), oyuncu-1(PLAYER_1), oyuncu-2(PLAYER_2) tarafýndan kullanilabilinir.
     * Hücre için tahta kordinat bilgileri (x,y) ve grafiksel kordinat bilgileri bulunmaktadýr.
     * Ayrýca bir hücre kazanan_hücre_mi(winning_cell) bilgisi içermektedir.(Bakýnýz board.cs)
    */

    #region hücre_durumu
    public enum cell_status : byte
    {
        EMPTY=0,PLAYER_1=1,PLAYER_2=2
    } // Hücre durumu olasý deðerleri
    #endregion

    public class Cell
    {
        #region hücre_sinifi_üyeleri
        // tahta üzerinde hücre kordinatlarý
        public int x; 
        public int y;

        // hücre durumu - EMPTY, PLAYER_1, PLAYER_2
        public cell_status status;

        // grafiksel kordinatlar ( tahta grafiðinin çizilmesinde kullanýlýr )
        public float graph_x1, graph_x2, graph_y1, graph_y2;

        public Boolean winning_cell = false; // bir oyuncu oyunu kazandýðýnda, kazandýðý pozisyondaki hücrelerin iþaretlenmesini saðlar
        #endregion

        public Cell()
        {
           // öntanýmlý kurucu
        }

        
    }
}
