using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace SalesManagement
{
    public class DbInitializer : CreateDatabaseIfNotExists<SalesContext>
    {
        protected override void Seed(SalesContext context)
        {
            base.Seed(context);

            new List<M_Message>
            {
                new M_Message {MsgID = "M00001", MsgComments = "販売管理システムを終了してよろしいですか？", MsgTitle = "終了確認", MsgButton = 1,MsgICon = 32},
                new M_Message {MsgID = "M10001", MsgComments = "データを追加してよろしいですか？", MsgTitle = "追加確認", MsgButton = 1,MsgICon = 32},
                new M_Message {MsgID = "M10002", MsgComments = "データを追加しました。", MsgTitle = "追加確認", MsgButton = 0,MsgICon = 64},
                new M_Message {MsgID = "M10003", MsgComments = "データを更新してよろしいですか？", MsgTitle = "更新確認", MsgButton = 1,MsgICon = 32},
                new M_Message {MsgID = "M10004", MsgComments = "データを更新しました。", MsgTitle = "更新確認", MsgButton = 0,MsgICon = 64},
                new M_Message {MsgID = "M10005", MsgComments = "データを削除してよろしいですか？", MsgTitle = "削除確認", MsgButton = 1,MsgICon = 32},
                new M_Message {MsgID = "M10006", MsgComments = "データを削除しました。", MsgTitle = "削除確認", MsgButton = 0,MsgICon = 64},
                new M_Message {MsgID = "M10007", MsgComments = "部署マスタデータをインポートしました。", MsgTitle = "インポート確認", MsgButton = 0,MsgICon = 64},
                new M_Message {MsgID = "M10008", MsgComments = "部署マスタを閉じてよろしいですか？", MsgTitle = "フォーム確認", MsgButton = 1,MsgICon = 32},
                new M_Message {MsgID = "M10009", MsgComments = "部署名を入力してください。", MsgTitle = "入力確認", MsgButton = 0,MsgICon = 16},
                new M_Message {MsgID = "M10010", MsgComments = "部署名は半角で50文字までです。", MsgTitle = "入力確認", MsgButton = 0,MsgICon = 16},
                new M_Message {MsgID = "M10011", MsgComments = "1～3の値を入力してください。", MsgTitle = "入力確認", MsgButton = 0,MsgICon = 16},
                new M_Message {MsgID = "M10012", MsgComments = "指定した部署IDは存在しません。", MsgTitle = "入力確認", MsgButton = 0,MsgICon = 16},
            }.ForEach(m => context.M_Messages.Add(m));
         
            context.SaveChanges();
        }
    }
}
