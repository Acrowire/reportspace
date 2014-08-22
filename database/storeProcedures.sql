USE PMPRepository
GO

IF OBJECT_ID('sp_rpt_weekly_client_project_data', 'P') IS NOT NULL
DROP PROC sp_rpt_weekly_client_project_data
GO

CREATE PROCEDURE sp_rpt_weekly_client_project_data
    @week_name nvarchar(10)
AS 
select user_name, project, 
    sum(total_hours) as total_hours, 
    sum(billable_hours) as billable_hours,
    sum(gross_revenue) as gross_revenue,
    sum(direct_labor) as direct_labor
from
   dbo.vw_project_summary_by_user
where
    weekname >= @week_name
group by 
    user_name, 
    project
order by
    project,
    user_name
GO


--exec sp_rpt_weekly_client_project_data @week_name='13'