CREATE FUNCTION dbo.fn_age
(
  @birthdate AS DATETIME,
  @eventdate AS DATETIME
)
RETURNS INT
AS
BEGIN
  RETURN
    DATEDIFF(year, @birthdate, @eventdate)
    - CASE WHEN 100 * MONTH(@eventdate) + DAY(@eventdate) < 100 * MONTH(@birthdate) + DAY(@birthdate)
           THEN 1 
           ELSE 0
      END
END
