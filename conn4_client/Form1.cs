using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;
using System.Net;

namespace conn4_client
{
    public partial class Form1 : Form
    {
        public board b; // Form üzerinde board türünden b nesnesi
        
        #region Form1()_default_constructor
        public Form1()
        {
            InitializeComponent();
        }
        #endregion

        #region Form1_Load - baþlangýç fonksiyonu
        private void Form1_Load(object sender, EventArgs e) // Form1_Load() - baþlangýç fonksiyonu
        {
            desk.pic_turn1 = pic_seat1_turn;
            desk.pic_turn2 = pic_seat2_turn;
            desk.bw = bw; // background-worker - Yapay zekanýn thread ile arka planda çalýþmasýný saðlayan nesne
            desk.cursor = this.Cursor;
            desk.lbl_status = lbl_status;
            desk.pb = pic_board;
            b = new board(); // geçici board nesnesi - oyun baþlamadan boþ tahta grafiðinin boyanmasýný saðlar
        }
        #endregion

        #region pic_board_Paint();
        private void pic_board_Paint(object sender, PaintEventArgs e)
        {
                graph.paint_board(pic_board, e, b); // tahtayý boya
        }
        #endregion

        #region pic_board_MouseDown()
        private void pic_board_MouseDown(object sender, MouseEventArgs e)
        {
                graph.board_mouse_down(e, b, (move_type)desk.get_current_player()); // insan oyuncunun hamlesini iþle
        }
        #endregion

        #region DragDrop_iþleyicisi
        private void lbl_AI_MouseDown(object sender, MouseEventArgs e)
        {
            lbl_AI.DoDragDrop("AI", DragDropEffects.Copy); // yapay zeka taþýnýyor
        }

        private void lbl_AI_net_MouseDown(object sender, MouseEventArgs e)
        {
            lbl_AI_net.DoDragDrop("AI_net", DragDropEffects.Copy); // að üzerinden yapay zeka taþýnýyýor
        }

        private void lbl_human_MouseDown(object sender, MouseEventArgs e)
        {
            lbl_human.DoDragDrop("human", DragDropEffects.Copy); // insan oyuncu taþýnýyor
        }

        private void lbl_seat1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy; // drag-dropu kabul et
        }

