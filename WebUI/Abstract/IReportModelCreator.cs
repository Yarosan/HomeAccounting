﻿using System;
using WebUI.Models;

namespace WebUI.Abstract
{
    public interface IReportModelCreator
    {
        ReportModel CreateByDatesReportModel(WebUser user, DateTime dtFrom, DateTime dtTo, int page);
        ReportModel CreateByTypeReportModel(TempReportModel model, WebUser user, int page);
    }
}
