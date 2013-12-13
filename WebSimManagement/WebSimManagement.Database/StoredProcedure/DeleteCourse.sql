--TODO
--If SP exists then drop


-- =============================================
-- Author:		dbo
-- Create date: 12/10/2013
-- Description:	Deletes the course name and take courseid as input
-- =============================================
CREATE PROCEDURE [dbo].[DeleteCourse] 
	-- Add the parameters for the stored procedure here
	@courseid uniqueidentifier = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

-- TODO add transaction add try catch block 
    -- Insert statements for procedure here
    DELETE FROM User_Course_Mapping
    WHERE CourseId = @courseid
    
	DELETE FROM CoursesDetail
	WHERE CourseId = @courseid
END
