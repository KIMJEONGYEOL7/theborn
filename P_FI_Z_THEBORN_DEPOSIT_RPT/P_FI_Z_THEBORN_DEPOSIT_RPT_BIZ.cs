using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using Duzon.Common.Forms;
using Duzon.Common.Util;
using Duzon.ERPU;

namespace account
{
    class P_FI_Z_THEBORN_DEPOSIT_RPT_BIZ
    { 

        #region -> 조회(Search)
        public DataTable Search(object[] param)
        {
            DataTable dt = DBHelper.GetDataTable("UP_FI_Z_THEBORN_DEPOSIT_RPT_S", param);
            T.SetDefaultValue(dt);

            // 기본값 설정
            //dt.Columns["DT_REQ_REPAIR"].DefaultValue = Global.MainFrame.GetStringToday;
            //dt.Columns["DT_TROUBLE"].DefaultValue = Global.MainFrame.GetStringToday;
            //dt.Columns["NO_SEQ"].DefaultValue = 0;
            //dt.Columns["REPAIR_STATUS"].DefaultValue = "010";
            //dt.Columns["S"].DefaultValue = "N";

            return dt;
        }
        #endregion

        //public DataSet Search(object[] param)
        //{
        //    ResultData _dS = (ResultData)Global.MainFrame.FillDataSet("UP_SA_Z_EDIYA_FRAN_STOOWNVO_S", param);
        //    return (DataSet)_dS.DataValue;
        //}

        #region -> SEARCH_DOC()

        public DataTable SEARCH_DOC(string param)
        {

            string SelectQuery = string.Empty;

            SelectQuery = "SELECT	CD_SYSDEF AS CODE, NM_SYSDEF AS NAME ";
            SelectQuery = SelectQuery + "FROM	MA_CODEDTL ";
            SelectQuery = SelectQuery + "WHERE	CD_COMPANY = '" + Global.MainFrame.LoginInfo.CompanyCode.ToString() + "' ";
            SelectQuery = SelectQuery + "AND		CD_FIELD = '" + param + "' ";
            SelectQuery = SelectQuery + "ORDER BY  CD_SYSDEF";

            DataTable dt = DBHelper.GetDataTable(SelectQuery);
            return dt;
        }

        #endregion

        #region -> SAVE_KEY_CHECK()

        public DataTable SAVE_KEY_CHECK(object[] param)
        {

            string SelectQuery = string.Empty;

            SelectQuery = "SELECT	COUNT(*) AS CNT ";
            SelectQuery = SelectQuery + "FROM	QU_Z_ANJUN_SUGGEST ";
            SelectQuery = SelectQuery + "WHERE	CD_COMPANY = '" + param[0].ToString() + "' ";
            SelectQuery = SelectQuery + "AND		NO_EMP = '" + param[1].ToString() + "' ";
            SelectQuery = SelectQuery + "AND		NO_SUG = '" + param[2].ToString() + "' ";

            DataTable dt = DBHelper.GetDataTable(SelectQuery);
            return dt;
        }

        #endregion

        #region -> SEARCH_CLASS()

        public DataTable SEARCH_CLASS(object[] param)
        {

            string SelectQuery = string.Empty;

            SelectQuery = SelectQuery + "SELECT '' AS CODE, '' AS NAME, '1' AS NUM ";
            SelectQuery = SelectQuery + "UNION ALL ";
            SelectQuery = SelectQuery + "SELECT	CD_SYSDEF AS CODE, NM_SYSDEF AS NAME, '2' AS NUM ";
            SelectQuery = SelectQuery + "FROM	MA_CODEDTL ";
            SelectQuery = SelectQuery + "WHERE	CD_COMPANY = '" + param[0].ToString() + "' ";
            SelectQuery = SelectQuery + "AND		CD_FIELD = '" + param[1].ToString() + "' ";
            SelectQuery = SelectQuery + "AND		CD_FLAG1 = '" + param[2].ToString() + "' ";
            SelectQuery = SelectQuery + "ORDER BY  NUM, CODE";

            DataTable dt = DBHelper.GetDataTable(SelectQuery);
            return dt;
        }

        #endregion



        internal void Save(DataTable dt)
        {

            SpInfoCollection sc = new SpInfoCollection();

            if (dt != null)
            {
                SpInfo si = null;
                si = new SpInfo();
                si.DataValue = dt;
                si.CompanyID = MA.Login.회사코드;
                si.UserID = MA.Login.사용자아이디;
                //si.SpNameInsert = "UP_QU_Z_ANJUN_SUGGEST_MNG_I";
                si.SpNameUpdate = "UP_FI_Z_THEBORN_DEPOSIT_RPT_U";
                //si.SpNameDelete = "UP_QU_Z_ANJUN_SUGGEST_MNG_D";
                //si.SpParamsInsert = new string[] { "CD_COMPANY", "NO_EMP", "DT_SUG", "FG_SUG", "NO_SUG", "TP_SUG", "NM_SUG",
                //                                    "YN_ACT", "YN_FIN", "R_CLASS", "M_CLASS", "H_CLASS", "FN_CLASS", "AM",
                //                                    "AM_CLS", "ID_INSERT" };
                si.SpParamsUpdate = new string[] { "CD_COMPANY", "CD_DEPOSIT", "CD_USERDEF1", "NM_Z_USERDEF1", "CD_USERDEF2", "YN_Z_DEPOSIT", "DC_Z_RMK", "ID_UPDATE" };
                //si.SpParamsDelete = new string[] { "CD_COMPANY", "NO_EMP", "NO_SUG" };

                sc.Add(si);

            }



            DBHelper.Save(sc);



        }
         
       
       
    }
}
