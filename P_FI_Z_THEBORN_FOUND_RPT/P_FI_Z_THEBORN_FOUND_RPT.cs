//********************************************************************
// 작   성   자 : 김정열
// 작   성   일 : 2014.01.23
// 모   듈   명 : 품질
// 시 스  템 명 : 유니포인트
// 서브시스템명 : 계약문서현황
// 페 이 지  명 : 계약문서현황
// 프로젝트  명 : P_WP_Z_UNIP_SOPTY_DOC_RPT
//********************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

using Duzon.Common.Controls;
using Duzon.Common.Forms;
using Duzon.Common.Forms.Help;
using C1.Win.C1FlexGrid;
using Dass.FlexGrid;
using Duzon.ERPU;
using Duzon.ERPU.OLD;
using Duzon.Common.BpControls;
using System.Xml;
using Duzon.Windows.Print;
//using Duzon.ERPU.MF.Common;
using DevExpress.Data.PivotGrid;
using DevExpress.XtraPivotGrid;
using Duzon.Common.Util.Uploader;
//using Excel = Microsoft.Office.Interop.Excel;

using DzHelpFormLib; //추가

namespace account
{
    public partial class P_FI_Z_THEBORN_FOUND_RPT : PageBase
  {
        P_FI_Z_THEBORN_FOUND_RPT_BIZ _biz;
        FreeBinding _free;
        private bool _isMsg = true;//맴버필드
        private PrintHelper _prtHelp = null;
        private FreeBinding _header = new FreeBinding();
        private DataTable S_DT = null;
        private string SAVE_CHK = "N";



        /// <summary>
        /// 사진 정보
        /// </summary>
        DataView _dvPhoto;


        public P_FI_Z_THEBORN_FOUND_RPT()
        {
            InitializeComponent();

            MainGrids = new FlexGrid[] { _flex };
            //DataChanged += new EventHandler(Page_DataChanged);
        }

        #region ♪ 초기화        ♬

        protected override void InitLoad()
        {
            base.InitLoad();
            _biz = new P_FI_Z_THEBORN_FOUND_RPT_BIZ();
            _free = new FreeBinding();
            InitGrid();
            InitGrid1();
            InitEvent();



            //this._prtHelp = new PrintHelper(this.MainFrameInterface);
            //this._prtHelp.OnPrintEventProc += new PrintHelper.PrintEventHandler(_prtHelp_OnPrintEventProc);
            //this._prtHelp.OnPrintDialogEventProc += new PrintHelper.PrintDialogEventHandler(_prtHelp_OnPrintDialogEventProc);

        }

        private void InitGrid()
        {
            _flex.BeginSetting(1, 1, false);


            _flex.SetCol("NM_BANK_STORE", "계좌구분", 200, 500, false);
            _flex.SetCol("NO_DEPOSIT", "계좌번호", 120, 30, false);
            _flex.SetCol("NM_DEPOSIT", "계좌명", 300, 100, false);

            _flex.SetCol("PRE_JAN_AMT", "전일잔액", 120, 20, false, typeof(decimal), FormatTpType.MONEY);
            _flex.SetCol("DR_AMT", "입금액", 120, 20, false, typeof(decimal), FormatTpType.MONEY);
            _flex.SetCol("CR_AMT", "출금액", 120, 20, false, typeof(decimal), FormatTpType.MONEY);
            _flex.SetCol("JAN_AMT", "금일잔액", 120, 20, false, typeof(decimal), FormatTpType.MONEY);
            _flex.SetCol("DC_Z_RMK", "비고", 200, 500, false);
            _flex.SetCol("GUBUN", "구분", 0, 20, false);
            _flex.SetCol("ORDERBY", "SORT", 0, 50, false);

            _flex.Cols["NM_BANK_STORE"].AllowMerging = true;
            _flex.AllowMerging = AllowMergingEnum.RestrictCols;

            _flex.SettingVersion = "1.0.0.3";
            _flex.EndSetting(GridStyleEnum.Green, AllowSortingEnum.None, SumPositionEnum.None);

        }

