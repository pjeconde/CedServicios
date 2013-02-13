using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.ComponentModel;

namespace CedServicios.WebForms
{
    public class PagingGridView : GridView
    {
        public PagingGridView()
            : base()
        {
            this.AllowPaging = true;
            this.AllowSorting = true;
            this.PagerSettings.Mode = PagerButtons.NumericFirstLast;
            this.PagerSettings.Position = PagerPosition.Bottom;
        }

        #region Custom properties
        [Browsable(true), Category("NewDynamic")]
        [Description("Set the virtual item count for this grid")]
        public int VirtualItemCount
        {
            get
            {
                if (ViewState["pgv_vitemcount"] == null)
                    ViewState["pgv_vitemcount"] = -1;
                return Convert.ToInt32(ViewState["pgv_vitemcount"]);
            }
            set
            {
                ViewState["pgv_vitemcount"] = value;
            }
        }

        [Browsable(true), Category("NewDynamic")]
        [Description("Get the order by string to use for this grid when sorting event is triggered")]
        public string OrderBy
        {
            get
            {
                if (ViewState["pgv_orderby"] == null)
                    ViewState["pgv_orderby"] = string.Empty;
                return ViewState["pgv_orderby"].ToString();
            }
            protected set
            {
                ViewState["pgv_orderby"] = value;
            }
        }

        public int CurrentPageIndex
        {
            get
            {
                if (ViewState["pgv_pageindex"] == null)
                    ViewState["pgv_pageindex"] = 0;
                return Convert.ToInt32(ViewState["pgv_pageindex"]);
            }
            set
            {
                ViewState["pgv_pageindex"] = value;
            }
        }
        public bool CustomPaging
        {
            get
            {
                return (VirtualItemCount != -1);
            }
        }
        #endregion

        #region Overriding the parent methods
        public override object DataSource
        {
            get
            {
                return base.DataSource;
            }
            set
            {
                base.DataSource = value;
                CurrentPageIndex = PageIndex;
            }
        }

        protected override void OnSorting(GridViewSortEventArgs e)
        {
            SortDirection direction = SortDirection.Ascending;
            if (ViewState[e.SortExpression] != null && (SortDirection)ViewState[e.SortExpression] == SortDirection.Ascending)
            {
                direction = SortDirection.Descending;
            }
            ViewState[e.SortExpression] = direction;
            OrderBy = string.Format("{0} {1}", e.SortExpression, (direction == SortDirection.Descending ? "DESC" : ""));
            base.OnSorting(e);
        }

        protected override void InitializePager(GridViewRow row, int columnSpan, PagedDataSource pagedDataSource)
        {
            if (CustomPaging)
            {
                pagedDataSource.AllowCustomPaging = true;
                pagedDataSource.VirtualCount = VirtualItemCount;
                pagedDataSource.CurrentPageIndex = CurrentPageIndex;
            }
            base.InitializePager(row, columnSpan, pagedDataSource);
        }
        #endregion
    }
}
