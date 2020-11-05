using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalesManagement
{
    class MessageDsp
    {
        ///////////////////////////////
        //メソッド名：MsgDsp()
        //引　数   ：string型：msgId（メッセージ番号）
        //          ：int型   ：id（処理対象のID）
        //          :string型：nm（処理対処の名前）
        //戻り値   ：メッセージのボタン値
        //機　能   ：メッセージを取得して表示
        ///////////////////////////////
        public DialogResult MsgDsp(string msgId,int cnt,string nm)
        {
            DialogResult result=DialogResult.None;
            try
            {
                var context = new SalesContext();
                var message = context.M_Messages.Where(x => x.MsgID == msgId).ToArray();
                MessageBoxButtons btn = new MessageBoxButtons();
                MessageBoxIcon icon = new MessageBoxIcon();
                btn = (MessageBoxButtons)message[0].MsgButton;
                icon = (MessageBoxIcon)message[0].MsgICon;
                string str = "";
                switch (msgId.Substring(0, 2))
                {
                    case "M1":
                        str = "部署";
                        break;
                    case "M2":
                        str = "役職";
                        break;
                }
                result = MessageBox.Show(str + "ID：" + cnt + "　" + str + "名：" + nm + "\n\r" +
                                                message[0].MsgComments, message[0].MsgTitle, btn, icon);
                context.Dispose();
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }

        ///////////////////////////////
        //メソッド名：MsgDsp()
        //引　数   ：string型：msgId（メッセージ番号）
        //戻り値   ：メッセージのボタン値
        //機　能   ：メッセージを取得して表示
        ///////////////////////////////
        public DialogResult MsgDsp(string msgId)
        {
            DialogResult result = DialogResult.None;
            try
            {
                var context = new SalesContext();
                var message = context.M_Messages.Where(x => x.MsgID == msgId).ToArray();
                MessageBoxButtons btn = new MessageBoxButtons();
                MessageBoxIcon icon = new MessageBoxIcon();
                btn = (MessageBoxButtons)message[0].MsgButton;
                icon = (MessageBoxIcon)message[0].MsgICon;
                result = MessageBox.Show(message[0].MsgComments, message[0].MsgTitle, btn, icon);
                context.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
    }
}