        private void InitGrid1()
        {
            _flex1.BeginSetting(1, 1, false);


            _flex1.SetCol("NM_BANK_STORE", "계좌구분", 200, 500, false);
            _flex1.SetCol("NO_DEPOSIT", "계좌번호", 120, 30, false);
            _flex1.SetCol("NM_DEPOSIT", "계좌명", 300, 100, false);

            _flex1.SetCol("PRE_JAN_AMT", "전일잔액(USD)", 120, 20, false, typeof(decimal), FormatTpType.FOREIGN_MONEY);
            _flex1.SetCol("DR_AMT", "입금액(USD)", 120, 20, false, typeof(decimal), FormatTpType.FOREIGN_MONEY);
            _flex1.SetCol("CR_AMT", "출금액(USD)", 120, 20, false, typeof(decimal), FormatTpType.FOREIGN_MONEY);
            _flex1.SetCol("JAN_AMT", "금일잔액(USD)", 120, 20, false, typeof(decimal), FormatTpType.FOREIGN_MONEY);
            _flex1.SetCol("DC_Z_RMK", "비고", 200, 500, false);
            _flex1.SetCol("GUBUN", "구분", 0, 20, false);
            _flex1.SetCol("ORDERBY", "SORT", 0, 50, false);

            _flex1.Cols["NM_BANK_STORE"].AllowMerging = true;
            _flex1.AllowMerging = AllowMergingEnum.RestrictCols;

            _flex1.SettingVersion = "1.0.0.2";
            _flex1.EndSetting(GridStyleEnum.Green, AllowSortingEnum.None, SumPositionEnum.None);

        }

        private void InitEvent()
        {

        }

        protected override void InitPaint()
        {
            base.InitPaint();

            InitControl();
            
           
        }

        private void InitControl()
        {

            //관련부문[0], 관련부문[1], 제안유형[2], 최종등급[3]
            DataSet _ds = GetComboData("S;CZ_TB0003", "N;QU_Z000001", "N;QU_Z000002", "S;QU_Z000003");

            //SetControl setctr = new SetControl();
            //setctr.SetCombobox(CBO_YN_USE, MA.GetCodeUser(new string[] { "Y", "N" }, new string[] { "Y", "N" }, true));
            //CBO_YN_USE.SelectedValue = "Y";

            //_flex.SetDataMap("YN_USE", MA.GetCodeUser(new string[] { "Y", "N" }, new string[] { "Y", "N" }, false), "CODE", "NAME");
            //_flex.SetDataMap("CD_USERDEF1", _ds.Tables[0], "CODE", "NAME");

            ////관련부문
            //CBO_FG_SUG.DataSource = _ds.Tables[0];
            //CBO_FG_SUG.DisplayMember = "NAME";
            //CBO_FG_SUG.ValueMember = "CODE";


            DTP_등록기간.StartDateToString = MainFrameInterface.GetStringFirstDayInMonth;
            DTP_등록기간.EndDateToString = MainFrameInterface.GetStringToday;

            //DT_FR.Text = MainFrameInterface.GetDateTimeToday().ToString();


        }

        protected override bool IsChanged()
        {
            if (base.IsChanged()) return true;

            return 헤더변경여부;
        }

        #endregion

        #region ♪ 메인 버튼     ♬

        protected override bool BeforeSearch()
        {
            if (!base.BeforeSearch()) return false;
            return true;
        }

        public override void OnToolBarSearchButtonClicked(object sender, EventArgs e)
        {
            try
            {
                if (!base.BeforeSearch() || !DT_등록기간) return;


                object[] param = new object[3];
                param[0] = this.LoginInfo.CompanyCode;                      //회사코드  
                param[1] = D.GetString(DTP_등록기간.StartDateToString);                          //공장  
                param[2] = D.GetString(DTP_등록기간.EndDateToString);       //품목


                MsgControl.ShowMsg("자료 조회중입니다. 잠시만 기다려주세요.");

                _flex.Binding = _biz.Search(param);
                _flex1.Binding = _biz.Search1(param);
                
                MsgControl.CloseMsg();

                if (!_flex.HasNormalRow && !_flex1.HasNormalRow)
                {
                    this.ShowMessage(공통메세지.조건에해당하는내용이없습니다);
                }
                else
                {

                    CellRange cr;
                    if (_flex.HasNormalRow == true)
                    {
                        for (int i = 1; i <= this._flex.Rows.Count - 1; i++)
                        {
                            cr = _flex.GetCellRange(i, 1, i, _flex.Cols.Count - 1);

                            //  원순로가 없는 경우 해당 Row 의 배경을 LitePink로..
                            if (_flex.Rows[i]["GUBUN"].ToString().Equals("2"))
                            {
                                cr.StyleNew.BackColor = Color.LightSkyBlue;
                            }
                            else if (_flex.Rows[i]["GUBUN"].ToString().Equals("3"))
                            {
                                cr.StyleNew.BackColor = Color.LightCoral;
                            }
                            else if (_flex.Rows[i]["GUBUN"].ToString().Equals("4"))
                            {
                                cr.StyleNew.BackColor = Color.LightGray;
                            }
                            else
                            {
                                cr.StyleNew.BackColor = Color.White;
                            }

                        }
                    }
                    if (_flex1.HasNormalRow == true)
                    {
                        for (int i = 1; i <= this._flex1.Rows.Count - 1; i++)
                        {
                            cr = _flex1.GetCellRange(i, 1, i, _flex1.Cols.Count - 1);

                            //  원순로가 없는 경우 해당 Row 의 배경을 LitePink로..
                            if (_flex1.Rows[i]["GUBUN"].ToString().Equals("2"))
                            {
                                cr.StyleNew.BackColor = Color.LightSkyBlue;
                            }
                            else if (_flex1.Rows[i]["GUBUN"].ToString().Equals("3"))
                            {
                                cr.StyleNew.BackColor = Color.LightCoral;
                            }
                            else if (_flex1.Rows[i]["GUBUN"].ToString().Equals("4"))
                            {
                                cr.StyleNew.BackColor = Color.LightGray;
                            }
                            else
                            {
                                cr.StyleNew.BackColor = Color.White;
                            }

                        }
                    }
                    //SetGridSubTotal1();
                }


            }
            catch (Exception ex)
            {
                MsgControl.CloseMsg();
                MsgEnd(ex);
            }
            finally
            {
                MsgControl.CloseMsg();
            }
        }