        private void lbl_seat2_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }


        private void lbl_seat1_DragDrop(object sender, DragEventArgs e)
        {
            string item;
            item = e.Data.GetData(DataFormats.Text).ToString(); // taþýnan nesnenin türünü oku

            if (item == "AI") // yapay zeka ise
            {
                lbl_seat1.Image = img_list.Images[0];
                desk.seat1 = seat.AI; // oturaða yapay zeka oturdu
                grp_AI_1.Visible = true;
            }
            else if (item == "AI_net") // að üzerinden yapay zeka ise
            {
                // rakibi kontrol et
                if (desk.seat2 != seat.AI_OVER_NET) 
                {
                    lbl_seat1.Image = img_list.Images[1];
                    desk.seat1 = seat.AI_OVER_NET; // að üzerinden yapay zekayý oturt
                    grp_AI_net.Visible = true;
                }
                else // rakipte að üzerinden yapay zeka ise, oyun oynanamaz
                {
                    lbl_status.Text  = "Ýki tane að üzerinden yapay zeka oynayamaz!";
                }
            }
            else if (item == "human") // insan oyuncu ise
            {
                lbl_seat1.Image = img_list.Images[2];
                desk.seat1 = seat.HUMAN; // insan oyuncuyu oturt
            }

            show_group_boxes();
        }

        private void lbl_seat2_DragDrop(object sender, DragEventArgs e)
        {
            string item;
            item = e.Data.GetData(DataFormats.Text).ToString();


            if (item == "AI")
            {
                lbl_seat2.Image = img_list.Images[0];
                desk.seat2 = seat.AI;
                grp_AI_2.Visible = true;
            }
            else if (item == "AI_net")
            {
                if (desk.seat1 != seat.AI_OVER_NET)
                {
                    lbl_seat2.Image = img_list.Images[1];
                    desk.seat2 = seat.AI_OVER_NET;
                    grp_AI_net.Visible = true;
                }
                else
                {
                    lbl_status.Text  = "Ýki tane að üzerinden yapay zeka oynayamaz!";
                }
            }
            else if (item == "human")
            {
                lbl_seat2.Image = img_list.Images[2];
                desk.seat2 = seat.HUMAN;
            }

            show_group_boxes();
        }
        #endregion

        #region oyuncu_ayarlari
        public void show_group_boxes()
        {
            // oyuncu ayarlarini içeren gropboxlarý mevcut oyuncular için göster
            int x_pos = 8;
            int curr_pos = 344;
            int width = 248;
            int heigt = 90;

            grp_AI_1.Visible = false;
            grp_AI_2.Visible = false;
            grp_AI_net.Visible = false;

            switch (desk.seat1)
            {
                case seat.EMPTY:
                    break;
                case seat.AI:
                    grp_AI_1.Left = x_pos;
                    grp_AI_1.Top = curr_pos;
                    grp_AI_1.Width = width;
                    grp_AI_1.Height = heigt;
                    lbl_AI1_color.BackColor = lbl_seat1.BackColor;
                    grp_AI_1.Visible = true;
                    curr_pos = 445;
                    break;
                case seat.AI_OVER_NET:
                    grp_AI_net.Left = x_pos;
                    grp_AI_net.Top = curr_pos;
                    grp_AI_net.Width = width;
                    grp_AI_net.Height = heigt;
                    lbl_AI_net_color.BackColor = lbl_seat1.BackColor;
                    grp_AI_net.Visible = true;
                    curr_pos = 445;
                    break;
                case seat.HUMAN:
                    break;
                default:
                    break;
            }

            switch (desk.seat2)
            {
                case seat.EMPTY:
                    break;
                case seat.AI:
                    grp_AI_2.Left = x_pos;
                    grp_AI_2.Top = curr_pos;
                    grp_AI_2.Width = width;
                    grp_AI_2.Height = heigt;
                    lbl_AI2_color.BackColor = lbl_seat2.BackColor;
                    grp_AI_2.Visible = true;
                    break;
                case seat.AI_OVER_NET:
                    grp_AI_net.Left = x_pos;
                    grp_AI_net.Top = curr_pos;
                    grp_AI_net.Width = width;
                    grp_AI_net.Height = heigt;
                    lbl_AI_net_color.BackColor = lbl_seat2.BackColor;
                    grp_AI_net.Visible = true;
                    break;
                case seat.HUMAN:
                    break;
                default:
                    break;
            }
        }

        // oyuncu-1 yapak zekasý olduðu durumda, arama derinliðini deðiþtirilmesini saðlar
        private void num_AI1_look_ahead_ValueChanged(object sender, EventArgs e)
        {
            desk.seat1_look_ahead = Int32.Parse(num_AI1_look_ahead.Value.ToString());
        }

        // oyuncu-2 yapak zekasý olduðu durumda, arama derinliðini deðiþtirilmesini saðlar
        private void num_AI2_look_ahead_ValueChanged(object sender, EventArgs e)
        {
            desk.seat2_look_ahead = Int32.Parse(num_AI2_look_ahead.Value.ToString());
        }
        #endregion

        #region cmd_start_Click - Oyunu baslat
        private void cmd_start_Click(object sender, EventArgs e)
        {
                if (desk.game_state == state.FINISHED) // zaten oyun bitmiþ bir tahta varsa
                {
                    desk.game_state = state.NOT_STARTED; // oyunu sýfýrla
                    desk.seat1 = seat.EMPTY; // oturaklarý sýfýrla
                    desk.seat2 = seat.EMPTY;
                    show_group_boxes(); // oyuncu ayar bölümlerini yenide ayarla
                }
                if (desk.seat1 != seat.EMPTY & desk.seat2 != seat.EMPTY) // iki oturakta doluysa
                {
                    b = new board(); // yeni tahta yarat
                    desk.b = b; // masa üzerinde tahtaya referans ver
                    pic_board.Refresh(); // oyun baþlamadan önce grafiði hazýrla
                    desk.play(); // oyun motorunu çalýþtýr
                }
                else
                {
                    lbl_seat1.Image = null;
                    lbl_seat2.Image = null;
                    lbl_status.Text = "Oyun masasýný ayarlamalýsýnýz!";
                }

            }
        #endregion

        #region background_worker - yapay zekanýn threading ile arka planda çalýþmasýný saðla       
        private void bw_DoWork(object sender, DoWorkEventArgs e) // Yapay zekayý thread ile arka planda çalýþtýr
        {
            move_type player;
            player = (move_type)e.Argument; // oynayacak oyuncuyu bul

            desk.last_ai = player; // oynayan oyuncuyu kaydet
            
            // yapay zekanýn compute_move() fonksiyonunu çalýþtýr
            if(player== move_type.PLAYER_1)
                e.Result=ai.compute_move(desk.b, move_type.PLAYER_1,desk.seat1_look_ahead,bw);
            else
                e.Result=ai.compute_move(desk.b, move_type.PLAYER_2, desk.seat2_look_ahead,bw);
        }

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progress_bar.Value = e.ProgressPercentage; // iþlem durumunu progress bara yansýt
        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) // yapay zeka hamlesine karar verdiðinde hamleyi tahtada oyna
        {
            int best_move;
            best_move = Int32.Parse(e.Result.ToString()); // thread döndürdüðü oynanacak sütun bul
            b.move(desk.last_ai, best_move); // hamleyi oyna
            desk.last_move = best_move; // hamleyi kaydet (að üzerinden gönderilmesinin gerektiði durumlar için)
            desk.turn_complete(); // hamleyi sonlandýr
        }
        #endregion

        #region cmd_connect_Click - Að üzerinden baþka bir oyuncuya baðlantý
        private void cmd_connect_Click(object sender, EventArgs e)
        {
            string server; // sunucu adresi
            int port=0;

            server = txt_server.Text;
            if (server == "") // sunucu adresi kontrol et
            {
                lbl_status.Text = "Sunucu adresini girin...";
                return;
            }
            try // portu kontrol et
            {
                port = Int32.Parse(txt_port.Text);
            }
            catch(Exception exc) 
            {
                lbl_status.Text = "Port hatalý!";
                return;
            }

            try
            {
                NetworkStream ns;
                StreamReader sr;
                StreamWriter sw;
                String msg;
                TcpClient client = new TcpClient();
                
                lbl_status.Text = "Baðlanýlýyor; " + server + ":" + port;
                b = new board(); // yeni tahta yarat
                desk.b = b; // masa üzerinde tahtaya referans ver
                pic_board.Refresh();

                client.Connect(server, port); // sunucuya baðlan
                lbl_status.Text = "Baðlantý kuruldu...";
                ns = client.GetStream();
                sr = new StreamReader(ns); // soket okyucusu 
                sw = new StreamWriter(client.GetStream()); // soket yazýcýsý
                desk.sr = sr; // masaya soket okuyucu baðla
                desk.sw = sw; // masaya soket yazýcýyý baðla

                msg = sr.ReadLine(); // ilk hamlenin hangi oyuncuya ait olduðunu sunucudan oku
                if (msg.ToLower().ToString() == "white") // eðer white gelirse lokal oyuncu ilk oynacaktýr
                {
                    if (desk.seat1 == seat.AI_OVER_NET)
                    {
                        desk.game_state = state.PLAYER2; // lokal oyuncu; oyuncu-2
                    }
                    else if (desk.seat2 == seat.AI_OVER_NET)
                    {
                        desk.game_state = state.PLAYER1; // lokal oyuncu; oyuncu-1
                    }
                }
                else // "white" dýþý durumda, að üzerindeki rakip oyuncu ilk hamleyi yapacak
                {
                    if (desk.seat1 == seat.AI_OVER_NET)
                    {
                        desk.game_state = state.PLAYER1; // sýra rakip oyuncuda
                    }
                    else if (desk.seat2 == seat.AI_OVER_NET)
                    {
                        desk.game_state = state.PLAYER2; // sýra rakip oyuncuda
                    }
                }
                desk.play(); // oyun motorunu çalýþtýr
            }
            catch (Exception socket_exc) // baðlantýnýn saðlanamadýðý durumlar
            {
                MessageBox.Show(socket_exc.Message);
                lbl_status.Text = "Baðlantý baþarýsýz. Sunucu adresini kontrol edin...";
            }
        }
        #endregion





    }
}