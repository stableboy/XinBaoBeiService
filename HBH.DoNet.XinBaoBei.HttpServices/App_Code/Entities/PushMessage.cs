﻿using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Entities
{
    /// <summary>
    /// Message 的摘要说明
    /// </summary>
    public class PushMessage
    {
        public PushMessage()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        private long id;

        public long ID
        {
            get { return id; }
            set { id = value; }
        }

        private string message_Title;

        public string Message_Title
        {
            get { return message_Title; }
            set { message_Title = value; }
        }

        private string subhead;

        public string Subhead
        {
            get { return subhead; }
            set { subhead = value; }
        }


        private string message_Content;

        public string Message_Content
        {
            get { return message_Content; }
            set { message_Content = value; }
        }

       
        private string messDate;
      //  [JsonConverter(typeof(IsoDateTimeConverter))]
        public string MessDate
        {
            get { return messDate; }
            set { messDate = value; }
        }

        private bool isRead;

        public bool IsRead
        {
            get { return isRead; }
            set { isRead = value; }
        }
        private long user_id;

        public long User_ID
        {
            get { return user_id; }
            set { user_id = value; }
        }

        private long poster_id;
        //发布者
        public long Poster_ID
        {
            get { return poster_id; }
            set { poster_id = value; }
        }

        // 生日
        private string userBirthday;
        /// <summary>
        /// 生日
        /// </summary>
        public string UserBirthday
        {
            get { return userBirthday; }
            set { userBirthday = value; }
        }


        public static PushMessage GetFromTable(DataRow row)
        {
            PushMessage message = new PushMessage();

            message.ID = UIHelper.GetLong(row["id"]);
            message.Message_Title = UIHelper.GetString(row["message_Title"]);

            message.Subhead = UIHelper.GetString(row["subhead"]);
            message.Message_Content = UIHelper.GetString(row["message_Content"]);
            message.MessDate = UIHelper.GetString(row["messDate"]);
            message.User_ID = UIHelper.GetLong(row["user_id"]);
            message.IsRead = UIHelper.GetBool(row["isRead"]);

            object objBirth = row["UserBirthday"];
            if (objBirth != null)
            {
                DateTime dt;
                if (DateTime.TryParse(objBirth.ToString(), out dt))
                {
                    message.UserBirthday = dt.ToString("yyyy-MM-dd");
                }
            }

            return message;
        }
        //public static int GetRowsCount(DataSet ds)
        //{
        //   List<Message> messagelst = GetMessageFromTable(ds);
        //   if (messagelst == null)
        //   {
        //       return 0;
        //   }
        //   return messagelst.Count;
        //}
        public static List<PushMessage> GetFromTable(DataTable table)
        {
            if (table.Rows != null
                && table.Rows.Count > 0
                )
            {
                List<PushMessage> list = new List<PushMessage>();
                foreach (DataRow row in table.Rows)
                {
                    PushMessage message = GetFromTable(row);

                    if (message != null)
                    {
                        list.Add(message);
                    }
                }

                return list;
            }

            return null;
        }

        public static List<PushMessage> GetFromTable(DataSet ds)
        {
            //if (ds != null
            //    && ds.Tables != null
            //    && ds.Tables.Count > 0
            //    )
            //{
            //    return GetFromTable(ds.Tables[0]);
            //}

            //return null;

            return EntityHelper.GetFromDataSet<PushMessage>(ds, GetFromTable);
        }
    }
}