        protected override bool BeforeAdd()
        {
            if (!base.BeforeAdd()) return false;

            // 메인의 추가버튼 클릭 시 변경된 사항이 있으면 메세지 처리 후 추가..
            if (!MsgAndSave(PageActionMode.Search)) return false;

            return true;
        }

        public override void OnToolBarAddButtonClicked(object sender, EventArgs e)
        {
            try
            {
                //if (!BeforeAdd()) return;

                //_flex.Rows.Add();

                //_flex.Row = _flex.Rows.Count - 1;

               
            }
            catch (Exception ex)
            {
                MsgEnd(ex);
            }
        }

        protected override bool BeforeDelete()
        {
            //if (!base.BeforeDelete()) return false;

            //DialogResult result = ShowMessage(공통메세지.자료를삭제하시겠습니까, PageName);
            //if (result != DialogResult.Yes) return false;
            return true;
        }

        public override void OnToolBarDeleteButtonClicked(object sender, EventArgs e)
        {
            try
            {
                //if (!_flex.HasNormalRow) return;


                //_flex.Rows.Remove(_flex.Row);
               

            }
            catch (Exception ex)
            {
                MsgEnd(ex);
            }
        }

        protected override bool BeforeSave()
        {
            if (!HeaderCheck(0)) return false;

            if (!Verify()) return false;    // 그리드 체크

            return true;
        }
        
        public override void OnToolBarSaveButtonClicked(object sender, EventArgs e)
        {
            try
            {
                //if (!BeforeSave()) return;


                //if (MsgAndSave(PageActionMode.Save))
                //{
                //    ShowMessage(PageResultMode.SaveGood);
                //    _flex.AcceptChanges();
                //    //OnToolBarSearchButtonClicked(null, null);
                //}

            }
            catch (Exception ex)
            {
                MsgEnd(ex);
            }
        }

