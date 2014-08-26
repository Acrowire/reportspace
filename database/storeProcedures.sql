USE PMPRepository
GO

IF OBJECT_ID('sp_rpt_weekly_client_project_data', 'P') IS NOT NULL
DROP PROC sp_rpt_weekly_client_project_data
GO

CREATE PROCEDURE sp_rpt_weekly_client_project_data
    @week int,
	@year int,
	@projectName nvarchar(50) = null
AS 

print 'week [' +CAST(@week AS VARCHAR) + '] Year ['+CAST(@year AS VARCHAR) + '] name [' + @projectName + ']'

select user_name, project, 
    sum(total_hours) as total_hours, 
    sum(billable_hours) as billable_hours,
    sum(gross_revenue) as gross_revenue,
    sum(direct_labor) as direct_labor
from
   dbo.vw_project_summary_by_user
where
    week >= @week AND
	year >= @year
	AND ( @projectName IS NULL OR project = @projectName )
group by 
    user_name, 
    project
order by
    project,
    user_name
GO


/*DROP TABLE vw_project_summary_by_user

CREATE TABLE vw_project_summary_by_user (
[user_name] [varchar](50) NULL,
	[project] [varchar](50) NULL,
	[total_hours] [float] NULL,
	[billable_hours] [float] NULL,
	[gross_revenue] [float] NULL,
	[direct_labor] [float] NULL,
	[week] [int] NULL,
	[year] [int] NULL
  );*/

--exec sp_rpt_weekly_client_project_data @week=15, @year=2014, @projectName = 'SUNO-SPSM-04'
--, @projectName = 'ACRO-ADMIN'
--select * from vw_project_summary_by_user where project = 'SUNO-SPSM-04' and week >= 15 AND YEAR>=2014
