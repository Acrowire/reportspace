﻿----------------------------------------
-- Generated by Iris Generator
-- The 7/16/2014 at 9:45 AM

-- The %D% at %T% :rpt_client_project_hours
-- 1 stored procedures to generate.


if exists (select * from sys.objects where ([type] = 'P' and [name]='sp_rpt_client_project_hours_Select_All'))
drop procedure sp_rpt_client_project_hours_Select_All


GO


Create Procedure sp_rpt_client_project_hours_Select_All
AS
BEGIN
    SELECT [week_name],[day_of_week],[day_name],[begin_date],[end_date],[date],[age],[created_on],[latency],[user_name],[actual_user],[company_name],[project_name],[parent_name],[billable_hours],[unbillable_hours],[total_hours]
    FROM [dbo].[rpt_client_project_hours]
END

GO