        public override void OnToolBarPrintButtonClicked(object sender, EventArgs e)
        {
            try
            {
                //string CODE = string.Empty;
                //string NAME = string.Empty;
                ////switch (tabControlExt1.SelectedIndex.ToString())
                ////{
                ////    case "0":
                ////        flex = _flex_매출;
                ////        CODE = "R_SA_IV_LEDGER_1";
                ////        NAME = "매출기준";
                ////        break;
                ////    case "1":
                ////        flex = _flex_미매출;
                ////        CODE = "R_SA_IV_LEDGER_2";
                ////        NAME = "미매출기준";
                ////        break;

                ////    case "2":
                ////        flex = _flex_매출상세;
                ////        CODE = "R_SA_IV_LEDGER_3";
                ////        NAME = "매출기준-상세";
                ////        break;

                ////    case "3":
                ////        flex = _flex_미매출상세;
                ////        CODE = "R_SA_IV_LEDGER_4";
                ////        NAME = "미매출기준-상세";
                ////        break;
                ////}
                //if (tabControlExt1.SelectedTab.Name.ToString() == "tabPage1")
                //{
                //    if (!_flex1.HasNormalRow) return;

                //    ReportHelper rpt = new ReportHelper("R_QU_Z_ANJUN_SUGGEST_RPT1", "제안현황(제안자별)");
                //    //rpt.SetData("조회일", dp_조회일from.MaskEditBox.FormattedText + " ~ " + dp_조회일to.MaskEditBox.FormattedText);

                //    //string 영업그룹 = bp_영업그룹.SelectedText;
                //    //if (bp_영업그룹.Count > 1)
                //    //{
                //    //    영업그룹 += "외 " + D.GetString(bp_영업그룹.Count - 1) + "건";
                //    //}

                //    //System.Diagnostics.Debug.WriteLine(영업그룹);

                //    //rpt.SetData("영업그룹", 영업그룹);
                //    //rpt.SetData("수주담당자", bp_담당자.CodeName);
                //    //rpt.SetData("거래처", bp_거래처.CodeName);
                //    rpt.SetDataTable(_flex1.DataTable);
                //    rpt.Print();
                //}
                //else
                //{
                //    if (!_flex2.HasNormalRow) return;

                //    ReportHelper rpt = new ReportHelper("R_QU_Z_ANJUN_SUGGEST_RPT2", "제안현황(등급별)");
                //    //rpt.SetData("조회일", dp_조회일from.MaskEditBox.FormattedText + " ~ " + dp_조회일to.MaskEditBox.FormattedText);

                //    //string 영업그룹 = bp_영업그룹.SelectedText;
                //    //if (bp_영업그룹.Count > 1)
                //    //{
                //    //    영업그룹 += "외 " + D.GetString(bp_영업그룹.Count - 1) + "건";
                //    //}

                //    //System.Diagnostics.Debug.WriteLine(영업그룹);

                //    //rpt.SetData("영업그룹", 영업그룹);
                //    //rpt.SetData("수주담당자", bp_담당자.CodeName);
                //    //rpt.SetData("거래처", bp_거래처.CodeName);
                //    rpt.SetDataTable(_flex2.DataTable);
                //    rpt.Print();
                //}
            }
            catch (Exception ex)
            {
                MsgEnd(ex);
            }
        }
       
        #endregion

        #region ♪ 화면 내 버튼  ♬

        

        #endregion

        #region ♪ 저장 관련     ♬

        bool HeaderCheck(int pChk)
        {

            // 헤더 데이터 필수 등록 체크

            return true;
        }

        protected override bool SaveData()
        {
            if (!base.SaveData()) return false;

            //DataTable dt = _flex.GetChanges();

            //if (dt == null || dt.Rows.Count <= 0) return false;


            //_biz.Save(dt);


            return true;
        }

        #endregion

        #region ♪ 그리드 이벤트 ♬

       
       
        #endregion

        #region ♪ 기타 이벤트

        #region Control_QueryBefore
        void Control_QueryBefore(object sender, BpQueryArgs e)
        {
            switch (e.ControlName)
            {


                case "BP_NO_DEPOSIT":

                    e.HelpParam.P61_CODE1 = "1";//공장코드

                    break;

                case "CTX_CD_SL":

                    e.HelpParam.P09_CD_PLANT = D.GetString(LoginInfo.CdPlant);//공장코드

                    break;
            }
        }
        #endregion

        #region -> Control_QueryAfter

        private void Control_QueryAfter(object sender, Duzon.Common.BpControls.BpQueryArgs e)
        {
            if (e.DialogResult == DialogResult.Cancel)
                return;

            switch (e.ControlName)
            {
                case "BP_창고":
                    //BP_창고.CodeName = e.HelpReturn.Rows[0]["NM_SL"].ToString();
                    //BP_창고.CodeValue = e.HelpReturn.Rows[0]["CD_SL"].ToString();

                    break;
            }
        }

        #endregion

        #endregion

        #region ♪ 기타 메서드   ♬
        #region -> 컨트롤 초기화(0)
        //private void SetControlClear(Control ctrls)
        //{

