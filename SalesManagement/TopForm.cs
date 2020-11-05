using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SalesManagement
{
    public partial class TopForm : Form
    {
        //メッセージ表示用クラスのインスタンス化
        MessageDsp msg = new MessageDsp();
        public TopForm()
        {
            //DBの作成
            var context = new SalesContext();
            context.M_Divisions.Create();
            context.M_Potisions.Create();
            context.M_Messages.Create();
            context.SaveChanges();

            fncMessageImport();
            context.Dispose();
            InitializeComponent();

        }


        private void buttonDivision_Click(object sender, EventArgs e)
        {
            fncDivisionForm();
        }

        private void ToolStripMenuItemDivisionM_Click(object sender, EventArgs e)
        {
            fncDivisionForm();
        }

        ///////////////////////////////
        //メソッド名：fncDivisionForm()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：部署マスタのフォームを開く
        ///////////////////////////////
        private void fncDivisionForm()
        {
            //フォームを透明化
            Opacity = 0;

            //frmMenuをfrmという名前で開く
            DivisionForm frmD = new DivisionForm();
            frmD.ShowDialog();

            //開いたフォームから戻ってきたら
            //メモリを解放する
            frmD.Dispose();
        }

        ///////////////////////////////
        //メソッド名：fncMessageImport()
        //引　数   ：なし
        //戻り値   ：なし
        //機　能   ：メッセージテーブルを確認しデータが
        //          ：存在していなければインポート
        ///////////////////////////////
        private void fncMessageImport()
        {
            try
            {
                var context = new SalesContext();
                //DBのM_Messageテーブルデータ有無チェック
                //データが存在していなけばデータをインポート
                int cntMsg = context.Database.SqlQuery<int>("SELECT count(*) FROM [dbo].[M_Message]").First();
                context.Dispose();
                if (cntMsg > 0)
                    return;

                //インポートするCSVファイルの指定
                string csvpth = System.Environment.CurrentDirectory + "\\Message.csv";

                //データテーブルの設定
                DataTable dt = new DataTable();
                dt.TableName = "M_Message";

                //csvファイルの内容をDataTableへ
                //csvファイル及び、デリミタの指定
                var parser = new Microsoft.VisualBasic.FileIO.TextFieldParser(csvpth, Encoding.GetEncoding("Shift-JIS"))
                {
                    TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited,
                    Delimiters = new string[] { "," }
                };
                // 全行読み込み
                var rows = new List<string[]>();
                while (!parser.EndOfData)
                {
                    rows.Add(parser.ReadFields());
                }
                // 列設定
                dt.Columns.AddRange(rows.First().Select(s => new DataColumn(s)).ToArray());
                // 行追加
                foreach (var row in rows.Skip(1))
                {
                    dt.Rows.Add(row);
                }

                //DB接続情報の取得
                var dbpth = System.Configuration.ConfigurationManager.ConnectionStrings["SalesContext"].ConnectionString;
                //DataTableの内容をDBへ追加
                using (var bulkCopy = new SqlBulkCopy(dbpth))
                {
                    bulkCopy.DestinationTableName = dt.TableName;
                    bulkCopy.WriteToServer(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void 終了ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // フォームを閉じる確認メッセージの表示
            DialogResult result = msg.MsgDsp("M00001");

            if (result == DialogResult.OK)
            {
                // OKの時の処理
                this.Close();
            }
            else
            {
                // キャンセルの時の処理
            }
        }

        private void TopForm_Activated(object sender, EventArgs e)
        {
            if (Opacity == 0)
            {
                Opacity = 1;
            }
        }

    }
}