        //    foreach (Control ctrlsPanel in ((FlexibleRoundedCornerBox)ctrls).Controls)
        //    {
        //        // **** 커런시 컨트롤
        //        if (ctrlsPanel.GetType().Name == "CurrencyTextBox")
        //        {
        //            ((Duzon.Common.Controls.CurrencyTextBox)ctrlsPanel).DecimalValue = 0;
        //        }
        //        // **** 마스크에디터
        //        else if (ctrlsPanel.GetType().Name == "MaskedEditBox")
        //        {
        //            ((Duzon.Common.Controls.MaskedEditBox)ctrlsPanel).Text = string.Empty;
        //        }
        //        // **** TextBox
        //        else if (ctrlsPanel.GetType().Name == "TextBoxExt")
        //        {
        //            ((TextBoxExt)ctrlsPanel).Text = string.Empty;
        //        }
        //        // **** DatePicker
        //        else if (ctrlsPanel.GetType().Name == "DatePicker")
        //        {
        //            ((DatePicker)ctrlsPanel).Text = string.Empty;
        //        }
        //        // **** BpCodeTextBox
        //        else if (ctrlsPanel.GetType().Name == "BpCodeTextBox")
        //        {
        //            ((Duzon.Common.BpControls.BpCodeTextBox)ctrlsPanel).Text = string.Empty;
        //            ((Duzon.Common.BpControls.BpCodeTextBox)ctrlsPanel).CodeName = string.Empty;
        //            ((Duzon.Common.BpControls.BpCodeTextBox)ctrlsPanel).CodeValue = string.Empty;
        //        }
        //        // **** BpCodeNTextBox
        //        else if (ctrlsPanel.GetType().Name == "BpCodeNTextBox")
        //        {
        //            ((Duzon.Common.BpControls.BpCodeNTextBox)ctrlsPanel).Text = string.Empty;
        //            ((Duzon.Common.BpControls.BpCodeNTextBox)ctrlsPanel).CodeName = string.Empty;
        //            ((Duzon.Common.BpControls.BpCodeNTextBox)ctrlsPanel).CodeValue = string.Empty;
        //        }
        //        // 콤보박스
        //        else if (ctrlsPanel.GetType().Name == "DropDownComboBox")
        //        {
        //            ((DropDownComboBox)ctrlsPanel).SelectedIndex = -1;
        //        }
        //        else if (ctrlsPanel.GetType().Name == "PanelExt")
        //            SetControlClear(ctrlsPanel);
        //    }
        //}
        
        private void SetControlClear(Control ctrls)
        {
            foreach (Control ctrlsPanel in ((PanelExt)ctrls).Controls)
            {
                // **** 커런시 컨트롤
                if (ctrlsPanel.GetType().Name == "CurrencyTextBox")
                {
                    ((Duzon.Common.Controls.CurrencyTextBox)ctrlsPanel).DecimalValue = 0;
                }
                // **** 마스크에디터
                else if (ctrlsPanel.GetType().Name == "MaskedEditBox")
                {
                    ((Duzon.Common.Controls.MaskedEditBox)ctrlsPanel).Text = string.Empty;
                }
                // **** TextBox
                else if (ctrlsPanel.GetType().Name == "TextBoxExt")
                {
                    ((TextBoxExt)ctrlsPanel).Text = string.Empty;
                }
                // **** DatePicker
                else if (ctrlsPanel.GetType().Name == "DatePicker")
                {
                    ((DatePicker)ctrlsPanel).Text = string.Empty;
                }
                // **** BpCodeTextBox
                else if (ctrlsPanel.GetType().Name == "BpCodeTextBox")
                {
                    ((Duzon.Common.BpControls.BpCodeTextBox)ctrlsPanel).Text = string.Empty;
                    ((Duzon.Common.BpControls.BpCodeTextBox)ctrlsPanel).CodeName = string.Empty;
                    ((Duzon.Common.BpControls.BpCodeTextBox)ctrlsPanel).CodeValue = string.Empty;
                }
                // **** BpCodeNTextBox
                else if (ctrlsPanel.GetType().Name == "BpCodeNTextBox")
                {
                    ((Duzon.Common.BpControls.BpCodeNTextBox)ctrlsPanel).Text = string.Empty;
                    ((Duzon.Common.BpControls.BpCodeNTextBox)ctrlsPanel).CodeName = string.Empty;
                    ((Duzon.Common.BpControls.BpCodeNTextBox)ctrlsPanel).CodeValue = string.Empty;
                }
                // 콤보박스
                else if (ctrlsPanel.GetType().Name == "DropDownComboBox")
                {
                    ((DropDownComboBox)ctrlsPanel).SelectedIndex = -1;
                }
                else if (ctrlsPanel.GetType().Name == "PanelExt")
                    SetControlClear(ctrlsPanel);
            }
        }
        
        #endregion -> 컨트롤 초기화(0)


        #endregion

        #region ♪ 속성          ♬


        private bool DT_등록기간 { get { return Checker.IsValid(DTP_등록기간, true, DD("기간")); } }
        //private bool DT_비교기간 { get { return Checker.IsValid(DTP_비교기간, true, DD("비교기간")); } }

        private bool 헤더변경여부
        {
            get
            {
                bool bChange = false;

                bChange = _free.GetChanges() != null ? true : false;
                DataTable dt = _free.GetChanges();

                //if (bChange && _free.JobMode == JobModeEnum.추가후수정 && !_flex.HasNormalRow)
                //    bChange = false;

                return bChange;
            }
        }
        #endregion


    }
}